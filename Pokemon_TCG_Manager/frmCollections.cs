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

        public frmCollections()
        {
            InitializeComponent();
        }

        private void frmCollections_Load(object sender, EventArgs e)
        {
            // Load owned cards from database (for now, use sample data)
            LoadSampleCards();
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

        private void lstOwnedCards_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstOwnedCards.SelectedIndex == -1) return;

            Card selected = ownedCards[lstOwnedCards.SelectedIndex];

            // Update textboxes/fields
            /* 
             * Not yet fully implemented 
             */
            txtRarity.Text = selected.Rarity;
            txtPrice.Text = selected.Price.ToString("C");
            //txtSupertype.Text = selected.Supertype;
            //txtSubtype.Text = selected.Subtype;
            //numHealth.Value = selected.Health;

            //// Try to load card image
            //try
            //{
            //    picCardImage.Image = Image.FromFile($"Images\\{selected.CardImage}");
            //}
            //catch
            //{
            //    picCardImage.Image = null;
            //}
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lstOwnedCards.SelectedIndex == -1) return;

            ownedCards.RemoveAt(lstOwnedCards.SelectedIndex);
            DisplayCards();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (frmAddCard addCardForm = new frmAddCard())
            {
                if (addCardForm.ShowDialog() == DialogResult.OK)
                {
                    ownedCards.Add(addCardForm.NewCard);
                    DisplayCards();
                }
            }

        }
    }


    }
