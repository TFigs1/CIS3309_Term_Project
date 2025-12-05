using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Pokemon_TCG_Manager.ClassLibrary;

namespace Pokemon_TCG_Manager
{
    public partial class frmSearch : Form
    {
        DatabaseService _db = new DatabaseService();

        public frmSearch()
        {
            InitializeComponent();
        }

        private void frmSearch_Load(object sender, EventArgs e)
        {
            DataTable dtSets = _db.ExecuteQuery(
                "SELECT SetName FROM tblSets ORDER BY SetName");

            cmbSet.Items.Clear();
            foreach (DataRow row in dtSets.Rows)
            {
                string setName = row["SetName"].ToString();
                cmbSet.Items.Add(setName);
            }

            cmbSet.SelectedIndex = -1;

            // Rarities when you use the dropdown box
            cmbRarity.Items.Clear();
            cmbRarity.Items.Add("Common");
            cmbRarity.Items.Add("Uncommon");
            cmbRarity.Items.Add("Rare");
            cmbRarity.Items.Add("Holo Rare");
            cmbRarity.Items.Add("Ultra Rare");
            cmbRarity.Items.Add("Secret Rare");
            cmbRarity.SelectedIndex = -1;

            // Shows all the cards in the dgv by default
            string sqlAll =
                "SELECT tblCards.CardID, tblCards.CardName, tblCards.Rarity, " +
                "       tblSets.SetName " +
                "FROM tblCards INNER JOIN tblSets ON tblCards.SetID = tblSets.SetID";

            DataTable dtAllCards = _db.ExecuteQuery(sqlAll);
            dgvResults.DataSource = dtAllCards;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            // Filtering
            string name = txtCardName.Text.Trim();
            string rarity = cmbRarity.Text.Trim();
            string setName = cmbSet.Text.Trim();

            // If it is blank then it doesn't count in the filter

            string sql =
                "SELECT tblCards.CardID, tblCards.CardName, tblCards.Rarity, " +
                "       tblSets.SetName " +
                "FROM tblCards INNER JOIN tblSets ON tblCards.SetID = tblSets.SetID " +
                "WHERE tblCards.CardName LIKE ? " +
                "  AND (tblCards.Rarity = ? OR ? = '') " +
                "  AND (tblSets.SetName = ? OR ? = '')";

         
            string nameLike = "%" + name + "%";

            // Show the results
            DataTable dt = _db.ExecuteQuery(
                sql,
                nameLike, 
                rarity,     
                rarity,    
                setName,    
                setName    
            );

            dgvResults.DataSource = dt;
        }

        private void dgvResults_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
