namespace Pokemon_TCG_Manager
{
    partial class frmSearch
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
            this.lblName = new System.Windows.Forms.Label();
            this.txtCardName = new System.Windows.Forms.TextBox();
            this.lblRarity = new System.Windows.Forms.Label();
            this.cmbRarity = new System.Windows.Forms.ComboBox();
            this.lblSet = new System.Windows.Forms.Label();
            this.cmbSet = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dgvResults = new System.Windows.Forms.DataGridView();
            this.btnAddToWIshList = new System.Windows.Forms.Button();
            this.btnAddToCollection = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).BeginInit();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(56, 31);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(38, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name:";
            // 
            // txtCardName
            // 
            this.txtCardName.Location = new System.Drawing.Point(100, 28);
            this.txtCardName.Name = "txtCardName";
            this.txtCardName.Size = new System.Drawing.Size(150, 20);
            this.txtCardName.TabIndex = 1;
            // 
            // lblRarity
            // 
            this.lblRarity.AutoSize = true;
            this.lblRarity.Location = new System.Drawing.Point(275, 31);
            this.lblRarity.Name = "lblRarity";
            this.lblRarity.Size = new System.Drawing.Size(37, 13);
            this.lblRarity.TabIndex = 2;
            this.lblRarity.Text = "Rarity:";
            // 
            // cmbRarity
            // 
            this.cmbRarity.FormattingEnabled = true;
            this.cmbRarity.Location = new System.Drawing.Point(318, 28);
            this.cmbRarity.Name = "cmbRarity";
            this.cmbRarity.Size = new System.Drawing.Size(121, 21);
            this.cmbRarity.TabIndex = 3;
            // 
            // lblSet
            // 
            this.lblSet.AutoSize = true;
            this.lblSet.Location = new System.Drawing.Point(471, 31);
            this.lblSet.Name = "lblSet";
            this.lblSet.Size = new System.Drawing.Size(26, 13);
            this.lblSet.TabIndex = 4;
            this.lblSet.Text = "Set:";
            // 
            // cmbSet
            // 
            this.cmbSet.DropDownWidth = 150;
            this.cmbSet.FormattingEnabled = true;
            this.cmbSet.Location = new System.Drawing.Point(503, 27);
            this.cmbSet.Name = "cmbSet";
            this.cmbSet.Size = new System.Drawing.Size(121, 21);
            this.cmbSet.TabIndex = 5;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(678, 22);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(80, 30);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dgvResults
            // 
            this.dgvResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResults.Location = new System.Drawing.Point(59, 70);
            this.dgvResults.Name = "dgvResults";
            this.dgvResults.Size = new System.Drawing.Size(699, 314);
            this.dgvResults.TabIndex = 7;
            this.dgvResults.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvResults_CellContentClick);
            // 
            // btnAddToWIshList
            // 
            this.btnAddToWIshList.Location = new System.Drawing.Point(59, 400);
            this.btnAddToWIshList.Name = "btnAddToWIshList";
            this.btnAddToWIshList.Size = new System.Drawing.Size(94, 23);
            this.btnAddToWIshList.TabIndex = 8;
            this.btnAddToWIshList.Text = "Add to Wishlist";
            this.btnAddToWIshList.UseVisualStyleBackColor = true;
            // 
            // btnAddToCollection
            // 
            this.btnAddToCollection.Location = new System.Drawing.Point(186, 400);
            this.btnAddToCollection.Name = "btnAddToCollection";
            this.btnAddToCollection.Size = new System.Drawing.Size(105, 23);
            this.btnAddToCollection.TabIndex = 9;
            this.btnAddToCollection.Text = "Add to Collection";
            this.btnAddToCollection.UseVisualStyleBackColor = true;
            // 
            // frmSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnAddToCollection);
            this.Controls.Add(this.btnAddToWIshList);
            this.Controls.Add(this.dgvResults);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.cmbSet);
            this.Controls.Add(this.lblSet);
            this.Controls.Add(this.cmbRarity);
            this.Controls.Add(this.lblRarity);
            this.Controls.Add(this.txtCardName);
            this.Controls.Add(this.lblName);
            this.Name = "frmSearch";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.frmSearch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtCardName;
        private System.Windows.Forms.Label lblRarity;
        private System.Windows.Forms.ComboBox cmbRarity;
        private System.Windows.Forms.Label lblSet;
        private System.Windows.Forms.ComboBox cmbSet;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridView dgvResults;
        private System.Windows.Forms.Button btnAddToWIshList;
        private System.Windows.Forms.Button btnAddToCollection;
    }
}