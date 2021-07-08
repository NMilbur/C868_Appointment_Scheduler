using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Milburn_Appointment_Scheduler
{
    public partial class LoginPortalForm : Form
    {
        Models.Notification notification = new Models.Notification();

        public LoginPortalForm()
        {
            InitializeComponent();
            Models.CurrentUser.UserId = -1;
            Models.CurrentUser.AccountType = "";
        }

        // Caching user data on login
        private void login_btn_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(username_input.Text) || String.IsNullOrWhiteSpace(password_input.Text))
            {
                MessageBox.Show("Please enter both a username and password.");
            
            } else
            {
                bool isLoggedIn = ViewModels.AccountHandler.LogUserIn(username_input.Text, password_input.Text);

                if (isLoggedIn) {
                    username_input.Text = "";
                    password_input.Text = "";

                    if (Models.CurrentUser.AccountType != "Admin")
                    {
                        notification.checkMeetingReminder();
                    }
                    
                    if (Models.CurrentUser.AccountType != "Client")
                    {
                        notification.checkRequests();
                    }
                    
                    this.Hide();

                    Views.HomeView homeView = new Views.HomeView();
                    homeView.ShowDialog();

                    this.Show();

                } else
                {
                    MessageBox.Show("The username/password does not exist in our system.");
                } 
            }
        }

        private void create_account_link_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();

            AccountAddEditForm accountCreationForm = new AccountAddEditForm();
            accountCreationForm.ShowDialog();

            this.Show();
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
