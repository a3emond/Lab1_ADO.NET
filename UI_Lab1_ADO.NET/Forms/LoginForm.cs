using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            
        }
    }
}
