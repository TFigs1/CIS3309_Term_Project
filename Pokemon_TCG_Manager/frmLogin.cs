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

        public int LoggedInUserId { get; private set; } = -1;

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
                frmMain create = new frmMain(LoggedInUserId); // pass userID when frmMain expects one, 
                create.Show();
                this.Hide();
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

      
    }
}
