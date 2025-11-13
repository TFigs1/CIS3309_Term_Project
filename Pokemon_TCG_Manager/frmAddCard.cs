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
        public frmAddCard()
        {
            InitializeComponent();
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
            // Validate inputs
            if (string.IsNullOrWhiteSpace(txtCardName.Text))
            {
                MessageBox.Show("Please enter a card name.", "Missing Data");
                return;
            }

            if (!double.TryParse(txtPrice.Text, out double price))
            {
                MessageBox.Show("Please enter a valid price.", "Invalid Input");
                return;
            }

            // Create new card object
            NewCard = new Card
            {
                SetID = cmbSet.SelectedIndex + 1, // temporary — later match actual SetID from DB
                CardNumber = txtCardNumber.Text.Trim(),
                CardName = txtCardName.Text.Trim(),
                Rarity = cmbRarity.Text,
                Supertype = txtSupertype.Text.Trim(),
                Subtype = txtSubtype.Text.Trim(),
                Health = (int)numHealth.Value,
                Price = price,
                CardImage = txtImagePath.Text.Trim()
            };

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
