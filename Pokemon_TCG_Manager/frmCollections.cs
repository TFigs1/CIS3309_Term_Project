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
    public partial class frmCollections : Form
    {
        private List<Card> ownedCards = new List<Card>();
        private DatabaseService _db = new DatabaseService();
        private int _currentUserId; // make sure this gets passed in at login
        public frmCollections(int userID)
        {
            InitializeComponent();
            _currentUserId = userID;
            LoadUserOwnedCards();
            DisplayCards();
        }

        private void frmCollections_Load(object sender, EventArgs e)
        {
            // Load owned cards from database (for now, use sample data)
            //LoadSampleCards();
            LoadUserOwnedCards();
            DisplayCards();
        }

        private void LoadSampleCards()
        {
            // Using the new constructor that matches the updated Card class
            ownedCards.Add(new Card(1, "025", "Pikachu", "Common", "Pokémon", "Basic", 60, 5.00, "pikachu.jpg"));
            ownedCards.Add(new Card(1, "006", "Charizard EX", "Ultra Rare", "Pokémon", "EX", 180, 150.00, "charizard.jpg"));
            ownedCards.Add(new Card(2, "001", "Bulbasaur", "Common", "Pokémon", "Basic", 70, 3.00, "bulbasaur.jpg"));
        }

        private void DisplayCards()
        {
            lstOwnedCards.Items.Clear();
            foreach (var card in ownedCards)
            {
                // Card.ToString() now gives something like "Pikachu (Common) - $5.00"
                lstOwnedCards.Items.Add(card);
            }
        }
        Card selected = null;
        private void lstOwnedCards_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstOwnedCards.SelectedIndex == -1) return;

            selected = ownedCards[lstOwnedCards.SelectedIndex];

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lstOwnedCards.SelectedIndex == -1) return;

            int index = lstOwnedCards.SelectedIndex;
            Card cardToDelete = ownedCards[index];

            var confirm = MessageBox.Show(
                $"Delete \"{cardToDelete.CardName}\" from your collection?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirm != DialogResult.Yes)
                return;

            _db.DeleteOwnedCard(_currentUserId, cardToDelete.CardID);

            LoadUserOwnedCards();
        }

        

        private void LoadUserOwnedCards()
        {
            ownedCards.Clear();
            lstOwnedCards.Items.Clear();

            DataTable table = _db.GetOwnedCards(_currentUserId);

            foreach (DataRow row in table.Rows)
            {
                Card c = new Card
                {
                    CardID = Convert.ToInt32(row["CardID"]),
                    SetID = Convert.ToInt32(row["SetID"]),
                    CardNumber = row["CardNumber"].ToString(),
                    CardName = row["CardName"].ToString(),
                    Rarity = row["Rarity"].ToString(),
                    Supertype = row["Supertype"].ToString(),
                    Subtype = row["Subtype"].ToString(),
                    Health = Convert.ToInt32(row["Health"]),
                    Price = Convert.ToDouble(row["Price"]),
                    CardImage = row["CardImage"].ToString(),
                    Quantity = Convert.ToInt32(row["Quantity"])
                };

                ownedCards.Add(c);
                lstOwnedCards.Items.Add(c.CardName);
            }
        }

        private void btnAddCard_Click(object sender, EventArgs e)
        {
            frmAddCard addForm = new frmAddCard(_currentUserId);
            //addForm.ShowDialog();

            if (addForm.ShowDialog() == DialogResult.OK)
                LoadUserOwnedCards();  // refresh collection list
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lstOwnedCards.SelectedIndex == -1) return;

            Card cardToEdit = ownedCards[lstOwnedCards.SelectedIndex];

            frmAddCard editForm = new frmAddCard(_currentUserId, cardToEdit);

            if (editForm.ShowDialog() == DialogResult.OK)
            {
                LoadUserOwnedCards();
            }
        }
    }


}
