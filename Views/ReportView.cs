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
    public partial class ReportView : Form
    {
        ViewModels.ReportViewModel reportViewModel = new ViewModels.ReportViewModel();

        public ReportView()
        {
            InitializeComponent();
        }

        private void initReportTable(string reportType)
        {
            string column1Title = "";
            string column2Title = "";
            string column3Title = "";
            string column4Title = "";

            if (reportType == "meetings_per_month")
            {
                column1Title = "Number of Meetings";
                column2Title = "Month";

            }
            else if (reportType == "appointments_per_user")
            {
                column1Title = "Employee Name";
                column2Title = "Client Name";
                column3Title = "Start";
                column4Title = "End";

            }
            else if (reportType == "requests_per_month")
            {
                column1Title = "Number of Requests";
                column2Title = "Month";
            }

            reportDataGridView.DataSource = null;
            reportDataGridView.DataSource = reportViewModel.getReport(reportType);
            reportDataGridView.AutoGenerateColumns = false;

            reportDataGridView.Columns["Column1"].HeaderText = column1Title;
            reportDataGridView.Columns["Column1"].DisplayIndex = 0;
            reportDataGridView.Columns["Column1"].Width = 130;

            reportDataGridView.Columns["Column2"].HeaderText = column2Title;
            reportDataGridView.Columns["Column2"].DisplayIndex = 1;
            reportDataGridView.Columns["Column2"].Width = 130;

            reportDataGridView.Columns["Column3"].HeaderText = column3Title;
            reportDataGridView.Columns["Column3"].DisplayIndex = 2;
            reportDataGridView.Columns["Column3"].Width = 130;
            reportDataGridView.Columns["Column3"].Visible = column3Title != "";

            reportDataGridView.Columns["Column4"].HeaderText = column4Title;
            reportDataGridView.Columns["Column4"].DisplayIndex = 3;
            reportDataGridView.Columns["Column4"].Width = 130;
            reportDataGridView.Columns["Column4"].Visible = column4Title != "";
        }

        private void appt_per_month_Click(object sender, EventArgs e)
        {
            initReportTable("meetings_per_month");
        }

        private void schedule_per_emp_Click(object sender, EventArgs e)
        {
            initReportTable("appointments_per_user");
        }

        private void requests_per_month_Click(object sender, EventArgs e)
        {
            initReportTable("requests_per_month");
        }

        private void go_back_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
