namespace FormSectors
{
    partial class frmManteniment_Sectors
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
            this.GrupCamps = new System.Windows.Forms.GroupBox();
            this.swCodi1 = new MisControles.SWCodi();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.GrupCamps.SuspendLayout();
            this.SuspendLayout();
            // 
            // GrupCamps
            // 
            this.GrupCamps.Controls.Add(this.swCodi1);
            this.GrupCamps.Controls.Add(this.textBox3);
            this.GrupCamps.Controls.Add(this.textBox4);
            this.GrupCamps.Controls.Add(this.textBox1);
            this.GrupCamps.Controls.Add(this.textBox2);
            this.GrupCamps.ForeColor = System.Drawing.Color.White;
            this.GrupCamps.Location = new System.Drawing.Point(12, 312);
            this.GrupCamps.Name = "GrupCamps";
            this.GrupCamps.Size = new System.Drawing.Size(775, 126);
            this.GrupCamps.TabIndex = 3;
            this.GrupCamps.TabStop = false;
            this.GrupCamps.Text = "Camps";
            // 
            // swCodi1
            // 
            this.swCodi1.Location = new System.Drawing.Point(98, 90);
            this.swCodi1.Margin = new System.Windows.Forms.Padding(2);
            this.swCodi1.Name = "swCodi1";
            this.swCodi1.Origen = null;
            this.swCodi1.Size = new System.Drawing.Size(284, 21);
            this.swCodi1.TabIndex = 23;
            this.swCodi1.Tag = "idRegion";
            this.swCodi1.Tag2 = "";
            this.swCodi1.Tag3 = "DescRegion";
            this.swCodi1.TextDesc = "XXX";
            this.swCodi1.TextId = "";
            this.swCodi1.TextValue = "";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(291, 18);
            this.textBox3.Margin = new System.Windows.Forms.Padding(2);
            this.textBox3.MaxLength = 2000;
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox3.Size = new System.Drawing.Size(479, 68);
            this.textBox3.TabIndex = 21;
            this.textBox3.Tag = "Remarks";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(98, 66);
            this.textBox4.Margin = new System.Windows.Forms.Padding(2);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(96, 20);
            this.textBox4.TabIndex = 22;
            this.textBox4.Tag = "idSector";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(98, 18);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.MaxLength = 12;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(96, 20);
            this.textBox1.TabIndex = 19;
            this.textBox1.Tag = "CodeSector";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(98, 42);
            this.textBox2.Margin = new System.Windows.Forms.Padding(2);
            this.textBox2.MaxLength = 50;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(96, 20);
            this.textBox2.TabIndex = 20;
            this.textBox2.Tag = "DescSector";
            // 
            // frmManteniment_Sectors
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.GrupCamps);
            this.Name = "frmManteniment_Sectors";
            this.Text = "";
            this.Load += new System.EventHandler(this.frmManteniment_Sectors_Load);
            this.Controls.SetChildIndex(this.GrupCamps, 0);
            this.GrupCamps.ResumeLayout(false);
            this.GrupCamps.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GrupCamps;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private MisControles.SWCodi swCodi1;
    }
}

