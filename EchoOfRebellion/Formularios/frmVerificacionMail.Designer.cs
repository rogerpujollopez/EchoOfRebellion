
namespace EchoOfRebellion.Formularios
{
    partial class frmVerificacionMail
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
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelTxtVerificacion = new System.Windows.Forms.Label();
            this.txtCodeEmail = new System.Windows.Forms.TextBox();
            this.bttnEnviarCodigo = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.labelReenviar = new System.Windows.Forms.Label();
            this.panelSuccess = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.imgArrow = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.bttnAceptar = new System.Windows.Forms.Button();
            this.panelSuccess.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgArrow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.BackColor = System.Drawing.Color.Transparent;
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.ForeColor = System.Drawing.Color.White;
            this.labelTitle.Location = new System.Drawing.Point(44, 21);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(240, 25);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "Verificación por email";
            // 
            // labelTxtVerificacion
            // 
            this.labelTxtVerificacion.AutoSize = true;
            this.labelTxtVerificacion.BackColor = System.Drawing.Color.Transparent;
            this.labelTxtVerificacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTxtVerificacion.ForeColor = System.Drawing.Color.White;
            this.labelTxtVerificacion.Location = new System.Drawing.Point(27, 124);
            this.labelTxtVerificacion.Name = "labelTxtVerificacion";
            this.labelTxtVerificacion.Size = new System.Drawing.Size(276, 48);
            this.labelTxtVerificacion.TabIndex = 1;
            this.labelTxtVerificacion.Text = "Hemos enviado un número de verifiación a tu\r\ncorreo.\r\nIntorduce el código en el r" +
    "ecuadro inferior.";
            this.labelTxtVerificacion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtCodeEmail
            // 
            this.txtCodeEmail.Location = new System.Drawing.Point(92, 187);
            this.txtCodeEmail.Name = "txtCodeEmail";
            this.txtCodeEmail.Size = new System.Drawing.Size(139, 20);
            this.txtCodeEmail.TabIndex = 3;
            this.txtCodeEmail.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // bttnEnviarCodigo
            // 
            this.bttnEnviarCodigo.Location = new System.Drawing.Point(118, 224);
            this.bttnEnviarCodigo.Name = "bttnEnviarCodigo";
            this.bttnEnviarCodigo.Size = new System.Drawing.Size(87, 29);
            this.bttnEnviarCodigo.TabIndex = 4;
            this.bttnEnviarCodigo.Text = "Enviar código";
            this.bttnEnviarCodigo.UseVisualStyleBackColor = true;
            this.bttnEnviarCodigo.Click += new System.EventHandler(this.bttnEnviarCodigo_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(63, 269);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "¿No has recibido el código?";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelReenviar
            // 
            this.labelReenviar.AutoSize = true;
            this.labelReenviar.BackColor = System.Drawing.Color.Transparent;
            this.labelReenviar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelReenviar.ForeColor = System.Drawing.Color.Blue;
            this.labelReenviar.Location = new System.Drawing.Point(203, 269);
            this.labelReenviar.Name = "labelReenviar";
            this.labelReenviar.Size = new System.Drawing.Size(58, 13);
            this.labelReenviar.TabIndex = 6;
            this.labelReenviar.Text = "Reenviar";
            this.labelReenviar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelReenviar.Click += new System.EventHandler(this.labelReenviar_Click);
            // 
            // panelSuccess
            // 
            this.panelSuccess.Controls.Add(this.bttnAceptar);
            this.panelSuccess.Controls.Add(this.pictureBox2);
            this.panelSuccess.Controls.Add(this.label2);
            this.panelSuccess.Location = new System.Drawing.Point(66, 66);
            this.panelSuccess.Name = "panelSuccess";
            this.panelSuccess.Size = new System.Drawing.Size(203, 187);
            this.panelSuccess.TabIndex = 9;
            this.panelSuccess.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(34, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 48);
            this.label2.TabIndex = 0;
            this.label2.Text = "¡Enhorabuena! \r\nSe ha actualizado \r\nsu contraseña";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::EchoOfRebellion.Properties.Resources.reset_password_icon;
            this.pictureBox2.Location = new System.Drawing.Point(75, 70);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(51, 63);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // imgArrow
            // 
            this.imgArrow.Image = global::EchoOfRebellion.Properties.Resources.arrow_icon;
            this.imgArrow.Location = new System.Drawing.Point(6, 5);
            this.imgArrow.Name = "imgArrow";
            this.imgArrow.Size = new System.Drawing.Size(28, 26);
            this.imgArrow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgArrow.TabIndex = 8;
            this.imgArrow.TabStop = false;
            this.imgArrow.Click += new System.EventHandler(this.imgArrow_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::EchoOfRebellion.Properties.Resources.email_image;
            this.pictureBox1.Location = new System.Drawing.Point(134, 54);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(68, 63);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // bttnAceptar
            // 
            this.bttnAceptar.Location = new System.Drawing.Point(64, 147);
            this.bttnAceptar.Name = "bttnAceptar";
            this.bttnAceptar.Size = new System.Drawing.Size(75, 23);
            this.bttnAceptar.TabIndex = 2;
            this.bttnAceptar.Text = "Aceptar";
            this.bttnAceptar.UseVisualStyleBackColor = true;
            this.bttnAceptar.Click += new System.EventHandler(this.bttnAceptar_Click);
            // 
            // frmVerificacionMail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(337, 321);
            this.Controls.Add(this.panelSuccess);
            this.Controls.Add(this.imgArrow);
            this.Controls.Add(this.labelReenviar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bttnEnviarCodigo);
            this.Controls.Add(this.txtCodeEmail);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.labelTxtVerificacion);
            this.Controls.Add(this.labelTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmVerificacionMail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmVerificacionMail";
            this.panelSuccess.ResumeLayout(false);
            this.panelSuccess.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgArrow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelTxtVerificacion;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtCodeEmail;
        private System.Windows.Forms.Button bttnEnviarCodigo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelReenviar;
        private System.Windows.Forms.PictureBox imgArrow;
        private System.Windows.Forms.Panel panelSuccess;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bttnAceptar;
    }
}