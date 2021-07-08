namespace Milburn_Appointment_Scheduler.Views
{
    partial class AppointmentAddEditForm
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
            this.meeting_subject = new System.Windows.Forms.TextBox();
            this.user_dd = new System.Windows.Forms.ComboBox();
            this.meeting_date = new System.Windows.Forms.DateTimePicker();
            this.start_time = new System.Windows.Forms.DateTimePicker();
            this.end_time = new System.Windows.Forms.DateTimePicker();
            this.is_approved_input = new System.Windows.Forms.ComboBox();
            this.user_label = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.is_approved_label = new System.Windows.Forms.Label();
            this.save_btn = new System.Windows.Forms.Button();
            this.cancel_btn = new System.Windows.Forms.Button();
            this.appointment_title = new System.Windows.Forms.Label();
            this.employee_label = new System.Windows.Forms.Label();
            this.employee_dd = new System.Windows.Forms.ComboBox();
            this.meeting_id_input = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // meeting_subject
            // 
            this.meeting_subject.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.meeting_subject.Location = new System.Drawing.Point(273, 186);
            this.meeting_subject.MaximumSize = new System.Drawing.Size(333, 35);
            this.meeting_subject.MinimumSize = new System.Drawing.Size(333, 35);
            this.meeting_subject.Name = "meeting_subject";
            this.meeting_subject.Size = new System.Drawing.Size(333, 30);
            this.meeting_subject.TabIndex = 0;
            // 
            // user_dd
            // 
            this.user_dd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.user_dd.FormattingEnabled = true;
            this.user_dd.Location = new System.Drawing.Point(273, 131);
            this.user_dd.Name = "user_dd";
            this.user_dd.Size = new System.Drawing.Size(333, 34);
            this.user_dd.TabIndex = 1;
            // 
            // meeting_date
            // 
            this.meeting_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.meeting_date.Location = new System.Drawing.Point(273, 245);
            this.meeting_date.MaximumSize = new System.Drawing.Size(333, 35);
            this.meeting_date.MinimumSize = new System.Drawing.Size(333, 35);
            this.meeting_date.Name = "meeting_date";
            this.meeting_date.Size = new System.Drawing.Size(333, 35);
            this.meeting_date.TabIndex = 2;
            // 
            // start_time
            // 
            this.start_time.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.start_time.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.start_time.Location = new System.Drawing.Point(273, 338);
            this.start_time.MaximumSize = new System.Drawing.Size(333, 35);
            this.start_time.MinimumSize = new System.Drawing.Size(333, 35);
            this.start_time.Name = "start_time";
            this.start_time.ShowUpDown = true;
            this.start_time.Size = new System.Drawing.Size(333, 35);
            this.start_time.TabIndex = 3;
            // 
            // end_time
            // 
            this.end_time.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.end_time.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.end_time.Location = new System.Drawing.Point(273, 399);
            this.end_time.MaximumSize = new System.Drawing.Size(333, 35);
            this.end_time.MinimumSize = new System.Drawing.Size(333, 35);
            this.end_time.Name = "end_time";
            this.end_time.ShowUpDown = true;
            this.end_time.Size = new System.Drawing.Size(333, 35);
            this.end_time.TabIndex = 4;
            // 
            // is_approved_input
            // 
            this.is_approved_input.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.is_approved_input.FormattingEnabled = true;
            this.is_approved_input.Location = new System.Drawing.Point(273, 457);
            this.is_approved_input.Name = "is_approved_input";
            this.is_approved_input.Size = new System.Drawing.Size(333, 34);
            this.is_approved_input.TabIndex = 5;
            // 
            // user_label
            // 
            this.user_label.AutoSize = true;
            this.user_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.user_label.Location = new System.Drawing.Point(36, 131);
            this.user_label.Name = "user_label";
            this.user_label.Size = new System.Drawing.Size(75, 29);
            this.user_label.TabIndex = 6;
            this.user_label.Text = "Client";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(36, 186);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(213, 29);
            this.label2.TabIndex = 7;
            this.label2.Text = "Subject of Meeting";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(36, 245);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 29);
            this.label3.TabIndex = 8;
            this.label3.Text = "Date";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(36, 342);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(124, 29);
            this.label4.TabIndex = 9;
            this.label4.Text = "Start Time";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(36, 403);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(118, 29);
            this.label5.TabIndex = 10;
            this.label5.Text = "End Time";
            // 
            // is_approved_label
            // 
            this.is_approved_label.AutoSize = true;
            this.is_approved_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.is_approved_label.Location = new System.Drawing.Point(36, 457);
            this.is_approved_label.Name = "is_approved_label";
            this.is_approved_label.Size = new System.Drawing.Size(129, 29);
            this.is_approved_label.TabIndex = 11;
            this.is_approved_label.Text = "Approved?";
            // 
            // save_btn
            // 
            this.save_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.save_btn.Location = new System.Drawing.Point(251, 523);
            this.save_btn.Name = "save_btn";
            this.save_btn.Size = new System.Drawing.Size(168, 52);
            this.save_btn.TabIndex = 12;
            this.save_btn.Text = "Save";
            this.save_btn.UseVisualStyleBackColor = true;
            this.save_btn.Click += new System.EventHandler(this.save_btn_Click);
            // 
            // cancel_btn
            // 
            this.cancel_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancel_btn.Location = new System.Drawing.Point(438, 523);
            this.cancel_btn.Name = "cancel_btn";
            this.cancel_btn.Size = new System.Drawing.Size(168, 52);
            this.cancel_btn.TabIndex = 13;
            this.cancel_btn.Text = "Cancel";
            this.cancel_btn.UseVisualStyleBackColor = true;
            this.cancel_btn.Click += new System.EventHandler(this.cancel_btn_Click);
            // 
            // appointment_title
            // 
            this.appointment_title.AutoSize = true;
            this.appointment_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.appointment_title.Location = new System.Drawing.Point(185, 19);
            this.appointment_title.Name = "appointment_title";
            this.appointment_title.Size = new System.Drawing.Size(265, 37);
            this.appointment_title.TabIndex = 14;
            this.appointment_title.Text = "Add Appointment";
            // 
            // employee_label
            // 
            this.employee_label.AutoSize = true;
            this.employee_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.employee_label.Location = new System.Drawing.Point(36, 78);
            this.employee_label.Name = "employee_label";
            this.employee_label.Size = new System.Drawing.Size(122, 29);
            this.employee_label.TabIndex = 16;
            this.employee_label.Text = "Employee";
            // 
            // employee_dd
            // 
            this.employee_dd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.employee_dd.FormattingEnabled = true;
            this.employee_dd.Location = new System.Drawing.Point(273, 78);
            this.employee_dd.Name = "employee_dd";
            this.employee_dd.Size = new System.Drawing.Size(333, 34);
            this.employee_dd.TabIndex = 15;
            // 
            // meeting_id_input
            // 
            this.meeting_id_input.Location = new System.Drawing.Point(41, 539);
            this.meeting_id_input.Name = "meeting_id_input";
            this.meeting_id_input.Size = new System.Drawing.Size(100, 26);
            this.meeting_id_input.TabIndex = 17;
            this.meeting_id_input.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(36, 297);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(356, 29);
            this.label1.TabIndex = 18;
            this.label1.Text = "Below times are in Central Time";
            // 
            // AppointmentAddEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 593);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.meeting_id_input);
            this.Controls.Add(this.employee_label);
            this.Controls.Add(this.employee_dd);
            this.Controls.Add(this.appointment_title);
            this.Controls.Add(this.cancel_btn);
            this.Controls.Add(this.save_btn);
            this.Controls.Add(this.is_approved_label);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.user_label);
            this.Controls.Add(this.is_approved_input);
            this.Controls.Add(this.end_time);
            this.Controls.Add(this.start_time);
            this.Controls.Add(this.meeting_date);
            this.Controls.Add(this.user_dd);
            this.Controls.Add(this.meeting_subject);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AppointmentAddEditForm";
            this.Text = "AppointmentAddEditForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox meeting_subject;
        private System.Windows.Forms.ComboBox user_dd;
        private System.Windows.Forms.DateTimePicker meeting_date;
        private System.Windows.Forms.DateTimePicker start_time;
        private System.Windows.Forms.DateTimePicker end_time;
        private System.Windows.Forms.ComboBox is_approved_input;
        private System.Windows.Forms.Label user_label;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label is_approved_label;
        private System.Windows.Forms.Button save_btn;
        private System.Windows.Forms.Button cancel_btn;
        private System.Windows.Forms.Label appointment_title;
        private System.Windows.Forms.Label employee_label;
        private System.Windows.Forms.ComboBox employee_dd;
        private System.Windows.Forms.TextBox meeting_id_input;
        private System.Windows.Forms.Label label1;
    }
}