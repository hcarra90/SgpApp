namespace Layer.Win.Siembra
{
    partial class FrmSplit
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grdOpciones = new System.Windows.Forms.GroupBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnProcesar = new System.Windows.Forms.Button();
            this.btnCarga = new System.Windows.Forms.Button();
            this.grpProgreso = new System.Windows.Forms.GroupBox();
            this.lbltotal = new System.Windows.Forms.Label();
            this.lblPorcentaje = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.prgGraba = new System.Windows.Forms.ProgressBar();
            this.lblActual = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.grdResumen = new System.Windows.Forms.DataGridView();
            this.lblEuids = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnExportar = new System.Windows.Forms.Button();
            this.grpDetalle = new System.Windows.Forms.GroupBox();
            this.grdDetalle = new System.Windows.Forms.DataGridView();
            this.Euids = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EuidSplit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Num = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IndEuid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Year = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Country = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Location = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExpName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProjectLead = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Crop = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProjectCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GmoEvent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodInternacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodReception = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Client = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ResImportacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GranosHilera = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bi1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bi2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bi3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bi4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Owner = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodPermanencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LotId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grdOpciones.SuspendLayout();
            this.grpProgreso.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdResumen)).BeginInit();
            this.grpDetalle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDetalle)).BeginInit();
            this.SuspendLayout();
            // 
            // grdOpciones
            // 
            this.grdOpciones.Controls.Add(this.btnCancelar);
            this.grdOpciones.Controls.Add(this.btnProcesar);
            this.grdOpciones.Controls.Add(this.btnCarga);
            this.grdOpciones.Location = new System.Drawing.Point(5, 2);
            this.grdOpciones.Name = "grdOpciones";
            this.grdOpciones.Size = new System.Drawing.Size(285, 56);
            this.grdOpciones.TabIndex = 1;
            this.grdOpciones.TabStop = false;
            this.grdOpciones.Text = "Opciones";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(217, 20);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(62, 23);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnProcesar
            // 
            this.btnProcesar.Enabled = false;
            this.btnProcesar.Location = new System.Drawing.Point(149, 20);
            this.btnProcesar.Name = "btnProcesar";
            this.btnProcesar.Size = new System.Drawing.Size(62, 23);
            this.btnProcesar.TabIndex = 1;
            this.btnProcesar.Text = "Procesar";
            this.btnProcesar.UseVisualStyleBackColor = true;
            this.btnProcesar.Click += new System.EventHandler(this.btnProcesar_Click);
            // 
            // btnCarga
            // 
            this.btnCarga.Location = new System.Drawing.Point(5, 20);
            this.btnCarga.Name = "btnCarga";
            this.btnCarga.Size = new System.Drawing.Size(62, 23);
            this.btnCarga.TabIndex = 0;
            this.btnCarga.Text = "Buscar";
            this.btnCarga.UseVisualStyleBackColor = true;
            this.btnCarga.Click += new System.EventHandler(this.btnCarga_Click);
            // 
            // grpProgreso
            // 
            this.grpProgreso.Controls.Add(this.lbltotal);
            this.grpProgreso.Controls.Add(this.lblPorcentaje);
            this.grpProgreso.Controls.Add(this.label4);
            this.grpProgreso.Controls.Add(this.prgGraba);
            this.grpProgreso.Controls.Add(this.lblActual);
            this.grpProgreso.Controls.Add(this.label2);
            this.grpProgreso.Location = new System.Drawing.Point(296, 2);
            this.grpProgreso.Name = "grpProgreso";
            this.grpProgreso.Size = new System.Drawing.Size(377, 56);
            this.grpProgreso.TabIndex = 9;
            this.grpProgreso.TabStop = false;
            this.grpProgreso.Visible = false;
            // 
            // lbltotal
            // 
            this.lbltotal.AutoSize = true;
            this.lbltotal.Font = new System.Drawing.Font("OCR A Extended", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltotal.Location = new System.Drawing.Point(269, 36);
            this.lbltotal.Name = "lbltotal";
            this.lbltotal.Size = new System.Drawing.Size(16, 13);
            this.lbltotal.TabIndex = 17;
            this.lbltotal.Text = ".";
            // 
            // lblPorcentaje
            // 
            this.lblPorcentaje.AutoSize = true;
            this.lblPorcentaje.Font = new System.Drawing.Font("OCR A Extended", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPorcentaje.Location = new System.Drawing.Point(20, 36);
            this.lblPorcentaje.Name = "lblPorcentaje";
            this.lblPorcentaje.Size = new System.Drawing.Size(13, 12);
            this.lblPorcentaje.TabIndex = 3;
            this.lblPorcentaje.Text = ".";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("OCR A Extended", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(234, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "De";
            // 
            // prgGraba
            // 
            this.prgGraba.Location = new System.Drawing.Point(13, 10);
            this.prgGraba.Name = "prgGraba";
            this.prgGraba.Size = new System.Drawing.Size(351, 23);
            this.prgGraba.Step = 1;
            this.prgGraba.TabIndex = 1;
            // 
            // lblActual
            // 
            this.lblActual.AutoSize = true;
            this.lblActual.Font = new System.Drawing.Font("OCR A Extended", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActual.Location = new System.Drawing.Point(195, 36);
            this.lblActual.Name = "lblActual";
            this.lblActual.Size = new System.Drawing.Size(16, 13);
            this.lblActual.TabIndex = 15;
            this.lblActual.Text = ".";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("OCR A Extended", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(111, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Cargando";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.grdResumen);
            this.groupBox2.Location = new System.Drawing.Point(5, 64);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(221, 338);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Resumen Archivo";
            // 
            // grdResumen
            // 
            this.grdResumen.AllowUserToAddRows = false;
            this.grdResumen.AllowUserToDeleteRows = false;
            this.grdResumen.AllowUserToOrderColumns = true;
            this.grdResumen.BackgroundColor = System.Drawing.SystemColors.Control;
            this.grdResumen.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdResumen.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.grdResumen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdResumen.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Euids,
            this.EuidSplit});
            this.grdResumen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdResumen.Location = new System.Drawing.Point(3, 17);
            this.grdResumen.Name = "grdResumen";
            this.grdResumen.ReadOnly = true;
            this.grdResumen.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdResumen.RowHeadersDefaultCellStyle = dataGridViewCellStyle14;
            this.grdResumen.RowHeadersVisible = false;
            this.grdResumen.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdResumen.Size = new System.Drawing.Size(215, 318);
            this.grdResumen.TabIndex = 0;
            // 
            // lblEuids
            // 
            this.lblEuids.AutoSize = true;
            this.lblEuids.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEuids.Location = new System.Drawing.Point(226, 405);
            this.lblEuids.Name = "lblEuids";
            this.lblEuids.Size = new System.Drawing.Size(18, 26);
            this.lblEuids.TabIndex = 12;
            this.lblEuids.Text = ".";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 405);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(196, 26);
            this.label1.TabIndex = 11;
            this.label1.Text = "N° Euids Procesados: ";
            // 
            // btnExportar
            // 
            this.btnExportar.Enabled = false;
            this.btnExportar.Location = new System.Drawing.Point(611, 408);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(62, 23);
            this.btnExportar.TabIndex = 13;
            this.btnExportar.Text = "Exportar";
            this.btnExportar.UseVisualStyleBackColor = true;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // grpDetalle
            // 
            this.grpDetalle.Controls.Add(this.grdDetalle);
            this.grpDetalle.Location = new System.Drawing.Point(229, 64);
            this.grpDetalle.Name = "grpDetalle";
            this.grpDetalle.Size = new System.Drawing.Size(444, 338);
            this.grpDetalle.TabIndex = 14;
            this.grpDetalle.TabStop = false;
            this.grpDetalle.Text = "Detalle Información";
            // 
            // grdDetalle
            // 
            this.grdDetalle.AllowUserToAddRows = false;
            this.grdDetalle.AllowUserToDeleteRows = false;
            this.grdDetalle.AllowUserToOrderColumns = true;
            this.grdDetalle.BackgroundColor = System.Drawing.SystemColors.Control;
            this.grdDetalle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdDetalle.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle15;
            this.grdDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdDetalle.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Num,
            this.dataGridViewTextBoxColumn1,
            this.IndEuid,
            this.Year,
            this.Country,
            this.Location,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.ExpName,
            this.ProjectLead,
            this.Cc,
            this.Crop,
            this.dataGridViewTextBoxColumn7,
            this.ProjectCode,
            this.GmoEvent,
            this.Sag,
            this.CodInternacion,
            this.CodReception,
            this.Client,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.ResImportacion,
            this.GranosHilera,
            this.Bi1,
            this.Bi2,
            this.Bi3,
            this.Bi4,
            this.Owner,
            this.CodPermanencia,
            this.LotId});
            this.grdDetalle.Location = new System.Drawing.Point(4, 13);
            this.grdDetalle.Name = "grdDetalle";
            this.grdDetalle.ReadOnly = true;
            this.grdDetalle.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdDetalle.RowHeadersDefaultCellStyle = dataGridViewCellStyle16;
            this.grdDetalle.RowHeadersVisible = false;
            this.grdDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdDetalle.Size = new System.Drawing.Size(437, 319);
            this.grdDetalle.TabIndex = 2;
            // 
            // Euids
            // 
            this.Euids.DataPropertyName = "Euid";
            this.Euids.HeaderText = "Euid";
            this.Euids.Name = "Euids";
            this.Euids.ReadOnly = true;
            this.Euids.Width = 130;
            // 
            // EuidSplit
            // 
            this.EuidSplit.DataPropertyName = "EuidSplit";
            this.EuidSplit.HeaderText = "N° Split";
            this.EuidSplit.Name = "EuidSplit";
            this.EuidSplit.ReadOnly = true;
            this.EuidSplit.Width = 70;
            // 
            // Num
            // 
            this.Num.DataPropertyName = "Index";
            this.Num.HeaderText = "N°";
            this.Num.Name = "Num";
            this.Num.ReadOnly = true;
            this.Num.Width = 50;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Euid";
            this.dataGridViewTextBoxColumn1.HeaderText = "Euid";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 90;
            // 
            // IndEuid
            // 
            this.IndEuid.DataPropertyName = "IndEuid";
            this.IndEuid.HeaderText = "IndEuid";
            this.IndEuid.Name = "IndEuid";
            this.IndEuid.ReadOnly = true;
            // 
            // Year
            // 
            this.Year.DataPropertyName = "Year";
            this.Year.HeaderText = "Year";
            this.Year.Name = "Year";
            this.Year.ReadOnly = true;
            this.Year.Width = 50;
            // 
            // Country
            // 
            this.Country.DataPropertyName = "Country";
            this.Country.HeaderText = "Country";
            this.Country.Name = "Country";
            this.Country.ReadOnly = true;
            this.Country.Width = 80;
            // 
            // Location
            // 
            this.Location.DataPropertyName = "Location";
            this.Location.HeaderText = "Location";
            this.Location.Name = "Location";
            this.Location.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Rng";
            this.dataGridViewTextBoxColumn2.HeaderText = "Rng";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 40;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Plt";
            this.dataGridViewTextBoxColumn5.HeaderText = "Plt";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 40;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Ent";
            this.dataGridViewTextBoxColumn6.HeaderText = "Ent";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 70;
            // 
            // ExpName
            // 
            this.ExpName.DataPropertyName = "ExpName";
            this.ExpName.HeaderText = "ExpName";
            this.ExpName.Name = "ExpName";
            this.ExpName.ReadOnly = true;
            // 
            // ProjectLead
            // 
            this.ProjectLead.DataPropertyName = "ProjectLead";
            this.ProjectLead.HeaderText = "ProjectLead";
            this.ProjectLead.Name = "ProjectLead";
            this.ProjectLead.ReadOnly = true;
            // 
            // Cc
            // 
            this.Cc.DataPropertyName = "Cc";
            this.Cc.HeaderText = "Cc";
            this.Cc.Name = "Cc";
            this.Cc.ReadOnly = true;
            // 
            // Crop
            // 
            this.Crop.DataPropertyName = "Crop";
            this.Crop.HeaderText = "Crop";
            this.Crop.Name = "Crop";
            this.Crop.ReadOnly = true;
            this.Crop.Width = 70;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "Obs";
            this.dataGridViewTextBoxColumn7.HeaderText = "Obs";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // ProjectCode
            // 
            this.ProjectCode.DataPropertyName = "ProjectCode";
            this.ProjectCode.HeaderText = "ProjectCode";
            this.ProjectCode.Name = "ProjectCode";
            this.ProjectCode.ReadOnly = true;
            this.ProjectCode.Width = 80;
            // 
            // GmoEvent
            // 
            this.GmoEvent.DataPropertyName = "GmoEvent";
            this.GmoEvent.HeaderText = "GmoEvent";
            this.GmoEvent.Name = "GmoEvent";
            this.GmoEvent.ReadOnly = true;
            // 
            // Sag
            // 
            this.Sag.DataPropertyName = "Sag";
            this.Sag.HeaderText = "Sag";
            this.Sag.Name = "Sag";
            this.Sag.ReadOnly = true;
            this.Sag.Width = 70;
            // 
            // CodInternacion
            // 
            this.CodInternacion.DataPropertyName = "CodInternacion";
            this.CodInternacion.HeaderText = "CodInternacion";
            this.CodInternacion.Name = "CodInternacion";
            this.CodInternacion.ReadOnly = true;
            // 
            // CodReception
            // 
            this.CodReception.DataPropertyName = "CodReception";
            this.CodReception.HeaderText = "CodReception";
            this.CodReception.Name = "CodReception";
            this.CodReception.ReadOnly = true;
            // 
            // Client
            // 
            this.Client.DataPropertyName = "Client";
            this.Client.HeaderText = "Client";
            this.Client.Name = "Client";
            this.Client.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "EntName";
            this.dataGridViewTextBoxColumn8.HeaderText = "Ent Name";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Width = 75;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "EntRole";
            this.dataGridViewTextBoxColumn9.HeaderText = "Ent Role";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Width = 70;
            // 
            // ResImportacion
            // 
            this.ResImportacion.DataPropertyName = "ResImportacion";
            this.ResImportacion.HeaderText = "ResImportacion";
            this.ResImportacion.Name = "ResImportacion";
            this.ResImportacion.ReadOnly = true;
            // 
            // GranosHilera
            // 
            this.GranosHilera.DataPropertyName = "GranosHilera";
            this.GranosHilera.HeaderText = "GranosHilera";
            this.GranosHilera.Name = "GranosHilera";
            this.GranosHilera.ReadOnly = true;
            this.GranosHilera.Width = 80;
            // 
            // Bi1
            // 
            this.Bi1.DataPropertyName = "Bi1";
            this.Bi1.HeaderText = "Bi1";
            this.Bi1.Name = "Bi1";
            this.Bi1.ReadOnly = true;
            // 
            // Bi2
            // 
            this.Bi2.DataPropertyName = "Bi2";
            this.Bi2.HeaderText = "Bi2";
            this.Bi2.Name = "Bi2";
            this.Bi2.ReadOnly = true;
            // 
            // Bi3
            // 
            this.Bi3.DataPropertyName = "Bi3";
            this.Bi3.HeaderText = "Bi3";
            this.Bi3.Name = "Bi3";
            this.Bi3.ReadOnly = true;
            // 
            // Bi4
            // 
            this.Bi4.DataPropertyName = "Bi4";
            this.Bi4.HeaderText = "Bi4";
            this.Bi4.Name = "Bi4";
            this.Bi4.ReadOnly = true;
            // 
            // Owner
            // 
            this.Owner.DataPropertyName = "Owner";
            this.Owner.HeaderText = "Owner";
            this.Owner.Name = "Owner";
            this.Owner.ReadOnly = true;
            // 
            // CodPermanencia
            // 
            this.CodPermanencia.DataPropertyName = "CodPermanencia";
            this.CodPermanencia.HeaderText = "Permanencia";
            this.CodPermanencia.Name = "CodPermanencia";
            this.CodPermanencia.ReadOnly = true;
            this.CodPermanencia.Width = 80;
            // 
            // LotId
            // 
            this.LotId.DataPropertyName = "LotId";
            this.LotId.HeaderText = "Lot Id";
            this.LotId.Name = "LotId";
            this.LotId.ReadOnly = true;
            this.LotId.Width = 70;
            // 
            // FrmSplit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(679, 456);
            this.Controls.Add(this.grpDetalle);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.lblEuids);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.grpProgreso);
            this.Controls.Add(this.grdOpciones);
            this.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSplit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Split";
            this.Load += new System.EventHandler(this.FrmSplit_Load);
            this.grdOpciones.ResumeLayout(false);
            this.grpProgreso.ResumeLayout(false);
            this.grpProgreso.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdResumen)).EndInit();
            this.grpDetalle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdDetalle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grdOpciones;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnProcesar;
        private System.Windows.Forms.Button btnCarga;
        private System.Windows.Forms.GroupBox grpProgreso;
        private System.Windows.Forms.Label lbltotal;
        private System.Windows.Forms.Label lblPorcentaje;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ProgressBar prgGraba;
        private System.Windows.Forms.Label lblActual;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView grdResumen;
        private System.Windows.Forms.Label lblEuids;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.GroupBox grpDetalle;
        private System.Windows.Forms.DataGridView grdDetalle;
        private System.Windows.Forms.DataGridViewTextBoxColumn Euids;
        private System.Windows.Forms.DataGridViewTextBoxColumn EuidSplit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Num;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn IndEuid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Year;
        private System.Windows.Forms.DataGridViewTextBoxColumn Country;
        private System.Windows.Forms.DataGridViewTextBoxColumn Location;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExpName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProjectLead;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cc;
        private System.Windows.Forms.DataGridViewTextBoxColumn Crop;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProjectCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn GmoEvent;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sag;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodInternacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodReception;
        private System.Windows.Forms.DataGridViewTextBoxColumn Client;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn ResImportacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn GranosHilera;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bi1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bi2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bi3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bi4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Owner;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodPermanencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn LotId;
    }
}