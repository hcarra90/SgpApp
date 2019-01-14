namespace Layer.Win.Shipping
{
    partial class FrmCaja
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCaja));
            this.btnPrint = new System.Windows.Forms.Button();
            this.cboShipTo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dataCajasNuevas = new System.Windows.Forms.DataGridView();
            this.ctxCajaMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.imprimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.nuevaCaja = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CajaId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataCajasNuevas)).BeginInit();
            this.ctxCajaMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPrint
            // 
            this.btnPrint.FlatAppearance.BorderSize = 0;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Image = global::Layer.Win.Properties.Resources.impresora_24;
            this.btnPrint.Location = new System.Drawing.Point(187, 38);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(43, 36);
            this.btnPrint.TabIndex = 17;
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // cboShipTo
            // 
            this.cboShipTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboShipTo.FormattingEnabled = true;
            this.cboShipTo.Location = new System.Drawing.Point(52, 46);
            this.cboShipTo.Name = "cboShipTo";
            this.cboShipTo.Size = new System.Drawing.Size(121, 22);
            this.cboShipTo.TabIndex = 16;
            this.cboShipTo.SelectedIndexChanged += new System.EventHandler(this.cboShipTo_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(0, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 14);
            this.label3.TabIndex = 15;
            this.label3.Text = "SHIP TO";
            // 
            // dataCajasNuevas
            // 
            this.dataCajasNuevas.AllowUserToAddRows = false;
            this.dataCajasNuevas.AllowUserToDeleteRows = false;
            this.dataCajasNuevas.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(176)))), ((int)(((byte)(62)))));
            this.dataCajasNuevas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataCajasNuevas.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataCajasNuevas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(176)))), ((int)(((byte)(62)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Calibri", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataCajasNuevas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataCajasNuevas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataCajasNuevas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nuevaCaja,
            this.CajaId});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(176)))), ((int)(((byte)(62)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Calibri", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataCajasNuevas.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataCajasNuevas.EnableHeadersVisualStyles = false;
            this.dataCajasNuevas.Location = new System.Drawing.Point(3, 79);
            this.dataCajasNuevas.Name = "dataCajasNuevas";
            this.dataCajasNuevas.ReadOnly = true;
            this.dataCajasNuevas.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(176)))), ((int)(((byte)(62)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Calibri", 9F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataCajasNuevas.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataCajasNuevas.RowHeadersVisible = false;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(176)))), ((int)(((byte)(62)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            this.dataCajasNuevas.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dataCajasNuevas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataCajasNuevas.Size = new System.Drawing.Size(251, 346);
            this.dataCajasNuevas.TabIndex = 18;
            this.dataCajasNuevas.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataCajasNuevas_MouseClick);
            // 
            // ctxCajaMenu
            // 
            this.ctxCajaMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.imprimeToolStripMenuItem});
            this.ctxCajaMenu.Name = "contextMenu";
            this.ctxCajaMenu.Size = new System.Drawing.Size(167, 26);
            // 
            // imprimeToolStripMenuItem
            // 
            this.imprimeToolStripMenuItem.Name = "imprimeToolStripMenuItem";
            this.imprimeToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.imprimeToolStripMenuItem.Text = "Imprimir Etiqueta";
            this.imprimeToolStripMenuItem.Click += new System.EventHandler(this.imprimeToolStripMenuItem_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Layer.Win.Properties.Resources.packing;
            this.pictureBox2.Location = new System.Drawing.Point(3, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(29, 31);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 19;
            this.pictureBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Franklin Gothic Medium", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(38, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 24);
            this.label1.TabIndex = 20;
            this.label1.Text = "Creación Caja";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Layer.Win.Properties.Resources.if_icon_close_round_211651;
            this.pictureBox1.Location = new System.Drawing.Point(240, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(15, 15);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 21;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // nuevaCaja
            // 
            this.nuevaCaja.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.nuevaCaja.DataPropertyName = "nuevaCaja";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(176)))), ((int)(((byte)(62)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            this.nuevaCaja.DefaultCellStyle = dataGridViewCellStyle2;
            this.nuevaCaja.HeaderText = "CAJA";
            this.nuevaCaja.Name = "nuevaCaja";
            this.nuevaCaja.ReadOnly = true;
            this.nuevaCaja.Width = 220;
            // 
            // CajaId
            // 
            this.CajaId.DataPropertyName = "Id";
            this.CajaId.HeaderText = "CajaId";
            this.CajaId.Name = "CajaId";
            this.CajaId.ReadOnly = true;
            this.CajaId.Visible = false;
            this.CajaId.Width = 120;
            // 
            // FrmCaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(176)))), ((int)(((byte)(62)))));
            this.ClientSize = new System.Drawing.Size(258, 437);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.dataCajasNuevas);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.cboShipTo);
            this.Controls.Add(this.label3);
            this.Font = new System.Drawing.Font("Calibri", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCaja";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Caja";
            this.Load += new System.EventHandler(this.FrmCaja_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FrmCaja_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.dataCajasNuevas)).EndInit();
            this.ctxCajaMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.ComboBox cboShipTo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataCajasNuevas;
        private System.Windows.Forms.ContextMenuStrip ctxCajaMenu;
        private System.Windows.Forms.ToolStripMenuItem imprimeToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn nuevaCaja;
        private System.Windows.Forms.DataGridViewTextBoxColumn CajaId;
    }
}