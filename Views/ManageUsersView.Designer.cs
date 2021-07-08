namespace Milburn_Appointment_Scheduler.Views
{
    partial class ManageUsersView
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
            this.add_account = new System.Windows.Forms.Button();
            this.edit_account = new System.Windows.Forms.Button();
            this.activate_deactivate_account = new System.Windows.Forms.Button();
            this.go_back_btn = new System.Windows.Forms.Button();
            this.accountDataGridView = new System.Windows.Forms.DataGridView();
            this.all_radio = new System.Windows.Forms.RadioButton();
            this.admin_radio = new System.Windows.Forms.RadioButton();
            this.employee_radio = new System.Windows.Forms.RadioButton();
            this.client_radio = new System.Windows.Forms.RadioButton();
            this.show_all_check = new System.Windows.Forms.CheckBox();
            this.search_box = new System.Windows.Forms.TextBox();
            this.search_label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.accountDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // add_account
            // 
            this.add_account.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.add_account.Location = new System.Drawing.Point(12, 86);
            this.add_account.Name = "add_account";
            this.add_account.Size = new System.Drawing.Size(220, 103);
            this.add_account.TabIndex = 0;
            this.add_account.Text = "Add Account";
            this.add_account.UseVisualStyleBackColor = true;
            // 
            // edit_account
            // 
            this.edit_account.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edit_account.Location = new System.Drawing.Point(12, 205);
            this.edit_account.Name = "edit_account";
            this.edit_account.Size = new System.Drawing.Size(220, 103);
            this.edit_account.TabIndex = 1;
            this.edit_account.Text = "Edit Account";
            this.edit_account.UseVisualStyleBackColor = true;
            this.edit_account.Click += new System.EventHandler(this.edit_account_Click);
            // 
            // activate_deactivate_account
            // 
            this.activate_deactivate_account.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.activate_deactivate_account.Location = new System.Drawing.Point(12, 326);
            this.activate_deactivate_account.Name = "activate_deactivate_account";
            this.activate_deactivate_account.Size = new System.Drawing.Size(220, 103);
            this.activate_deactivate_account.TabIndex = 2;
            this.activate_deactivate_account.Text = "Activate/Deactivate Account";
            this.activate_deactivate_account.UseVisualStyleBackColor = true;
            this.activate_deactivate_account.Click += new System.EventHandler(this.activate_deactivate_account_Click);
            // 
            // go_back_btn
            // 
            this.go_back_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.go_back_btn.Location = new System.Drawing.Point(12, 445);
            this.go_back_btn.Name = "go_back_btn";
            this.go_back_btn.Size = new System.Drawing.Size(220, 103);
            this.go_back_btn.TabIndex = 3;
            this.go_back_btn.Text = "Go Back";
            this.go_back_btn.UseVisualStyleBackColor = true;
            this.go_back_btn.Click += new System.EventHandler(this.go_back_btn_Click);
            // 
            // accountDataGridView
            // 
            this.accountDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.accountDataGridView.Location = new System.Drawing.Point(253, 95);
            this.accountDataGridView.Name = "accountDataGridView";
            this.accountDataGridView.RowHeadersWidth = 62;
            this.accountDataGridView.RowTemplate.Height = 28;
            this.accountDataGridView.Size = new System.Drawing.Size(1083, 462);
            this.accountDataGridView.TabIndex = 4;
            // 
            // all_radio
            // 
            this.all_radio.AutoSize = true;
            this.all_radio.Checked = true;
            this.all_radio.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.all_radio.Location = new System.Drawing.Point(253, 51);
            this.all_radio.Name = "all_radio";
            this.all_radio.Size = new System.Drawing.Size(59, 29);
            this.all_radio.TabIndex = 5;
            this.all_radio.TabStop = true;
            this.all_radio.Text = "All";
            this.all_radio.UseVisualStyleBackColor = true;
            this.all_radio.CheckedChanged += new System.EventHandler(this.all_radio_CheckedChanged);
            // 
            // admin_radio
            // 
            this.admin_radio.AutoSize = true;
            this.admin_radio.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.admin_radio.Location = new System.Drawing.Point(318, 51);
            this.admin_radio.Name = "admin_radio";
            this.admin_radio.Size = new System.Drawing.Size(103, 29);
            this.admin_radio.TabIndex = 6;
            this.admin_radio.Text = "Admins";
            this.admin_radio.UseVisualStyleBackColor = true;
            this.admin_radio.CheckedChanged += new System.EventHandler(this.admin_radio_CheckedChanged);
            // 
            // employee_radio
            // 
            this.employee_radio.AutoSize = true;
            this.employee_radio.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.employee_radio.Location = new System.Drawing.Point(427, 51);
            this.employee_radio.Name = "employee_radio";
            this.employee_radio.Size = new System.Drawing.Size(134, 29);
            this.employee_radio.TabIndex = 7;
            this.employee_radio.Text = "Employees";
            this.employee_radio.UseVisualStyleBackColor = true;
            this.employee_radio.CheckedChanged += new System.EventHandler(this.employee_radio_CheckedChanged);
            // 
            // client_radio
            // 
            this.client_radio.AutoSize = true;
            this.client_radio.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.client_radio.Location = new System.Drawing.Point(567, 51);
            this.client_radio.Name = "client_radio";
            this.client_radio.Size = new System.Drawing.Size(97, 29);
            this.client_radio.TabIndex = 8;
            this.client_radio.Text = "Clients";
            this.client_radio.UseVisualStyleBackColor = true;
            this.client_radio.CheckedChanged += new System.EventHandler(this.client_radio_CheckedChanged);
            // 
            // show_all_check
            // 
            this.show_all_check.AutoSize = true;
            this.show_all_check.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.show_all_check.Location = new System.Drawing.Point(703, 52);
            this.show_all_check.Name = "show_all_check";
            this.show_all_check.Size = new System.Drawing.Size(181, 29);
            this.show_all_check.TabIndex = 11;
            this.show_all_check.Text = "Show Inactives?";
            this.show_all_check.UseVisualStyleBackColor = true;
            this.show_all_check.CheckedChanged += new System.EventHandler(this.show_all_check_CheckedChanged);
            // 
            // search_box
            // 
            this.search_box.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.search_box.Location = new System.Drawing.Point(1097, 49);
            this.search_box.Name = "search_box";
            this.search_box.Size = new System.Drawing.Size(239, 30);
            this.search_box.TabIndex = 12;
            this.search_box.TextChanged += new System.EventHandler(this.search_box_TextChanged);
            // 
            // search_label
            // 
            this.search_label.AutoSize = true;
            this.search_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.search_label.Location = new System.Drawing.Point(1016, 54);
            this.search_label.Name = "search_label";
            this.search_label.Size = new System.Drawing.Size(75, 25);
            this.search_label.TabIndex = 13;
            this.search_label.Text = "Search";
            // 
            // ManageUsersView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1357, 569);
            this.Controls.Add(this.search_label);
            this.Controls.Add(this.search_box);
            this.Controls.Add(this.show_all_check);
            this.Controls.Add(this.client_radio);
            this.Controls.Add(this.employee_radio);
            this.Controls.Add(this.admin_radio);
            this.Controls.Add(this.all_radio);
            this.Controls.Add(this.accountDataGridView);
            this.Controls.Add(this.go_back_btn);
            this.Controls.Add(this.activate_deactivate_account);
            this.Controls.Add(this.edit_account);
            this.Controls.Add(this.add_account);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ManageUsersView";
            this.Text = "ManageUsersView";
            ((System.ComponentModel.ISupportInitialize)(this.accountDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button add_account;
        private System.Windows.Forms.Button edit_account;
        private System.Windows.Forms.Button activate_deactivate_account;
        private System.Windows.Forms.Button go_back_btn;
        private System.Windows.Forms.DataGridView accountDataGridView;
        private System.Windows.Forms.RadioButton all_radio;
        private System.Windows.Forms.RadioButton admin_radio;
        private System.Windows.Forms.RadioButton employee_radio;
        private System.Windows.Forms.RadioButton client_radio;
        private System.Windows.Forms.CheckBox show_all_check;
        private System.Windows.Forms.TextBox search_box;
        private System.Windows.Forms.Label search_label;
    }
}