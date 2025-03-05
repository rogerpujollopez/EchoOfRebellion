namespace FormFKSpaceShips
{
    partial class frmMantenimentFKSpaceShips
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtBoxCodeType = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBoxDescType = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbBoxCategories = new System.Windows.Forms.ComboBox();
            this.bttnSave = new System.Windows.Forms.Button();
            this.bttnEdit = new System.Windows.Forms.Button();
            this.bttnDrop = new System.Windows.Forms.Button();
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // txtBoxCodeType
            // 
            this.txtBoxCodeType.Location = new System.Drawing.Point(255, 119);
            this.txtBoxCodeType.Margin = new System.Windows.Forms.Padding(4);
            this.txtBoxCodeType.Name = "txtBoxCodeType";
            this.txtBoxCodeType.Size = new System.Drawing.Size(132, 22);
            this.txtBoxCodeType.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(103, 123);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "CodeSpaceShipType";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(103, 169);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(138, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "DescSpaceShipType";
            // 
            // txtBoxDescType
            // 
            this.txtBoxDescType.Location = new System.Drawing.Point(255, 165);
            this.txtBoxDescType.Margin = new System.Windows.Forms.Padding(4);
            this.txtBoxDescType.Name = "txtBoxDescType";
            this.txtBoxDescType.Size = new System.Drawing.Size(132, 22);
            this.txtBoxDescType.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.Control;
            this.label4.Location = new System.Drawing.Point(103, 215);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "SpaceShipCategories";
            // 
            // cmbBoxCategories
            // 
            this.cmbBoxCategories.FormattingEnabled = true;
            this.cmbBoxCategories.Location = new System.Drawing.Point(255, 212);
            this.cmbBoxCategories.Margin = new System.Windows.Forms.Padding(4);
            this.cmbBoxCategories.Name = "cmbBoxCategories";
            this.cmbBoxCategories.Size = new System.Drawing.Size(160, 24);
            this.cmbBoxCategories.TabIndex = 7;
            // 
            // bttnSave
            // 
            this.bttnSave.Location = new System.Drawing.Point(628, 462);
            this.bttnSave.Margin = new System.Windows.Forms.Padding(4);
            this.bttnSave.Name = "bttnSave";
            this.bttnSave.Size = new System.Drawing.Size(100, 28);
            this.bttnSave.TabIndex = 8;
            this.bttnSave.Text = "Guardar";
            this.bttnSave.UseVisualStyleBackColor = true;
            this.bttnSave.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // bttnEdit
            // 
            this.bttnEdit.Location = new System.Drawing.Point(736, 462);
            this.bttnEdit.Margin = new System.Windows.Forms.Padding(4);
            this.bttnEdit.Name = "bttnEdit";
            this.bttnEdit.Size = new System.Drawing.Size(100, 28);
            this.bttnEdit.TabIndex = 9;
            this.bttnEdit.Text = "Edit";
            this.bttnEdit.UseVisualStyleBackColor = true;
            this.bttnEdit.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // bttnDrop
            // 
            this.bttnDrop.Location = new System.Drawing.Point(844, 462);
            this.bttnDrop.Margin = new System.Windows.Forms.Padding(4);
            this.bttnDrop.Name = "bttnDrop";
            this.bttnDrop.Size = new System.Drawing.Size(100, 28);
            this.bttnDrop.TabIndex = 10;
            this.bttnDrop.Text = "Borrar";
            this.bttnDrop.UseVisualStyleBackColor = true;
            this.bttnDrop.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // dgvDatos
            // 
            this.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatos.Location = new System.Drawing.Point(75, 270);
            this.dgvDatos.Margin = new System.Windows.Forms.Padding(4);
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.RowHeadersWidth = 51;
            this.dgvDatos.Size = new System.Drawing.Size(869, 185);
            this.dgvDatos.TabIndex = 11;
            this.dgvDatos.SelectionChanged += new System.EventHandler(this.dgvDatos_SelectionChanged);
            // 
            // frmMantenimentFKSpaceShips
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.dgvDatos);
            this.Controls.Add(this.bttnDrop);
            this.Controls.Add(this.bttnEdit);
            this.Controls.Add(this.bttnSave);
            this.Controls.Add(this.cmbBoxCategories);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtBoxDescType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBoxCodeType);
            this.Location = new System.Drawing.Point(0, 0);
            this.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.Name = "frmMantenimentFKSpaceShips";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            this.Load += new System.EventHandler(this.frmMantenimentFKSpaceShips_Load);
            this.Controls.SetChildIndex(this.txtBoxCodeType, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txtBoxDescType, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.cmbBoxCategories, 0);
            this.Controls.SetChildIndex(this.bttnSave, 0);
            this.Controls.SetChildIndex(this.bttnEdit, 0);
            this.Controls.SetChildIndex(this.bttnDrop, 0);
            this.Controls.SetChildIndex(this.dgvDatos, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBoxCodeType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBoxDescType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbBoxCategories;
        private System.Windows.Forms.Button bttnSave;
        private System.Windows.Forms.Button bttnEdit;
        private System.Windows.Forms.Button bttnDrop;
        private System.Windows.Forms.DataGridView dgvDatos;
    }
}

