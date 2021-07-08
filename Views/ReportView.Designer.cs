namespace Milburn_Appointment_Scheduler.Views
{
    partial class ReportView
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
            this.reportDataGridView = new System.Windows.Forms.DataGridView();
            this.appt_per_month = new System.Windows.Forms.Button();
            this.schedule_per_emp = new System.Windows.Forms.Button();
            this.requests_per_month = new System.Windows.Forms.Button();
            this.go_back_btn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.reportDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // reportDataGridView
            // 
            this.reportDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.reportDataGridView.Location = new System.Drawing.Point(12, 188);
            this.reportDataGridView.Name = "reportDataGridView";
            this.reportDataGridView.RowHeadersWidth = 62;
            this.reportDataGridView.RowTemplate.Height = 28;
            this.reportDataGridView.Size = new System.Drawing.Size(1295, 489);
            this.reportDataGridView.TabIndex = 0;
            // 
            // appt_per_month
            // 
            this.appt_per_month.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.appt_per_month.Location = new System.Drawing.Point(12, 38);
            this.appt_per_month.Name = "appt_per_month";
            this.appt_per_month.Size = new System.Drawing.Size(308, 133);
            this.appt_per_month.TabIndex = 1;
            this.appt_per_month.Text = "Appointments Per Month";
            this.appt_per_month.UseVisualStyleBackColor = true;
            this.appt_per_month.Click += new System.EventHandler(this.appt_per_month_Click);
            // 
            // schedule_per_emp
            // 
            this.schedule_per_emp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.schedule_per_emp.Location = new System.Drawing.Point(342, 38);
            this.schedule_per_emp.Name = "schedule_per_emp";
            this.schedule_per_emp.Size = new System.Drawing.Size(308, 133);
            this.schedule_per_emp.TabIndex = 2;
            this.schedule_per_emp.Text = "Schedule Per Employee";
            this.schedule_per_emp.UseVisualStyleBackColor = true;
            this.schedule_per_emp.Click += new System.EventHandler(this.schedule_per_emp_Click);
            // 
            // requests_per_month
            // 
            this.requests_per_month.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.requests_per_month.Location = new System.Drawing.Point(669, 38);
            this.requests_per_month.Name = "requests_per_month";
            this.requests_per_month.Size = new System.Drawing.Size(308, 133);
            this.requests_per_month.TabIndex = 3;
            this.requests_per_month.Text = "Appointment Requests Per Month";
            this.requests_per_month.UseVisualStyleBackColor = true;
            this.requests_per_month.Click += new System.EventHandler(this.requests_per_month_Click);
            // 
            // go_back_btn
            // 
            this.go_back_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.go_back_btn.Location = new System.Drawing.Point(999, 38);
            this.go_back_btn.Name = "go_back_btn";
            this.go_back_btn.Size = new System.Drawing.Size(308, 133);
            this.go_back_btn.TabIndex = 4;
            this.go_back_btn.Text = "Go Back";
            this.go_back_btn.UseVisualStyleBackColor = true;
            this.go_back_btn.Click += new System.EventHandler(this.go_back_btn_Click);
            // 
            // ReportView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1319, 689);
            this.Controls.Add(this.go_back_btn);
            this.Controls.Add(this.requests_per_month);
            this.Controls.Add(this.schedule_per_emp);
            this.Controls.Add(this.appt_per_month);
            this.Controls.Add(this.reportDataGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ReportView";
            this.Text = "ReportView";
            ((System.ComponentModel.ISupportInitialize)(this.reportDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView reportDataGridView;
        private System.Windows.Forms.Button appt_per_month;
        private System.Windows.Forms.Button schedule_per_emp;
        private System.Windows.Forms.Button requests_per_month;
        private System.Windows.Forms.Button go_back_btn;
    }
}