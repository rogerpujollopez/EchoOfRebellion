namespace MisControles
{
    partial class SWLabelWithTimer
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
            this.components = new System.ComponentModel.Container();
            this.lbltext = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // lbltext
            // 
            this.lbltext.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbltext.Location = new System.Drawing.Point(3, 3);
            this.lbltext.Name = "lbltext";
            this.lbltext.Size = new System.Drawing.Size(100, 15);
            this.lbltext.TabIndex = 0;
            this.lbltext.Text = "demo";
            // 
            // SWLabelWithTimer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbltext);
            this.Name = "SWLabelWithTimer";
            this.Size = new System.Drawing.Size(109, 22);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbltext;
        private System.Windows.Forms.Timer timer1;
    }
}
