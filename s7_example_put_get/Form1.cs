using S7.Net;
using System.Net;
using System.Data.SQLite;
using System.Diagnostics;

namespace s7_example_put_get
{
    public partial class Form1 : Form
    {
        System.Windows.Forms.Timer Task_toRead_data = new System.Windows.Forms.Timer();
        System.Windows.Forms.Timer Task_to_yr = new System.Windows.Forms.Timer();
        System.Windows.Forms.Timer Task_Time = new System.Windows.Forms.Timer();

        private bool isConnect = false;
        private bool auto_overide_enable = false;
        private string str_history = "";
        private Plc plc;
        private int pb_value = 0;
        private bool start_cal_to_yr = false;
        private double calculation_value = 1;
        private double current_yr = 0.00f;
        private double current_pulse = 0.00f;
        const int task_interval = 200;
        private bool nofab = false;
        private string _filePath;
        private string _connectionString;
        private bool isRun = false;

        public Form1()
        {
            InitializeComponent();
            try
            {
                calculation_value = YAMLHelper.ReadCalculationData();
                if (calculation_value <= 0)
                {
                    calculation_value = 1;
                    YAMLHelper.SaveCalculationData(calculation_value);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Load Save data error");
                calculation_value = 1;
            }

            System.DateTime current_time = System.DateTime.Now;
            lb_date.Text = current_time.ToString("dd/MM/yyyy\n HH:mm:ss");
            tab_con.Enabled = isConnect;
            tb_calculation_value.Text = calculation_value.ToString();
            GB_control.Enabled = auto_overide_enable;
            CreateDatabaseAndTable();
            Task_Time.Tick += new EventHandler(Task_Time_callback);
            Task_Time.Interval = 1000;
            Task_Time.Start();
        }

        private void CreateDatabaseAndTable()
        {
            string folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "s7_app");
            _filePath = Path.Combine(folderPath, "data.db");
            _connectionString = $"Data Source={_filePath};Version=3;";
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            if (!File.Exists(_filePath))
            {
                SQLiteConnection.CreateFile(_filePath);

                string connectionString = $"Data Source={_filePath};Version=3;";
                using (SQLiteConnection con = new SQLiteConnection(connectionString))
                {
                    con.Open();
                    using (SQLiteCommand command = new SQLiteCommand(con))
                    {
                        command.CommandText = @"CREATE TABLE fsm_step (
                                        step INTEGER PRIMARY KEY,
                                        des TEXT
                                    )";
                        command.ExecuteNonQuery();

                        string[,] initialData = new string[,]
{
    {"0", "Init DB"},
    {"1", "System Ready"},
    {"1000", "Emergency Stop"},
    {"1001", "Await for Reset"},
    {"1100", "Reset via cutting"},
    {"100", "Manual Mode"},
    {"200", "Online Mode"},
    {"201", "Auto Cycle Start"},
    {"210", "Auto Cutting Start Go up"},
    {"211", "Cutter Rise to Top"},
    {"212", "Cutter Go down"},
    {"213", "Auto Cutting Stop"}
};

                        for (int i = 0; i < initialData.GetLength(0); i++)
                        {
                            Debug.WriteLine(initialData[i, 0] + " - " + initialData[i, 1]);
                            command.CommandText = $"INSERT INTO fsm_step (step, des) VALUES (@step, @des)";
                            command.Parameters.Clear();
                            command.Parameters.AddWithValue("@step", initialData[i, 0]);
                            command.Parameters.AddWithValue("@des", initialData[i, 1]);
                            command.ExecuteNonQuery();
                        }

                    }
                }
            }
        }

        public string GetDesForStep(int step)
        {
            string des = null;
            using (SQLiteConnection con = new SQLiteConnection(_connectionString))
            {
                con.Open();
                using (SQLiteCommand command = new SQLiteCommand(con))
                {
                    command.CommandText = "SELECT des FROM fsm_step WHERE step = @step";
                    command.Parameters.AddWithValue("@step", step);
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            des = reader["des"].ToString();
                        }
                    }
                }
            }
            return des;
        }
        private void Task_Time_callback(object sender, EventArgs e)
        {
            System.DateTime current_time = System.DateTime.Now;
            lb_date.Text = current_time.ToString("dd/MM/yyyy\n HH:mm:ss");
        }
        bool init_connection(CpuType plc_type, IPAddress plc_ip, short plc_rack_no, short plc_slot_no)
        {

            try
            {
                plc = new Plc(plc_type, plc_ip.ToString(), plc_rack_no, plc_slot_no);
                plc.Open();
                return true;
            }
            catch (Exception e)
            {
                string msg = e.Message + "\n\nCheck PLC Connections";
                MessageBox.Show(msg, "Connention Error");
                return false;
            }

        }

        private double calculation()
        {
            return current_pulse / calculation_value;
        }

        private void Task_toRead_data_callback(object sender, EventArgs e)
        {
            if (!auto_overide_enable)
            {
                Task_toRead_data.Dispose();
                return;
            }
            pb_value += 25;
            pb_connect.Value = pb_value;
            if (pb_value >= 100)
            {
                pb_value = 0;
            }
            current_pulse = getEncoder_data();
            current_yr = calculation();
            if (!getReset_state())
            {
                btn_reset_state.BackColor = Color.LightSteelBlue;
                btn_reset_state.ForeColor = Color.Black;
            }
            else
            {
                btn_reset_state.BackColor = Color.Blue;
                btn_reset_state.ForeColor = Color.White;
            }

            nofab = getFab_roll1() && getFab_roll2(); // Check ผ้า

            if (!nofab)
            {
                btn_cycle_cut.Text = "ไม่มีผ้า";
            }

            int current_step = read_int("DB1", "0.0");
            string step_info_str = $"{current_step} - {GetDesForStep(current_step)}";
            lb_step_info.Text = step_info_str;

            lb_pulse.Text = current_pulse.ToString("0");
            lb_cail_yard.Text = current_yr.ToString("0.00");
            if (current_yr <= 0.01)
            {
                lb_yr_en.Text = current_yr.ToString("0.00000");
            }
            else if (current_yr >= 0.1)
            {
                lb_yr_en.Text = current_yr.ToString("0.000");
            }
            else
            {
                lb_yr_en.Text = current_yr.ToString("0.00");
            }

        }

        private void StartRead_task()
        {
            Task_toRead_data.Tick += new EventHandler(Task_toRead_data_callback);
            Task_toRead_data.Interval = task_interval * 2;
            Task_toRead_data.Start();
        }
        private void StopRead_task()
        {
            Task_toRead_data.Stop();
        }

        private void Task_to_yr_task_callback(object sender, EventArgs e)
        {
            if (!auto_overide_enable)
            {
                Task_toRead_data.Dispose();
                return;
            }
            double target_to_move = 0.00f;
            try
            {
                target_to_move = double.Parse(tb_yr_to_move.Text);
                if (start_cal_to_yr && (target_to_move >= current_yr))
                {
                    start_moving();
                    write_int("DB1", "0.0", 201);
                    btn_cycle_cut.Enabled = false;
                    btn_on_off_cutter.Enabled = false;
                    btn_m3_up.Enabled = false;
                    btn_m3_down.Enabled = false;
                    btn_m2_cw.Enabled = false;
                    btn_m2_ccw.Enabled = false;
                    btn_m1_cw.Enabled = false;
                    btn_m1_ccw.Enabled = false;
                    btn_cycle_cut.Text = "Moving";
                    isRun = true;
                }
                else
                {
                    isRun = false;
                    Task_to_yr.Dispose();
                    Task_to_yr.Stop();
                    write_int("DB1", "0.0", 202);
                    stop_moving();
                    btn_cycle_cut.Enabled = true;
                    btn_on_off_cutter.Enabled = true;
                    btn_m3_up.Enabled = true;
                    btn_m3_down.Enabled = true;
                    btn_m2_cw.Enabled = true;
                    btn_m2_ccw.Enabled = true;
                    btn_m1_cw.Enabled = true;
                    btn_m1_ccw.Enabled = true;
                    btn_cycle_cut.Text = "Cut";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void start_moving()
        {
            if (auto_overide_enable)
            {
                write_bool("DB1", "40.5", false);
            }
            btn_move_yr.Text = "Moving";
            btn_move_yr.ForeColor = Color.White;
            btn_move_yr.BackColor = Color.Blue;
            btn_yr_tare.Text = "Stop/Reset";
            write_bool("DB1", "28.0", false);
            write_bool("DB1", "28.1", true);
            write_bool("DB1", "28.2", false);
            write_bool("DB1", "28.3", true);
        }
        public int GetCurrentTimestampInSeconds()
        {
            return (int)DateTimeOffset.Now.ToUnixTimeSeconds();
        }
        /*
         Bug Here
        */
        private async void stop_moving()
        {
            btn_yr_tare.Text = "Reset";
            btn_move_yr.Text = "Start";
            btn_move_yr.ForeColor = Color.Black;
            btn_move_yr.BackColor = Color.Chartreuse;
            m1_stop();
            m2_stop();
            start_cal_to_yr = false;                        // stop Thread state                    
            start_cutting_cycle();                          // start cutting
            int st = GetCurrentTimestampInSeconds();
            while (getCuttingStatus() == false)
            {
                if ((GetCurrentTimestampInSeconds() - st) >= 120)
                {
                    break;
                }
                await Task.Delay(100);
            }        // await cutting state done
            m2_cw_rolling();                                // rolling M2 forward
            st = GetCurrentTimestampInSeconds();
            while (getFab_roll2() == false)
            {
                if ((GetCurrentTimestampInSeconds() - st) >= 10)
                {
                    break;
                }
                await Task.Delay(100);
            }
            m2_stop();
        }

        private void Start_to_yr_task()
        {
            start_cal_to_yr = true;
            Task_to_yr.Tick += new EventHandler(Task_to_yr_task_callback);
            Task_to_yr.Interval = task_interval;
            Task_to_yr.Start();
        }
        private void Stop_to_yr_task()
        {
            start_cal_to_yr = false;
            btn_move_yr.Text = "Resume";
            btn_move_yr.ForeColor = Color.Black;
            btn_move_yr.BackColor = Color.Yellow;
            m1_stop();
            m2_stop();
            Task_to_yr.Stop();
        }
        private void btn_connect_Click(object sender, EventArgs e)
        {
            if (!isConnect)
            {
                CpuType cpuType;
                IPAddress plc_ip;
                short plc_slot_no = 0;
                short plc_rack_no = 0;
                string plc_type_str = cb_plc_type.Text;

                if (plc_type_str == "S7 - 1200")
                {
                    cpuType = CpuType.S71200;
                }
                else if (plc_type_str == "S7 - 1500")
                {
                    cpuType = CpuType.S71500;
                }
                else
                {
                    MessageBox.Show("Invaild CPU Type", "CPU Select Error");
                    cpuType = new CpuType();
                    str_history += "CPU Select Error \r\n";
                }

                try
                {
                    plc_ip = IPAddress.Parse(tb_plc_ip.Text);
                    str_history += "Connecting to " + plc_ip + "\r\n";
                }
                catch (Exception ex)
                {
                    plc_ip = IPAddress.Parse("127.0.0.1");
                    MessageBox.Show("Invaild IP Address \n" + ex.Message, "IP Address Error");
                    str_history += "Error " + ex.Message + "\r\n";
                }
                try
                {
                    plc_rack_no = short.Parse(tb_plc_rack.Text);
                }
                catch (Exception ex)
                {
                    str_history += "Error " + ex.Message + "\r\n";
                    MessageBox.Show("Invaild Rack No\n" + ex.Message, "Invaild Data Type");
                }

                try
                {
                    plc_slot_no = short.Parse(tb_plc_slot.Text);
                }
                catch (Exception ex)
                {
                    str_history += "Error " + ex.Message + "\r\n";
                    MessageBox.Show("Invaild Slot No\n" + ex.Message, "Invaild Data Type");
                }

                isConnect = init_connection(cpuType, plc_ip, plc_rack_no, plc_slot_no);
                str_history += "CPU Select: ";
                str_history += plc_type_str;
                str_history += " Rack: ";
                str_history += plc_rack_no.ToString();
                str_history += " Slot: ";
                str_history += plc_slot_no.ToString() + "\r\n";

            }
            else
            {
                str_history += "PLC Disconnect" + "\r\n";
                plc.Close();
                isConnect = false;

            }
            if (isConnect)
            {
                btn_connect.Text = "ตัดการเชื่อมต่อ";
                this.Text = "S7 Example :: PLC is connect on " + tb_plc_ip.Text;
            }
            else
            {
                btn_connect.Text = "เชื่อมต่อ PLC";
                this.Text = "S7 Example :: PLC is not connect";
            }
            tab_con.Enabled = isConnect;
            tb_history.Text = str_history;
        }

        private void btn_read_data_Click(object sender, EventArgs e)
        {
            try
            {
                string type_str = cb_read_type.Text;
                string data_address = "";
                data_address += tb_read_db.Text;
                if (type_str == "Bool")
                {
                    data_address += ".DBX";
                    data_address += tb_read_address.Text;
                    lb_data_read.Text = plc.Read(data_address).ToString();
                }
                else if (type_str == "Dint")
                {
                    data_address += ".DBW";
                    data_address += tb_read_address.Text;
                    lb_data_read.Text = (plc.Read(data_address)).ToString();
                }
                else if (type_str == "Real")
                {
                    data_address += ".DBD";
                    data_address += tb_read_address.Text;
                    lb_data_read.Text = (plc.Read(data_address)).ToString();
                }
                else
                {
                    MessageBox.Show("Type Not support", "Invalid Data");
                    return;
                }

            }
            catch (Exception ex)
            {
                lb_data_read.Text = "Error";
                MessageBox.Show(ex.Message, "READ ERROR");
            }
        }

        void write_bool(string data_block, string data_address, bool data)
        {
            string con = "";
            con += data_block;
            try
            {
                con += ".DBX";
                con += data_address;
                //str_history += "Write " + data.ToString() + " to " + con + "\r\n";
                str_history = "MOVE " + data.ToString() + " to " + con + "\r\n" + str_history;
                plc.Write(con, data);
            }
            catch (Exception ex)
            {
                str_history += "Write Error " + ex.Message + "\r\n";
                MessageBox.Show(ex.Message, "Error");
            }
            tb_history.Text = str_history;
        }
        void write_int(string data_block, string data_address, short data)
        {

            string con = "";
            con += data_block;
            try
            {
                con += ".DBW";
                con += data_address;
                //str_history += "Write " + data.ToString() + " to " + con + "\r\n";
                str_history = "MOVE " + data.ToString() + " to " + con + "\r\n" + str_history;
                plc.Write(con, data);
            }
            catch (Exception ex)
            {
                str_history += "Write Error " + ex.Message + "\r\n";
                MessageBox.Show(ex.Message, "Error");
            }
            tb_history.Text = str_history;
        }

        void write_real(string data_block, string data_address, double data)
        {
            string con = "";
            con += data_block;
            try
            {
                con += ".DBD";
                con += data_address;
                //str_history += "Write " + data.ToString() + " to " + con + "\r\n";
                str_history = "MOVE " + data.ToString() + " to " + con + "\r\n" + str_history;
                plc.Write(con, data);
            }
            catch (Exception ex)
            {
                str_history += "Write Error " + ex.Message + "\r\n";
                MessageBox.Show(ex.Message, "Error");
            }
            tb_history.Text = str_history;
        }
        int read_int(string data_block, string data_address, bool err = true)
        {
            int real = 0;
            string con = "";
            con += data_block;
            try
            {
                con += ".DBD";
                con += data_address;
                //str_history += "Write " + data.ToString() + " to " + con + "\r\n";
                var dword = (uint)(plc.Read(con));
                real = dword.ConvertToInt();
            }
            catch (Exception ex)
            {
                str_history += "Read Error " + ex.Message + "\r\n";
                if (err)
                {
                    MessageBox.Show(ex.Message, "Error");
                }

            }

            return real;
        }
        double read_real(string data_block, string data_address, bool err = false)
        {
            double real = 0.0f;
            string con = "";
            con += data_block;
            try
            {
                con += ".DBD";
                con += data_address;
                //str_history += "Write " + data.ToString() + " to " + con + "\r\n";
                var dword = (uint)(plc.Read(con));
                real = dword.ConvertToFloat();
            }
            catch (Exception ex)
            {
                str_history += "Read Error " + ex.Message + "\r\n";
                if (err)
                {
                    MessageBox.Show(ex.Message, "Error");
                }
            }

            return real;
        }


        bool read_bool(string data_block, string data_address, bool err = true)
        {
            bool real = false;
            string con = "";
            con += data_block;
            try
            {
                con += ".DBX";
                con += data_address;
                //str_history += "Write " + data.ToString() + " to " + con + "\r\n";
                real = (bool)(plc.Read(con));
            }
            catch (Exception ex)
            {
                str_history += "Read Error " + ex.Message + "\r\n";
                if (err)
                {
                    MessageBox.Show(ex.Message, "Error");
                }
            }
            return real;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string type_str = cb_write_type.Text;
                string data_address = "";
                data_address += tb_write_db.Text;
                if (type_str == "Bool")
                {
                    data_address += ".DBX";
                    data_address += tb_write_address.Text;
                    bool data = bool.Parse(tb_data_to_write.Text);
                    plc.Write(data_address, data);
                    MessageBox.Show("Write data into :" + data_address + "\n Data = " + data.ToString(), "Write Sucess");
                }
                else if (type_str == "Dint")
                {
                    data_address += ".DBW";
                    data_address += tb_write_address.Text;
                    short data = short.Parse(tb_data_to_write.Text);
                    plc.Write(data_address, data);
                    MessageBox.Show("Write data into :" + data_address + "\n Data = " + data.ToString(), "Write Sucess");

                }
                else if (type_str == "Real")
                {
                    float data = float.Parse(tb_data_to_write.Text);
                    data_address += ".DBD";
                    data_address += tb_write_address.Text;
                    plc.Write(data_address, data);
                    MessageBox.Show("Write data into :" + data_address + "\n Data = " + data.ToString(), "Write Sucess");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Invalid Data");
            }
        }

        private void btn_enable_Click(object sender, EventArgs e)
        {

            stop_cutting_cycle();
            auto_overide_enable = !auto_overide_enable;
            GB_control.Enabled = auto_overide_enable;
            if (auto_overide_enable)
            {
                StartRead_task();
                btn_enable.Text = "Disable";
                auto_override_enable();
            }
            else
            {
                StopRead_task();
                btn_enable.Text = "Enable";
                auto_override_disable();
                btn_move_yr.Text = "Move yr";
                m1_stop();
                m2_stop();
            }
        }

        private void btn_m1_cw_MouseDown(object sender, MouseEventArgs e)
        {
            m1_cw_rolling();
        }


        private void btn_m1_cw_MouseUp(object sender, MouseEventArgs e)
        {
            m1_stop();
        }


        private void btn_m1_ccw_MouseDown(object sender, MouseEventArgs e)
        {
            m1_ccw_rolling();
        }

        private void btn_m1_ccw_MouseUp(object sender, MouseEventArgs e)
        {
            m1_stop();
        }

        private void btn_m2_cw_MouseDown(object sender, MouseEventArgs e)
        {
            m2_cw_rolling();
        }

        private void btn_m2_cw_MouseUp(object sender, MouseEventArgs e)
        {
            m2_stop();
        }

        private void btn_m2_ccw_MouseDown(object sender, MouseEventArgs e)
        {
            m2_ccw_rolling();
        }

        private void btn_m2_ccw_MouseUp(object sender, MouseEventArgs e)
        {
            m2_stop();
        }
        private void btn_m3_up_MouseDown(object sender, MouseEventArgs e)
        {
            m3_up_run();
        }

        private void btn_m3_up_MouseUp(object sender, MouseEventArgs e)
        {
            m3_up_stop();
        }

        private void btn_m3_down_MouseDown(object sender, MouseEventArgs e)
        {
            m3_down_run();
        }

        private void btn_m3_down_MouseUp(object sender, MouseEventArgs e)
        {
            m3_down_stop();
        }


        private void btn_on_off_cutter_MouseDown(object sender, MouseEventArgs e)
        {
            cutter_on();
        }

        private void btn_on_off_cutter_MouseUp(object sender, MouseEventArgs e)
        {
            cutter_off();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isConnect)
            {
                auto_override_disable();
            }
            Task_Time.Stop();
            Task_toRead_data.Stop();
            Task_to_yr.Stop();
        }

        private void btn_move_yr_Click(object sender, EventArgs e)
        {
            double target_to_move = 0.00f;
            try
            {

                target_to_move = double.Parse(tb_yr_to_move.Text);
                if (target_to_move < 0.1)
                {
                    MessageBox.Show("Taget near ~0.0", "Invalid Parameter");
                    target_to_move = 1.0;
                    tb_yr_to_move.Text = target_to_move.ToString();
                }
                if ((target_to_move >= current_yr))
                {
                    if (!start_cal_to_yr)
                    {
                        Start_to_yr_task();
                    }
                    else
                    {
                        Stop_to_yr_task();
                    }
                }
                else
                {
                    DialogResult result = MessageBox.Show("Current length is on setting. Do you want to reset the setting parameter?", "Setting Parameter Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        tb_yr_to_move.Text = "0.00";
                        write_real("DB1", "16.0", 0.0);
                    }
                    else
                    {
                        return;
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }


        }

        private void lb_yr_en_Click(object sender, EventArgs e)
        {

        }

        private void btn_yr_tare_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to stop and reset current job?", "Warning abort work", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                reset_encoder_value();
            }
        }

        private void btn_yr_tare_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void btn_yr_tare_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void btn_m1_cw_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            calculation_value = 1;
            try
            {
                calculation_value = double.Parse(tb_calculation_value.Text);
                if (calculation_value <= 0)
                {
                    calculation_value = 1;
                }
                YAMLHelper.SaveCalculationData(calculation_value);
            }
            catch (Exception ex)
            {
                calculation_value = 1;
                MessageBox.Show(ex.Message, "Parse Parameter Error");
            }
        }

        private void btn_cycle_cut_Click(object sender, EventArgs e)
        {
            if (auto_overide_enable)
            {
                start_cutting_cycle();
                btn_cycle_cut.Enabled = false;
                btn_cycle_cut.Text = "Cutting";
            }
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            short cutting_speed_value = 100;
            try
            {
                cutting_speed_value = short.Parse(tb_cutting_speed_value.Text);
                if (cutting_speed_value <= 0)
                {
                    cutting_speed_value = 10;
                }
                YAMLHelper.SaveCalculationData(cutting_speed_value);
                //write_int("DB1", "6.0", cutting_speed_value);
            }
            catch (Exception ex)
            {
                calculation_value = 1;
                MessageBox.Show(ex.Message, "Parse Parameter Error");
            }
        }

        private void lb_cail_yard_Click(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void btn_m3_up_Click(object sender, EventArgs e)
        {

        }


        /*
         // Binary send funs
        */

        private void m1_cw_rolling()
        {
            write_bool("DB1", "28.1", true);
            write_bool("DB1", "28.0", false);
        }
        private void m1_stop()
        {
            write_bool("DB1", "28.1", false);
        }
        private void m1_ccw_rolling()
        {
            write_bool("DB1", "28.1", true);
            write_bool("DB1", "28.0", true);
        }
        private void m2_cw_rolling()
        {
            write_bool("DB1", "28.3", true);
            write_bool("DB1", "28.2", false);
        }
        private void m2_stop()
        {
            write_bool("DB1", "28.3", false);
        }
        private void m2_ccw_rolling()
        {
            write_bool("DB1", "28.3", true);
            write_bool("DB1", "28.2", true);
        }
        private void m3_up_run()
        {
            write_bool("DB1", "40.2", true);
        }
        private void m3_up_stop()
        {
            write_bool("DB1", "40.2", false);
        }
        private void m3_down_run()
        {
            write_bool("DB1", "40.1", true);
        }
        private void m3_down_stop()
        {
            write_bool("DB1", "40.1", false);
        }
        private void cutter_on()
        {
            write_bool("DB1", "40.4", true);
        }
        private void cutter_off()
        {
            write_bool("DB1", "40.4", false);
        }
        private void reset_encoder_value()
        {
            write_bool("DB1", "40.5", true); // Reset Encoder Value
        }

        private void start_cutting_cycle()
        {
            write_int("DB1", "0.0", 210); // Pre-Cutting fsm
            write_bool("DB1", "28.4", true);
        }
        private void stop_cutting_cycle()
        {
            write_int("DB1", "0.0", 212); // Go down fsm
            write_bool("DB1", "28.4", false);
        }
        private bool getCuttingStatus()
        {
            return read_bool("DB1", "28.4");
        }
        private void auto_override_enable()
        {
            write_bool("DB1", "40.0", false);
            write_int("DB1", "0.0", 200);
        }

        private void auto_override_disable()
        {
            write_bool("DB1", "40.0", false);
        } 
        private bool getFab_roll1()
        {
            return read_bool("DB1", "41.4");
        }

        private bool getFab_roll2()
        {
            return read_bool("DB1", "41.5");
        }

        private bool getReset_state()
        {
            return read_bool("DB1", "41.3", false);
        }
        private double getEncoder_data()
        {
            return read_real("DB1", "16.0");
        }
    }
}