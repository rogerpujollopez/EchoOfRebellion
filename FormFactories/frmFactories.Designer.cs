
namespace FormFactories
{
    partial class frmFactories
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtgFactories = new System.Windows.Forms.DataGridView();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnNou = new System.Windows.Forms.Button();
            this.txtIdFactory = new System.Windows.Forms.TextBox();
            this.txtCodeFactory = new System.Windows.Forms.TextBox();
            this.txtDescFactory = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgFactories)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.dtgFactories);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.groupBox1.Location = new System.Drawing.Point(12, 74);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(776, 169);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Grid";
            // 
            // dtgFactories
            // 
            this.dtgFactories.AllowUserToAddRows = false;
            this.dtgFactories.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgFactories.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dtgFactories.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgFactories.DefaultCellStyle = dataGridViewCellStyle5;
            this.dtgFactories.Location = new System.Drawing.Point(6, 19);
            this.dtgFactories.Name = "dtgFactories";
            this.dtgFactories.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgFactories.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dtgFactories.Size = new System.Drawing.Size(758, 138);
            this.dtgFactories.TabIndex = 0;
            // 
            // btnUpdate
            // 
            this.btnUpdate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnUpdate.Location = new System.Drawing.Point(573, 268);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(102, 26);
            this.btnUpdate.TabIndex = 2;
            this.btnUpdate.Text = "Actualitzar";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnNou
            // 
            this.btnNou.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnNou.Location = new System.Drawing.Point(459, 268);
            this.btnNou.Name = "btnNou";
            this.btnNou.Size = new System.Drawing.Size(102, 26);
            this.btnNou.TabIndex = 1;
            this.btnNou.Text = "Nou";
            this.btnNou.UseVisualStyleBackColor = true;
            this.btnNou.Click += new System.EventHandler(this.btnNou_Click);
            // 
            // txtIdFactory
            // 
            this.txtIdFactory.Enabled = false;
            this.txtIdFactory.Location = new System.Drawing.Point(110, 320);
            this.txtIdFactory.Name = "txtIdFactory";
            this.txtIdFactory.Size = new System.Drawing.Size(30, 20);
            this.txtIdFactory.TabIndex = 0;
            this.txtIdFactory.Tag = "idFactory";
            // 
            // txtCodeFactory
            // 
            this.txtCodeFactory.Location = new System.Drawing.Point(110, 348);
            this.txtCodeFactory.Name = "txtCodeFactory";
            this.txtCodeFactory.Size = new System.Drawing.Size(150, 20);
            this.txtCodeFactory.TabIndex = 1;
            this.txtCodeFactory.Tag = "codeFactory";
            // 
            // txtDescFactory
            // 
            this.txtDescFactory.Location = new System.Drawing.Point(110, 374);
            this.txtDescFactory.Name = "txtDescFactory";
            this.txtDescFactory.Size = new System.Drawing.Size(250, 20);
            this.txtDescFactory.TabIndex = 2;
            this.txtDescFactory.Tag = "DescFactory";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(34, 351);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Code Factory";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(34, 377);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Desc Factory";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(50, 323);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Id Factory";
            // 
            // frmFactories
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtDescFactory);
            this.Controls.Add(this.txtCodeFactory);
            this.Controls.Add(this.btnNou);
            this.Controls.Add(this.txtIdFactory);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmFactories";
            this.Text = "frmFactories";
            this.Load += new System.EventHandler(this.frmFactories_Load);
            this.Controls.SetChildIndex(this.txtIdFactory, 0);
            this.Controls.SetChildIndex(this.btnNou, 0);
            this.Controls.SetChildIndex(this.txtCodeFactory, 0);
            this.Controls.SetChildIndex(this.txtDescFactory, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.btnUpdate, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgFactories)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dtgFactories;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnNou;
        private System.Windows.Forms.TextBox txtIdFactory;
        private System.Windows.Forms.TextBox txtCodeFactory;
        private System.Windows.Forms.TextBox txtDescFactory;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}