namespace Layer.Win.Shipping
{
    partial class FrmEnvioCaja
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEnvioCaja));
            this.label1 = new System.Windows.Forms.Label();
            this.dataBox = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Box = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PesoNeto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PesoBruto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pallet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Peso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bulto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PesoBulto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNeto = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBruto = new System.Windows.Forms.TextBox();
            this.lblShipmentCode = new System.Windows.Forms.Label();
            this.ctxCajaMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.borrarCajaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label5 = new System.Windows.Forms.Label();
            this.cboShipment = new System.Windows.Forms.ComboBox();
            this.pnlEmail = new System.Windows.Forms.Panel();
            this.cboPallet = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtPesoBulto = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtPesoPallet = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtPallet = new System.Windows.Forms.TextBox();
            this.lblTotalKilosBruto = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblTotalKilosNeto = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnGrabar = new System.Windows.Forms.Button();
            this.cboBulto = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataBox)).BeginInit();
            this.ctxCajaMenu.SuspendLayout();
            this.pnlEmail.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(1, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "Shipment";
            // 
            // dataBox
            // 
            this.dataBox.AllowUserToAddRows = false;
            this.dataBox.AllowUserToDeleteRows = false;
            this.dataBox.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(237)))), ((int)(((byte)(237)))));
            this.dataBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataBox.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataBox.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(145)))), ((int)(((byte)(45)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Calibri", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataBox.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataBox.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataBox.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Box,
            this.PesoNeto,
            this.PesoBruto,
            this.Pallet,
            this.Peso,
            this.Bulto,
            this.PesoBulto});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(176)))), ((int)(((byte)(62)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Calibri", 9F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataBox.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataBox.EnableHeadersVisualStyles = false;
            this.dataBox.Location = new System.Drawing.Point(3, 199);
            this.dataBox.Name = "dataBox";
            this.dataBox.ReadOnly = true;
            this.dataBox.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(176)))), ((int)(((byte)(62)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Calibri", 9F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataBox.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataBox.RowHeadersVisible = false;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(176)))), ((int)(((byte)(62)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            this.dataBox.RowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dataBox.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataBox.Size = new System.Drawing.Size(704, 246);
            this.dataBox.TabIndex = 9;
            this.dataBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataBox_MouseClick);
            // 
            // Id
            // 
            this.Id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Id.DataPropertyName = "IdMovimiento";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            // 
            // Box
            // 
            this.Box.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Box.DataPropertyName = "cajaEnvio";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(176)))), ((int)(((byte)(62)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            this.Box.DefaultCellStyle = dataGridViewCellStyle2;
            this.Box.HeaderText = "Box";
            this.Box.Name = "Box";
            this.Box.ReadOnly = true;
            // 
            // PesoNeto
            // 
            this.PesoNeto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.PesoNeto.DataPropertyName = "pesoNeto";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(176)))), ((int)(((byte)(62)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            this.PesoNeto.DefaultCellStyle = dataGridViewCellStyle3;
            this.PesoNeto.HeaderText = "Peso Neto";
            this.PesoNeto.Name = "PesoNeto";
            this.PesoNeto.ReadOnly = true;
            // 
            // PesoBruto
            // 
            this.PesoBruto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.PesoBruto.DataPropertyName = "pesoBruto";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(176)))), ((int)(((byte)(62)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            this.PesoBruto.DefaultCellStyle = dataGridViewCellStyle4;
            this.PesoBruto.HeaderText = "Peso Bruto";
            this.PesoBruto.Name = "PesoBruto";
            this.PesoBruto.ReadOnly = true;
            // 
            // Pallet
            // 
            this.Pallet.DataPropertyName = "palletEnvio";
            this.Pallet.HeaderText = "Pallet";
            this.Pallet.Name = "Pallet";
            this.Pallet.ReadOnly = true;
            // 
            // Peso
            // 
            this.Peso.DataPropertyName = "pesoPallet";
            this.Peso.HeaderText = "Peso";
            this.Peso.Name = "Peso";
            this.Peso.ReadOnly = true;
            // 
            // Bulto
            // 
            this.Bulto.DataPropertyName = "bultoEnvio";
            this.Bulto.HeaderText = "Bulto";
            this.Bulto.Name = "Bulto";
            this.Bulto.ReadOnly = true;
            // 
            // PesoBulto
            // 
            this.PesoBulto.DataPropertyName = "pesoBulto";
            this.PesoBulto.HeaderText = "Peso";
            this.PesoBulto.Name = "PesoBulto";
            this.PesoBulto.ReadOnly = true;
            // 
            // txtBox
            // 
            this.txtBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBox.Location = new System.Drawing.Point(39, 3);
            this.txtBox.Name = "txtBox";
            this.txtBox.Size = new System.Drawing.Size(100, 22);
            this.txtBox.TabIndex = 3;
            this.txtBox.TextChanged += new System.EventHandler(this.txtBox_TextChanged);
            this.txtBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBox_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(4, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 14);
            this.label2.TabIndex = 12;
            this.label2.Text = "BOX";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(162, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 14);
            this.label3.TabIndex = 14;
            this.label3.Text = "Peso Neto";
            // 
            // txtNeto
            // 
            this.txtNeto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNeto.Enabled = false;
            this.txtNeto.Location = new System.Drawing.Point(225, 3);
            this.txtNeto.Name = "txtNeto";
            this.txtNeto.Size = new System.Drawing.Size(57, 22);
            this.txtNeto.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(162, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 14);
            this.label4.TabIndex = 16;
            this.label4.Text = "Peso Bruto";
            // 
            // txtBruto
            // 
            this.txtBruto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBruto.Location = new System.Drawing.Point(225, 31);
            this.txtBruto.Name = "txtBruto";
            this.txtBruto.Size = new System.Drawing.Size(57, 22);
            this.txtBruto.TabIndex = 4;
            this.txtBruto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBruto_KeyPress);
            // 
            // lblShipmentCode
            // 
            this.lblShipmentCode.AutoSize = true;
            this.lblShipmentCode.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.lblShipmentCode.Location = new System.Drawing.Point(309, 46);
            this.lblShipmentCode.Name = "lblShipmentCode";
            this.lblShipmentCode.Size = new System.Drawing.Size(13, 19);
            this.lblShipmentCode.TabIndex = 18;
            this.lblShipmentCode.Text = ".";
            this.lblShipmentCode.Visible = false;
            // 
            // ctxCajaMenu
            // 
            this.ctxCajaMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.borrarCajaToolStripMenuItem});
            this.ctxCajaMenu.Name = "contextMenu";
            this.ctxCajaMenu.Size = new System.Drawing.Size(118, 26);
            // 
            // borrarCajaToolStripMenuItem
            // 
            this.borrarCajaToolStripMenuItem.Name = "borrarCajaToolStripMenuItem";
            this.borrarCajaToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.borrarCajaToolStripMenuItem.Text = "Eliminar";
            this.borrarCajaToolStripMenuItem.Click += new System.EventHandler(this.borrarCajaToolStripMenuItem_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Franklin Gothic Medium", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(38, 5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 24);
            this.label5.TabIndex = 29;
            this.label5.Text = "Envío Caja";
            // 
            // cboShipment
            // 
            this.cboShipment.BackColor = System.Drawing.Color.White;
            this.cboShipment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboShipment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboShipment.FormattingEnabled = true;
            this.cboShipment.Location = new System.Drawing.Point(61, 41);
            this.cboShipment.Name = "cboShipment";
            this.cboShipment.Size = new System.Drawing.Size(122, 22);
            this.cboShipment.TabIndex = 0;
            this.cboShipment.SelectedValueChanged += new System.EventHandler(this.cboShipment_SelectedValueChanged);
            // 
            // pnlEmail
            // 
            this.pnlEmail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(145)))), ((int)(((byte)(45)))));
            this.pnlEmail.Controls.Add(this.cboBulto);
            this.pnlEmail.Controls.Add(this.cboPallet);
            this.pnlEmail.Controls.Add(this.label10);
            this.pnlEmail.Controls.Add(this.txtPesoBulto);
            this.pnlEmail.Controls.Add(this.label11);
            this.pnlEmail.Controls.Add(this.txtPesoPallet);
            this.pnlEmail.Controls.Add(this.label6);
            this.pnlEmail.Controls.Add(this.label9);
            this.pnlEmail.Location = new System.Drawing.Point(4, 75);
            this.pnlEmail.Name = "pnlEmail";
            this.pnlEmail.Size = new System.Drawing.Size(237, 56);
            this.pnlEmail.TabIndex = 63;
            // 
            // cboPallet
            // 
            this.cboPallet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPallet.FormattingEnabled = true;
            this.cboPallet.Location = new System.Drawing.Point(56, 4);
            this.cboPallet.Name = "cboPallet";
            this.cboPallet.Size = new System.Drawing.Size(97, 22);
            this.cboPallet.TabIndex = 1;
            this.cboPallet.SelectedValueChanged += new System.EventHandler(this.CboPallet_SelectedValueChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(3, 34);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(33, 14);
            this.label10.TabIndex = 63;
            this.label10.Text = "Bulto";
            // 
            // txtPesoBulto
            // 
            this.txtPesoBulto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPesoBulto.Enabled = false;
            this.txtPesoBulto.Location = new System.Drawing.Point(195, 31);
            this.txtPesoBulto.Name = "txtPesoBulto";
            this.txtPesoBulto.Size = new System.Drawing.Size(39, 22);
            this.txtPesoBulto.TabIndex = 4;
            this.txtPesoBulto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(159, 33);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(30, 14);
            this.label11.TabIndex = 62;
            this.label11.Text = "Peso";
            // 
            // txtPesoPallet
            // 
            this.txtPesoPallet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPesoPallet.Enabled = false;
            this.txtPesoPallet.Location = new System.Drawing.Point(195, 4);
            this.txtPesoPallet.Name = "txtPesoPallet";
            this.txtPesoPallet.Size = new System.Drawing.Size(39, 22);
            this.txtPesoPallet.TabIndex = 2;
            this.txtPesoPallet.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(3, 7);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 14);
            this.label6.TabIndex = 56;
            this.label6.Text = "Pallet";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(159, 7);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(30, 14);
            this.label9.TabIndex = 58;
            this.label9.Text = "Peso";
            // 
            // txtPallet
            // 
            this.txtPallet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPallet.Location = new System.Drawing.Point(640, 63);
            this.txtPallet.Name = "txtPallet";
            this.txtPallet.Size = new System.Drawing.Size(57, 22);
            this.txtPallet.TabIndex = 5;
            this.txtPallet.Visible = false;
            // 
            // lblTotalKilosBruto
            // 
            this.lblTotalKilosBruto.AutoSize = true;
            this.lblTotalKilosBruto.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalKilosBruto.Location = new System.Drawing.Point(369, 109);
            this.lblTotalKilosBruto.Name = "lblTotalKilosBruto";
            this.lblTotalKilosBruto.Size = new System.Drawing.Size(10, 14);
            this.lblTotalKilosBruto.TabIndex = 62;
            this.lblTotalKilosBruto.Text = ".";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(253, 109);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(107, 14);
            this.label8.TabIndex = 61;
            this.label8.Text = "Total Kg Bruto Envio";
            // 
            // lblTotalKilosNeto
            // 
            this.lblTotalKilosNeto.AutoSize = true;
            this.lblTotalKilosNeto.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalKilosNeto.Location = new System.Drawing.Point(369, 86);
            this.lblTotalKilosNeto.Name = "lblTotalKilosNeto";
            this.lblTotalKilosNeto.Size = new System.Drawing.Size(10, 14);
            this.lblTotalKilosNeto.TabIndex = 60;
            this.lblTotalKilosNeto.Text = ".";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(253, 86);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 14);
            this.label7.TabIndex = 59;
            this.label7.Text = "Total Kg Neto Envio";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(145)))), ((int)(((byte)(45)))));
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtBox);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtNeto);
            this.panel1.Controls.Add(this.txtBruto);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(3, 137);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(411, 56);
            this.panel1.TabIndex = 64;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Layer.Win.Properties.Resources.cosecha_2_64;
            this.pictureBox2.Location = new System.Drawing.Point(3, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(29, 31);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 28;
            this.pictureBox2.TabStop = false;
            // 
            // btnCreate
            // 
            this.btnCreate.FlatAppearance.BorderSize = 0;
            this.btnCreate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreate.Image = global::Layer.Win.Properties.Resources.shipment_code;
            this.btnCreate.Location = new System.Drawing.Point(189, 39);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(49, 30);
            this.btnCreate.TabIndex = 99;
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.FlatAppearance.BorderSize = 0;
            this.btnGrabar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGrabar.Image = global::Layer.Win.Properties.Resources.caja_64;
            this.btnGrabar.Location = new System.Drawing.Point(420, 130);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(81, 63);
            this.btnGrabar.TabIndex = 5;
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // cboBulto
            // 
            this.cboBulto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBulto.FormattingEnabled = true;
            this.cboBulto.Location = new System.Drawing.Point(56, 30);
            this.cboBulto.Name = "cboBulto";
            this.cboBulto.Size = new System.Drawing.Size(97, 22);
            this.cboBulto.TabIndex = 2;
            this.cboBulto.SelectedValueChanged += new System.EventHandler(this.CboBulto_SelectedValueChanged);
            // 
            // FrmEnvioCaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(237)))), ((int)(((byte)(237)))));
            this.ClientSize = new System.Drawing.Size(709, 451);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlEmail);
            this.Controls.Add(this.lblTotalKilosBruto);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblTotalKilosNeto);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cboShipment);
            this.Controls.Add(this.txtPallet);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.lblShipmentCode);
            this.Controls.Add(this.dataBox);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Calibri", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmEnvioCaja";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Envio Caja";
            this.Load += new System.EventHandler(this.FrmEnvioCaja_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FrmEnvioCaja_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.dataBox)).EndInit();
            this.ctxCajaMenu.ResumeLayout(false);
            this.pnlEmail.ResumeLayout(false);
            this.pnlEmail.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.DataGridView dataBox;
        private System.Windows.Forms.TextBox txtBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNeto;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBruto;
        private System.Windows.Forms.Label lblShipmentCode;
        private System.Windows.Forms.ContextMenuStrip ctxCajaMenu;
        private System.Windows.Forms.ToolStripMenuItem borrarCajaToolStripMenuItem;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ComboBox cboShipment;
        private System.Windows.Forms.Panel pnlEmail;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtPesoBulto;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtPesoPallet;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtPallet;
        private System.Windows.Forms.Label lblTotalKilosBruto;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblTotalKilosNeto;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cboPallet;
        private System.Windows.Forms.Button btnGrabar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Box;
        private System.Windows.Forms.DataGridViewTextBoxColumn PesoNeto;
        private System.Windows.Forms.DataGridViewTextBoxColumn PesoBruto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pallet;
        private System.Windows.Forms.DataGridViewTextBoxColumn Peso;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bulto;
        private System.Windows.Forms.DataGridViewTextBoxColumn PesoBulto;
        private System.Windows.Forms.ComboBox cboBulto;
    }
}