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
    public partial class ManageUsersView : Form
    {
        ViewModels.AccountManagerViewModel accountManagerViewModel = new ViewModels.AccountManagerViewModel();
        string selectedType = "All";

        public ManageUsersView()
        {
            InitializeComponent();

            initUserTable("", "No", "");
            initPageView();
        }

        private void initPageView()
        {
            if (Models.CurrentUser.AccountType != "Admin")
            {
                all_radio.Visible = false;
                client_radio.Visible = false;
                employee_radio.Visible = false;
                admin_radio.Visible = false;
            }
        }

        private void initUserTable(string typeFilter, string inactiveFilter, string nameSearch)
        {
            accountDataGridView.DataSource = null;
            accountDataGridView.DataSource = accountManagerViewModel.getDataSource(typeFilter, inactiveFilter, nameSearch);
            accountDataGridView.AutoGenerateColumns = false;

            accountDataGridView.Columns["Name"].HeaderText = "Name";
            accountDataGridView.Columns["Name"].DisplayIndex = 0;
            accountDataGridView.Columns["Name"].Width = 130;

            accountDataGridView.Columns["Phone"].HeaderText = "Phone";
            accountDataGridView.Columns["Phone"].DisplayIndex = 1;
            accountDataGridView.Columns["Phone"].Width = 130;

            accountDataGridView.Columns["Email"].HeaderText = "Email";
            accountDataGridView.Columns["Email"].DisplayIndex = 2;
            accountDataGridView.Columns["Email"].Width = 130;

            accountDataGridView.Columns["AccountType"].HeaderText = "Account Type";
            accountDataGridView.Columns["AccountType"].DisplayIndex = 3;
            accountDataGridView.Columns["AccountType"].Width = 130;

            accountDataGridView.Columns["Active"].HeaderText = "Is Active";
            accountDataGridView.Columns["Active"].DisplayIndex = 4;
            accountDataGridView.Columns["Active"].Width = 130;

            accountDataGridView.Columns["AccountId"].Visible = false;
        }

        private void add_account_Click(object sender, EventArgs e)
        {
            this.Hide();

            AccountAddEditForm accountCreationForm = new AccountAddEditForm();
            accountCreationForm.ShowDialog();

            this.Show();
            initUserTable(selectedType, getCheckValue(), search_box.Text);
        }

        private void go_back_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void edit_account_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow selectedRow = accountDataGridView.SelectedRows[0];

                this.Hide();

                AccountAddEditForm accountCreationForm = new AccountAddEditForm(Convert.ToInt32(selectedRow.Cells["AccountId"].Value));
                accountCreationForm.ShowDialog();

                this.Show();
                initUserTable(selectedType, getCheckValue(), search_box.Text);
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

        private string getCheckValue()
        {
            return (show_all_check.Checked) ? "Yes" : "No";
        }

        private void all_radio_CheckedChanged(object sender, EventArgs e)
        {
            selectedType = "All";
            initUserTable("All", getCheckValue(), search_box.Text);
        }

        private void admin_radio_CheckedChanged(object sender, EventArgs e)
        {
            selectedType = "Admin";
            initUserTable("Admin", getCheckValue(), search_box.Text);
        }

        private void employee_radio_CheckedChanged(object sender, EventArgs e)
        {
            selectedType = "Employee";
            initUserTable("Employee", getCheckValue(), search_box.Text);
        }

        private void client_radio_CheckedChanged(object sender, EventArgs e)
        {
            selectedType = "Client";
            initUserTable("Client", getCheckValue(), search_box.Text);
        }

        private void show_all_check_CheckedChanged(object sender, EventArgs e)
        {
            initUserTable(selectedType, getCheckValue(), search_box.Text);
        }

        private void search_box_TextChanged(object sender, EventArgs e)
        {
            initUserTable(selectedType, getCheckValue(), search_box.Text);
        }

        private void activate_deactivate_account_Click(object sender, EventArgs e)
        {
            try
            {
                string confirmationMessage = "Are you sure you want to deactivate this account?";
                string finalValue = "No";

                DataGridViewRow selectedRow = accountDataGridView.SelectedRows[0];

                if (selectedRow.Cells["Active"].Value.ToString() == "No")
                {
                    confirmationMessage = "Are you sure you want to activate this account?";
                    finalValue = "Yes";
                }

                var confirmation = MessageBox.Show(confirmationMessage, "Confirm Action", MessageBoxButtons.YesNo);

                if (confirmation == DialogResult.Yes)
                {
                    accountManagerViewModel.updateAccountActivity(Convert.ToInt32(selectedRow.Cells["AccountId"].Value), finalValue);

                    initUserTable(selectedType, getCheckValue(), search_box.Text);
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
    }
}
