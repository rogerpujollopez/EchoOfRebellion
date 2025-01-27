using MisControles;
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
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.swTextbox4 = new MisControles.SWTextbox();
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
            this.button2 = new MisControles.SWBotons();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new MisControles.SWBotons();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.GrupCamps.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(106, 49);
            this.textBox2.MaxLength = 100;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(124, 20);
            this.textBox2.TabIndex = 1;
            this.textBox2.Tag = "UserName";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(106, 75);
            this.textBox3.MaxLength = 12;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(124, 20);
            this.textBox3.TabIndex = 2;
            this.textBox3.Tag = "Login";
            // 
            // swTextbox4
            // 
            this.swTextbox4.BackColorError = System.Drawing.Color.Empty;
            this.swTextbox4.BackColorGetFocus = System.Drawing.Color.Empty;
            this.swTextbox4.BackColorLostFocus = System.Drawing.Color.Empty;
            this.swTextbox4.Location = new System.Drawing.Point(106, 101);
            this.swTextbox4.Name = "swTextbox4";
            this.swTextbox4.Patro = "^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$";
            this.swTextbox4.Size = new System.Drawing.Size(124, 20);
            this.swTextbox4.TabIndex = 3;
            this.swTextbox4.Tag = "Mail";
            this.swTextbox4.Tipus = MisControles.SWTextbox.TipusDada.Personalitzat;
            // 
            // textBox5
            // 
            this.textBox5.Enabled = false;
            this.textBox5.Location = new System.Drawing.Point(106, 127);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(59, 20);
            this.textBox5.TabIndex = 9;
            this.textBox5.TabStop = false;
            this.textBox5.Tag = "idUser";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(21, 184);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(113, 118);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Tag = "Photo";
            // 
            // swCodi1
            // 
            this.swCodi1.Location = new System.Drawing.Point(412, 22);
            this.swCodi1.Margin = new System.Windows.Forms.Padding(2);
            this.swCodi1.Name = "swCodi1";
            this.swCodi1.Origen = null;
            this.swCodi1.Size = new System.Drawing.Size(342, 21);
            this.swCodi1.TabIndex = 4;
            this.swCodi1.Tag = "idUserRank";
            this.swCodi1.Tag2 = "";
            this.swCodi1.Tag3 = "DescRank";
            this.swCodi1.TextDesc = "";
            this.swCodi1.TextId = "";
            this.swCodi1.TextValue = "";
            this.swCodi1.VerFormularioSelect = false;
            // 
            // swCodi2
            // 
            this.swCodi2.Location = new System.Drawing.Point(412, 47);
            this.swCodi2.Margin = new System.Windows.Forms.Padding(2);
            this.swCodi2.Name = "swCodi2";
            this.swCodi2.Origen = null;
            this.swCodi2.Size = new System.Drawing.Size(342, 21);
            this.swCodi2.TabIndex = 5;
            this.swCodi2.Tag = "idUserCategory";
            this.swCodi2.Tag2 = "";
            this.swCodi2.Tag3 = "DescCategory";
            this.swCodi2.TextDesc = "";
            this.swCodi2.TextId = "";
            this.swCodi2.TextValue = "";
            this.swCodi2.VerFormularioSelect = false;
            // 
            // swCodi3
            // 
            this.swCodi3.Location = new System.Drawing.Point(412, 72);
            this.swCodi3.Margin = new System.Windows.Forms.Padding(2);
            this.swCodi3.Name = "swCodi3";
            this.swCodi3.Origen = null;
            this.swCodi3.Size = new System.Drawing.Size(342, 21);
            this.swCodi3.TabIndex = 6;
            this.swCodi3.Tag = "idPlanet";
            this.swCodi3.Tag2 = "";
            this.swCodi3.Tag3 = "";
            this.swCodi3.TextDesc = "";
            this.swCodi3.TextId = "";
            this.swCodi3.TextValue = "";
            this.swCodi3.VerFormularioSelect = true;
            // 
            // swCodi4
            // 
            this.swCodi4.Location = new System.Drawing.Point(412, 97);
            this.swCodi4.Margin = new System.Windows.Forms.Padding(2);
            this.swCodi4.Name = "swCodi4";
            this.swCodi4.Origen = null;
            this.swCodi4.Size = new System.Drawing.Size(342, 21);
            this.swCodi4.TabIndex = 7;
            this.swCodi4.Tag = "idSpecie";
            this.swCodi4.Tag2 = "";
            this.swCodi4.Tag3 = "";
            this.swCodi4.TextDesc = "";
            this.swCodi4.TextId = "";
            this.swCodi4.TextValue = "";
            this.swCodi4.VerFormularioSelect = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.crystalReportViewer1);
            this.panel1.Location = new System.Drawing.Point(171, 127);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(583, 284);
            this.panel1.TabIndex = 0;
            this.panel1.Tag = "PanelReport";
            this.panel1.Visible = false;
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer1.Location = new System.Drawing.Point(0, 0);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.Size = new System.Drawing.Size(583, 284);
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
            this.GrupCamps.Controls.Add(this.button2);
            this.GrupCamps.Controls.Add(this.textBox1);
            this.GrupCamps.Controls.Add(this.button1);
            this.GrupCamps.Controls.Add(this.panel1);
            this.GrupCamps.Controls.Add(this.textBox5);
            this.GrupCamps.Controls.Add(this.swCodi4);
            this.GrupCamps.Controls.Add(this.pictureBox1);
            this.GrupCamps.Controls.Add(this.swCodi3);
            this.GrupCamps.Controls.Add(this.swCodi2);
            this.GrupCamps.Controls.Add(this.textBox2);
            this.GrupCamps.Controls.Add(this.swCodi1);
            this.GrupCamps.Controls.Add(this.textBox3);
            this.GrupCamps.Controls.Add(this.swTextbox4);
            this.GrupCamps.ForeColor = System.Drawing.Color.White;
            this.GrupCamps.Location = new System.Drawing.Point(12, 313);
            this.GrupCamps.Name = "GrupCamps";
            this.GrupCamps.Size = new System.Drawing.Size(776, 428);
            this.GrupCamps.TabIndex = 10;
            this.GrupCamps.TabStop = false;
            this.GrupCamps.Text = "Camps";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Black;
            this.button2.DesactivarDragAndDrop = false;
            this.button2.Formulari = null;
            this.button2.Location = new System.Drawing.Point(9, 313);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(144, 46);
            this.button2.TabIndex = 5;
            this.button2.Texto = "Exportar";
            this.button2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.button2_Click);
            this.button2.DesactivarDragAndDrop = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(106, 23);
            this.textBox1.MaxLength = 12;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(124, 20);
            this.textBox1.TabIndex = 0;
            this.textBox1.Tag = "CodeUser";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Black;
            this.button1.DesactivarDragAndDrop = false;
            this.button1.Formulari = null;
            this.button1.Location = new System.Drawing.Point(9, 365);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(144, 46);
            this.button1.TabIndex = 5;
            this.button1.Texto = "Veure fitxa";
            this.button1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.button1_Click);
            this.button1.DesactivarDragAndDrop = true;
            // 
            // frmManteniment_Users
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 753);
            this.Controls.Add(this.GrupCamps);
            this.Margin = new System.Windows.Forms.Padding(2);
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
        private SWTextbox swTextbox4;
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
        private SWBotons button1;
        private SWBotons button2;
    }
}

