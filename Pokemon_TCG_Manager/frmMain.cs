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
        //private int userID;
        private int _userID;
        private frmLogin prevFrm;
        public frmMain(int userid, frmLogin loginFrm)
        {
            InitializeComponent();
            _userID = userid;
            prevFrm = loginFrm;

            //userID = userId;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnGoToCollections_Click(object sender, EventArgs e)
        {
            new frmCollections(_userID).ShowDialog();
           
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            int userID = Session.LoggedInUserId;
           // prevFrm.Close();
            
        }
    }
}
