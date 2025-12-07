namespace Pokemon_TCG_Manager
{
    partial class frmWishlist
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
            this.lblWishlist = new System.Windows.Forms.Label();
            this.dgvWishlist = new System.Windows.Forms.DataGridView();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnMoveToCollection = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWishlist)).BeginInit();
            this.SuspendLayout();
            // 
            // lblWishlist
            // 
            this.lblWishlist.AutoSize = true;
            this.lblWishlist.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWishlist.Location = new System.Drawing.Point(5, 9);
            this.lblWishlist.Name = "lblWishlist";
            this.lblWishlist.Size = new System.Drawing.Size(147, 39);
            this.lblWishlist.TabIndex = 0;
            this.lblWishlist.Text = "Wishlist";
            // 
            // dgvWishlist
            // 
            this.dgvWishlist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWishlist.Location = new System.Drawing.Point(12, 96);
            this.dgvWishlist.Name = "dgvWishlist";
            this.dgvWishlist.Size = new System.Drawing.Size(776, 259);
            this.dgvWishlist.TabIndex = 1;
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(12, 361);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(140, 27);
            this.btnRemove.TabIndex = 2;
            this.btnRemove.Text = "Remove from Wishlist";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnMoveToCollection
            // 
            this.btnMoveToCollection.Location = new System.Drawing.Point(203, 361);
            this.btnMoveToCollection.Name = "btnMoveToCollection";
            this.btnMoveToCollection.Size = new System.Drawing.Size(124, 28);
            this.btnMoveToCollection.TabIndex = 3;
            this.btnMoveToCollection.Text = "Move to Collection";
            this.btnMoveToCollection.UseVisualStyleBackColor = true;
            this.btnMoveToCollection.Click += new System.EventHandler(this.btnMoveToCollection_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(388, 360);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 29);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmWishlist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnMoveToCollection);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.dgvWishlist);
            this.Controls.Add(this.lblWishlist);
            this.Name = "frmWishlist";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.frmWishlist_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvWishlist)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblWishlist;
        private System.Windows.Forms.DataGridView dgvWishlist;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnMoveToCollection;
        private System.Windows.Forms.Button btnClose;
    }
}