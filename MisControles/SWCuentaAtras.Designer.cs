namespace MisControles
{
    partial class SWCuentaAtras
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbltiempo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbltiempo
            // 
            this.lbltiempo.Font = new System.Drawing.Font("Agency FB", 27.85714F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltiempo.ForeColor = System.Drawing.Color.Red;
            this.lbltiempo.Location = new System.Drawing.Point(0, 0);
            this.lbltiempo.Margin = new System.Windows.Forms.Padding(0);
            this.lbltiempo.Name = "lbltiempo";
            this.lbltiempo.Size = new System.Drawing.Size(91, 46);
            this.lbltiempo.TabIndex = 0;
            this.lbltiempo.Text = "00:00";
            // 
            // SWCuentaAtras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.lbltiempo);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "SWCuentaAtras";
            this.Size = new System.Drawing.Size(91, 46);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbltiempo;
    }
}
