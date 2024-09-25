using Buisness_Lab1_ADO.NET.Localization;
using Buisness_Lab1_ADO.NET.Services;
using System;
using System.Windows.Forms;

namespace UI_Lab1_ADO.NET.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void textBoxFocusSelect(object sender, EventArgs e)
        {
            //textbox select all on active (EnterEvent)
            TextBox tb = (TextBox)sender;//cast the sender to a textbox
            tb.SelectAll();
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if the user presses enter, PerformClick on the login button
            if (e.KeyChar == (char)13)//Enter key
            {
                btnLogin.PerformClick();
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            UserService userService = new UserService();

            //check if the user exists
            if (username.Contains("@"))
            {
                LoginByEmail(username, password, userService);
            }
            else
            {
                LoginByUsername(username, password, userService);
            }
        }
        private void btnRegister_Click(object sender, EventArgs e)
        {
            //hide the login form
            this.Hide();
            //show the register form
            RegisterForm registerForm = new RegisterForm();
            registerForm.Show();
            return;
        }

        //
        // Utility methods
        //
        private void LoginByUsername(string username, string password, UserService userService)
        {
            //check if the user exists by username
            if (userService.UserExistsByUsername(username))
            {
                //validate Credentials
                if (userService.ValidateCredentials(username, password))
                {
                    LoginSuccess();
                }
                else
                {
                    MessageBox.Show(LocalizationStrings.PasswordIncorrect);
                    //TODO: Implement password recovery
                    return;
                }
            }
            else
            {
                MessageBox.Show(LocalizationStrings.UserDoesNotExist);
                return;
            }
        }
        private void LoginByEmail(string email, string password, UserService userService)
        {
            //check if the user exists by email
            if (userService.UserExistsByEmail(email))
            {
                //validate Credentials
                if (userService.ValidateCredentials(email, password))
                {
                    LoginSuccess();
                }
                else
                {
                    MessageBox.Show(LocalizationStrings.PasswordIncorrect);
                    //TODO: Implement password recovery
                    return;
                }
            }
            else
            {
                MessageBox.Show(LocalizationStrings.PasswordIncorrect);
                return;
            }
        }
        private void LoginSuccess()
        {
            MessageBox.Show(LocalizationStrings.LoginSuccess);
            //hide the login form
            this.Hide();
            //show the main form
            MainForm mainForm = new MainForm();
            mainForm.Show();
            
        }


        //TODO: Implement Role based redirection
    }
}
            
