
namespace FormSpaceShip
{
    partial class frmManteniment_SpaceShipTypes
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
            this.swCodi1 = new MisControles.SWCodi();
            this.swCodi2 = new MisControles.SWCodi();
            this.swTextbox1 = new MisControles.SWTextbox();
            this.swTextbox2 = new MisControles.SWTextbox();
            this.swTextbox3 = new MisControles.SWTextbox();
            this.GrupCamps = new System.Windows.Forms.GroupBox();
            this.GrupCamps.SuspendLayout();
            this.SuspendLayout();
            // 
            // swCodi1
            // 
            this.swCodi1.Location = new System.Drawing.Point(141, 70);
            this.swCodi1.Margin = new System.Windows.Forms.Padding(2);
            this.swCodi1.Name = "swCodi1";
            this.swCodi1.Origen = null;
            this.swCodi1.Size = new System.Drawing.Size(342, 21);
            this.swCodi1.TabIndex = 11;
            this.swCodi1.Tag = "idSpaceShipCategory";
            this.swCodi1.Tag2 = "";
            this.swCodi1.Tag3 = "DescSpaceShipCategory";
            this.swCodi1.TextDesc = "";
            this.swCodi1.TextId = "";
            this.swCodi1.TextValue = "";
            // 
            // swCodi2
            // 
            this.swCodi2.Location = new System.Drawing.Point(141, 95);
            this.swCodi2.Margin = new System.Windows.Forms.Padding(2);
            this.swCodi2.Name = "swCodi2";
            this.swCodi2.Origen = null;
            this.swCodi2.Size = new System.Drawing.Size(342, 21);
            this.swCodi2.TabIndex = 12;
            this.swCodi2.Tag = "idFiliation";
            this.swCodi2.Tag2 = "";
            this.swCodi2.Tag3 = "DescFiliations";
            this.swCodi2.TextDesc = "";
            this.swCodi2.TextId = "";
            this.swCodi2.TextValue = "";
            // 
            // swTextbox1
            // 
            this.swTextbox1.BackColorError = System.Drawing.Color.Empty;
            this.swTextbox1.BackColorGetFocus = System.Drawing.Color.Empty;
            this.swTextbox1.BackColorLostFocus = System.Drawing.Color.Empty;
            this.swTextbox1.Location = new System.Drawing.Point(430, 19);
            this.swTextbox1.Name = "swTextbox1";
            this.swTextbox1.Patro = null;
            this.swTextbox1.Size = new System.Drawing.Size(53, 20);
            this.swTextbox1.TabIndex = 13;
            this.swTextbox1.Tag = "idSpaceShipType";
            this.swTextbox1.Tipus = MisControles.SWTextbox.TipusDada.Sense;
            // 
            // swTextbox2
            // 
            this.swTextbox2.BackColorError = System.Drawing.Color.Empty;
            this.swTextbox2.BackColorGetFocus = System.Drawing.Color.Empty;
            this.swTextbox2.BackColorLostFocus = System.Drawing.Color.Empty;
            this.swTextbox2.Location = new System.Drawing.Point(141, 19);
            this.swTextbox2.Name = "swTextbox2";
            this.swTextbox2.Patro = null;
            this.swTextbox2.Size = new System.Drawing.Size(169, 20);
            this.swTextbox2.TabIndex = 14;
            this.swTextbox2.Tag = "CodeSpaceShipType";
            this.swTextbox2.Tipus = MisControles.SWTextbox.TipusDada.Sense;
            // 
            // swTextbox3
            // 
            this.swTextbox3.BackColorError = System.Drawing.Color.Empty;
            this.swTextbox3.BackColorGetFocus = System.Drawing.Color.Empty;
            this.swTextbox3.BackColorLostFocus = System.Drawing.Color.Empty;
            this.swTextbox3.Location = new System.Drawing.Point(141, 45);
            this.swTextbox3.Name = "swTextbox3";
            this.swTextbox3.Patro = null;
            this.swTextbox3.Size = new System.Drawing.Size(169, 20);
            this.swTextbox3.TabIndex = 15;
            this.swTextbox3.Tag = "DescSpaceShipType";
            this.swTextbox3.Tipus = MisControles.SWTextbox.TipusDada.Sense;
            // 
            // GrupCamps
            // 
            this.GrupCamps.Controls.Add(this.swTextbox2);
            this.GrupCamps.Controls.Add(this.swTextbox3);
            this.GrupCamps.Controls.Add(this.swCodi1);
            this.GrupCamps.Controls.Add(this.swCodi2);
            this.GrupCamps.Controls.Add(this.swTextbox1);
            this.GrupCamps.ForeColor = System.Drawing.Color.White;
            this.GrupCamps.Location = new System.Drawing.Point(12, 315);
            this.GrupCamps.Name = "GrupCamps";
            this.GrupCamps.Size = new System.Drawing.Size(776, 124);
            this.GrupCamps.TabIndex = 16;
            this.GrupCamps.TabStop = false;
            this.GrupCamps.Text = "Camps";
            // 
            // frmManteniment_SpaceShipTypes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.GrupCamps);
            this.Name = "frmManteniment_SpaceShipTypes";
            this.Text = "frmManteniment_SpaceShipTypes";
            this.Load += new System.EventHandler(this.frmManteniment_SpaceShipTypes_Load);
            this.Controls.SetChildIndex(this.GrupCamps, 0);
            this.GrupCamps.ResumeLayout(false);
            this.GrupCamps.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private MisControles.SWCodi swCodi1;
        private MisControles.SWCodi swCodi2;
        private MisControles.SWTextbox swTextbox1;
        private MisControles.SWTextbox swTextbox2;
        private MisControles.SWTextbox swTextbox3;
        private System.Windows.Forms.GroupBox GrupCamps;
    }
}