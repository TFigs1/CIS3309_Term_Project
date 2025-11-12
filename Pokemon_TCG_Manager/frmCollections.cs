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
        private List<card> ownedCards = new List<card>();
        public frmCollections()
        {
            InitializeComponent();
        }

        private void frmCollections_Load(object sender, EventArgs e)
        {
            // Load owned cards from database
            LoadSampleCards();
            DisplayCards();
        }

        private void LoadSampleCards()
        {
            ownedCards.Add(new card("Pikachu", "Common", 5.00m, "path/to/pikachu.jpg", 2));
            ownedCards.Add(new card("Charizard", "Rare", 150.00m, "path/to/charizard.jpg", 1));
            ownedCards.Add(new card("Bulbasaur", "Common", 3.00m, "path/to/bulbasaur.jpg", 4));
        }
        private void DisplayCards()
        {
            lstOwnedCards.Items.Clear();
            foreach (var card in ownedCards)
            {
                lstOwnedCards.Items.Add(card.Name);
            }
        }
        private void lstOwnedCards_SelectedIndexChanged(object sender, EventArgs e) {
            if (lstOwnedCards.SelectedIndex == -1) return;
            card selected = ownedCards[lstOwnedCards.SelectedIndex];
            txtRarity.Text = selected.Rarity;
            txtPrice.Text = selected.Price.ToString("C");
            numQuantity.Value = selected.Quantity;

            // try to load img
            //try
            //{
            //    picCardImage.Image =
            //}
            //catch
            //{
            //    picCardImage.image = null;
            //}
        }

        //private void btnAdd_Click(object sender, EventArgs e)
        //{
        //    AddCardForm addForm = new AddCardForm();
        //    if (addForm.ShowDialog() == DialogResult.OK)
        //    {
        //        ownedCards.Add(addForm.NewCard);
        //        DisplayCards();
        //    }
        //}

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lstOwnedCards.SelectedIndex == -1) return;

            ownedCards.RemoveAt(lstOwnedCards.SelectedIndex);
            DisplayCards();
        }
    }


    }
