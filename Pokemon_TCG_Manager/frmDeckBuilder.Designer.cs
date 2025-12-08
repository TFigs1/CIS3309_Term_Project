namespace Pokemon_TCG_Manager
{
    partial class frmDeckBuilder
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.dgvOwnedCards = new System.Windows.Forms.DataGridView();
            this.btnAddToDeck = new System.Windows.Forms.Button();
            this.btnRemoveFromDeck = new System.Windows.Forms.Button();
            this.dgvDeckCards = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOwnedCards)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeckCards)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(44, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(213, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Your Collection";
            // 
            // dgvOwnedCards
            // 
            this.dgvOwnedCards.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOwnedCards.Location = new System.Drawing.Point(50, 92);
            this.dgvOwnedCards.Name = "dgvOwnedCards";
            this.dgvOwnedCards.Size = new System.Drawing.Size(240, 150);
            this.dgvOwnedCards.TabIndex = 1;
            this.dgvOwnedCards.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOwnedCards_CellContentClick);
            // 
            // btnAddToDeck
            // 
            this.btnAddToDeck.Location = new System.Drawing.Point(50, 261);
            this.btnAddToDeck.Name = "btnAddToDeck";
            this.btnAddToDeck.Size = new System.Drawing.Size(75, 23);
            this.btnAddToDeck.TabIndex = 2;
            this.btnAddToDeck.Text = "Add";
            this.btnAddToDeck.UseVisualStyleBackColor = true;
            this.btnAddToDeck.Click += new System.EventHandler(this.btnAddToDeck_Click);
            // 
            // btnRemoveFromDeck
            // 
            this.btnRemoveFromDeck.Location = new System.Drawing.Point(484, 261);
            this.btnRemoveFromDeck.Name = "btnRemoveFromDeck";
            this.btnRemoveFromDeck.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveFromDeck.TabIndex = 3;
            this.btnRemoveFromDeck.Text = "Remove";
            this.btnRemoveFromDeck.UseVisualStyleBackColor = true;
            this.btnRemoveFromDeck.Click += new System.EventHandler(this.btnRemoveFromDeck_Click);
            // 
            // dgvDeckCards
            // 
            this.dgvDeckCards.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDeckCards.Location = new System.Drawing.Point(484, 92);
            this.dgvDeckCards.Name = "dgvDeckCards";
            this.dgvDeckCards.Size = new System.Drawing.Size(240, 150);
            this.dgvDeckCards.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(501, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 31);
            this.label2.TabIndex = 5;
            this.label2.Text = "Deck";
            // 
            // frmDeckBuilder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvDeckCards);
            this.Controls.Add(this.btnRemoveFromDeck);
            this.Controls.Add(this.btnAddToDeck);
            this.Controls.Add(this.dgvOwnedCards);
            this.Controls.Add(this.label1);
            this.Name = "frmDeckBuilder";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.frmDeckBuilder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOwnedCards)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeckCards)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvOwnedCards;
        private System.Windows.Forms.Button btnAddToDeck;
        private System.Windows.Forms.Button btnRemoveFromDeck;
        private System.Windows.Forms.DataGridView dgvDeckCards;
        private System.Windows.Forms.Label label2;
    }
}