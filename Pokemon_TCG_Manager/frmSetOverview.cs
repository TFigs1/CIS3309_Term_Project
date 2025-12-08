using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Pokemon_TCG_Manager;
using Pokemon_TCG_Manager.ClassLibrary;
namespace Pokemon_TCG_Manager
{
    public partial class frmSetOverview : Form
    {
        DatabaseService _db = new DatabaseService();
        public frmSetOverview()
        {
            InitializeComponent();
        }

        private void frmSetOverview_Load(object sender, EventArgs e)
        {
            DataTable dt = _db.ExecuteQuery("SELECT SetName FROM tblSets ORDER BY SetName");
            lstSets.Items.Clear();
            foreach (DataRow row in dt.Rows)
            {
                lstSets.Items.Add(row ["SetName"].ToString());
            }
        }

        private void lstSets_SelectedIndexChanged(object sender, EventArgs e)
        {
            // get set name
            string setName = lstSets.SelectedItem.ToString();
            // getting all cards when the set name is the same
            string sql =
                "SELECT tblCards.CardID, tblCards.CardName, tblCards.Rarity " +
                "FROM tblCards " +
                "INNER JOIN tblSets ON tblCards.SetID = tblSets.SetID " +
                "WHERE tblSets.SetName = ?";
            // run it and then display
            DataTable dt = _db.ExecuteQuery(sql, setName);
            dgvSetCards.DataSource = dt;
        }
    }
}
