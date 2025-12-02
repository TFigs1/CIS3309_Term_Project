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
            this.SuspendLayout();
            // 
            // btnGoToCollections
            // 
            this.btnGoToCollections.Location = new System.Drawing.Point(568, 413);
            this.btnGoToCollections.Name = "btnGoToCollections";
            this.btnGoToCollections.Size = new System.Drawing.Size(280, 36);
            this.btnGoToCollections.TabIndex = 0;
            this.btnGoToCollections.Text = "Go to collections";
            this.btnGoToCollections.UseVisualStyleBackColor = true;
            this.btnGoToCollections.Click += new System.EventHandler(this.btnGoToCollections_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(589, 385);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(250, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Card Collection Manager";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1479, 954);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnGoToCollections);
            this.Name = "frmMain";
            this.Text = "Pokemon TCG Manager ";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGoToCollections;
        private System.Windows.Forms.Label label1;
    }
}

