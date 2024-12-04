
namespace EchoOfRebellion.Formularios
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.swCodi1 = new MisControles.SWCodi();
            this.swCodi2 = new MisControles.SWCodi();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 3;
            this.textBox1.Tag = "idSpaceShipType";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(164, 63);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 9;
            this.textBox2.Tag = "CodeSpaceShipType";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(164, 89);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 20);
            this.textBox3.TabIndex = 10;
            this.textBox3.Tag = "DescSpaceShipType";
            // 
            // swCodi1
            // 
            this.swCodi1.Location = new System.Drawing.Point(164, 126);
            this.swCodi1.Margin = new System.Windows.Forms.Padding(2);
            this.swCodi1.Name = "swCodi1";
            this.swCodi1.Origen = null;
            this.swCodi1.Size = new System.Drawing.Size(342, 21);
            this.swCodi1.TabIndex = 11;
            this.swCodi1.Tag = "idSpaceShipCategory";
            this.swCodi1.Tag2 = "CodeSpaceShipType";
            this.swCodi1.Tag3 = "DescSpaceShipCategory";
            this.swCodi1.TextDesc = "XXX";
            this.swCodi1.TextId = "";
            this.swCodi1.TextValue = "";
            // 
            // swCodi2
            // 
            this.swCodi2.Location = new System.Drawing.Point(164, 163);
            this.swCodi2.Margin = new System.Windows.Forms.Padding(2);
            this.swCodi2.Name = "swCodi2";
            this.swCodi2.Origen = null;
            this.swCodi2.Size = new System.Drawing.Size(342, 21);
            this.swCodi2.TabIndex = 12;
            this.swCodi2.Tag = "idFiliation";
            this.swCodi2.Tag2 = "CodeSpaceShipType";
            this.swCodi2.Tag3 = "DescFiliations";
            this.swCodi2.TextDesc = "XXX";
            this.swCodi2.TextId = "";
            this.swCodi2.TextValue = "";
            // 
            // frmManteniment_SpaceShipTypes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.swCodi2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.swCodi1);
            this.Name = "frmManteniment_SpaceShipTypes";
            this.Text = "frmManteniment_SpaceShipTypes";
            this.Load += new System.EventHandler(this.frmManteniment_SpaceShipTypes_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private MisControles.SWCodi swCodi1;
        private MisControles.SWCodi swCodi2;
    }
}