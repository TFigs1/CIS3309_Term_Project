namespace Pokemon_TCG_Manager
{
    partial class frmSetOverview
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
            this.lblOverview = new System.Windows.Forms.Label();
            this.lstSets = new System.Windows.Forms.ListBox();
            this.dgvSetCards = new System.Windows.Forms.DataGridView();
            this.lblSeters = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSetCards)).BeginInit();
            this.SuspendLayout();
            // 
            // lblOverview
            // 
            this.lblOverview.AutoSize = true;
            this.lblOverview.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOverview.Location = new System.Drawing.Point(328, 9);
            this.lblOverview.Name = "lblOverview";
            this.lblOverview.Size = new System.Drawing.Size(151, 25);
            this.lblOverview.TabIndex = 0;
            this.lblOverview.Text = "Set Overview";
            // 
            // lstSets
            // 
            this.lstSets.FormattingEnabled = true;
            this.lstSets.Location = new System.Drawing.Point(135, 107);
            this.lstSets.Name = "lstSets";
            this.lstSets.Size = new System.Drawing.Size(120, 95);
            this.lstSets.TabIndex = 1;
            this.lstSets.SelectedIndexChanged += new System.EventHandler(this.lstSets_SelectedIndexChanged);
            // 
            // dgvSetCards
            // 
            this.dgvSetCards.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSetCards.Location = new System.Drawing.Point(454, 107);
            this.dgvSetCards.Name = "dgvSetCards";
            this.dgvSetCards.Size = new System.Drawing.Size(240, 150);
            this.dgvSetCards.TabIndex = 2;
            // 
            // lblSeters
            // 
            this.lblSeters.AutoSize = true;
            this.lblSeters.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSeters.Location = new System.Drawing.Point(72, 107);
            this.lblSeters.Name = "lblSeters";
            this.lblSeters.Size = new System.Drawing.Size(46, 20);
            this.lblSeters.TabIndex = 3;
            this.lblSeters.Text = "Sets:";
            // 
            // frmSetOverview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblSeters);
            this.Controls.Add(this.dgvSetCards);
            this.Controls.Add(this.lstSets);
            this.Controls.Add(this.lblOverview);
            this.Name = "frmSetOverview";
            this.Text = "frmSetOverview";
            this.Load += new System.EventHandler(this.frmSetOverview_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSetCards)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblOverview;
        private System.Windows.Forms.ListBox lstSets;
        private System.Windows.Forms.DataGridView dgvSetCards;
        private System.Windows.Forms.Label lblSeters;
    }
}