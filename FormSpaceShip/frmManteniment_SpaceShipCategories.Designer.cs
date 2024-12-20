namespace FormSpaceShip
{
    partial class frmManteniment_SpaceShipCategories
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
            this.swTextbox1 = new MisControles.SWTextbox();
            this.swTextbox2 = new MisControles.SWTextbox();
            this.swTextbox3 = new MisControles.SWTextbox();
            this.SuspendLayout();
            // 
            // swTextbox1
            // 
            this.swTextbox1.BackColorError = System.Drawing.Color.Empty;
            this.swTextbox1.BackColorGetFocus = System.Drawing.Color.Empty;
            this.swTextbox1.BackColorLostFocus = System.Drawing.Color.Empty;
            this.swTextbox1.Location = new System.Drawing.Point(129, 12);
            this.swTextbox1.Name = "swTextbox1";
            this.swTextbox1.Patro = null;
            this.swTextbox1.Size = new System.Drawing.Size(32, 20);
            this.swTextbox1.TabIndex = 3;
            this.swTextbox1.Tag = "idSpaceShipCategory";
            this.swTextbox1.Tipus = MisControles.SWTextbox.TipusDada.Sense;
            // 
            // swTextbox2
            // 
            this.swTextbox2.BackColorError = System.Drawing.Color.Empty;
            this.swTextbox2.BackColorGetFocus = System.Drawing.Color.Empty;
            this.swTextbox2.BackColorLostFocus = System.Drawing.Color.Empty;
            this.swTextbox2.Location = new System.Drawing.Point(187, 41);
            this.swTextbox2.Name = "swTextbox2";
            this.swTextbox2.Patro = null;
            this.swTextbox2.Size = new System.Drawing.Size(210, 20);
            this.swTextbox2.TabIndex = 4;
            this.swTextbox2.Tag = "CodeSpaceShipCategory";
            this.swTextbox2.Tipus = MisControles.SWTextbox.TipusDada.Sense;
            // 
            // swTextbox3
            // 
            this.swTextbox3.BackColorError = System.Drawing.Color.Empty;
            this.swTextbox3.BackColorGetFocus = System.Drawing.Color.Empty;
            this.swTextbox3.BackColorLostFocus = System.Drawing.Color.Empty;
            this.swTextbox3.Location = new System.Drawing.Point(187, 84);
            this.swTextbox3.Name = "swTextbox3";
            this.swTextbox3.Patro = null;
            this.swTextbox3.Size = new System.Drawing.Size(210, 20);
            this.swTextbox3.TabIndex = 5;
            this.swTextbox3.Tag = "DescSpaceShipCategory";
            this.swTextbox3.Tipus = MisControles.SWTextbox.TipusDada.Sense;
            // 
            // frmManteniment_SpaceShipCategories
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.swTextbox3);
            this.Controls.Add(this.swTextbox2);
            this.Controls.Add(this.swTextbox1);
            this.Name = "frmManteniment_SpaceShipCategories";
            this.Text = "frmMantniment_Naus";
            this.Load += new System.EventHandler(this.frmManteniment_ShipCategories_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MisControles.SWTextbox swTextbox1;
        private MisControles.SWTextbox swTextbox2;
        private MisControles.SWTextbox swTextbox3;
    }
}