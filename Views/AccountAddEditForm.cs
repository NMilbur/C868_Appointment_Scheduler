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

namespace Milburn_Appointment_Scheduler
{
    public partial class AccountAddEditForm : Form
    {
        ViewModels.AccountFormHandler accountFormHandler = new ViewModels.AccountFormHandler();

        public AccountAddEditForm()
        {
            InitializeComponent();
            initForm();
        }

        public AccountAddEditForm(int accountId)
        {
            InitializeComponent();
            initForm(accountId);
        }

        private void initForm()
        {
            account_header.Text = "Create Account";
            showHideAccountTypeField();
            initDropDowns();
        }

        private void initForm(int accountId)
        {
            account_header.Text = "Update Account";

            showHideAccountTypeField();
            initDropDowns();

            List<Hashtable> results = accountFormHandler.getStoredAccountValues(accountId);

            account_id_input.Text = results[0][0].ToString();
            username_input.Text = results[0][1].ToString();
            password_input.Text = results[0][2].ToString();
            first_name_input.Text = results[0][3].ToString();
            last_name_input.Text = results[0][4].ToString();
            phone_input.Text = results[0][5].ToString();
            email_input.Text = results[0][6].ToString();
            address_input.Text = results[0][7].ToString();
            address2_input.Text = results[0][8].ToString();
            city_input.Text = results[0][9].ToString();
            state_input.SelectedValue = Convert.ToInt32(results[0][10]);
            postal_code_input.Text = results[0][11].ToString();
            account_type_input.SelectedValue = results[0][12].ToString();
            address_id_input.Text = results[0][13].ToString();
        }

        private void showHideAccountTypeField()
        {
            account_type_label.Visible = (Models.CurrentUser.AccountType == "Admin") ? true : false;
            account_type_input.Visible = (Models.CurrentUser.AccountType == "Admin") ? true : false;
        }

        private void initDropDowns()
        {
            state_input.DisplayMember = "Name";
            state_input.ValueMember = "ID";
            state_input.DataSource = accountFormHandler.getStateDropdownOpts();

            account_type_input.DisplayMember = "Name";
            account_type_input.ValueMember = "Value";
            account_type_input.DataSource = accountFormHandler.getAccountTypeDropdownOpts();
        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> response = accountFormHandler.saveAccountForm(
                new Dictionary<string, string>()
                {
                    ["accountId"] = account_id_input.Text,
                    ["addressId"] = address_id_input.Text,
                    ["username"] = username_input.Text,
                    ["password"] = password_input.Text,
                    ["firstName"] = first_name_input.Text,
                    ["lastName"] = last_name_input.Text,
                    ["phone"] = phone_input.Text,
                    ["email"] = email_input.Text,
                    ["address"] = address_input.Text,
                    ["address2"] = address2_input.Text,
                    ["city"] = city_input.Text,
                    ["stateId"] = state_input.SelectedValue.ToString(),
                    ["postalCode"] = postal_code_input.Text,
                    ["accountType"] = account_type_input.SelectedValue.ToString()
                }
            );

            if (response["status"] == "SUCCESS")
            {
                this.Close();

            }
            else
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
