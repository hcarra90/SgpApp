namespace Layer.Win.Consulta
{
    partial class FrmPackingList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPackingList));
            this.label1 = new System.Windows.Forms.Label();
            this.cboShipment = new System.Windows.Forms.ComboBox();
            this.dataBox = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaEnvio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShipTo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CajaEnvio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PesoNeto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PesoBruto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CountryR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StateR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CityR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AddressR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ZipCodeR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ContactR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmailR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PhoneR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClientR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataDetail = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShipmentCod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Box = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Euid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IndEuid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaPacking = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalKernels = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalEars = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShipT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Country = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Location = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExpName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bc1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bc2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bc3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bc4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProjectLead = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Crop = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Obs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Client = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Event = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodInternacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodReception = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.pnlEmail = new System.Windows.Forms.Panel();
            this.cboEmail = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnEnvio = new System.Windows.Forms.Button();
            this.txtMensaje = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnExportar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lblTotalResumen = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblTotalDetalle = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataDetail)).BeginInit();
            this.pnlEmail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(0, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Shipment Code";
            // 
            // cboShipment
            // 
            this.cboShipment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboShipment.FormattingEnabled = true;
            this.cboShipment.Location = new System.Drawing.Point(97, 50);
            this.cboShipment.Name = "cboShipment";
            this.cboShipment.Size = new System.Drawing.Size(142, 23);
            this.cboShipment.TabIndex = 1;
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
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Calibri", 9.75F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataBox.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataBox.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataBox.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.FechaEnvio,
            this.ShipTo,
            this.CajaEnvio,
            this.PesoNeto,
            this.PesoBruto,
            this.CountryR,
            this.StateR,
            this.CityR,
            this.AddressR,
            this.ZipCodeR,
            this.ContactR,
            this.EmailR,
            this.PhoneR,
            this.ClientR});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(176)))), ((int)(((byte)(62)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Calibri", 9.75F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataBox.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataBox.EnableHeadersVisualStyles = false;
            this.dataBox.Location = new System.Drawing.Point(3, 81);
            this.dataBox.Name = "dataBox";
            this.dataBox.ReadOnly = true;
            this.dataBox.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(176)))), ((int)(((byte)(62)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Calibri", 9.75F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataBox.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataBox.RowHeadersVisible = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(176)))), ((int)(((byte)(62)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            this.dataBox.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataBox.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataBox.Size = new System.Drawing.Size(460, 144);
            this.dataBox.TabIndex = 12;
            this.dataBox.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataBox_CellContentClick);
            // 
            // Id
            // 
            this.Id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            // 
            // FechaEnvio
            // 
            this.FechaEnvio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.FechaEnvio.DataPropertyName = "fechaEnvio";
            this.FechaEnvio.HeaderText = "Fecha Envio";
            this.FechaEnvio.Name = "FechaEnvio";
            this.FechaEnvio.ReadOnly = true;
            // 
            // ShipTo
            // 
            this.ShipTo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ShipTo.DataPropertyName = "shipTo";
            this.ShipTo.HeaderText = "Ship To";
            this.ShipTo.Name = "ShipTo";
            this.ShipTo.ReadOnly = true;
            this.ShipTo.Width = 70;
            // 
            // CajaEnvio
            // 
            this.CajaEnvio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.CajaEnvio.DataPropertyName = "cajaEnvio";
            this.CajaEnvio.HeaderText = "Caja Envio";
            this.CajaEnvio.Name = "CajaEnvio";
            this.CajaEnvio.ReadOnly = true;
            // 
            // PesoNeto
            // 
            this.PesoNeto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.PesoNeto.DataPropertyName = "pesoNeto";
            this.PesoNeto.HeaderText = "Peso Neto";
            this.PesoNeto.Name = "PesoNeto";
            this.PesoNeto.ReadOnly = true;
            this.PesoNeto.Width = 90;
            // 
            // PesoBruto
            // 
            this.PesoBruto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.PesoBruto.DataPropertyName = "pesoBruto";
            this.PesoBruto.HeaderText = "Peso Bruto";
            this.PesoBruto.Name = "PesoBruto";
            this.PesoBruto.ReadOnly = true;
            this.PesoBruto.Width = 90;
            // 
            // CountryR
            // 
            this.CountryR.DataPropertyName = "country";
            this.CountryR.HeaderText = "Country";
            this.CountryR.Name = "CountryR";
            this.CountryR.ReadOnly = true;
            // 
            // StateR
            // 
            this.StateR.DataPropertyName = "state";
            this.StateR.HeaderText = "State";
            this.StateR.Name = "StateR";
            this.StateR.ReadOnly = true;
            // 
            // CityR
            // 
            this.CityR.DataPropertyName = "city";
            this.CityR.HeaderText = "City";
            this.CityR.Name = "CityR";
            this.CityR.ReadOnly = true;
            // 
            // AddressR
            // 
            this.AddressR.DataPropertyName = "address";
            this.AddressR.HeaderText = "Address";
            this.AddressR.Name = "AddressR";
            this.AddressR.ReadOnly = true;
            // 
            // ZipCodeR
            // 
            this.ZipCodeR.DataPropertyName = "zipCode";
            this.ZipCodeR.HeaderText = "ZipCode";
            this.ZipCodeR.Name = "ZipCodeR";
            this.ZipCodeR.ReadOnly = true;
            // 
            // ContactR
            // 
            this.ContactR.DataPropertyName = "contact";
            this.ContactR.HeaderText = "Contact";
            this.ContactR.Name = "ContactR";
            this.ContactR.ReadOnly = true;
            // 
            // EmailR
            // 
            this.EmailR.DataPropertyName = "email";
            this.EmailR.HeaderText = "Email";
            this.EmailR.Name = "EmailR";
            this.EmailR.ReadOnly = true;
            // 
            // PhoneR
            // 
            this.PhoneR.DataPropertyName = "phone";
            this.PhoneR.HeaderText = "Phone";
            this.PhoneR.Name = "PhoneR";
            this.PhoneR.ReadOnly = true;
            // 
            // ClientR
            // 
            this.ClientR.DataPropertyName = "client";
            this.ClientR.HeaderText = "Client";
            this.ClientR.Name = "ClientR";
            this.ClientR.ReadOnly = true;
            // 
            // dataDetail
            // 
            this.dataDetail.AllowUserToAddRows = false;
            this.dataDetail.AllowUserToDeleteRows = false;
            this.dataDetail.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(237)))), ((int)(((byte)(237)))));
            this.dataDetail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataDetail.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataDetail.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(145)))), ((int)(((byte)(45)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Calibri", 9.75F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataDetail.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dataDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.ShipmentCod,
            this.Box,
            this.Euid,
            this.IndEuid,
            this.FechaPacking,
            this.TotalWeight,
            this.TotalKernels,
            this.TotalEars,
            this.ShipT,
            this.Country,
            this.Location,
            this.ExpName,
            this.Bc1,
            this.Bc2,
            this.Bc3,
            this.Bc4,
            this.ProjectLead,
            this.Cc,
            this.Crop,
            this.Obs,
            this.Client,
            this.Event,
            this.Sag,
            this.CodInternacion,
            this.CodReception});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(176)))), ((int)(((byte)(62)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Calibri", 9.75F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataDetail.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataDetail.EnableHeadersVisualStyles = false;
            this.dataDetail.Location = new System.Drawing.Point(3, 231);
            this.dataDetail.Name = "dataDetail";
            this.dataDetail.ReadOnly = true;
            this.dataDetail.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(176)))), ((int)(((byte)(62)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Calibri", 9.75F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataDetail.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dataDetail.RowHeadersVisible = false;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(176)))), ((int)(((byte)(62)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            this.dataDetail.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dataDetail.Size = new System.Drawing.Size(1001, 258);
            this.dataDetail.TabIndex = 13;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn1.HeaderText = "Id";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // ShipmentCod
            // 
            this.ShipmentCod.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ShipmentCod.DataPropertyName = "shipmentCode";
            this.ShipmentCod.HeaderText = "Shipment Code";
            this.ShipmentCod.Name = "ShipmentCod";
            this.ShipmentCod.ReadOnly = true;
            this.ShipmentCod.Width = 65;
            // 
            // Box
            // 
            this.Box.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Box.DataPropertyName = "cajaEnvio";
            this.Box.HeaderText = "Box";
            this.Box.Name = "Box";
            this.Box.ReadOnly = true;
            this.Box.Width = 70;
            // 
            // Euid
            // 
            this.Euid.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Euid.DataPropertyName = "euid";
            this.Euid.HeaderText = "Euid";
            this.Euid.Name = "Euid";
            this.Euid.ReadOnly = true;
            this.Euid.Width = 70;
            // 
            // IndEuid
            // 
            this.IndEuid.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.IndEuid.DataPropertyName = "indEuid";
            this.IndEuid.HeaderText = "Ind Euid";
            this.IndEuid.Name = "IndEuid";
            this.IndEuid.ReadOnly = true;
            this.IndEuid.Width = 90;
            // 
            // FechaPacking
            // 
            this.FechaPacking.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.FechaPacking.DataPropertyName = "fechaPacking";
            this.FechaPacking.HeaderText = "FechaPacking";
            this.FechaPacking.Name = "FechaPacking";
            this.FechaPacking.ReadOnly = true;
            this.FechaPacking.Visible = false;
            // 
            // TotalWeight
            // 
            this.TotalWeight.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.TotalWeight.DataPropertyName = "totalWeight";
            this.TotalWeight.HeaderText = "Total Weight";
            this.TotalWeight.Name = "TotalWeight";
            this.TotalWeight.ReadOnly = true;
            this.TotalWeight.Width = 50;
            // 
            // TotalKernels
            // 
            this.TotalKernels.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.TotalKernels.DataPropertyName = "totalKernels";
            this.TotalKernels.HeaderText = "Total Kernels";
            this.TotalKernels.Name = "TotalKernels";
            this.TotalKernels.ReadOnly = true;
            this.TotalKernels.Width = 50;
            // 
            // TotalEars
            // 
            this.TotalEars.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.TotalEars.DataPropertyName = "totalEar";
            this.TotalEars.HeaderText = "Total Ears";
            this.TotalEars.Name = "TotalEars";
            this.TotalEars.ReadOnly = true;
            this.TotalEars.Width = 50;
            // 
            // ShipT
            // 
            this.ShipT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ShipT.DataPropertyName = "shipTo";
            this.ShipT.HeaderText = "Ship To";
            this.ShipT.Name = "ShipT";
            this.ShipT.ReadOnly = true;
            this.ShipT.Width = 50;
            // 
            // Country
            // 
            this.Country.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Country.DataPropertyName = "country";
            this.Country.HeaderText = "Country";
            this.Country.Name = "Country";
            this.Country.ReadOnly = true;
            this.Country.Width = 55;
            // 
            // Location
            // 
            this.Location.DataPropertyName = "location";
            this.Location.HeaderText = "Location";
            this.Location.Name = "Location";
            this.Location.ReadOnly = true;
            // 
            // ExpName
            // 
            this.ExpName.DataPropertyName = "expName";
            this.ExpName.HeaderText = "Exp Name";
            this.ExpName.Name = "ExpName";
            this.ExpName.ReadOnly = true;
            // 
            // Bc1
            // 
            this.Bc1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Bc1.DataPropertyName = "bc1";
            this.Bc1.HeaderText = "Breeders Code 1";
            this.Bc1.Name = "Bc1";
            this.Bc1.ReadOnly = true;
            // 
            // Bc2
            // 
            this.Bc2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Bc2.DataPropertyName = "bc2";
            this.Bc2.HeaderText = "Breeders Code 2";
            this.Bc2.Name = "Bc2";
            this.Bc2.ReadOnly = true;
            // 
            // Bc3
            // 
            this.Bc3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Bc3.DataPropertyName = "bc3";
            this.Bc3.HeaderText = "Breeders Code 3";
            this.Bc3.Name = "Bc3";
            this.Bc3.ReadOnly = true;
            // 
            // Bc4
            // 
            this.Bc4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Bc4.DataPropertyName = "bc4";
            this.Bc4.HeaderText = "Breeders Code 4";
            this.Bc4.Name = "Bc4";
            this.Bc4.ReadOnly = true;
            // 
            // ProjectLead
            // 
            this.ProjectLead.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ProjectLead.DataPropertyName = "projectLead";
            this.ProjectLead.HeaderText = "Project Lead";
            this.ProjectLead.Name = "ProjectLead";
            this.ProjectLead.ReadOnly = true;
            this.ProjectLead.Width = 90;
            // 
            // Cc
            // 
            this.Cc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Cc.DataPropertyName = "cc";
            this.Cc.HeaderText = "Cc";
            this.Cc.Name = "Cc";
            this.Cc.ReadOnly = true;
            // 
            // Crop
            // 
            this.Crop.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Crop.DataPropertyName = "crop";
            this.Crop.HeaderText = "Crop";
            this.Crop.Name = "Crop";
            this.Crop.ReadOnly = true;
            this.Crop.Width = 80;
            // 
            // Obs
            // 
            this.Obs.DataPropertyName = "obs";
            this.Obs.HeaderText = "Obs";
            this.Obs.Name = "Obs";
            this.Obs.ReadOnly = true;
            // 
            // Client
            // 
            this.Client.DataPropertyName = "client";
            this.Client.HeaderText = "Client";
            this.Client.Name = "Client";
            this.Client.ReadOnly = true;
            // 
            // Event
            // 
            this.Event.DataPropertyName = "gmoEvent";
            this.Event.HeaderText = "Event";
            this.Event.Name = "Event";
            this.Event.ReadOnly = true;
            // 
            // Sag
            // 
            this.Sag.DataPropertyName = "sag";
            this.Sag.HeaderText = "Sag";
            this.Sag.Name = "Sag";
            this.Sag.ReadOnly = true;
            // 
            // CodInternacion
            // 
            this.CodInternacion.DataPropertyName = "codInternation";
            this.CodInternacion.HeaderText = "Cod Internacion";
            this.CodInternacion.Name = "CodInternacion";
            this.CodInternacion.ReadOnly = true;
            // 
            // CodReception
            // 
            this.CodReception.DataPropertyName = "codReception";
            this.CodReception.HeaderText = "Cod Reception";
            this.CodReception.Name = "CodReception";
            this.CodReception.ReadOnly = true;
            // 
            // pnlEmail
            // 
            this.pnlEmail.Controls.Add(this.cboEmail);
            this.pnlEmail.Controls.Add(this.label4);
            this.pnlEmail.Controls.Add(this.btnEnvio);
            this.pnlEmail.Controls.Add(this.txtMensaje);
            this.pnlEmail.Controls.Add(this.label3);
            this.pnlEmail.Controls.Add(this.txtEmail);
            this.pnlEmail.Controls.Add(this.label2);
            this.pnlEmail.Location = new System.Drawing.Point(581, 81);
            this.pnlEmail.Name = "pnlEmail";
            this.pnlEmail.Size = new System.Drawing.Size(423, 117);
            this.pnlEmail.TabIndex = 19;
            this.pnlEmail.Visible = false;
            // 
            // cboEmail
            // 
            this.cboEmail.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEmail.FormattingEnabled = true;
            this.cboEmail.Location = new System.Drawing.Point(103, 5);
            this.cboEmail.Name = "cboEmail";
            this.cboEmail.Size = new System.Drawing.Size(300, 23);
            this.cboEmail.TabIndex = 28;
            this.cboEmail.SelectedIndexChanged += new System.EventHandler(this.cboEmail_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 15);
            this.label4.TabIndex = 27;
            this.label4.Text = "Email Destino:";
            // 
            // btnEnvio
            // 
            this.btnEnvio.FlatAppearance.BorderSize = 0;
            this.btnEnvio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnvio.Image = global::Layer.Win.Properties.Resources.send_24;
            this.btnEnvio.Location = new System.Drawing.Point(15, 87);
            this.btnEnvio.Name = "btnEnvio";
            this.btnEnvio.Size = new System.Drawing.Size(36, 23);
            this.btnEnvio.TabIndex = 26;
            this.btnEnvio.UseVisualStyleBackColor = true;
            this.btnEnvio.Click += new System.EventHandler(this.btnEnvio_Click);
            // 
            // txtMensaje
            // 
            this.txtMensaje.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMensaje.Location = new System.Drawing.Point(103, 56);
            this.txtMensaje.Multiline = true;
            this.txtMensaje.Name = "txtMensaje";
            this.txtMensaje.Size = new System.Drawing.Size(307, 54);
            this.txtMensaje.TabIndex = 25;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 15);
            this.label3.TabIndex = 24;
            this.label3.Text = "Mensaje:";
            // 
            // txtEmail
            // 
            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmail.Location = new System.Drawing.Point(103, 34);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(307, 23);
            this.txtEmail.TabIndex = 23;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 15);
            this.label2.TabIndex = 22;
            this.label2.Text = "Email Destino:";
            // 
            // btnEnviar
            // 
            this.btnEnviar.FlatAppearance.BorderSize = 0;
            this.btnEnviar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnviar.Image = global::Layer.Win.Properties.Resources.email_24;
            this.btnEnviar.Location = new System.Drawing.Point(890, 37);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(44, 36);
            this.btnEnviar.TabIndex = 16;
            this.btnEnviar.UseVisualStyleBackColor = true;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.FlatAppearance.BorderSize = 0;
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.Image = global::Layer.Win.Properties.Resources.escobilla_24;
            this.btnLimpiar.Location = new System.Drawing.Point(940, 37);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(44, 36);
            this.btnLimpiar.TabIndex = 15;
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnExportar
            // 
            this.btnExportar.FlatAppearance.BorderSize = 0;
            this.btnExportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportar.Image = global::Layer.Win.Properties.Resources.excel_24;
            this.btnExportar.Location = new System.Drawing.Point(840, 39);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(44, 36);
            this.btnExportar.TabIndex = 14;
            this.btnExportar.UseVisualStyleBackColor = true;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Image = global::Layer.Win.Properties.Resources.lupa_16;
            this.btnBuscar.Location = new System.Drawing.Point(245, 52);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(42, 23);
            this.btnBuscar.TabIndex = 2;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Franklin Gothic Medium", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(38, 5);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(121, 24);
            this.label10.TabIndex = 52;
            this.label10.Text = "Packing List";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Layer.Win.Properties.Resources.supermercado_64;
            this.pictureBox2.Location = new System.Drawing.Point(3, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(29, 31);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 51;
            this.pictureBox2.TabStop = false;
            // 
            // lblTotalResumen
            // 
            this.lblTotalResumen.AutoSize = true;
            this.lblTotalResumen.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblTotalResumen.ForeColor = System.Drawing.Color.Black;
            this.lblTotalResumen.Location = new System.Drawing.Point(543, 81);
            this.lblTotalResumen.Name = "lblTotalResumen";
            this.lblTotalResumen.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblTotalResumen.Size = new System.Drawing.Size(20, 23);
            this.lblTotalResumen.TabIndex = 54;
            this.lblTotalResumen.Text = "0";
            this.lblTotalResumen.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(469, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 23);
            this.label5.TabIndex = 53;
            this.label5.Text = "TOTAL :";
            // 
            // lblTotalDetalle
            // 
            this.lblTotalDetalle.AutoSize = true;
            this.lblTotalDetalle.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblTotalDetalle.ForeColor = System.Drawing.Color.Black;
            this.lblTotalDetalle.Location = new System.Drawing.Point(73, 495);
            this.lblTotalDetalle.Name = "lblTotalDetalle";
            this.lblTotalDetalle.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblTotalDetalle.Size = new System.Drawing.Size(20, 23);
            this.lblTotalDetalle.TabIndex = 56;
            this.lblTotalDetalle.Text = "0";
            this.lblTotalDetalle.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(-1, 495);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 23);
            this.label6.TabIndex = 55;
            this.label6.Text = "TOTAL :";
            // 
            // FrmPackingList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(237)))), ((int)(((byte)(237)))));
            this.ClientSize = new System.Drawing.Size(1008, 524);
            this.Controls.Add(this.lblTotalDetalle);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblTotalResumen);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pnlEmail);
            this.Controls.Add(this.btnEnviar);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.dataDetail);
            this.Controls.Add(this.dataBox);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.cboShipment);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPackingList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Packing List";
            this.Load += new System.EventHandler(this.FrmPackingList_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FrmPackingList_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.dataBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataDetail)).EndInit();
            this.pnlEmail.ResumeLayout(false);
            this.pnlEmail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboShipment;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.DataGridView dataBox;
        private System.Windows.Forms.DataGridView dataDetail;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnEnviar;
        private System.Windows.Forms.Panel pnlEmail;
        private System.Windows.Forms.Button btnEnvio;
        private System.Windows.Forms.TextBox txtMensaje;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lblTotalResumen;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblTotalDetalle;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaEnvio;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShipTo;
        private System.Windows.Forms.DataGridViewTextBoxColumn CajaEnvio;
        private System.Windows.Forms.DataGridViewTextBoxColumn PesoNeto;
        private System.Windows.Forms.DataGridViewTextBoxColumn PesoBruto;
        private System.Windows.Forms.DataGridViewTextBoxColumn CountryR;
        private System.Windows.Forms.DataGridViewTextBoxColumn StateR;
        private System.Windows.Forms.DataGridViewTextBoxColumn CityR;
        private System.Windows.Forms.DataGridViewTextBoxColumn AddressR;
        private System.Windows.Forms.DataGridViewTextBoxColumn ZipCodeR;
        private System.Windows.Forms.DataGridViewTextBoxColumn ContactR;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmailR;
        private System.Windows.Forms.DataGridViewTextBoxColumn PhoneR;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClientR;
        private System.Windows.Forms.ComboBox cboEmail;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShipmentCod;
        private System.Windows.Forms.DataGridViewTextBoxColumn Box;
        private System.Windows.Forms.DataGridViewTextBoxColumn Euid;
        private System.Windows.Forms.DataGridViewTextBoxColumn IndEuid;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaPacking;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalWeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalKernels;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalEars;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShipT;
        private System.Windows.Forms.DataGridViewTextBoxColumn Country;
        private System.Windows.Forms.DataGridViewTextBoxColumn Location;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExpName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bc1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bc2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bc3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bc4;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProjectLead;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cc;
        private System.Windows.Forms.DataGridViewTextBoxColumn Crop;
        private System.Windows.Forms.DataGridViewTextBoxColumn Obs;
        private System.Windows.Forms.DataGridViewTextBoxColumn Client;
        private System.Windows.Forms.DataGridViewTextBoxColumn Event;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sag;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodInternacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodReception;
    }
}