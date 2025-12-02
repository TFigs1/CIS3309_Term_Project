using Pokemon_TCG_Manager.ClassLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pokemon_TCG_Manager
{
    public partial class frmAddCard : Form
    {
        public Card NewCard;
        private int _currentUserId;
        private DatabaseService _db;

        public frmAddCard(int userId)
        {
            InitializeComponent();
            _currentUserId = userId;
            _db = new DatabaseService();
            // Populate Rarity dropdown
            cmbRarity.Items.AddRange(new string[]
            {
                "Common", "Uncommon", "Rare", "Ultra Rare", "Secret Rare"
            });
            cmbRarity.SelectedIndex = 0;

            // Populate Set dropdown (for now, just dummy data)
            cmbSet.Items.AddRange(new string[]
            {
                "Obsidian Flames",
                "Temporal Forces",
                "Twilight Masquerade"
            });
            cmbSet.SelectedIndex = 0;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            //
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.png;*.jpg;*.jpeg;*.gif";
            ofd.Title = "Select Card Image";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string filename = Path.GetFileName(ofd.FileName);
                txtImagePath.Text = filename;

                try
                {
                    picPreview.Image = Image.FromFile(ofd.FileName);
                }
                catch
                {
                    MessageBox.Show("Could not load image preview.", "Error");
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCardName.Text))
            {
                MessageBox.Show("Please enter a card name.");
                return;
            }

            if (!double.TryParse(txtPrice.Text, out double price))
            {
                MessageBox.Show("Invalid price.");
                return;
            }

            // Build card object
            Card newCard = new Card
            {
                SetID = cmbSet.SelectedIndex + 1,
                CardNumber = txtCardNumber.Text.Trim(),
                CardName = txtCardName.Text.Trim(),
                Rarity = cmbRarity.Text,
                Supertype = txtSupertype.Text.Trim(),
                Subtype = txtSubtype.Text.Trim(),
                Health = (int)numHealth.Value,
                Price = price,
                CardImage = txtImagePath.Text.Trim()
            };

            // 1. Insert into tblCards
            int cardId = _db.InsertCard(newCard);   // returns AutoNumber ID

            // 2. Insert into tblOwnedCards for current user
            _db.InsertOwnedCard(_currentUserId, cardId, 1);

            MessageBox.Show("Card added successfully!");
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

    }
}
