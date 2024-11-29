namespace MisControles
{
    partial class SWCodi
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
            this.txtcodi = new System.Windows.Forms.TextBox();
            this.txtLabel = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtcodi
            // 
            this.txtcodi.Location = new System.Drawing.Point(0, 0);
            this.txtcodi.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtcodi.Name = "txtcodi";
            this.txtcodi.Size = new System.Drawing.Size(96, 29);
            this.txtcodi.TabIndex = 0;
            this.txtcodi.Enter += new System.EventHandler(this.txtcodi_Enter);
            this.txtcodi.Leave += new System.EventHandler(this.txtcodi_Leave);
            // 
            // txtLabel
            // 
            this.txtLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.txtLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLabel.Location = new System.Drawing.Point(106, 0);
            this.txtLabel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtLabel.Name = "txtLabel";
            this.txtLabel.ReadOnly = true;
            this.txtLabel.Size = new System.Drawing.Size(514, 29);
            this.txtLabel.TabIndex = 1;
            this.txtLabel.Text = "XXX";
            this.txtLabel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtLabel_MouseClick);
            // 
            // SWCodi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtLabel);
            this.Controls.Add(this.txtcodi);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "SWCodi";
            this.Size = new System.Drawing.Size(627, 39);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtcodi;
        private System.Windows.Forms.TextBox txtLabel;
    }
}
