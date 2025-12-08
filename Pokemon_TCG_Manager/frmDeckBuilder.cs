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
    public partial class frmDeckBuilder : Form
    {
        DatabaseService _db = new DatabaseService();

        DataTable _deckTable;
        public frmDeckBuilder()
        {
            InitializeComponent();
        }

        private void frmDeckBuilder_Load(object sender, EventArgs e)
        {
            LoadOwnedCards();
            SetupDeckTable();
        }

        // load the owned cards with the user's collection
        private void LoadOwnedCards()
        {
            int userId = Session.LoggedInUserId;

            string sql =
                "SELECT tblCards.CardID, " +
                " tblCards.CardName, " +
                " tblCards.Rarity, " +
                " tblSets.SetName " +
                "FROM ((tblOwnedCards " +
                "INNER JOIN tblCards ON tblOwnedCards.CardID = tblCards.CardID) " +
                "INNER JOIN tblSets ON tblCards.SetID = tblSets.SetID) " +
                "WHERE tblOwnedCards.UserID = ?";

            DataTable dt = _db.ExecuteQuery(sql, userId);
            dgvOwnedCards.DataSource = dt;
        }

        // this will tell us the cardid cardname and etc
        private void SetupDeckTable()
        {
            _deckTable = new DataTable();
            _deckTable.Columns.Add("CardID", typeof(int));
            _deckTable.Columns.Add("CardName", typeof(string));
            _deckTable.Columns.Add("Rarity", typeof(string));
            _deckTable.Columns.Add("SetName", typeof(string));

            dgvDeckCards.DataSource = _deckTable;
        }

        private void dgvOwnedCards_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAddToDeck_Click(object sender, EventArgs e)
        {
            if (dgvOwnedCards.CurrentRow == null)
            {
                return;
            }


            DataRow row = _deckTable.NewRow();
            row["CardID"] = dgvOwnedCards.CurrentRow.Cells["CardID"].Value;
            row["CardName"] = dgvOwnedCards.CurrentRow.Cells["CardName"].Value;
            row["Rarity"] = dgvOwnedCards.CurrentRow.Cells["Rarity"].Value;
            row["SetName"] = dgvOwnedCards.CurrentRow.Cells["SetName"].Value;

            _deckTable.Rows.Add(row);
        }

        private void btnRemoveFromDeck_Click(object sender, EventArgs e)
        {
            if (dgvDeckCards.CurrentRow == null)
            {
                return;
            }

            dgvDeckCards.Rows.RemoveAt(dgvDeckCards.CurrentRow.Index);


        }

    }
}
