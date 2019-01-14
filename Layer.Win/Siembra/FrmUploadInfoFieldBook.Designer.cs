namespace Layer.Win.Siembra
{
    partial class FrmUploadInfoFieldBook
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.grdDetalle = new System.Windows.Forms.DataGridView();
            this.btnExportar = new System.Windows.Forms.Button();
            this.lblEuids = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Num = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IndEuid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Year = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Country = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Location = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Order = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BreedersCode1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BreedersCode2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BreedersCode3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BreedersCode4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExpName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProjectLead = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Shelling = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Instructions = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TargetEars = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TargetKern = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TargetWg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShipTo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Crop = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProjectCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GmoEvent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodInternacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.groupBox1.SuspendLayout();
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.grdDetalle);
            this.groupBox1.Location = new System.Drawing.Point(5, 64);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(668, 348);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Detalle Archivo";
            // 
            // grdDetalle
            // 
            this.grdDetalle.AllowUserToAddRows = false;
            this.grdDetalle.AllowUserToDeleteRows = false;
            this.grdDetalle.AllowUserToOrderColumns = true;
            this.grdDetalle.BackgroundColor = System.Drawing.SystemColors.Control;
            this.grdDetalle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Calibri", 8.25F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdDetalle.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.grdDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdDetalle.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Num,
            this.dataGridViewTextBoxColumn1,
            this.IndEuid,
            this.Year,
            this.Country,
            this.Location,
            this.Order,
            this.BreedersCode1,
            this.BreedersCode2,
            this.BreedersCode3,
            this.BreedersCode4,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.ExpName,
            this.ProjectLead,
            this.Cc,
            this.Shelling,
            this.Instructions,
            this.TargetEars,
            this.TargetKern,
            this.TargetWg,
            this.ShipTo,
            this.Crop,
            this.dataGridViewTextBoxColumn7,
            this.ProjectCode,
            this.GmoEvent,
            this.Sag,
            this.CodInternacion,
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
            this.grdDetalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdDetalle.Location = new System.Drawing.Point(3, 17);
            this.grdDetalle.Name = "grdDetalle";
            this.grdDetalle.ReadOnly = true;
            this.grdDetalle.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Calibri", 8.25F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdDetalle.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.grdDetalle.RowHeadersVisible = false;
            this.grdDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdDetalle.Size = new System.Drawing.Size(662, 328);
            this.grdDetalle.TabIndex = 3;
            // 
            // btnExportar
            // 
            this.btnExportar.Enabled = false;
            this.btnExportar.Location = new System.Drawing.Point(611, 418);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(62, 23);
            this.btnExportar.TabIndex = 15;
            this.btnExportar.Text = "Exportar";
            this.btnExportar.UseVisualStyleBackColor = true;
            this.btnExportar.Visible = false;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // lblEuids
            // 
            this.lblEuids.AutoSize = true;
            this.lblEuids.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEuids.Location = new System.Drawing.Point(305, 415);
            this.lblEuids.Name = "lblEuids";
            this.lblEuids.Size = new System.Drawing.Size(18, 26);
            this.lblEuids.TabIndex = 14;
            this.lblEuids.Text = ".";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 415);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(286, 26);
            this.label1.TabIndex = 13;
            this.label1.Text = "N° Individual Euids Procesados: ";
            // 
            // Num
            // 
            this.Num.DataPropertyName = "Index";
            this.Num.HeaderText = "N°";
            this.Num.Name = "Num";
            this.Num.ReadOnly = true;
            this.Num.Visible = false;
            this.Num.Width = 50;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "euid";
            this.dataGridViewTextBoxColumn1.HeaderText = "Euid";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 90;
            // 
            // IndEuid
            // 
            this.IndEuid.DataPropertyName = "indEuid";
            this.IndEuid.HeaderText = "IndEuid";
            this.IndEuid.Name = "IndEuid";
            this.IndEuid.ReadOnly = true;
            // 
            // Year
            // 
            this.Year.DataPropertyName = "year";
            this.Year.HeaderText = "Year";
            this.Year.Name = "Year";
            this.Year.ReadOnly = true;
            this.Year.Width = 50;
            // 
            // Country
            // 
            this.Country.DataPropertyName = "country";
            this.Country.HeaderText = "Country";
            this.Country.Name = "Country";
            this.Country.ReadOnly = true;
            this.Country.Width = 80;
            // 
            // Location
            // 
            this.Location.DataPropertyName = "location";
            this.Location.HeaderText = "Location";
            this.Location.Name = "Location";
            this.Location.ReadOnly = true;
            // 
            // Order
            // 
            this.Order.DataPropertyName = "order";
            this.Order.HeaderText = "Order";
            this.Order.Name = "Order";
            this.Order.ReadOnly = true;
            this.Order.Width = 50;
            // 
            // BreedersCode1
            // 
            this.BreedersCode1.DataPropertyName = "BreedersCode1";
            this.BreedersCode1.HeaderText = "Breeders Code 1";
            this.BreedersCode1.Name = "BreedersCode1";
            this.BreedersCode1.ReadOnly = true;
            // 
            // BreedersCode2
            // 
            this.BreedersCode2.DataPropertyName = "BreedersCode2";
            this.BreedersCode2.HeaderText = "Breeders Code 2";
            this.BreedersCode2.Name = "BreedersCode2";
            this.BreedersCode2.ReadOnly = true;
            // 
            // BreedersCode3
            // 
            this.BreedersCode3.DataPropertyName = "BreedersCode3";
            this.BreedersCode3.HeaderText = "Breeders Code 3";
            this.BreedersCode3.Name = "BreedersCode3";
            this.BreedersCode3.ReadOnly = true;
            // 
            // BreedersCode4
            // 
            this.BreedersCode4.DataPropertyName = "BreedersCode4";
            this.BreedersCode4.HeaderText = "Breeders Code 4";
            this.BreedersCode4.Name = "BreedersCode4";
            this.BreedersCode4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "rng";
            this.dataGridViewTextBoxColumn2.HeaderText = "Rng";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 40;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "plt";
            this.dataGridViewTextBoxColumn5.HeaderText = "Plt";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 40;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "ent";
            this.dataGridViewTextBoxColumn6.HeaderText = "Ent";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 70;
            // 
            // ExpName
            // 
            this.ExpName.DataPropertyName = "opExpName";
            this.ExpName.HeaderText = "ExpName";
            this.ExpName.Name = "ExpName";
            this.ExpName.ReadOnly = true;
            // 
            // ProjectLead
            // 
            this.ProjectLead.DataPropertyName = "projecLead";
            this.ProjectLead.HeaderText = "ProjectLead";
            this.ProjectLead.Name = "ProjectLead";
            this.ProjectLead.ReadOnly = true;
            // 
            // Cc
            // 
            this.Cc.DataPropertyName = "cc";
            this.Cc.HeaderText = "Cc";
            this.Cc.Name = "Cc";
            this.Cc.ReadOnly = true;
            // 
            // Shelling
            // 
            this.Shelling.DataPropertyName = "shelling";
            this.Shelling.HeaderText = "Shelling";
            this.Shelling.Name = "Shelling";
            this.Shelling.ReadOnly = true;
            // 
            // Instructions
            // 
            this.Instructions.DataPropertyName = "instructions";
            this.Instructions.HeaderText = "Instructions";
            this.Instructions.Name = "Instructions";
            this.Instructions.ReadOnly = true;
            // 
            // TargetEars
            // 
            this.TargetEars.DataPropertyName = "targetEars";
            this.TargetEars.HeaderText = "T. Ears";
            this.TargetEars.Name = "TargetEars";
            this.TargetEars.ReadOnly = true;
            // 
            // TargetKern
            // 
            this.TargetKern.DataPropertyName = "targetKern";
            this.TargetKern.HeaderText = "T. Kern";
            this.TargetKern.Name = "TargetKern";
            this.TargetKern.ReadOnly = true;
            // 
            // TargetWg
            // 
            this.TargetWg.DataPropertyName = "targetWg";
            this.TargetWg.HeaderText = "T. Wg";
            this.TargetWg.Name = "TargetWg";
            this.TargetWg.ReadOnly = true;
            // 
            // ShipTo
            // 
            this.ShipTo.DataPropertyName = "shipTo";
            this.ShipTo.HeaderText = "Ship To";
            this.ShipTo.Name = "ShipTo";
            this.ShipTo.ReadOnly = true;
            // 
            // Crop
            // 
            this.Crop.DataPropertyName = "crop";
            this.Crop.HeaderText = "Crop";
            this.Crop.Name = "Crop";
            this.Crop.ReadOnly = true;
            this.Crop.Width = 70;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "obs";
            this.dataGridViewTextBoxColumn7.HeaderText = "Obs";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // ProjectCode
            // 
            this.ProjectCode.DataPropertyName = "projectCode";
            this.ProjectCode.HeaderText = "ProjectCode";
            this.ProjectCode.Name = "ProjectCode";
            this.ProjectCode.ReadOnly = true;
            this.ProjectCode.Width = 80;
            // 
            // GmoEvent
            // 
            this.GmoEvent.DataPropertyName = "gmoEvent";
            this.GmoEvent.HeaderText = "GmoEvent";
            this.GmoEvent.Name = "GmoEvent";
            this.GmoEvent.ReadOnly = true;
            // 
            // Sag
            // 
            this.Sag.DataPropertyName = "sag";
            this.Sag.HeaderText = "Sag";
            this.Sag.Name = "Sag";
            this.Sag.ReadOnly = true;
            this.Sag.Width = 70;
            // 
            // CodInternacion
            // 
            this.CodInternacion.DataPropertyName = "codInternacion";
            this.CodInternacion.HeaderText = "CodInternacion";
            this.CodInternacion.Name = "CodInternacion";
            this.CodInternacion.ReadOnly = true;
            // 
            // Client
            // 
            this.Client.DataPropertyName = "client";
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
            this.Bi1.DataPropertyName = "BreedersInstructions1";
            this.Bi1.HeaderText = "Bi1";
            this.Bi1.Name = "Bi1";
            this.Bi1.ReadOnly = true;
            // 
            // Bi2
            // 
            this.Bi2.DataPropertyName = "BreedersInstructions2";
            this.Bi2.HeaderText = "Bi2";
            this.Bi2.Name = "Bi2";
            this.Bi2.ReadOnly = true;
            // 
            // Bi3
            // 
            this.Bi3.DataPropertyName = "BreedersInstructions3";
            this.Bi3.HeaderText = "Bi3";
            this.Bi3.Name = "Bi3";
            this.Bi3.ReadOnly = true;
            // 
            // Bi4
            // 
            this.Bi4.DataPropertyName = "BreedersInstructions4";
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
            // FrmUploadInfoFieldBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(679, 450);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.lblEuids);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grpProgreso);
            this.Controls.Add(this.grdOpciones);
            this.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmUploadInfoFieldBook";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Carga Field Book";
            this.Load += new System.EventHandler(this.FrmUploadInfoFieldBook_Load);
            this.grdOpciones.ResumeLayout(false);
            this.grpProgreso.ResumeLayout(false);
            this.grpProgreso.PerformLayout();
            this.groupBox1.ResumeLayout(false);
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
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.Label lblEuids;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView grdDetalle;
        private System.Windows.Forms.DataGridViewTextBoxColumn Num;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn IndEuid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Year;
        private System.Windows.Forms.DataGridViewTextBoxColumn Country;
        private System.Windows.Forms.DataGridViewTextBoxColumn Location;
        private System.Windows.Forms.DataGridViewTextBoxColumn Order;
        private System.Windows.Forms.DataGridViewTextBoxColumn BreedersCode1;
        private System.Windows.Forms.DataGridViewTextBoxColumn BreedersCode2;
        private System.Windows.Forms.DataGridViewTextBoxColumn BreedersCode3;
        private System.Windows.Forms.DataGridViewTextBoxColumn BreedersCode4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExpName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProjectLead;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cc;
        private System.Windows.Forms.DataGridViewTextBoxColumn Shelling;
        private System.Windows.Forms.DataGridViewTextBoxColumn Instructions;
        private System.Windows.Forms.DataGridViewTextBoxColumn TargetEars;
        private System.Windows.Forms.DataGridViewTextBoxColumn TargetKern;
        private System.Windows.Forms.DataGridViewTextBoxColumn TargetWg;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShipTo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Crop;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProjectCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn GmoEvent;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sag;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodInternacion;
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