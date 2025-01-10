using System.Collections.Generic;

namespace FormUsers
{
    partial class frmManteniment_Users
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
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.swCodi1 = new MisControles.SWCodi();
            this.swCodi2 = new MisControles.SWCodi();
            this.swCodi3 = new MisControles.SWCodi();
            this.swCodi4 = new MisControles.SWCodi();
            this.panel1 = new System.Windows.Forms.Panel();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.btnMostrar = new System.Windows.Forms.Button();
            this.GrupCamps = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.GrupCamps.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(141, 28);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(164, 22);
            this.textBox1.TabIndex = 0;
            this.textBox1.Tag = "CodeUser";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(141, 60);
            this.textBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(164, 22);
            this.textBox2.TabIndex = 1;
            this.textBox2.Tag = "UserName";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(141, 92);
            this.textBox3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(164, 22);
            this.textBox3.TabIndex = 2;
            this.textBox3.Tag = "Login";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(141, 124);
            this.textBox4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(164, 22);
            this.textBox4.TabIndex = 3;
            this.textBox4.Tag = "Mail";
            // 
            // textBox5
            // 
            this.textBox5.Enabled = false;
            this.textBox5.Location = new System.Drawing.Point(141, 156);
            this.textBox5.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(77, 22);
            this.textBox5.TabIndex = 9;
            this.textBox5.Tag = "idUser";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(28, 226);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(150, 145);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Tag = "Photo";
            // 
            // swCodi1
            // 
            this.swCodi1.Location = new System.Drawing.Point(549, 27);
            this.swCodi1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.swCodi1.Name = "swCodi1";
            this.swCodi1.Origen = null;
            this.swCodi1.Size = new System.Drawing.Size(456, 26);
            this.swCodi1.TabIndex = 5;
            this.swCodi1.Tag = "idUserRank";
            this.swCodi1.Tag2 = "";
            this.swCodi1.Tag3 = "DescRank";
            this.swCodi1.TextDesc = "XXX";
            this.swCodi1.TextId = "";
            this.swCodi1.TextValue = "";
            // 
            // swCodi2
            // 
            this.swCodi2.Location = new System.Drawing.Point(549, 58);
            this.swCodi2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.swCodi2.Name = "swCodi2";
            this.swCodi2.Origen = null;
            this.swCodi2.Size = new System.Drawing.Size(456, 26);
            this.swCodi2.TabIndex = 6;
            this.swCodi2.Tag = "idUserCategory";
            this.swCodi2.Tag2 = "DescCategory";
            this.swCodi2.Tag3 = "";
            this.swCodi2.TextDesc = "XXX";
            this.swCodi2.TextId = "";
            this.swCodi2.TextValue = "";
            // 
            // swCodi3
            // 
            this.swCodi3.Location = new System.Drawing.Point(549, 89);
            this.swCodi3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.swCodi3.Name = "swCodi3";
            this.swCodi3.Origen = null;
            this.swCodi3.Size = new System.Drawing.Size(456, 26);
            this.swCodi3.TabIndex = 7;
            this.swCodi3.Tag = "idPlanet";
            this.swCodi3.Tag2 = "";
            this.swCodi3.Tag3 = "";
            this.swCodi3.TextDesc = "XXX";
            this.swCodi3.TextId = "";
            this.swCodi3.TextValue = "";
            // 
            // swCodi4
            // 
            this.swCodi4.Location = new System.Drawing.Point(549, 119);
            this.swCodi4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.swCodi4.Name = "swCodi4";
            this.swCodi4.Origen = null;
            this.swCodi4.Size = new System.Drawing.Size(456, 26);
            this.swCodi4.TabIndex = 8;
            this.swCodi4.Tag = "idSpecie";
            this.swCodi4.Tag2 = "";
            this.swCodi4.Tag3 = "";
            this.swCodi4.TextDesc = "XXX";
            this.swCodi4.TextId = "";
            this.swCodi4.TextValue = "";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.crystalReportViewer1);
            this.panel1.Location = new System.Drawing.Point(228, 156);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(777, 350);
            this.panel1.TabIndex = 0;
            this.panel1.Tag = "PanelReport";
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer1.Location = new System.Drawing.Point(0, 0);
            this.crystalReportViewer1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.Size = new System.Drawing.Size(777, 350);
            this.crystalReportViewer1.TabIndex = 0;
            this.crystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // btnMostrar
            // 
            this.btnMostrar.Location = new System.Drawing.Point(0, 0);
            this.btnMostrar.Name = "btnMostrar";
            this.btnMostrar.Size = new System.Drawing.Size(75, 23);
            this.btnMostrar.TabIndex = 14;
            this.btnMostrar.Tag = "btnMostrar";
            this.btnMostrar.Text = "Mostrar";
            this.btnMostrar.UseVisualStyleBackColor = true;
            // 
            // GrupCamps
            // 
            this.GrupCamps.Controls.Add(this.button1);
            this.GrupCamps.Controls.Add(this.panel1);
            this.GrupCamps.Controls.Add(this.textBox5);
            this.GrupCamps.Controls.Add(this.swCodi4);
            this.GrupCamps.Controls.Add(this.pictureBox1);
            this.GrupCamps.Controls.Add(this.swCodi3);
            this.GrupCamps.Controls.Add(this.textBox1);
            this.GrupCamps.Controls.Add(this.swCodi2);
            this.GrupCamps.Controls.Add(this.textBox2);
            this.GrupCamps.Controls.Add(this.swCodi1);
            this.GrupCamps.Controls.Add(this.textBox3);
            this.GrupCamps.Controls.Add(this.textBox4);
            this.GrupCamps.ForeColor = System.Drawing.Color.White;
            this.GrupCamps.Location = new System.Drawing.Point(16, 385);
            this.GrupCamps.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.GrupCamps.Name = "GrupCamps";
            this.GrupCamps.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.GrupCamps.Size = new System.Drawing.Size(1035, 527);
            this.GrupCamps.TabIndex = 10;
            this.GrupCamps.TabStop = false;
            this.GrupCamps.Text = "Camps";
            // 
            // button1
            // 
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(48, 411);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 28);
            this.button1.TabIndex = 10;
            this.button1.Text = "Mostrar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmManteniment_Users
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 927);
            this.Controls.Add(this.GrupCamps);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmManteniment_Users";
            this.Text = "frmManteniment_Users";
            this.Load += new System.EventHandler(this.frmManteniment_Users_Load);
            this.Controls.SetChildIndex(this.GrupCamps, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.GrupCamps.ResumeLayout(false);
            this.GrupCamps.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private MisControles.SWCodi swCodi1;
        private MisControles.SWCodi swCodi2;
        private MisControles.SWCodi swCodi3;
        private MisControles.SWCodi swCodi4;
        private System.Windows.Forms.Panel panel1;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private System.Windows.Forms.Button btnMostrar;
        private System.Windows.Forms.GroupBox GrupCamps;
        private System.Windows.Forms.Button button1;
    }
}

