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
{   // tis form contains on line 110 a method that has the capability of opening a window to select a file from the
    // local computer file system and import into the application. 
    // Though working with images is not inheriently new, letting the user select an image during the programs runtime
    // is new as previously I have only worked with hardcoding the image paths into the program
    // This was something new I had to research and learn how to implement - Tim Figueroa
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

            // Populate Set dropdown from database (distinct set values from tblCards)
            try
            {
                DataTable dt = _db.GetAllCards();
                var sets = new SortedSet<string>(StringComparer.OrdinalIgnoreCase);

                if (dt != null && dt.Rows.Count > 0)
                {
                    // Prefer textual set name columns if present
                    string setColumn = null;
                    if (dt.Columns.Contains("SetName"))
                        setColumn = "SetName";
                    else if (dt.Columns.Contains("SetTitle"))
                        setColumn = "SetTitle";
                    else if (dt.Columns.Contains("Set"))
                        setColumn = "Set";

                    if (!string.IsNullOrEmpty(setColumn))
                    {
                        foreach (DataRow row in dt.Rows)
                        {
                            var val = row[setColumn];
                            if (val != null)
                            {
                                string s = val.ToString().Trim();
                                if (!string.IsNullOrEmpty(s))
                                    sets.Add(s);
                            }
                        }
                    }
                    else if (dt.Columns.Contains("SetID"))
                    {
                        // Fallback to SetID when no textual set name exists
                        foreach (DataRow row in dt.Rows)
                        {
                            var val = row["SetID"];
                            if (val != null && int.TryParse(val.ToString(), out int id))
                            {
                                sets.Add($"Set {id}");
                            }
                            else if (val != null)
                            {
                                // non-integer fallback
                                string s = val.ToString().Trim();
                                if (!string.IsNullOrEmpty(s))
                                    sets.Add($"Set {s}");
                            }
                        }
                    }
                }

                if (sets.Count > 0)
                {
                    cmbSet.Items.AddRange(sets.ToArray());
                    cmbSet.SelectedIndex = 0;
                }
                else
                {
                    // No sets found: leave cmbSet empty so UI can handle or user can type/select manually.
                }
            }
            catch (Exception ex)
            {
                // If DB fails, do not crash the form; optionally log the exception.
                // For now, just leave cmbSet empty.
                Console.WriteLine("Failed to load sets: " + ex.Message);
            }
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
