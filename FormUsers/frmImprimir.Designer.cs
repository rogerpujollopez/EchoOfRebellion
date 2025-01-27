namespace FormUsers
{
    partial class frmImprimir
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.swBotons1 = new MisControles.SWBotons();
            this.swBotons2 = new MisControles.SWBotons();
            this.chkOpen = new System.Windows.Forms.CheckBox();
            this.swBotons3 = new MisControles.SWBotons();
            this.swBotons4 = new MisControles.SWBotons();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.ForeColor = System.Drawing.Color.Black;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(49, 180);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(700, 33);
            this.comboBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(44, 130);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(226, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Seleccionar impresora";
            // 
            // swBotons1
            // 
            this.swBotons1.BackColor = System.Drawing.Color.Black;
            this.swBotons1.DesactivarDragAndDrop = true;
            this.swBotons1.Formulari = null;
            this.swBotons1.Location = new System.Drawing.Point(33, 635);
            this.swBotons1.Name = "swBotons1";
            this.swBotons1.Size = new System.Drawing.Size(220, 69);
            this.swBotons1.TabIndex = 5;
            this.swBotons1.Texto = "Guardar PDF";
            this.swBotons1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.swBotons1_MouseClick);
            // 
            // swBotons2
            // 
            this.swBotons2.BackColor = System.Drawing.Color.Black;
            this.swBotons2.DesactivarDragAndDrop = true;
            this.swBotons2.Formulari = null;
            this.swBotons2.Location = new System.Drawing.Point(278, 241);
            this.swBotons2.Name = "swBotons2";
            this.swBotons2.Size = new System.Drawing.Size(220, 69);
            this.swBotons2.TabIndex = 6;
            this.swBotons2.Texto = "Imprimir";
            this.swBotons2.Click += new System.EventHandler(this.swBotons2_Click);
            // 
            // chkOpen
            // 
            this.chkOpen.AutoSize = true;
            this.chkOpen.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkOpen.ForeColor = System.Drawing.Color.White;
            this.chkOpen.Location = new System.Drawing.Point(54, 591);
            this.chkOpen.Name = "chkOpen";
            this.chkOpen.Size = new System.Drawing.Size(345, 29);
            this.chkOpen.TabIndex = 7;
            this.chkOpen.Text = "Abrir fichero después de guardar";
            this.chkOpen.UseVisualStyleBackColor = true;
            // 
            // swBotons3
            // 
            this.swBotons3.BackColor = System.Drawing.Color.Black;
            this.swBotons3.DesactivarDragAndDrop = true;
            this.swBotons3.Formulari = null;
            this.swBotons3.Location = new System.Drawing.Point(286, 635);
            this.swBotons3.Name = "swBotons3";
            this.swBotons3.Size = new System.Drawing.Size(220, 69);
            this.swBotons3.TabIndex = 8;
            this.swBotons3.Texto = "Guardar Word";
            this.swBotons3.MouseClick += new System.Windows.Forms.MouseEventHandler(this.swBotons3_MouseClick);
            // 
            // swBotons4
            // 
            this.swBotons4.BackColor = System.Drawing.Color.Black;
            this.swBotons4.DesactivarDragAndDrop = true;
            this.swBotons4.Formulari = null;
            this.swBotons4.Location = new System.Drawing.Point(538, 635);
            this.swBotons4.Name = "swBotons4";
            this.swBotons4.Size = new System.Drawing.Size(220, 69);
            this.swBotons4.TabIndex = 9;
            this.swBotons4.Texto = "Guardar Excel";
            this.swBotons4.MouseClick += new System.Windows.Forms.MouseEventHandler(this.swBotons4_MouseClick);
            // 
            // frmImprimir
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 753);
            this.Controls.Add(this.swBotons4);
            this.Controls.Add(this.swBotons3);
            this.Controls.Add(this.chkOpen);
            this.Controls.Add(this.swBotons2);
            this.Controls.Add(this.swBotons1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmImprimir";
            this.Text = "frmImprimir";
            this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            this.Load += new System.EventHandler(this.frmImprimir_Load);
            this.Controls.SetChildIndex(this.comboBox1, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.swBotons1, 0);
            this.Controls.SetChildIndex(this.swBotons2, 0);
            this.Controls.SetChildIndex(this.chkOpen, 0);
            this.Controls.SetChildIndex(this.swBotons3, 0);
            this.Controls.SetChildIndex(this.swBotons4, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private MisControles.SWBotons swBotons1;
        private MisControles.SWBotons swBotons2;
        private System.Windows.Forms.CheckBox chkOpen;
        private MisControles.SWBotons swBotons3;
        private MisControles.SWBotons swBotons4;
    }
}