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

        // edit mode fields
        private bool _isEditMode = false;
        private int _editingCardId = 0;

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

            // Populate Set dropdown from tblSets
            try
            {
                DataTable dt = _db.GetAllSets();
                if (dt != null && dt.Rows.Count > 0)
                {
                    // use DataSource so each item has a SetName (display) and SetID (value)
                    cmbSet.DisplayMember = "SetName";
                    cmbSet.ValueMember = "SetID";
                    cmbSet.DataSource = dt;
                    cmbSet.SelectedIndex = 0;
                }
                else
                {
                    // fallback: leave empty so user can type/select manually
                    cmbSet.Items.Clear();
                }
            }
            catch (Exception ex)
            {
                // If DB fails, do not crash the form; optionally log the exception.
                // For now, just leave cmbSet empty.
                Console.WriteLine("Failed to load sets: " + ex.Message);
            }
        }

        // new constructor for edit mode
        public frmAddCard(int userId, Card cardToEdit) : this(userId)
        {
            if (cardToEdit == null) return;

            _isEditMode = true;
            _editingCardId = cardToEdit.CardID;

            // Select the set by its SetID (ValueMember)
            try
            {
                if (cardToEdit.SetID > 0 && cmbSet.DataSource != null)
                {
                    cmbSet.SelectedValue = cardToEdit.SetID;
                }
                else if (cmbSet.Items.Count > 0)
                {
                    cmbSet.SelectedIndex = 0;
                }
            }
            catch
            {
                // ignore selection issues
            }

            txtCardNumber.Text = cardToEdit.CardNumber;
            txtCardName.Text = cardToEdit.CardName;
            cmbRarity.Text = cardToEdit.Rarity;
            txtSupertype.Text = cardToEdit.Supertype;
            txtSubtype.Text = cardToEdit.Subtype;
            try
            {
                numHealth.Value = Math.Max(numHealth.Minimum, Math.Min(numHealth.Maximum, cardToEdit.Health));
            }
            catch { /* ignore if out of range */ }

            txtPrice.Text = cardToEdit.Price.ToString("0.00");
            txtImagePath.Text = cardToEdit.CardImage ?? string.Empty;

            // Try to load preview image if path exists
            try
            {
                string imagePath = cardToEdit.CardImage;
                if (!string.IsNullOrWhiteSpace(imagePath))
                {
                    if (File.Exists(imagePath))
                        picPreview.Image = Image.FromFile(imagePath);
                    else
                    {
                        // If stored value is just filename, try to load from app directory
                        string appImage = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, imagePath);
                        if (File.Exists(appImage))
                            picPreview.Image = Image.FromFile(appImage);
                    }
                }
            }
            catch
            {
                // ignore preview problems
            }

            // update button text to indicate edit
            btnSave.Text = "Save Changes";
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

            // Determine SetID from combo (ValueMember) or fallback to SelectedIndex + 1
            int setId = 0;
            try
            {
                if (cmbSet.SelectedValue != null && int.TryParse(cmbSet.SelectedValue.ToString(), out int parsed))
                    setId = parsed;
                else
                    setId = cmbSet.SelectedIndex >= 0 ? cmbSet.SelectedIndex + 1 : 0;
            }
            catch
            {
                setId = cmbSet.SelectedIndex >= 0 ? cmbSet.SelectedIndex + 1 : 0;
            }

            // Build card object
            Card newCard = new Card
            {
                SetID = setId,
                CardNumber = txtCardNumber.Text.Trim(),
                CardName = txtCardName.Text.Trim(),
                Rarity = cmbRarity.Text,
                Supertype = txtSupertype.Text.Trim(),
                Subtype = txtSubtype.Text.Trim(),
                Health = (int)numHealth.Value,
                Price = price,
                CardImage = txtImagePath.Text.Trim()
            };

            if (_isEditMode)
            {
                // update existing card
                newCard.CardID = _editingCardId;
                _db.UpdateCard(newCard);

                MessageBox.Show("Card updated successfully!");
                this.DialogResult = DialogResult.OK;
                this.Close();
                return;
            }

            // Insert into tblCards
            int cardId = _db.InsertCard(newCard);   // returns AutoNumber ID

            // Insert into tblOwnedCards for current user
            _db.InsertOwnedCard(_currentUserId, cardId, 1);

            MessageBox.Show("Card added successfully!");
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

    }
}
