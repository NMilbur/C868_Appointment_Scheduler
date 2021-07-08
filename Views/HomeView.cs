using System;
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
    public partial class HomeView : Form
    {
        ViewModels.HomeViewModel homeViewModel = new ViewModels.HomeViewModel();

        string selectedRadio = "";

        public HomeView()
        {
            InitializeComponent();
            initHomeView();
            initMeetingTable("", "");
        }

        private void initHomeView()
        {
            welcome_message.Text = $"Welcome, {Models.CurrentUser.FirstName}!";

            if (Models.CurrentUser.AccountType == "Client")
            {
                report_btn.Visible = false;
                manage_accounts_btn.Visible = false;
            }
        }

        private void initMeetingTable(string dateFilter, string pastFilter)
        {
            meetingDataGridView.DataSource = null;
            meetingDataGridView.DataSource = homeViewModel.getDataSource(dateFilter, pastFilter);
            meetingDataGridView.AutoGenerateColumns = false;

            if (Models.CurrentUser.AccountType == "Client" || Models.CurrentUser.AccountType == "Admin")
            {
                meetingDataGridView.Columns["EmployeeName"].HeaderText = "Employee Name";
                meetingDataGridView.Columns["EmployeeName"].DisplayIndex = 0;
                meetingDataGridView.Columns["EmployeeName"].Width = 130;
            }

            if (Models.CurrentUser.AccountType == "Employee" || Models.CurrentUser.AccountType == "Admin")
            {
                meetingDataGridView.Columns["ClientName"].HeaderText = "Client Name";
                meetingDataGridView.Columns["ClientName"].DisplayIndex = 1;
                meetingDataGridView.Columns["ClientName"].Width = 130;
            }

            meetingDataGridView.Columns["Type"].HeaderText = "Meeting Subject";
            meetingDataGridView.Columns["Type"].DisplayIndex = 2;
            meetingDataGridView.Columns["Type"].Width = 130;

            meetingDataGridView.Columns["Start"].HeaderText = "Start";
            meetingDataGridView.Columns["Start"].DisplayIndex = 3;
            meetingDataGridView.Columns["Start"].Width = 130;

            meetingDataGridView.Columns["End"].HeaderText = "End";
            meetingDataGridView.Columns["End"].DisplayIndex = 4;
            meetingDataGridView.Columns["End"].Width = 130;

            meetingDataGridView.Columns["Approved"].HeaderText = "Is Approved";
            meetingDataGridView.Columns["Approved"].DisplayIndex = 5;
            meetingDataGridView.Columns["Approved"].Width = 130;

            meetingDataGridView.Columns["MeetingId"].Visible = false;
        }

        private void log_out_btn_Click(object sender, EventArgs e)
        {
            ViewModels.AccountHandler.LogUserOut();

            this.Close();
        }

        private void account_manage_link_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();

            AccountAddEditForm accountCreationForm = new AccountAddEditForm(Models.CurrentUser.UserId);
            accountCreationForm.ShowDialog();

            this.Show();
        }

        private void manage_accounts_btn_Click(object sender, EventArgs e)
        {
            this.Hide();

            ManageUsersView manageUsersView = new ManageUsersView();
            manageUsersView.ShowDialog();

            this.Show();
        }

        private void add_appt_btn_Click(object sender, EventArgs e)
        {
            this.Hide();

            AppointmentAddEditForm appointmentAddEditForm = new AppointmentAddEditForm();
            appointmentAddEditForm.ShowDialog();

            this.Show();
        }

        private string showPastRecords()
        {
            return (show_past_check.Checked) ? "Yes" : "No";
        }

        private void all_radio_CheckedChanged(object sender, EventArgs e)
        {
            selectedRadio = "";
            initMeetingTable("", showPastRecords());
        }

        private void month_radio_CheckedChanged(object sender, EventArgs e)
        {
            selectedRadio = "Month";
            initMeetingTable("Month", showPastRecords());
        }

        private void week_radio_CheckedChanged(object sender, EventArgs e)
        {
            selectedRadio = "Week";
            initMeetingTable("Week", showPastRecords());
        }

        private void show_past_check_CheckedChanged(object sender, EventArgs e)
        {
            initMeetingTable(selectedRadio, showPastRecords());
        }

        private void edit_appt_btn_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow selectedRow = meetingDataGridView.SelectedRows[0];

                this.Hide();

                AppointmentAddEditForm appointmentAddEditForm = new AppointmentAddEditForm(Convert.ToInt32(selectedRow.Cells["MeetingId"].Value));
                appointmentAddEditForm.ShowDialog();

                this.Show();
                initMeetingTable(selectedRadio, showPastRecords());
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("No valid row was selected");
                return;
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("No row was selected");
                return;
            }
        }

        private void delete_appt_btn_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow selectedRow = meetingDataGridView.SelectedRows[0];

                var confirmation = MessageBox.Show("Are you sure you want to remove this appointment?", "Confirm Action", MessageBoxButtons.YesNo);

                if (confirmation == DialogResult.Yes)
                {
                    homeViewModel.removeMeeting(Convert.ToInt32(selectedRow.Cells["MeetingId"].Value));

                    initMeetingTable(selectedRadio, showPastRecords());
                }

            }
            catch (NullReferenceException)
            {
                MessageBox.Show("No valid row was selected");
                return;
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("No row was selected");
                return;
            }
        }

        private void report_btn_Click(object sender, EventArgs e)
        {
            this.Hide();

            ReportView reportView = new ReportView();
            reportView.ShowDialog();

            this.Show();
        }
    }
}
