using S7.Net;
using System.Net;
using System.Numerics;

namespace s7_example_put_get
{
    public partial class Form1 : Form
    {
        private bool isConnect = false;
        private Plc plc;
        public Form1()
        {
            InitializeComponent();
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
                short plc_rack_no = 0;
                short plc_slot_no = 0;
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
                }

                try
                {
                    plc_ip = IPAddress.Parse(tb_plc_ip.Text);
                }
                catch (Exception ex)
                {
                    plc_ip = IPAddress.Parse("127.0.0.1");
                    MessageBox.Show("Invaild IP Address \n" + ex.Message, "IP Address Error");
                }
                try
                {
                    plc_rack_no = short.Parse(tb_plc_rack.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Invaild Rack No\n" + ex.Message, "Invaild Data Type");
                }

                try
                {
                    plc_slot_no = short.Parse(tb_plc_slot.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Invaild Slot No\n" + ex.Message, "Invaild Data Type");
                }

                isConnect = init_connection(cpuType, plc_ip, plc_rack_no, plc_slot_no);


            }
            else
            {
                plc.Close();
                isConnect = false;

            }
            if (isConnect)
            { btn_connect.Text = "ตัดการเชื่อมต่อ";
                this.Text = "S7 Example :: PLC is connect on " + tb_plc_ip.Text;
            }
            else { btn_connect.Text = "เชื่อมต่อ PLC";
                this.Text = "S7 Example :: PLC is not connect";
            }
            gb_main.Enabled = isConnect;
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
                    lb_data_read.Text = ((int)plc.Read(data_address)).ToString();
                }
                else if (type_str == "Real")
                {
                    data_address += ".DBD";
                    data_address += tb_read_address.Text;
                    lb_data_read.Text = ((double)plc.Read(data_address)).ToString();
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

        private void tb_read_address_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}