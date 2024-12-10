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
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(181, 30);
            this.textBox1.MaxLength = 12;
            this.textBox1.Name = "txt1";
            this.textBox1.Size = new System.Drawing.Size(172, 20);
            this.textBox1.TabIndex = 15;
            this.textBox1.Tag = "CodeRegion";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(181, 80);
            this.textBox2.MaxLength = 50;
            this.textBox2.Name = "txt2";
            this.textBox2.Size = new System.Drawing.Size(172, 20);
            this.textBox2.TabIndex = 16;
            this.textBox2.Tag = "DescRegion";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(500, 30);
            this.textBox3.MaxLength = 2000;
            this.textBox3.Multiline = true;
            this.textBox3.Name = "txt3";
            this.textBox3.Size = new System.Drawing.Size(500, 80);
            this.textBox3.TabIndex = 17;
            this.textBox3.Tag = "Remarks";
            this.textBox3.ScrollBars = ScrollBars.Vertical;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(764, 112);
            this.textBox4.Name = "txt4";
            this.textBox4.Size = new System.Drawing.Size(145, 29);
            this.textBox4.TabIndex = 18;
            this.textBox4.Tag = "idRegion";
            // 
            // frmManteniment_Regions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1467, 831);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            //this.Margin = new System.Windows.Forms.Padding(13);
            this.Name = "frmManteniment_Regions";
            this.Text = "";
            this.Load += new System.EventHandler(this.frmManteniment_Regions_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
    }
}

