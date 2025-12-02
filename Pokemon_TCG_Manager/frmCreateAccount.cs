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
    public partial class frmCreateAccount : Form
    {
        private UserService _users = new UserService();

        public frmCreateAccount()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            string result = _users.CreateUser(
                txtNewUsername.Text,
                txtNewPassword.Text
            );

            if (result == "SUCCESS")
            {
                MessageBox.Show("Account created successfully!");
                this.Close();
            }
            else
            {
                MessageBox.Show(result);
            }
        }

        
    }
}
