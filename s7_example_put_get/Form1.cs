using S7.Net;
using System.Net;
using System.Numerics;

namespace s7_example_put_get
{
    public partial class Form1 : Form
    {
        private bool isConnect = false;
        private bool auto_overide_enable = false;
        private string str_history = "";
        private Plc plc;
        public Form1()
        {
            InitializeComponent();
            tab_con.Enabled = isConnect;
            GB_control.Enabled = auto_overide_enable;
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
            auto_overide_enable = !auto_overide_enable;
            GB_control.Enabled = auto_overide_enable;
            if (auto_overide_enable)
            {
                btn_enable.Text = "Disable";
                write_bool("DB1", "40.0", true);
            }
            else
            {
                btn_enable.Text = "Enable";
                write_bool("DB1", "40.0", false);
            }
        }

        private void btn_m1_cw_MouseDown(object sender, MouseEventArgs e)
        {
            write_bool("DB1", "28.1", true);
            write_bool("DB1", "28.0", false);
        }

        private void btn_m1_cw_MouseUp(object sender, MouseEventArgs e)
        {
            write_bool("DB1", "28.1", false);
        }

        private void btn_m1_ccw_MouseDown(object sender, MouseEventArgs e)
        {
            write_bool("DB1", "28.0", true);
            write_bool("DB1", "28.1", true);
        }

        private void btn_m1_ccw_MouseUp(object sender, MouseEventArgs e)
        {
            write_bool("DB1", "28.1", false);
        }



        private void btn_m2_cw_MouseDown(object sender, MouseEventArgs e)
        {
            write_bool("DB1", "28.3", true);
            write_bool("DB1", "28.2", false);
        }

        private void btn_m2_cw_MouseUp(object sender, MouseEventArgs e)
        {
            write_bool("DB1", "28.3", false);
        }

        private void btn_m2_ccw_MouseDown(object sender, MouseEventArgs e)
        {
            write_bool("DB1", "28.3", true);
            write_bool("DB1", "28.2", true);
        }

        private void btn_m2_ccw_MouseUp(object sender, MouseEventArgs e)
        {
            write_bool("DB1", "28.3", false);
        }

        private void btn_m3_up_MouseDown(object sender, MouseEventArgs e)
        {
            write_bool("DB1", "40.1", true);
        }

        private void btn_m3_up_MouseUp(object sender, MouseEventArgs e)
        {
            write_bool("DB1", "40.1", false);
        }

        private void btn_m3_down_MouseDown(object sender, MouseEventArgs e)
        {
            write_bool("DB1", "40.2", true);
        }

        private void btn_m3_down_MouseUp(object sender, MouseEventArgs e)
        {
            write_bool("DB1", "40.2", false);
        }

        private void btn_on_off_cutter_MouseDown(object sender, MouseEventArgs e)
        {
            write_bool("DB1", "40.4", true);
        }

        private void btn_on_off_cutter_MouseUp(object sender, MouseEventArgs e)
        {
            write_bool("DB1", "40.4", false);
        }
    }
}