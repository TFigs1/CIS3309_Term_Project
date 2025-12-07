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
    public partial class frmWishlist : Form
    {
        DatabaseService _db = new DatabaseService();
        public frmWishlist()
        {
            InitializeComponent();
        }

        private void frmWishlist_Load(object sender, EventArgs e)
        {
            LoadWishlist();
        }

        private void LoadWishlist() // fill the dgv grid
        {
            string sql =
                "SELECT tblWishlist.WishlistID, " +
                " tblCards.CardID, " +
                " tblCards.CardName, " +
                " tblCards.Rarity, " +
                " tblSets.SetName " +
                "FROM (tblWishlist " +
                "INNER JOIN tblCards ON tblWishlist.CardID = tblCards.CardID) " +
                "INNER JOIN tblSets ON tblCards.SetID = tblSets.SetID";

            DataTable dt = _db.ExecuteQuery(sql);
            dgvWishlist.DataSource = dt;
        }



        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            // get the wishlist
            int wishlistId = Convert.ToInt32(dgvWishlist.CurrentRow.Cells["WishlistID"].Value);
            // delete
            string sql = "DELETE FROM tblWishlist WHERE WishlistID = ?";
            _db.ExecuteNonQuery(sql, wishlistId);
            // load again
            LoadWishlist();
        }

        private void btnMoveToCollection_Click(object sender, EventArgs e)
        {
            // get the CardID and WishlistID
            int cardId = Convert.ToInt32(dgvWishlist.CurrentRow.Cells["CardID"].Value);
            int wishlistId = Convert.ToInt32(dgvWishlist.CurrentRow.Cells["WishlistID"].Value);

            // insert the card into the collection
            string sqlInsert = "INSERT INTO tblCollection (CardID) VALUES (?)";
            _db.ExecuteNonQuery(sqlInsert, cardId);

            // delete it from wishlist
            string sqlDelete = "DELETE FROM tblWishlist WHERE WishlistID = ?";
            _db.ExecuteNonQuery(sqlDelete, wishlistId);

            // refresh the grid
            LoadWishlist();
        }
    }
}
