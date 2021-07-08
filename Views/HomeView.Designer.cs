namespace Milburn_Appointment_Scheduler.Views
{
    partial class HomeView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.meetingDataGridView = new System.Windows.Forms.DataGridView();
            this.manage_accounts_btn = new System.Windows.Forms.Button();
            this.add_appt_btn = new System.Windows.Forms.Button();
            this.edit_appt_btn = new System.Windows.Forms.Button();
            this.report_btn = new System.Windows.Forms.Button();
            this.delete_appt_btn = new System.Windows.Forms.Button();
            this.log_out_btn = new System.Windows.Forms.Button();
            this.all_radio = new System.Windows.Forms.RadioButton();
            this.month_radio = new System.Windows.Forms.RadioButton();
            this.week_radio = new System.Windows.Forms.RadioButton();
            this.welcome_message = new System.Windows.Forms.Label();
            this.account_manage_link = new System.Windows.Forms.LinkLabel();
            this.show_past_check = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.meetingDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // meetingDataGridView
            // 
            this.meetingDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.meetingDataGridView.Location = new System.Drawing.Point(544, 122);
            this.meetingDataGridView.Name = "meetingDataGridView";
            this.meetingDataGridView.RowHeadersWidth = 62;
            this.meetingDataGridView.RowTemplate.Height = 28;
            this.meetingDataGridView.Size = new System.Drawing.Size(1282, 393);
            this.meetingDataGridView.TabIndex = 0;
            // 
            // manage_accounts_btn
            // 
            this.manage_accounts_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manage_accounts_btn.Location = new System.Drawing.Point(12, 122);
            this.manage_accounts_btn.Name = "manage_accounts_btn";
            this.manage_accounts_btn.Size = new System.Drawing.Size(245, 119);
            this.manage_accounts_btn.TabIndex = 1;
            this.manage_accounts_btn.Text = "Manage Accounts";
            this.manage_accounts_btn.UseVisualStyleBackColor = true;
            this.manage_accounts_btn.Click += new System.EventHandler(this.manage_accounts_btn_Click);
            // 
            // add_appt_btn
            // 
            this.add_appt_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.add_appt_btn.Location = new System.Drawing.Point(275, 122);
            this.add_appt_btn.Name = "add_appt_btn";
            this.add_appt_btn.Size = new System.Drawing.Size(245, 119);
            this.add_appt_btn.TabIndex = 2;
            this.add_appt_btn.Text = "Add Appointment";
            this.add_appt_btn.UseVisualStyleBackColor = true;
            this.add_appt_btn.Click += new System.EventHandler(this.add_appt_btn_Click);
            // 
            // edit_appt_btn
            // 
            this.edit_appt_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edit_appt_btn.Location = new System.Drawing.Point(275, 258);
            this.edit_appt_btn.Name = "edit_appt_btn";
            this.edit_appt_btn.Size = new System.Drawing.Size(245, 119);
            this.edit_appt_btn.TabIndex = 4;
            this.edit_appt_btn.Text = "Edit Appointment";
            this.edit_appt_btn.UseVisualStyleBackColor = true;
            this.edit_appt_btn.Click += new System.EventHandler(this.edit_appt_btn_Click);
            // 
            // report_btn
            // 
            this.report_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.report_btn.Location = new System.Drawing.Point(12, 258);
            this.report_btn.Name = "report_btn";
            this.report_btn.Size = new System.Drawing.Size(245, 119);
            this.report_btn.TabIndex = 3;
            this.report_btn.Text = "Reports";
            this.report_btn.UseVisualStyleBackColor = true;
            this.report_btn.Click += new System.EventHandler(this.report_btn_Click);
            // 
            // delete_appt_btn
            // 
            this.delete_appt_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.delete_appt_btn.Location = new System.Drawing.Point(275, 396);
            this.delete_appt_btn.Name = "delete_appt_btn";
            this.delete_appt_btn.Size = new System.Drawing.Size(245, 119);
            this.delete_appt_btn.TabIndex = 6;
            this.delete_appt_btn.Text = "Delete Appointment";
            this.delete_appt_btn.UseVisualStyleBackColor = true;
            this.delete_appt_btn.Click += new System.EventHandler(this.delete_appt_btn_Click);
            // 
            // log_out_btn
            // 
            this.log_out_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.log_out_btn.Location = new System.Drawing.Point(12, 396);
            this.log_out_btn.Name = "log_out_btn";
            this.log_out_btn.Size = new System.Drawing.Size(245, 119);
            this.log_out_btn.TabIndex = 5;
            this.log_out_btn.Text = "Log Out";
            this.log_out_btn.UseVisualStyleBackColor = true;
            this.log_out_btn.Click += new System.EventHandler(this.log_out_btn_Click);
            // 
            // all_radio
            // 
            this.all_radio.AutoSize = true;
            this.all_radio.Checked = true;
            this.all_radio.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.all_radio.Location = new System.Drawing.Point(544, 79);
            this.all_radio.Name = "all_radio";
            this.all_radio.Size = new System.Drawing.Size(59, 29);
            this.all_radio.TabIndex = 7;
            this.all_radio.TabStop = true;
            this.all_radio.Text = "All";
            this.all_radio.UseVisualStyleBackColor = true;
            this.all_radio.CheckedChanged += new System.EventHandler(this.all_radio_CheckedChanged);
            // 
            // month_radio
            // 
            this.month_radio.AutoSize = true;
            this.month_radio.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.month_radio.Location = new System.Drawing.Point(616, 79);
            this.month_radio.Name = "month_radio";
            this.month_radio.Size = new System.Drawing.Size(162, 29);
            this.month_radio.TabIndex = 8;
            this.month_radio.Text = "Current Month";
            this.month_radio.UseVisualStyleBackColor = true;
            this.month_radio.CheckedChanged += new System.EventHandler(this.month_radio_CheckedChanged);
            // 
            // week_radio
            // 
            this.week_radio.AutoSize = true;
            this.week_radio.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.week_radio.Location = new System.Drawing.Point(784, 79);
            this.week_radio.Name = "week_radio";
            this.week_radio.Size = new System.Drawing.Size(159, 29);
            this.week_radio.TabIndex = 9;
            this.week_radio.Text = "Current Week";
            this.week_radio.UseVisualStyleBackColor = true;
            this.week_radio.CheckedChanged += new System.EventHandler(this.week_radio_CheckedChanged);
            // 
            // welcome_message
            // 
            this.welcome_message.AutoSize = true;
            this.welcome_message.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.welcome_message.Location = new System.Drawing.Point(13, 9);
            this.welcome_message.Name = "welcome_message";
            this.welcome_message.Size = new System.Drawing.Size(244, 37);
            this.welcome_message.TabIndex = 14;
            this.welcome_message.Text = "Welcome, User!";
            // 
            // account_manage_link
            // 
            this.account_manage_link.AutoSize = true;
            this.account_manage_link.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.account_manage_link.Location = new System.Drawing.Point(15, 46);
            this.account_manage_link.Name = "account_manage_link";
            this.account_manage_link.Size = new System.Drawing.Size(136, 25);
            this.account_manage_link.TabIndex = 15;
            this.account_manage_link.TabStop = true;
            this.account_manage_link.Text = "(Edit Account)";
            this.account_manage_link.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.account_manage_link_LinkClicked);
            // 
            // show_past_check
            // 
            this.show_past_check.AutoSize = true;
            this.show_past_check.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.show_past_check.Location = new System.Drawing.Point(1683, 79);
            this.show_past_check.Name = "show_past_check";
            this.show_past_check.Size = new System.Drawing.Size(143, 29);
            this.show_past_check.TabIndex = 16;
            this.show_past_check.Text = "Show Past?";
            this.show_past_check.UseVisualStyleBackColor = true;
            this.show_past_check.CheckedChanged += new System.EventHandler(this.show_past_check_CheckedChanged);
            // 
            // HomeView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1838, 528);
            this.Controls.Add(this.show_past_check);
            this.Controls.Add(this.account_manage_link);
            this.Controls.Add(this.welcome_message);
            this.Controls.Add(this.week_radio);
            this.Controls.Add(this.month_radio);
            this.Controls.Add(this.all_radio);
            this.Controls.Add(this.delete_appt_btn);
            this.Controls.Add(this.log_out_btn);
            this.Controls.Add(this.edit_appt_btn);
            this.Controls.Add(this.report_btn);
            this.Controls.Add(this.add_appt_btn);
            this.Controls.Add(this.manage_accounts_btn);
            this.Controls.Add(this.meetingDataGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "HomeView";
            this.Text = "EmployeeHomeView";
            ((System.ComponentModel.ISupportInitialize)(this.meetingDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView meetingDataGridView;
        private System.Windows.Forms.Button manage_accounts_btn;
        private System.Windows.Forms.Button add_appt_btn;
        private System.Windows.Forms.Button edit_appt_btn;
        private System.Windows.Forms.Button report_btn;
        private System.Windows.Forms.Button delete_appt_btn;
        private System.Windows.Forms.Button log_out_btn;
        private System.Windows.Forms.RadioButton all_radio;
        private System.Windows.Forms.RadioButton month_radio;
        private System.Windows.Forms.RadioButton week_radio;
        private System.Windows.Forms.Label welcome_message;
        private System.Windows.Forms.LinkLabel account_manage_link;
        private System.Windows.Forms.CheckBox show_past_check;
    }
}