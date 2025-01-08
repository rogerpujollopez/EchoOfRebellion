namespace FormUsers
{
    partial class frmManteniment_UserRangs
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
            this.GrupCamps = new System.Windows.Forms.GroupBox();
            this.GrupCamps.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(372, 30);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 0;
            this.textBox1.Tag = "idUserRank";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(146, 30);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 1;
            this.textBox2.Tag = "CodeRank";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(146, 60);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 20);
            this.textBox3.TabIndex = 2;
            this.textBox3.Tag = "DescRank";
            // 
            // GrupCamps
            // 
            this.GrupCamps.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GrupCamps.Controls.Add(this.textBox2);
            this.GrupCamps.Controls.Add(this.textBox1);
            this.GrupCamps.Controls.Add(this.textBox3);
            this.GrupCamps.ForeColor = System.Drawing.Color.White;
            this.GrupCamps.Location = new System.Drawing.Point(12, 312);
            this.GrupCamps.Name = "GrupCamps";
            this.GrupCamps.Size = new System.Drawing.Size(775, 96);
            this.GrupCamps.TabIndex = 3;
            this.GrupCamps.TabStop = false;
            this.GrupCamps.Text = "Camps";
            // 
            // frmManteniment_UserRangs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 418);
            this.Controls.Add(this.GrupCamps);
            this.Name = "frmManteniment_UserRangs";
            this.Text = "frmManteniment_UserRangs";
            this.Load += new System.EventHandler(this.frmManteniment_UserRangs_Load);
            this.Controls.SetChildIndex(this.GrupCamps, 0);
            this.GrupCamps.ResumeLayout(false);
            this.GrupCamps.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.GroupBox GrupCamps;
    }
}