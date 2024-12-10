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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.swCodi1 = new MisControles.SWCodi();
            this.swCodi2 = new MisControles.SWCodi();
            this.swCodi3 = new MisControles.SWCodi();
            this.swCodi4 = new MisControles.SWCodi();
            this.textBox5 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(96, 13);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(124, 20);
            this.textBox1.TabIndex = 0;
            this.textBox1.Tag = "CodeUser";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(96, 39);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(124, 20);
            this.textBox2.TabIndex = 1;
            this.textBox2.Tag = "UserName";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(96, 65);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(124, 20);
            this.textBox3.TabIndex = 2;
            this.textBox3.Tag = "Login";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(96, 91);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(124, 20);
            this.textBox4.TabIndex = 3;
            this.textBox4.Tag = "Mail";
            // 
            // pictureBox1
            // 
            //this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(285, 20);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(113, 118);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Tag = "Photo";
            // 
            // swCodi1
            // 
            this.swCodi1.Location = new System.Drawing.Point(96, 155);
            this.swCodi1.Margin = new System.Windows.Forms.Padding(2);
            this.swCodi1.Name = "swCodi1";
            this.swCodi1.Origen = null;
            this.swCodi1.Size = new System.Drawing.Size(342, 21);
            this.swCodi1.TabIndex = 5;
            this.swCodi1.Tag = "idUserRank";
            this.swCodi1.Tag2 = "";
            this.swCodi1.Tag3 = "DescRank";
            this.swCodi1.ViewDataColumns = new List<int> { 2, 1 };
            this.swCodi1.TextDesc = "XXX";
            this.swCodi1.TextId = "";
            this.swCodi1.TextValue = "";
            // 
            // swCodi2
            // 
            this.swCodi2.Location = new System.Drawing.Point(96, 180);
            this.swCodi2.Margin = new System.Windows.Forms.Padding(2);
            this.swCodi2.Name = "swCodi2";
            this.swCodi2.Origen = null;
            this.swCodi2.Size = new System.Drawing.Size(342, 21);
            this.swCodi2.TabIndex = 6;
            this.swCodi2.Tag = "idUserCategory";
            this.swCodi2.Tag2 = "DescCategory";
            this.swCodi2.Tag3 = "";
            this.swCodi2.ViewDataColumns = new List<int> { 2, 1, 3 };
            this.swCodi2.TextDesc = "XXX";
            this.swCodi2.TextId = "";
            this.swCodi2.TextValue = "";
            // 
            // swCodi3
            // 
            this.swCodi3.Location = new System.Drawing.Point(96, 205);
            this.swCodi3.Margin = new System.Windows.Forms.Padding(2);
            this.swCodi3.Name = "swCodi3";
            this.swCodi3.Origen = null;
            this.swCodi3.Size = new System.Drawing.Size(342, 21);
            this.swCodi3.TabIndex = 7;
            this.swCodi3.Tag = "idPlanet";
            this.swCodi3.Tag2 = "";
            this.swCodi3.Tag3 = "";
            this.swCodi3.ViewDataColumns = new List<int> { 2, 1 };
            this.swCodi3.TextDesc = "XXX";
            this.swCodi3.TextId = "";
            this.swCodi3.TextValue = "";
            // 
            // swCodi4
            // 
            this.swCodi4.Location = new System.Drawing.Point(96, 230);
            this.swCodi4.Margin = new System.Windows.Forms.Padding(2);
            this.swCodi4.Name = "swCodi4";
            this.swCodi4.Origen = null;
            this.swCodi4.Size = new System.Drawing.Size(342, 21);
            this.swCodi4.TabIndex = 8;
            this.swCodi4.Tag = "idSpecie";
            this.swCodi4.Tag2 = "";
            this.swCodi4.Tag3 = "";
            this.swCodi4.ViewDataColumns = new List<int> { 2, 1 };
            this.swCodi4.TextDesc = "XXX";
            this.swCodi4.TextId = "";
            this.swCodi4.TextValue = "";
            // 
            // textBox5
            // 
            this.textBox5.Enabled = false;
            this.textBox5.Location = new System.Drawing.Point(0, -1);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(35, 20);
            this.textBox5.TabIndex = 9;
            this.textBox5.Tag = "idUser";
            // 
            // frmManteniment_Users
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 554);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.swCodi4);
            this.Controls.Add(this.swCodi3);
            this.Controls.Add(this.swCodi2);
            this.Controls.Add(this.swCodi1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmManteniment_Users";
            this.Text = "frmManteniment_Users";
            this.Load += new System.EventHandler(this.frmManteniment_Users_Load);
            this.Controls.SetChildIndex(this.textBox1, 0);
            this.Controls.SetChildIndex(this.textBox2, 0);
            this.Controls.SetChildIndex(this.textBox3, 0);
            this.Controls.SetChildIndex(this.textBox4, 0);
            this.Controls.SetChildIndex(this.pictureBox1, 0);
            this.Controls.SetChildIndex(this.swCodi1, 0);
            this.Controls.SetChildIndex(this.swCodi2, 0);
            this.Controls.SetChildIndex(this.swCodi3, 0);
            this.Controls.SetChildIndex(this.swCodi4, 0);
            this.Controls.SetChildIndex(this.textBox5, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private MisControles.SWCodi swCodi1;
        private MisControles.SWCodi swCodi2;
        private MisControles.SWCodi swCodi3;
        private MisControles.SWCodi swCodi4;
        private System.Windows.Forms.TextBox textBox5;
    }
}

