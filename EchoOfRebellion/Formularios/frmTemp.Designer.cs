namespace EchoOfRebellion.Formularios
{
    partial class frmTemp
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
            this.buttonRoger = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnFactories = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonRoger
            // 
            this.buttonRoger.Location = new System.Drawing.Point(27, 19);
            this.buttonRoger.Name = "buttonRoger";
            this.buttonRoger.Size = new System.Drawing.Size(105, 47);
            this.buttonRoger.TabIndex = 9;
            this.buttonRoger.Text = "Crystal Roger";
            this.buttonRoger.UseVisualStyleBackColor = true;
            this.buttonRoger.Click += new System.EventHandler(this.buttonRoger_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(27, 73);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 47);
            this.button1.TabIndex = 10;
            this.button1.Text = "EDI";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnFactories
            // 
            this.btnFactories.Location = new System.Drawing.Point(27, 126);
            this.btnFactories.Name = "btnFactories";
            this.btnFactories.Size = new System.Drawing.Size(105, 47);
            this.btnFactories.TabIndex = 11;
            this.btnFactories.Text = "Factories";
            this.btnFactories.UseVisualStyleBackColor = true;
            this.btnFactories.Click += new System.EventHandler(this.btnFactories_Click);
            // 
            // frmTemp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnFactories);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonRoger);
            this.Name = "frmTemp";
            this.Text = "frmTemp";
            this.Load += new System.EventHandler(this.frmTemp_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonRoger;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnFactories;
    }
}