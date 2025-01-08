using System.Windows.Forms;

namespace FormRegions
{
    partial class frmManteniment_Regions
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
            this.textBox1.Location = new System.Drawing.Point(95, 27);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.MaxLength = 12;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(96, 20);
            this.textBox1.TabIndex = 15;
            this.textBox1.Tag = "CodeRegion";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(95, 51);
            this.textBox2.Margin = new System.Windows.Forms.Padding(2);
            this.textBox2.MaxLength = 50;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(96, 20);
            this.textBox2.TabIndex = 16;
            this.textBox2.Tag = "DescRegion";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(288, 27);
            this.textBox3.Margin = new System.Windows.Forms.Padding(2);
            this.textBox3.MaxLength = 2000;
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox3.Size = new System.Drawing.Size(479, 68);
            this.textBox3.TabIndex = 17;
            this.textBox3.Tag = "Remarks";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(95, 75);
            this.textBox4.Margin = new System.Windows.Forms.Padding(2);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(96, 20);
            this.textBox4.TabIndex = 18;
            this.textBox4.Tag = "idRegion";
            // 
            // GrupCamps
            // 
            this.GrupCamps.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GrupCamps.Controls.Add(this.textBox3);
            this.GrupCamps.Controls.Add(this.textBox4);
            this.GrupCamps.Controls.Add(this.textBox1);
            this.GrupCamps.Controls.Add(this.textBox2);
            this.GrupCamps.ForeColor = System.Drawing.Color.White;
            this.GrupCamps.Location = new System.Drawing.Point(12, 312);
            this.GrupCamps.Name = "GrupCamps";
            this.GrupCamps.Size = new System.Drawing.Size(775, 107);
            this.GrupCamps.TabIndex = 19;
            this.GrupCamps.TabStop = false;
            this.GrupCamps.Text = "Camps";
            // 
            // frmManteniment_Regions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 430);
            this.Controls.Add(this.GrupCamps);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmManteniment_Regions";
            this.Text = "";
            this.Load += new System.EventHandler(this.frmManteniment_Regions_Load);
            this.Controls.SetChildIndex(this.GrupCamps, 0);
            this.GrupCamps.ResumeLayout(false);
            this.GrupCamps.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private GroupBox GrupCamps;
    }
}

