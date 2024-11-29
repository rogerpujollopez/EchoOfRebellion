namespace EchoOfRebellion.Formularios
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.swCodi1 = new MisControles.SWCodi();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(85, 45);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(39, 20);
            this.textBox1.TabIndex = 0;
            this.textBox1.Tag = "idSector";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(97, 42);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(152, 20);
            this.textBox3.TabIndex = 2;
            this.textBox3.Tag = "CodeSector";
            // 
            // swCodi1
            // 
            this.swCodi1.Location = new System.Drawing.Point(97, 93);
            this.swCodi1.Margin = new System.Windows.Forms.Padding(2);
            this.swCodi1.Name = "swCodi1";
            this.swCodi1.NivellDesitjat = MisControles.SWCodi.TipusNivell.GM;
            this.swCodi1.Requerit = false;
            this.swCodi1.Size = new System.Drawing.Size(342, 21);
            this.swCodi1.TabIndex = 3;
            this.swCodi1.Tag = "idRegion";
            this.swCodi1.TextLabel = "XXX";
            this.swCodi1.TextValue = "";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(97, 68);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(152, 20);
            this.textBox4.TabIndex = 4;
            this.textBox4.Tag = "DescSector";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(379, 42);
            this.textBox5.Multiline = true;
            this.textBox5.Name = "textBox5";
            this.textBox5.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox5.Size = new System.Drawing.Size(317, 46);
            this.textBox5.TabIndex = 5;
            this.textBox5.Tag = "Remarks";
            // 
            // frmManteniment_Sectors
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.swCodi1);
            this.Controls.Add(this.textBox3);
            this.Name = "frmManteniment_Sectors";
            this.Text = "frmManteniment_Sectors";
            this.Load += new System.EventHandler(this.frmManteniment_Sectors_Load);
            this.Controls.SetChildIndex(this.textBox3, 0);
            this.Controls.SetChildIndex(this.swCodi1, 0);
            this.Controls.SetChildIndex(this.textBox4, 0);
            this.Controls.SetChildIndex(this.textBox5, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox3;
        private MisControles.SWCodi swCodi1;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
    }
}