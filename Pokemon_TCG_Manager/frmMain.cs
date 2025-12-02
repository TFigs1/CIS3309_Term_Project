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
    public partial class frmMain : Form
    {
        private int userID;
        public frmMain(int userId)
        {
            InitializeComponent();
            userID = userId;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnGoToCollections_Click(object sender, EventArgs e)
        {
            new frmCollections(userID).ShowDialog();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

        }
    }
}
