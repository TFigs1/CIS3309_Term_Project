namespace Pokemon_TCG_Manager
{
    partial class frmMain
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
            this.btnGoToCollections = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnWishlists = new System.Windows.Forms.Button();
            this.btnSetOverview = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnGoToCollections
            // 
            this.btnGoToCollections.Location = new System.Drawing.Point(284, 215);
            this.btnGoToCollections.Margin = new System.Windows.Forms.Padding(2);
            this.btnGoToCollections.Name = "btnGoToCollections";
            this.btnGoToCollections.Size = new System.Drawing.Size(140, 19);
            this.btnGoToCollections.TabIndex = 0;
            this.btnGoToCollections.Text = "Go to collections";
            this.btnGoToCollections.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(294, 200);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Card Collection Manager";
            // 
            // btnWishlists
            // 
            this.btnWishlists.Location = new System.Drawing.Point(284, 238);
            this.btnWishlists.Margin = new System.Windows.Forms.Padding(2);
            this.btnWishlists.Name = "btnWishlists";
            this.btnWishlists.Size = new System.Drawing.Size(140, 19);
            this.btnWishlists.TabIndex = 2;
            this.btnWishlists.Text = "Wishlist";
            this.btnWishlists.UseVisualStyleBackColor = true;
            this.btnWishlists.Click += new System.EventHandler(this.btnWishlists_Click);
            // 
            // btnSetOverview
            // 
            this.btnSetOverview.Location = new System.Drawing.Point(284, 261);
            this.btnSetOverview.Margin = new System.Windows.Forms.Padding(2);
            this.btnSetOverview.Name = "btnSetOverview";
            this.btnSetOverview.Size = new System.Drawing.Size(140, 19);
            this.btnSetOverview.TabIndex = 3;
            this.btnSetOverview.Text = "Overview";
            this.btnSetOverview.UseVisualStyleBackColor = true;
            this.btnSetOverview.Click += new System.EventHandler(this.btnSetOverview_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 496);
            this.Controls.Add(this.btnSetOverview);
            this.Controls.Add(this.btnWishlists);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnGoToCollections);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmMain";
            this.Text = "Pokemon TCG Manager ";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGoToCollections;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnWishlists;
        private System.Windows.Forms.Button btnSetOverview;
    }
}

