
namespace FormFactories
{
    partial class frmManteniment_Factories
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtgFactories = new System.Windows.Forms.DataGridView();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnNou = new System.Windows.Forms.Button();
            this.txtIdFactory = new System.Windows.Forms.TextBox();
            this.txtCodeFactory = new System.Windows.Forms.TextBox();
            this.txtDescFactory = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgFactories)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.dtgFactories);
            this.groupBox1.Controls.Add(this.txtIdFactory);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.groupBox1.Location = new System.Drawing.Point(16, 91);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(1035, 208);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Grid";
            // 
            // dtgFactories
            // 
            this.dtgFactories.AllowUserToAddRows = false;
            this.dtgFactories.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgFactories.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dtgFactories.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgFactories.DefaultCellStyle = dataGridViewCellStyle8;
            this.dtgFactories.Location = new System.Drawing.Point(8, 23);
            this.dtgFactories.Margin = new System.Windows.Forms.Padding(4);
            this.dtgFactories.Name = "dtgFactories";
            this.dtgFactories.ReadOnly = true;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgFactories.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dtgFactories.RowHeadersWidth = 51;
            this.dtgFactories.Size = new System.Drawing.Size(1011, 170);
            this.dtgFactories.TabIndex = 0;
            // 
            // btnUpdate
            // 
            this.btnUpdate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnUpdate.Location = new System.Drawing.Point(764, 330);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(4);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(136, 32);
            this.btnUpdate.TabIndex = 2;
            this.btnUpdate.Text = "Actualitzar";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnNou
            // 
            this.btnNou.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnNou.Location = new System.Drawing.Point(612, 330);
            this.btnNou.Margin = new System.Windows.Forms.Padding(4);
            this.btnNou.Name = "btnNou";
            this.btnNou.Size = new System.Drawing.Size(136, 32);
            this.btnNou.TabIndex = 1;
            this.btnNou.Text = "Nou";
            this.btnNou.UseVisualStyleBackColor = true;
            this.btnNou.Click += new System.EventHandler(this.btnNou_Click);
            // 
            // txtIdFactory
            // 
            this.txtIdFactory.Enabled = false;
            this.txtIdFactory.Location = new System.Drawing.Point(131, 152);
            this.txtIdFactory.Margin = new System.Windows.Forms.Padding(4);
            this.txtIdFactory.Name = "txtIdFactory";
            this.txtIdFactory.Size = new System.Drawing.Size(39, 22);
            this.txtIdFactory.TabIndex = 0;
            this.txtIdFactory.Tag = "idFactory";
            // 
            // txtCodeFactory
            // 
            this.txtCodeFactory.Location = new System.Drawing.Point(147, 428);
            this.txtCodeFactory.Margin = new System.Windows.Forms.Padding(4);
            this.txtCodeFactory.Name = "txtCodeFactory";
            this.txtCodeFactory.Size = new System.Drawing.Size(199, 22);
            this.txtCodeFactory.TabIndex = 1;
            this.txtCodeFactory.Tag = "codeFactory";
            // 
            // txtDescFactory
            // 
            this.txtDescFactory.Location = new System.Drawing.Point(147, 460);
            this.txtDescFactory.Margin = new System.Windows.Forms.Padding(4);
            this.txtDescFactory.Name = "txtDescFactory";
            this.txtDescFactory.Size = new System.Drawing.Size(332, 22);
            this.txtDescFactory.TabIndex = 2;
            this.txtDescFactory.Tag = "DescFactory";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(45, 432);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Code Factory";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(45, 464);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Desc Factory";
            // 
            // frmManteniment_Factories
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtDescFactory);
            this.Controls.Add(this.txtCodeFactory);
            this.Controls.Add(this.btnNou);
            this.Location = new System.Drawing.Point(0, 0);
            this.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.Name = "frmManteniment_Factories";
            this.Text = "frmFactories";
            this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            this.Load += new System.EventHandler(this.frmFactories_Load);
            this.Controls.SetChildIndex(this.btnNou, 0);
            this.Controls.SetChildIndex(this.txtCodeFactory, 0);
            this.Controls.SetChildIndex(this.txtDescFactory, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.btnUpdate, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
    }
}