namespace s7_example_put_get
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            cb_plc_type = new ComboBox();
            tb_plc_ip = new TextBox();
            tb_plc_rack = new TextBox();
            tb_plc_slot = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            btn_connect = new Button();
            gb_main = new GroupBox();
            tb_read_address = new TextBox();
            label14 = new Label();
            cb_read_type = new ComboBox();
            label13 = new Label();
            label6 = new Label();
            label12 = new Label();
            tb_write_address = new TextBox();
            cb_write_type = new ComboBox();
            label11 = new Label();
            label10 = new Label();
            tb_data_to_write = new TextBox();
            label8 = new Label();
            label9 = new Label();
            button1 = new Button();
            tb_write_db = new TextBox();
            label7 = new Label();
            lb_data_read = new Label();
            btn_read_data = new Button();
            tb_read_db = new TextBox();
            label5 = new Label();
            gb_main.SuspendLayout();
            SuspendLayout();
            // 
            // cb_plc_type
            // 
            cb_plc_type.FormattingEnabled = true;
            cb_plc_type.Items.AddRange(new object[] { resources.GetString("cb_plc_type.Items"), resources.GetString("cb_plc_type.Items1") });
            resources.ApplyResources(cb_plc_type, "cb_plc_type");
            cb_plc_type.Name = "cb_plc_type";
            // 
            // tb_plc_ip
            // 
            resources.ApplyResources(tb_plc_ip, "tb_plc_ip");
            tb_plc_ip.Name = "tb_plc_ip";
            // 
            // tb_plc_rack
            // 
            resources.ApplyResources(tb_plc_rack, "tb_plc_rack");
            tb_plc_rack.Name = "tb_plc_rack";
            // 
            // tb_plc_slot
            // 
            resources.ApplyResources(tb_plc_slot, "tb_plc_slot");
            tb_plc_slot.Name = "tb_plc_slot";
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(label2, "label2");
            label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(label3, "label3");
            label3.Name = "label3";
            // 
            // label4
            // 
            resources.ApplyResources(label4, "label4");
            label4.Name = "label4";
            // 
            // btn_connect
            // 
            resources.ApplyResources(btn_connect, "btn_connect");
            btn_connect.Name = "btn_connect";
            btn_connect.UseVisualStyleBackColor = true;
            btn_connect.Click += btn_connect_Click;
            // 
            // gb_main
            // 
            gb_main.Controls.Add(tb_read_address);
            gb_main.Controls.Add(label14);
            gb_main.Controls.Add(cb_read_type);
            gb_main.Controls.Add(label13);
            gb_main.Controls.Add(label6);
            gb_main.Controls.Add(label12);
            gb_main.Controls.Add(tb_write_address);
            gb_main.Controls.Add(cb_write_type);
            gb_main.Controls.Add(label11);
            gb_main.Controls.Add(label10);
            gb_main.Controls.Add(tb_data_to_write);
            gb_main.Controls.Add(label8);
            gb_main.Controls.Add(label9);
            gb_main.Controls.Add(button1);
            gb_main.Controls.Add(tb_write_db);
            gb_main.Controls.Add(label7);
            gb_main.Controls.Add(lb_data_read);
            gb_main.Controls.Add(btn_read_data);
            gb_main.Controls.Add(tb_read_db);
            gb_main.Controls.Add(label5);
            resources.ApplyResources(gb_main, "gb_main");
            gb_main.Name = "gb_main";
            gb_main.TabStop = false;
            // 
            // tb_read_address
            // 
            resources.ApplyResources(tb_read_address, "tb_read_address");
            tb_read_address.Name = "tb_read_address";
            // 
            // label14
            // 
            resources.ApplyResources(label14, "label14");
            label14.Name = "label14";
            // 
            // cb_read_type
            // 
            cb_read_type.FormattingEnabled = true;
            cb_read_type.Items.AddRange(new object[] { resources.GetString("cb_read_type.Items"), resources.GetString("cb_read_type.Items1"), resources.GetString("cb_read_type.Items2") });
            resources.ApplyResources(cb_read_type, "cb_read_type");
            cb_read_type.Name = "cb_read_type";
            // 
            // label13
            // 
            resources.ApplyResources(label13, "label13");
            label13.Name = "label13";
            // 
            // label6
            // 
            resources.ApplyResources(label6, "label6");
            label6.Name = "label6";
            // 
            // label12
            // 
            resources.ApplyResources(label12, "label12");
            label12.Name = "label12";
            // 
            // tb_write_address
            // 
            resources.ApplyResources(tb_write_address, "tb_write_address");
            tb_write_address.Name = "tb_write_address";
            // 
            // cb_write_type
            // 
            cb_write_type.FormattingEnabled = true;
            cb_write_type.Items.AddRange(new object[] { resources.GetString("cb_write_type.Items"), resources.GetString("cb_write_type.Items1"), resources.GetString("cb_write_type.Items2") });
            resources.ApplyResources(cb_write_type, "cb_write_type");
            cb_write_type.Name = "cb_write_type";
            // 
            // label11
            // 
            resources.ApplyResources(label11, "label11");
            label11.Name = "label11";
            // 
            // label10
            // 
            resources.ApplyResources(label10, "label10");
            label10.Name = "label10";
            // 
            // tb_data_to_write
            // 
            resources.ApplyResources(tb_data_to_write, "tb_data_to_write");
            tb_data_to_write.Name = "tb_data_to_write";
            // 
            // label8
            // 
            resources.ApplyResources(label8, "label8");
            label8.Name = "label8";
            // 
            // label9
            // 
            resources.ApplyResources(label9, "label9");
            label9.Name = "label9";
            label9.Click += label9_Click;
            // 
            // button1
            // 
            resources.ApplyResources(button1, "button1");
            button1.Name = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // tb_write_db
            // 
            resources.ApplyResources(tb_write_db, "tb_write_db");
            tb_write_db.Name = "tb_write_db";
            // 
            // label7
            // 
            resources.ApplyResources(label7, "label7");
            label7.Name = "label7";
            // 
            // lb_data_read
            // 
            resources.ApplyResources(lb_data_read, "lb_data_read");
            lb_data_read.Name = "lb_data_read";
            // 
            // btn_read_data
            // 
            resources.ApplyResources(btn_read_data, "btn_read_data");
            btn_read_data.Name = "btn_read_data";
            btn_read_data.UseVisualStyleBackColor = true;
            btn_read_data.Click += btn_read_data_Click;
            // 
            // tb_read_db
            // 
            resources.ApplyResources(tb_read_db, "tb_read_db");
            tb_read_db.Name = "tb_read_db";
            tb_read_db.TextChanged += tb_read_address_TextChanged;
            // 
            // label5
            // 
            resources.ApplyResources(label5, "label5");
            label5.Name = "label5";
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(gb_main);
            Controls.Add(btn_connect);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(tb_plc_slot);
            Controls.Add(tb_plc_rack);
            Controls.Add(tb_plc_ip);
            Controls.Add(cb_plc_type);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form1";
            gb_main.ResumeLayout(false);
            gb_main.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cb_plc_type;
        private TextBox tb_plc_ip;
        private TextBox tb_plc_rack;
        private TextBox tb_plc_slot;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button btn_connect;
        private GroupBox gb_main;
        private Label lb_data_read;
        private Button btn_read_data;
        private TextBox tb_read_db;
        private Label label5;
        private Label label10;
        private TextBox tb_data_to_write;
        private Label label8;
        private Label label9;
        private Button button1;
        private TextBox tb_write_db;
        private Label label7;
        private ComboBox cb_write_type;
        private Label label11;
        private Label label12;
        private TextBox tb_write_address;
        private TextBox tb_read_address;
        private Label label14;
        private ComboBox cb_read_type;
        private Label label13;
        private Label label6;
    }
}