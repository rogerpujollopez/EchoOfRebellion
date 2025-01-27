using System.Windows.Forms;

namespace FormPlanetes
{
    partial class frmManteniment_Planetes
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
            this.swCodi1 = new MisControles.SWCodi();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.swCodi2 = new MisControles.SWCodi();
            this.swCodi3 = new MisControles.SWCodi();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.GrupCamps = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.GrupCamps.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(165, 35);
            this.textBox1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(180, 29);
            this.textBox1.TabIndex = 0;
            this.textBox1.Tag = "CodePlanet";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(165, 90);
            this.textBox2.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(180, 29);
            this.textBox2.TabIndex = 0;
            this.textBox2.Tag = "DescPlanet";
            // 
            // swCodi1
            // 
            this.swCodi1.Location = new System.Drawing.Point(165, 146);
            this.swCodi1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.swCodi1.Name = "swCodi1";
            this.swCodi1.Origen = null;
            this.swCodi1.Size = new System.Drawing.Size(627, 39);
            this.swCodi1.TabIndex = 0;
            this.swCodi1.Tag = "idSector";
            this.swCodi1.Tag2 = "";
            this.swCodi1.Tag3 = "DescSector";
            this.swCodi1.TextDesc = "";
            this.swCodi1.TextId = "";
            this.swCodi1.TextValue = "";
            this.swCodi1.VerFormularioSelect = false;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(493, 35);
            this.textBox3.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(88, 29);
            this.textBox3.TabIndex = 0;
            this.textBox3.Tag = "long";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(493, 90);
            this.textBox4.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(88, 29);
            this.textBox4.TabIndex = 9;
            this.textBox4.Tag = "lat";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(700, 35);
            this.textBox5.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(88, 29);
            this.textBox5.TabIndex = 10;
            this.textBox5.Tag = "parsecs";
            // 
            // swCodi2
            // 
            this.swCodi2.Location = new System.Drawing.Point(165, 201);
            this.swCodi2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.swCodi2.Name = "swCodi2";
            this.swCodi2.Origen = null;
            this.swCodi2.Size = new System.Drawing.Size(627, 39);
            this.swCodi2.TabIndex = 0;
            this.swCodi2.Tag = "idNatives";
            this.swCodi2.Tag2 = "";
            this.swCodi2.Tag3 = "DescSpecie";
            this.swCodi2.TextDesc = "";
            this.swCodi2.TextId = "";
            this.swCodi2.TextValue = "";
            this.swCodi2.VerFormularioSelect = false;
            // 
            // swCodi3
            // 
            this.swCodi3.Location = new System.Drawing.Point(165, 257);
            this.swCodi3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.swCodi3.Name = "swCodi3";
            this.swCodi3.Origen = null;
            this.swCodi3.Size = new System.Drawing.Size(627, 39);
            this.swCodi3.TabIndex = 0;
            this.swCodi3.Tag = "idFiliation";
            this.swCodi3.Tag2 = "";
            this.swCodi3.Tag3 = "DescFiliations";
            this.swCodi3.TextDesc = "";
            this.swCodi3.TextId = "";
            this.swCodi3.TextValue = "";
            this.swCodi3.VerFormularioSelect = false;
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(1016, 35);
            this.textBox6.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(180, 29);
            this.textBox6.TabIndex = 0;
            this.textBox6.Tag = "PlanetPicture";
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(1016, 90);
            this.textBox7.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(180, 29);
            this.textBox7.TabIndex = 1;
            this.textBox7.Tag = "IPPlanet";
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(1016, 146);
            this.textBox8.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(180, 29);
            this.textBox8.TabIndex = 2;
            this.textBox8.Tag = "PortPlanet";
            // 
            // textBox9
            // 
            this.textBox9.Location = new System.Drawing.Point(1016, 201);
            this.textBox9.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(180, 29);
            this.textBox9.TabIndex = 3;
            this.textBox9.Tag = "PortPlanet1";
            // 
            // GrupCamps
            // 
            this.GrupCamps.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GrupCamps.Controls.Add(this.pictureBox1);
            this.GrupCamps.Controls.Add(this.textBox10);
            this.GrupCamps.Controls.Add(this.textBox1);
            this.GrupCamps.Controls.Add(this.swCodi2);
            this.GrupCamps.Controls.Add(this.swCodi3);
            this.GrupCamps.Controls.Add(this.textBox5);
            this.GrupCamps.Controls.Add(this.textBox6);
            this.GrupCamps.Controls.Add(this.textBox2);
            this.GrupCamps.Controls.Add(this.textBox7);
            this.GrupCamps.Controls.Add(this.textBox4);
            this.GrupCamps.Controls.Add(this.textBox8);
            this.GrupCamps.Controls.Add(this.swCodi1);
            this.GrupCamps.Controls.Add(this.textBox9);
            this.GrupCamps.Controls.Add(this.textBox3);
            this.GrupCamps.ForeColor = System.Drawing.Color.White;
            this.GrupCamps.Location = new System.Drawing.Point(22, 576);
            this.GrupCamps.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.GrupCamps.Name = "GrupCamps";
            this.GrupCamps.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.GrupCamps.Size = new System.Drawing.Size(1423, 316);
            this.GrupCamps.TabIndex = 11;
            this.GrupCamps.TabStop = false;
            this.GrupCamps.Text = "Camps";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(1223, 41);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(182, 183);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // textBox10
            // 
            this.textBox10.Enabled = false;
            this.textBox10.Location = new System.Drawing.Point(700, 90);
            this.textBox10.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(88, 29);
            this.textBox10.TabIndex = 11;
            this.textBox10.Tag = "idPlanet";
            // 
            // frmManteniment_Planetes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1467, 914);
            this.Controls.Add(this.GrupCamps);
            this.Margin = new System.Windows.Forms.Padding(13, 13, 13, 13);
            this.Name = "frmManteniment_Planetes";
            this.Load += new System.EventHandler(this.frmManteniment_Planetes_Load);
            this.Controls.SetChildIndex(this.GrupCamps, 0);
            this.GrupCamps.ResumeLayout(false);
            this.GrupCamps.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private TextBox textBox1;
        private TextBox textBox2;
        private MisControles.SWCodi swCodi1;
        private TextBox textBox3;
        private TextBox textBox4;
        private TextBox textBox5;
        private MisControles.SWCodi swCodi2;
        private MisControles.SWCodi swCodi3;
        private TextBox textBox6;
        private TextBox textBox7;
        private TextBox textBox8;
        private TextBox textBox9;
        private GroupBox GrupCamps;
        private TextBox textBox10;
        private PictureBox pictureBox1;
    }
}