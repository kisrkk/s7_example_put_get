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
            tab_con = new TabControl();
            tabPage1 = new TabPage();
            pb_connect = new ProgressBar();
            GB_control = new GroupBox();
            btn_reset_state = new Button();
            btn_cycle_cut = new Button();
            btn_yr_tare = new Button();
            label15 = new Label();
            lb_yr_en = new Label();
            btn_move_yr = new Button();
            tb_yr_to_move = new TextBox();
            btn_on_off_cutter = new Button();
            btn_m3_down = new Button();
            btn_m3_up = new Button();
            btn_m2_ccw = new Button();
            btn_m2_cw = new Button();
            btn_m1_ccw = new Button();
            btn_m1_cw = new Button();
            tb_history = new TextBox();
            btn_enable = new Button();
            tabPage2 = new TabPage();
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
            tabPage3 = new TabPage();
            label25 = new Label();
            label24 = new Label();
            button4 = new Button();
            label16 = new Label();
            tb_cutting_speed_value = new TextBox();
            label23 = new Label();
            button3 = new Button();
            button2 = new Button();
            label22 = new Label();
            label21 = new Label();
            label20 = new Label();
            tb_calculation_value = new TextBox();
            label19 = new Label();
            lb_cail_yard = new Label();
            lb_pulse = new Label();
            label18 = new Label();
            label17 = new Label();
            lb_date = new Label();
            lb_step_info = new Label();
            tab_con.SuspendLayout();
            tabPage1.SuspendLayout();
            GB_control.SuspendLayout();
            tabPage2.SuspendLayout();
            gb_main.SuspendLayout();
            tabPage3.SuspendLayout();
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
            // tab_con
            // 
            tab_con.Controls.Add(tabPage1);
            tab_con.Controls.Add(tabPage2);
            tab_con.Controls.Add(tabPage3);
            resources.ApplyResources(tab_con, "tab_con");
            tab_con.Name = "tab_con";
            tab_con.SelectedIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(lb_step_info);
            tabPage1.Controls.Add(pb_connect);
            tabPage1.Controls.Add(GB_control);
            tabPage1.Controls.Add(tb_history);
            tabPage1.Controls.Add(btn_enable);
            resources.ApplyResources(tabPage1, "tabPage1");
            tabPage1.Name = "tabPage1";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // pb_connect
            // 
            resources.ApplyResources(pb_connect, "pb_connect");
            pb_connect.Name = "pb_connect";
            // 
            // GB_control
            // 
            GB_control.Controls.Add(btn_reset_state);
            GB_control.Controls.Add(btn_cycle_cut);
            GB_control.Controls.Add(btn_yr_tare);
            GB_control.Controls.Add(label15);
            GB_control.Controls.Add(lb_yr_en);
            GB_control.Controls.Add(btn_move_yr);
            GB_control.Controls.Add(tb_yr_to_move);
            GB_control.Controls.Add(btn_on_off_cutter);
            GB_control.Controls.Add(btn_m3_down);
            GB_control.Controls.Add(btn_m3_up);
            GB_control.Controls.Add(btn_m2_ccw);
            GB_control.Controls.Add(btn_m2_cw);
            GB_control.Controls.Add(btn_m1_ccw);
            GB_control.Controls.Add(btn_m1_cw);
            resources.ApplyResources(GB_control, "GB_control");
            GB_control.Name = "GB_control";
            GB_control.TabStop = false;
            // 
            // btn_reset_state
            // 
            btn_reset_state.BackColor = Color.LightSkyBlue;
            resources.ApplyResources(btn_reset_state, "btn_reset_state");
            btn_reset_state.Name = "btn_reset_state";
            btn_reset_state.UseVisualStyleBackColor = false;
            // 
            // btn_cycle_cut
            // 
            btn_cycle_cut.BackColor = Color.GhostWhite;
            resources.ApplyResources(btn_cycle_cut, "btn_cycle_cut");
            btn_cycle_cut.Name = "btn_cycle_cut";
            btn_cycle_cut.UseVisualStyleBackColor = false;
            btn_cycle_cut.Click += btn_cycle_cut_Click;
            // 
            // btn_yr_tare
            // 
            btn_yr_tare.BackColor = Color.Pink;
            resources.ApplyResources(btn_yr_tare, "btn_yr_tare");
            btn_yr_tare.ForeColor = Color.Red;
            btn_yr_tare.Name = "btn_yr_tare";
            btn_yr_tare.UseVisualStyleBackColor = false;
            btn_yr_tare.Click += btn_yr_tare_Click;
            btn_yr_tare.MouseDown += btn_yr_tare_MouseDown;
            btn_yr_tare.MouseUp += btn_yr_tare_MouseUp;
            // 
            // label15
            // 
            resources.ApplyResources(label15, "label15");
            label15.Name = "label15";
            // 
            // lb_yr_en
            // 
            resources.ApplyResources(lb_yr_en, "lb_yr_en");
            lb_yr_en.Name = "lb_yr_en";
            lb_yr_en.Click += lb_yr_en_Click;
            // 
            // btn_move_yr
            // 
            btn_move_yr.BackColor = Color.Chartreuse;
            resources.ApplyResources(btn_move_yr, "btn_move_yr");
            btn_move_yr.Name = "btn_move_yr";
            btn_move_yr.UseVisualStyleBackColor = false;
            btn_move_yr.Click += btn_move_yr_Click;
            // 
            // tb_yr_to_move
            // 
            resources.ApplyResources(tb_yr_to_move, "tb_yr_to_move");
            tb_yr_to_move.Name = "tb_yr_to_move";
            // 
            // btn_on_off_cutter
            // 
            resources.ApplyResources(btn_on_off_cutter, "btn_on_off_cutter");
            btn_on_off_cutter.Name = "btn_on_off_cutter";
            btn_on_off_cutter.UseVisualStyleBackColor = true;
            btn_on_off_cutter.MouseDown += btn_on_off_cutter_MouseDown;
            btn_on_off_cutter.MouseUp += btn_on_off_cutter_MouseUp;
            // 
            // btn_m3_down
            // 
            resources.ApplyResources(btn_m3_down, "btn_m3_down");
            btn_m3_down.Name = "btn_m3_down";
            btn_m3_down.UseVisualStyleBackColor = true;
            btn_m3_down.MouseDown += btn_m3_down_MouseDown;
            btn_m3_down.MouseUp += btn_m3_down_MouseUp;
            // 
            // btn_m3_up
            // 
            resources.ApplyResources(btn_m3_up, "btn_m3_up");
            btn_m3_up.Name = "btn_m3_up";
            btn_m3_up.UseVisualStyleBackColor = true;
            btn_m3_up.Click += btn_m3_up_Click;
            btn_m3_up.MouseDown += btn_m3_up_MouseDown;
            btn_m3_up.MouseUp += btn_m3_up_MouseUp;
            // 
            // btn_m2_ccw
            // 
            resources.ApplyResources(btn_m2_ccw, "btn_m2_ccw");
            btn_m2_ccw.Name = "btn_m2_ccw";
            btn_m2_ccw.UseVisualStyleBackColor = true;
            btn_m2_ccw.MouseDown += btn_m2_ccw_MouseDown;
            btn_m2_ccw.MouseUp += btn_m2_ccw_MouseUp;
            // 
            // btn_m2_cw
            // 
            resources.ApplyResources(btn_m2_cw, "btn_m2_cw");
            btn_m2_cw.Name = "btn_m2_cw";
            btn_m2_cw.UseVisualStyleBackColor = true;
            btn_m2_cw.MouseDown += btn_m2_cw_MouseDown;
            btn_m2_cw.MouseUp += btn_m2_cw_MouseUp;
            // 
            // btn_m1_ccw
            // 
            resources.ApplyResources(btn_m1_ccw, "btn_m1_ccw");
            btn_m1_ccw.Name = "btn_m1_ccw";
            btn_m1_ccw.UseVisualStyleBackColor = true;
            btn_m1_ccw.MouseDown += btn_m1_ccw_MouseDown;
            btn_m1_ccw.MouseUp += btn_m1_ccw_MouseUp;
            // 
            // btn_m1_cw
            // 
            resources.ApplyResources(btn_m1_cw, "btn_m1_cw");
            btn_m1_cw.Name = "btn_m1_cw";
            btn_m1_cw.UseVisualStyleBackColor = true;
            btn_m1_cw.Click += btn_m1_cw_Click;
            btn_m1_cw.MouseDown += btn_m1_cw_MouseDown;
            btn_m1_cw.MouseUp += btn_m1_cw_MouseUp;
            // 
            // tb_history
            // 
            tb_history.BorderStyle = BorderStyle.FixedSingle;
            resources.ApplyResources(tb_history, "tb_history");
            tb_history.Name = "tb_history";
            tb_history.ReadOnly = true;
            // 
            // btn_enable
            // 
            resources.ApplyResources(btn_enable, "btn_enable");
            btn_enable.Name = "btn_enable";
            btn_enable.UseVisualStyleBackColor = true;
            btn_enable.Click += btn_enable_Click;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(gb_main);
            resources.ApplyResources(tabPage2, "tabPage2");
            tabPage2.Name = "tabPage2";
            tabPage2.UseVisualStyleBackColor = true;
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
            // 
            // label5
            // 
            resources.ApplyResources(label5, "label5");
            label5.Name = "label5";
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(label25);
            tabPage3.Controls.Add(label24);
            tabPage3.Controls.Add(button4);
            tabPage3.Controls.Add(label16);
            tabPage3.Controls.Add(tb_cutting_speed_value);
            tabPage3.Controls.Add(label23);
            tabPage3.Controls.Add(button3);
            tabPage3.Controls.Add(button2);
            tabPage3.Controls.Add(label22);
            tabPage3.Controls.Add(label21);
            tabPage3.Controls.Add(label20);
            tabPage3.Controls.Add(tb_calculation_value);
            tabPage3.Controls.Add(label19);
            tabPage3.Controls.Add(lb_cail_yard);
            tabPage3.Controls.Add(lb_pulse);
            tabPage3.Controls.Add(label18);
            tabPage3.Controls.Add(label17);
            resources.ApplyResources(tabPage3, "tabPage3");
            tabPage3.Name = "tabPage3";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // label25
            // 
            resources.ApplyResources(label25, "label25");
            label25.Name = "label25";
            // 
            // label24
            // 
            resources.ApplyResources(label24, "label24");
            label24.Name = "label24";
            // 
            // button4
            // 
            resources.ApplyResources(button4, "button4");
            button4.Name = "button4";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // label16
            // 
            resources.ApplyResources(label16, "label16");
            label16.Name = "label16";
            label16.Click += label16_Click;
            // 
            // tb_cutting_speed_value
            // 
            resources.ApplyResources(tb_cutting_speed_value, "tb_cutting_speed_value");
            tb_cutting_speed_value.Name = "tb_cutting_speed_value";
            // 
            // label23
            // 
            resources.ApplyResources(label23, "label23");
            label23.Name = "label23";
            // 
            // button3
            // 
            button3.BackColor = Color.Pink;
            resources.ApplyResources(button3, "button3");
            button3.ForeColor = Color.Red;
            button3.Name = "button3";
            button3.UseVisualStyleBackColor = false;
            button3.Click += btn_yr_tare_Click;
            // 
            // button2
            // 
            resources.ApplyResources(button2, "button2");
            button2.Name = "button2";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label22
            // 
            resources.ApplyResources(label22, "label22");
            label22.Name = "label22";
            label22.Click += label22_Click;
            // 
            // label21
            // 
            resources.ApplyResources(label21, "label21");
            label21.Name = "label21";
            // 
            // label20
            // 
            resources.ApplyResources(label20, "label20");
            label20.Name = "label20";
            // 
            // tb_calculation_value
            // 
            resources.ApplyResources(tb_calculation_value, "tb_calculation_value");
            tb_calculation_value.Name = "tb_calculation_value";
            // 
            // label19
            // 
            resources.ApplyResources(label19, "label19");
            label19.Name = "label19";
            // 
            // lb_cail_yard
            // 
            resources.ApplyResources(lb_cail_yard, "lb_cail_yard");
            lb_cail_yard.Name = "lb_cail_yard";
            lb_cail_yard.Click += lb_cail_yard_Click;
            // 
            // lb_pulse
            // 
            resources.ApplyResources(lb_pulse, "lb_pulse");
            lb_pulse.Name = "lb_pulse";
            // 
            // label18
            // 
            resources.ApplyResources(label18, "label18");
            label18.Name = "label18";
            // 
            // label17
            // 
            resources.ApplyResources(label17, "label17");
            label17.Name = "label17";
            // 
            // lb_date
            // 
            resources.ApplyResources(lb_date, "lb_date");
            lb_date.Name = "lb_date";
            // 
            // lb_step_info
            // 
            resources.ApplyResources(lb_step_info, "lb_step_info");
            lb_step_info.Name = "lb_step_info";
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lb_date);
            Controls.Add(tab_con);
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
            WindowState = FormWindowState.Maximized;
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            tab_con.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            GB_control.ResumeLayout(false);
            GB_control.PerformLayout();
            tabPage2.ResumeLayout(false);
            gb_main.ResumeLayout(false);
            gb_main.PerformLayout();
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
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
        private TabControl tab_con;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private GroupBox gb_main;
        private TextBox tb_read_address;
        private Label label14;
        private ComboBox cb_read_type;
        private Label label13;
        private Label label6;
        private Label label12;
        private TextBox tb_write_address;
        private ComboBox cb_write_type;
        private Label label11;
        private Label label10;
        private TextBox tb_data_to_write;
        private Label label8;
        private Label label9;
        private Button button1;
        private TextBox tb_write_db;
        private Label label7;
        private Label lb_data_read;
        private Button btn_read_data;
        private TextBox tb_read_db;
        private Label label5;
        private Button btn_enable;
        private TextBox tb_history;
        private GroupBox GB_control;
        private Button btn_on_off_cutter;
        private Button btn_m3_down;
        private Button btn_m3_up;
        private Button btn_m2_ccw;
        private Button btn_m2_cw;
        private Button btn_m1_ccw;
        private Button btn_m1_cw;
        private Label lb_yr_en;
        private Button btn_move_yr;
        private TextBox tb_yr_to_move;
        private Button btn_yr_tare;
        private Label label15;
        private TabPage tabPage3;
        private Label lb_date;
        private Label label22;
        private Label label21;
        private Label label20;
        private TextBox tb_calculation_value;
        private Label label19;
        private Label lb_cail_yard;
        private Label lb_pulse;
        private Label label18;
        private Label label17;
        private Button button2;
        private ProgressBar pb_connect;
        private Button btn_cycle_cut;
        private Button button3;
        private Button button4;
        private Label label16;
        private TextBox tb_cutting_speed_value;
        private Label label23;
        private Label label25;
        private Label label24;
        private Button btn_reset_state;
        private Label lb_step_info;
    }
}