namespace FormUsers
{
    partial class frmManteniment_UserCategories
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.GrupCamps = new System.Windows.Forms.GroupBox();
            this.GrupCamps.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(115, 25);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(35, 20);
            this.textBox1.TabIndex = 0;
            this.textBox1.Tag = "idUserCategory";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(115, 53);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(162, 20);
            this.textBox2.TabIndex = 1;
            this.textBox2.Tag = "CodeCategory";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(425, 25);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(162, 20);
            this.textBox3.TabIndex = 2;
            this.textBox3.Tag = "DescCategory";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(425, 53);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(162, 20);
            this.textBox4.TabIndex = 3;
            this.textBox4.Tag = "AccessLevel";
            // 
            // GrupCamps
            // 
            this.GrupCamps.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GrupCamps.Controls.Add(this.textBox2);
            this.GrupCamps.Controls.Add(this.textBox4);
            this.GrupCamps.Controls.Add(this.textBox1);
            this.GrupCamps.Controls.Add(this.textBox3);
            this.GrupCamps.ForeColor = System.Drawing.Color.White;
            this.GrupCamps.Location = new System.Drawing.Point(12, 311);
            this.GrupCamps.Name = "GrupCamps";
            this.GrupCamps.Size = new System.Drawing.Size(774, 88);
            this.GrupCamps.TabIndex = 4;
            this.GrupCamps.TabStop = false;
            this.GrupCamps.Text = "Camps";
            // 
            // frmManteniment_UserCategories
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 410);
            this.Controls.Add(this.GrupCamps);
            this.Name = "frmManteniment_UserCategories";
            this.Text = "frmMantniment_UserCategories";
            this.Load += new System.EventHandler(this.frmManteniment_UserCategories_Load);
            this.Controls.SetChildIndex(this.GrupCamps, 0);
            this.GrupCamps.ResumeLayout(false);
            this.GrupCamps.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.GroupBox GrupCamps;
    }
}