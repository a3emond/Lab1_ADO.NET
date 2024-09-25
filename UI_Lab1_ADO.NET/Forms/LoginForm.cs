using Buisness_Lab1_ADO.NET.Interfaces;
using Buisness_Lab1_ADO.NET.Localization;
using Buisness_Lab1_ADO.NET.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;

namespace UI_Lab1_ADO.NET.Forms
{
    public partial class LoginForm : Form
    {
        private IUserService _userService;
        public LoginForm(IUserService userService)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
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

            //check if the user exists
            if (username.Contains("@"))
            {
                LoginByEmail(username, password, _userService);
            }
            else
            {
                LoginByUsername(username, password, _userService);
            }
        }
        private void btnRegister_Click(object sender, EventArgs e)
        {
            //hide the login form
            this.Hide();
            //show the register form
            var registerForm = Program.serviceProvider.GetRequiredService<RegisterForm>();
            registerForm.Show();
            return;
        }

        //
        // Utility methods
        //
        private void LoginByUsername(string username, string password, IUserService userService)
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
        private void LoginByEmail(string email, string password, IUserService userService)
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
            var mainForm = Program.serviceProvider.GetRequiredService<MainForm>();
            mainForm.Show();
            
        }


        //TODO: Implement Role based redirection
    }
}
            
