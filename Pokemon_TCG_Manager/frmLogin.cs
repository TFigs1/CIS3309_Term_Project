using Pokemon_TCG_Manager.ClassLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pokemon_TCG_Manager
{
    public partial class frmLogin : Form
    {
        private UserService _users = new UserService();

      //  public int LoggedInUserId { get; private set; } = -1;
        public static int LoggedInUserId { get; private set; } = -1;

        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (_users.Login(txtUsername.Text, txtPassword.Text, out int userId))
            {
                LoggedInUserId = userId;
                DialogResult = DialogResult.OK;
                LoginUser(userId, txtUsername.Text);
            }
            else
            {
                MessageBox.Show("Incorrect username or password.");
            }
            
        }

        private void btnCreateAccount_Click(object sender, EventArgs e)
        {
            frmCreateAccount create = new frmCreateAccount();
            create.ShowDialog();
        }
        private void LoginUser(int userID, string username)
        {
            Session.LoggedInUserId = userID;
            Session.LoggedInUsername = username;
            frmMain main = new frmMain(userID, this);
            main.Show();
            this.Hide();
        }

      
    }
}
