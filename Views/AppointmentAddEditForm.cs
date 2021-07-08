using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Milburn_Appointment_Scheduler.Views
{
    public partial class AppointmentAddEditForm : Form
    {
        ViewModels.AppointmentFormHandler appointmentFormHandler = new ViewModels.AppointmentFormHandler();

        public AppointmentAddEditForm()
        {
            InitializeComponent();
            initAppointmentForm();
        }

        public AppointmentAddEditForm(int appointmentId)
        {
            InitializeComponent();
            initAppointmentForm(appointmentId);
        }

        private void initAppointmentForm()
        {
            setEmployeeFieldVisibility();
            setDropDownOpts();

            appointment_title.Text = "Add Appointment";

            is_approved_input.Visible = false;
            is_approved_label.Visible = false;
        }

        private void initAppointmentForm(int meetingId)
        {
            setEmployeeFieldVisibility();
            setDropDownOpts();

            appointment_title.Text = "Edit Appointment";

            List<Hashtable> results = appointmentFormHandler.getMeetingInfo(meetingId);

            meeting_id_input.Text = results[0][0].ToString();
            employee_dd.SelectedValue = (int)results[0][1];
            user_dd.SelectedValue = (int)results[0][2];
            meeting_subject.Text = results[0][3].ToString();
            meeting_date.Value = DateTime.Parse(results[0][4].ToString());
            start_time.Value = DateTime.Parse(results[0][5].ToString());
            end_time.Value = DateTime.Parse(results[0][6].ToString());
            is_approved_input.Text = results[0][7].ToString();

            // hide approved dd if the appointment is not a request
            is_approved_input.Visible = results[0][8].ToString() == "Yes";
        }

        private void setEmployeeFieldVisibility()
        {
            employee_dd.Visible = Models.CurrentUser.AccountType == "Admin";
            employee_label.Visible = Models.CurrentUser.AccountType == "Admin";

            user_label.Text = (Models.CurrentUser.AccountType == "Client") ? "Employee" : "Client";
        }

        private void setDropDownOpts()
        {
            string useAccountType = (Models.CurrentUser.AccountType == "Client") ? "Employee" : "Client";

            user_dd.DisplayMember = "Name";
            user_dd.ValueMember = "ID";
            user_dd.DataSource = appointmentFormHandler.getAccountDropdownOpts(useAccountType);

            employee_dd.Visible = Models.CurrentUser.AccountType == "Admin";
            employee_dd.DisplayMember = "Name";
            employee_dd.ValueMember = "ID";
            employee_dd.DataSource = appointmentFormHandler.getAccountDropdownOpts("Employee");

            is_approved_input.Enabled = !(Models.CurrentUser.AccountType == "Client");
            is_approved_input.DisplayMember = "Name";
            is_approved_input.ValueMember = "Value";

            List<Models.DropDown> yesNo = new List<Models.DropDown>();

            yesNo.Add(new Models.DropDown("Select...", ""));
            yesNo.Add(new Models.DropDown("Yes", "Yes"));
            yesNo.Add(new Models.DropDown("No", "No"));

            is_approved_input.DataSource = yesNo;
        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> response = appointmentFormHandler.saveAppointmentForm(
                new Dictionary<string, string>()
                {
                    ["employeeAccountId"] = employee_dd.SelectedValue.ToString(),
                    ["userAccountId"] = user_dd.SelectedValue.ToString(),
                    ["meetingId"] = meeting_id_input.Text,
                    ["meetingType"] = meeting_subject.Text,
                    ["meetingDate"] = meeting_date.Value.ToString("yyyy-MM-dd"),
                    ["startTime"] = start_time.Value.ToString("HH:mm:ss"),
                    ["endTime"] = end_time.Value.ToString("HH:mm:ss"),
                    ["approved"] = is_approved_input.SelectedValue.ToString()
                }
            );

            if (response["status"] == "SUCCESS")
            {
                this.Close();
            
            } else
            {
                MessageBox.Show(response["message"]);
            }
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
