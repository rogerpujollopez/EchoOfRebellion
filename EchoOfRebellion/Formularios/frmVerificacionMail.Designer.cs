
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.BackColor = System.Drawing.Color.Transparent;
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.ForeColor = System.Drawing.Color.White;
            this.labelTitle.Location = new System.Drawing.Point(51, 26);
            this.labelTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(294, 31);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "Verificación por email";
            // 
            // labelTxtVerificacion
            // 
            this.labelTxtVerificacion.AutoSize = true;
            this.labelTxtVerificacion.BackColor = System.Drawing.Color.Transparent;
            this.labelTxtVerificacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTxtVerificacion.ForeColor = System.Drawing.Color.White;
            this.labelTxtVerificacion.Location = new System.Drawing.Point(36, 153);
            this.labelTxtVerificacion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTxtVerificacion.Name = "labelTxtVerificacion";
            this.labelTxtVerificacion.Size = new System.Drawing.Size(346, 60);
            this.labelTxtVerificacion.TabIndex = 1;
            this.labelTxtVerificacion.Text = "Hemos enviado un número de verifiación a tu\r\ncorreo.\r\nIntorduce el código en el r" +
    "ecuadro inferior.";
            this.labelTxtVerificacion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtCodeEmail
            // 
            this.txtCodeEmail.Location = new System.Drawing.Point(123, 230);
            this.txtCodeEmail.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtCodeEmail.Name = "txtCodeEmail";
            this.txtCodeEmail.Size = new System.Drawing.Size(184, 22);
            this.txtCodeEmail.TabIndex = 3;
            this.txtCodeEmail.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // bttnEnviarCodigo
            // 
            this.bttnEnviarCodigo.Location = new System.Drawing.Point(157, 276);
            this.bttnEnviarCodigo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bttnEnviarCodigo.Name = "bttnEnviarCodigo";
            this.bttnEnviarCodigo.Size = new System.Drawing.Size(116, 36);
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
            this.label1.Location = new System.Drawing.Point(84, 331);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(184, 17);
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
            this.labelReenviar.Location = new System.Drawing.Point(271, 331);
            this.labelReenviar.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelReenviar.Name = "labelReenviar";
            this.labelReenviar.Size = new System.Drawing.Size(73, 17);
            this.labelReenviar.TabIndex = 6;
            this.labelReenviar.Text = "Reenviar";
            this.labelReenviar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelReenviar.Click += new System.EventHandler(this.labelReenviar_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::EchoOfRebellion.Properties.Resources.email_image;
            this.pictureBox1.Location = new System.Drawing.Point(179, 72);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(66, 62);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // frmVerificacionMail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(449, 395);
            this.Controls.Add(this.labelReenviar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bttnEnviarCodigo);
            this.Controls.Add(this.txtCodeEmail);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.labelTxtVerificacion);
            this.Controls.Add(this.labelTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmVerificacionMail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmVerificacionMail";
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
    }
}