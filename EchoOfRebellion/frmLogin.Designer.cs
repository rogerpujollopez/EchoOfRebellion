using System.Drawing;

namespace EchoOfRebellion
{
    partial class frmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.lblExit = new System.Windows.Forms.Label();
            this.lblSubmit = new System.Windows.Forms.Label();
            this.led1 = new System.Windows.Forms.PictureBox();
            this.led2 = new System.Windows.Forms.PictureBox();
            this.swCuentaAtras1 = new MisControles.SWCuentaAtras();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.led1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.led2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(530, 437);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // txtUsuario
            // 
            this.txtUsuario.BackColor = System.Drawing.Color.White;
            this.txtUsuario.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUsuario.Font = new System.Drawing.Font("Agency FB", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuario.Location = new System.Drawing.Point(196, 162);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(248, 35);
            this.txtUsuario.TabIndex = 1;
            this.txtUsuario.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Press_KeyDown);
            // 
            // txtPass
            // 
            this.txtPass.BackColor = System.Drawing.Color.White;
            this.txtPass.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPass.Font = new System.Drawing.Font("Agency FB", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPass.Location = new System.Drawing.Point(196, 223);
            this.txtPass.Name = "txtPass";
            this.txtPass.PasswordChar = '#';
            this.txtPass.Size = new System.Drawing.Size(248, 35);
            this.txtPass.TabIndex = 2;
            this.txtPass.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Press_KeyDown);
            // 
            // lblExit
            // 
            this.lblExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(17)))), ((int)(((byte)(67)))));
            this.lblExit.Font = new System.Drawing.Font("Agency FB", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExit.ForeColor = System.Drawing.Color.White;
            this.lblExit.Location = new System.Drawing.Point(117, 330);
            this.lblExit.Name = "lblExit";
            this.lblExit.Size = new System.Drawing.Size(131, 30);
            this.lblExit.TabIndex = 3;
            this.lblExit.Text = "Exit";
            this.lblExit.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblExit.Click += new System.EventHandler(this.lblExit_Click);
            // 
            // lblSubmit
            // 
            this.lblSubmit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(17)))), ((int)(((byte)(67)))));
            this.lblSubmit.Font = new System.Drawing.Font("Agency FB", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubmit.ForeColor = System.Drawing.Color.White;
            this.lblSubmit.Location = new System.Drawing.Point(283, 330);
            this.lblSubmit.Name = "lblSubmit";
            this.lblSubmit.Size = new System.Drawing.Size(131, 30);
            this.lblSubmit.TabIndex = 4;
            this.lblSubmit.Text = "Submit";
            this.lblSubmit.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblSubmit.Click += new System.EventHandler(this.lblSubmit_Click);
            // 
            // led1
            // 
            this.led1.Image = global::EchoOfRebellion.Properties.Resources.LedsRojo_Flojo;
            this.led1.Location = new System.Drawing.Point(6, 351);
            this.led1.Name = "led1";
            this.led1.Size = new System.Drawing.Size(58, 58);
            this.led1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.led1.TabIndex = 6;
            this.led1.TabStop = false;
            this.led1.Tag = "led";
            this.led1.Visible = false;
            // 
            // led2
            // 
            this.led2.Image = global::EchoOfRebellion.Properties.Resources.LedsRojo_Flojo;
            this.led2.Location = new System.Drawing.Point(468, 351);
            this.led2.Name = "led2";
            this.led2.Size = new System.Drawing.Size(58, 58);
            this.led2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.led2.TabIndex = 7;
            this.led2.TabStop = false;
            this.led2.Tag = "led";
            this.led2.Visible = false;
            // 
            // swCuentaAtras1
            // 
            this.swCuentaAtras1.Activado = false;
            this.swCuentaAtras1.BackColor = System.Drawing.Color.Black;
            this.swCuentaAtras1.Location = new System.Drawing.Point(53, 0);
            this.swCuentaAtras1.Margin = new System.Windows.Forms.Padding(2);
            this.swCuentaAtras1.Name = "swCuentaAtras1";
            this.swCuentaAtras1.Segundos = 0;
            this.swCuentaAtras1.Size = new System.Drawing.Size(92, 49);
            this.swCuentaAtras1.TabIndex = 5;
            this.swCuentaAtras1.TabStop = false;
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 435);
            this.Controls.Add(this.led2);
            this.Controls.Add(this.led1);
            this.Controls.Add(this.swCuentaAtras1);
            this.Controls.Add(this.lblSubmit);
            this.Controls.Add(this.lblExit);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.led1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.led2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.Label lblExit;
        private System.Windows.Forms.Label lblSubmit;
        private MisControles.SWCuentaAtras swCuentaAtras1;
        private System.Windows.Forms.PictureBox led1;
        private System.Windows.Forms.PictureBox led2;
    }
}

