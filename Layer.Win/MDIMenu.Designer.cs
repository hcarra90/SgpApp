namespace Layer.Win
{
    partial class MDIMenu
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MDIMenu));
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.btnTracking = new System.Windows.Forms.Button();
            this.btnPackingList = new System.Windows.Forms.Button();
            this.btnEnvio = new System.Windows.Forms.Button();
            this.btnLlenado = new System.Windows.Forms.Button();
            this.btnPacking = new System.Windows.Forms.Button();
            this.btnDesgrane = new System.Windows.Forms.Button();
            this.btnSecado = new System.Windows.Forms.Button();
            this.btnCosecha = new System.Windows.Forms.Button();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.stpUsuario = new System.Windows.Forms.ToolStripStatusLabel();
            this.stpSeparador1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.stpLabelPerfil = new System.Windows.Forms.ToolStripStatusLabel();
            this.stPerfil = new System.Windows.Forms.ToolStripStatusLabel();
            this.mnuBar = new System.Windows.Forms.MenuStrip();
            this.cosechaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.movimientoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.secadoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.movimientoToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.desgraneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.movimientoToolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.packingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.movimientoToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.envioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.movimientoToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.envioDeCajaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pesoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.packingListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trackingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.statusStrip.SuspendLayout();
            this.mnuBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnTracking
            // 
            this.btnTracking.Image = global::Layer.Win.Properties.Resources.Tracking1;
            this.btnTracking.Location = new System.Drawing.Point(480, 170);
            this.btnTracking.Name = "btnTracking";
            this.btnTracking.Size = new System.Drawing.Size(128, 128);
            this.btnTracking.TabIndex = 17;
            this.toolTip.SetToolTip(this.btnTracking, "Tracking");
            this.btnTracking.UseVisualStyleBackColor = true;
            this.btnTracking.Click += new System.EventHandler(this.btnTracking_Click);
            // 
            // btnPackingList
            // 
            this.btnPackingList.Image = global::Layer.Win.Properties.Resources.PackingList;
            this.btnPackingList.Location = new System.Drawing.Point(480, 36);
            this.btnPackingList.Name = "btnPackingList";
            this.btnPackingList.Size = new System.Drawing.Size(128, 128);
            this.btnPackingList.TabIndex = 16;
            this.toolTip.SetToolTip(this.btnPackingList, "Packing List");
            this.btnPackingList.UseVisualStyleBackColor = true;
            this.btnPackingList.Click += new System.EventHandler(this.btnPackingList_Click);
            // 
            // btnEnvio
            // 
            this.btnEnvio.Image = global::Layer.Win.Properties.Resources.shippingBox;
            this.btnEnvio.Location = new System.Drawing.Point(308, 170);
            this.btnEnvio.Name = "btnEnvio";
            this.btnEnvio.Size = new System.Drawing.Size(128, 128);
            this.btnEnvio.TabIndex = 14;
            this.toolTip.SetToolTip(this.btnEnvio, "Envío Caja");
            this.btnEnvio.UseVisualStyleBackColor = true;
            this.btnEnvio.Click += new System.EventHandler(this.btnEnvio_Click);
            // 
            // btnLlenado
            // 
            this.btnLlenado.Image = global::Layer.Win.Properties.Resources.fillBox;
            this.btnLlenado.Location = new System.Drawing.Point(308, 36);
            this.btnLlenado.Name = "btnLlenado";
            this.btnLlenado.Size = new System.Drawing.Size(128, 128);
            this.btnLlenado.TabIndex = 13;
            this.toolTip.SetToolTip(this.btnLlenado, "Llenado Caja");
            this.btnLlenado.UseVisualStyleBackColor = true;
            this.btnLlenado.Click += new System.EventHandler(this.btnLlenado_Click);
            // 
            // btnPacking
            // 
            this.btnPacking.Image = global::Layer.Win.Properties.Resources.CornBox;
            this.btnPacking.Location = new System.Drawing.Point(141, 170);
            this.btnPacking.Name = "btnPacking";
            this.btnPacking.Size = new System.Drawing.Size(128, 128);
            this.btnPacking.TabIndex = 10;
            this.toolTip.SetToolTip(this.btnPacking, "Packing");
            this.btnPacking.UseVisualStyleBackColor = true;
            this.btnPacking.Click += new System.EventHandler(this.btnPacking_Click);
            // 
            // btnDesgrane
            // 
            this.btnDesgrane.Image = global::Layer.Win.Properties.Resources.desgrane;
            this.btnDesgrane.Location = new System.Drawing.Point(8, 170);
            this.btnDesgrane.Name = "btnDesgrane";
            this.btnDesgrane.Size = new System.Drawing.Size(128, 128);
            this.btnDesgrane.TabIndex = 9;
            this.toolTip.SetToolTip(this.btnDesgrane, "Desgrane");
            this.btnDesgrane.UseVisualStyleBackColor = true;
            this.btnDesgrane.Click += new System.EventHandler(this.btnDesgrane_Click);
            // 
            // btnSecado
            // 
            this.btnSecado.Image = global::Layer.Win.Properties.Resources.CornDry;
            this.btnSecado.Location = new System.Drawing.Point(141, 36);
            this.btnSecado.Name = "btnSecado";
            this.btnSecado.Size = new System.Drawing.Size(128, 128);
            this.btnSecado.TabIndex = 8;
            this.toolTip.SetToolTip(this.btnSecado, "Secado");
            this.btnSecado.UseVisualStyleBackColor = true;
            this.btnSecado.Click += new System.EventHandler(this.btnSecado_Click);
            // 
            // btnCosecha
            // 
            this.btnCosecha.Image = global::Layer.Win.Properties.Resources.Harvest;
            this.btnCosecha.Location = new System.Drawing.Point(8, 36);
            this.btnCosecha.Name = "btnCosecha";
            this.btnCosecha.Size = new System.Drawing.Size(128, 128);
            this.btnCosecha.TabIndex = 7;
            this.toolTip.SetToolTip(this.btnCosecha, "Cosecha");
            this.btnCosecha.UseVisualStyleBackColor = true;
            this.btnCosecha.Click += new System.EventHandler(this.btnCosecha_Click);
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(114, 17);
            this.toolStripStatusLabel.Text = "Usuario Conectado: ";
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel,
            this.stpUsuario,
            this.stpSeparador1,
            this.stpLabelPerfil,
            this.stPerfil});
            this.statusStrip.Location = new System.Drawing.Point(0, 326);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(630, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "StatusStrip";
            // 
            // stpUsuario
            // 
            this.stpUsuario.Name = "stpUsuario";
            this.stpUsuario.Size = new System.Drawing.Size(118, 17);
            this.stpUsuario.Text = "toolStripStatusLabel1";
            this.stpUsuario.Click += new System.EventHandler(this.stpUsuario_Click);
            // 
            // stpSeparador1
            // 
            this.stpSeparador1.Name = "stpSeparador1";
            this.stpSeparador1.Size = new System.Drawing.Size(118, 17);
            this.stpSeparador1.Text = "toolStripStatusLabel1";
            // 
            // stpLabelPerfil
            // 
            this.stpLabelPerfil.Name = "stpLabelPerfil";
            this.stpLabelPerfil.Size = new System.Drawing.Size(40, 17);
            this.stpLabelPerfil.Text = "Perfil: ";
            // 
            // stPerfil
            // 
            this.stPerfil.Name = "stPerfil";
            this.stPerfil.Size = new System.Drawing.Size(118, 17);
            this.stPerfil.Text = "toolStripStatusLabel1";
            // 
            // mnuBar
            // 
            this.mnuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cosechaToolStripMenuItem,
            this.secadoToolStripMenuItem,
            this.desgraneToolStripMenuItem,
            this.packingToolStripMenuItem,
            this.envioToolStripMenuItem,
            this.consultasToolStripMenuItem});
            this.mnuBar.Location = new System.Drawing.Point(0, 0);
            this.mnuBar.Name = "mnuBar";
            this.mnuBar.Size = new System.Drawing.Size(924, 24);
            this.mnuBar.TabIndex = 4;
            this.mnuBar.Text = "menuStrip1";
            this.mnuBar.Visible = false;
            // 
            // cosechaToolStripMenuItem
            // 
            this.cosechaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.movimientoToolStripMenuItem});
            this.cosechaToolStripMenuItem.Name = "cosechaToolStripMenuItem";
            this.cosechaToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.cosechaToolStripMenuItem.Text = "&Cosecha";
            // 
            // movimientoToolStripMenuItem
            // 
            this.movimientoToolStripMenuItem.Image = global::Layer.Win.Properties.Resources.vegetales;
            this.movimientoToolStripMenuItem.Name = "movimientoToolStripMenuItem";
            this.movimientoToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.movimientoToolStripMenuItem.Text = "Movimiento";
            this.movimientoToolStripMenuItem.Click += new System.EventHandler(this.movimientoToolStripMenuItem_Click);
            // 
            // secadoToolStripMenuItem
            // 
            this.secadoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.movimientoToolStripMenuItem3});
            this.secadoToolStripMenuItem.Name = "secadoToolStripMenuItem";
            this.secadoToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.secadoToolStripMenuItem.Text = "&Secado";
            // 
            // movimientoToolStripMenuItem3
            // 
            this.movimientoToolStripMenuItem3.Image = global::Layer.Win.Properties.Resources.Dryer;
            this.movimientoToolStripMenuItem3.Name = "movimientoToolStripMenuItem3";
            this.movimientoToolStripMenuItem3.Size = new System.Drawing.Size(139, 22);
            this.movimientoToolStripMenuItem3.Text = "Movimiento";
            this.movimientoToolStripMenuItem3.Click += new System.EventHandler(this.movimientoToolStripMenuItem3_Click);
            // 
            // desgraneToolStripMenuItem
            // 
            this.desgraneToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.movimientoToolStripMenuItem4});
            this.desgraneToolStripMenuItem.Name = "desgraneToolStripMenuItem";
            this.desgraneToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.desgraneToolStripMenuItem.Text = "&Desgrane";
            // 
            // movimientoToolStripMenuItem4
            // 
            this.movimientoToolStripMenuItem4.Image = global::Layer.Win.Properties.Resources.corn;
            this.movimientoToolStripMenuItem4.Name = "movimientoToolStripMenuItem4";
            this.movimientoToolStripMenuItem4.Size = new System.Drawing.Size(139, 22);
            this.movimientoToolStripMenuItem4.Text = "Movimiento";
            this.movimientoToolStripMenuItem4.Click += new System.EventHandler(this.movimientoToolStripMenuItem4_Click);
            // 
            // packingToolStripMenuItem
            // 
            this.packingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.movimientoToolStripMenuItem1});
            this.packingToolStripMenuItem.Name = "packingToolStripMenuItem";
            this.packingToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.packingToolStripMenuItem.Text = "&Packing";
            // 
            // movimientoToolStripMenuItem1
            // 
            this.movimientoToolStripMenuItem1.Image = global::Layer.Win.Properties.Resources.packing;
            this.movimientoToolStripMenuItem1.Name = "movimientoToolStripMenuItem1";
            this.movimientoToolStripMenuItem1.Size = new System.Drawing.Size(139, 22);
            this.movimientoToolStripMenuItem1.Text = "Movimiento";
            this.movimientoToolStripMenuItem1.Click += new System.EventHandler(this.movimientoToolStripMenuItem1_Click);
            // 
            // envioToolStripMenuItem
            // 
            this.envioToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.movimientoToolStripMenuItem2,
            this.envioDeCajaToolStripMenuItem,
            this.pesoToolStripMenuItem});
            this.envioToolStripMenuItem.Name = "envioToolStripMenuItem";
            this.envioToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.envioToolStripMenuItem.Text = "&Shipping";
            this.envioToolStripMenuItem.Click += new System.EventHandler(this.envioToolStripMenuItem_Click);
            // 
            // movimientoToolStripMenuItem2
            // 
            this.movimientoToolStripMenuItem2.Image = global::Layer.Win.Properties.Resources.shipping;
            this.movimientoToolStripMenuItem2.Name = "movimientoToolStripMenuItem2";
            this.movimientoToolStripMenuItem2.Size = new System.Drawing.Size(146, 22);
            this.movimientoToolStripMenuItem2.Text = "Movimiento";
            this.movimientoToolStripMenuItem2.Click += new System.EventHandler(this.movimientoToolStripMenuItem2_Click);
            // 
            // envioDeCajaToolStripMenuItem
            // 
            this.envioDeCajaToolStripMenuItem.Image = global::Layer.Win.Properties.Resources.envio;
            this.envioDeCajaToolStripMenuItem.Name = "envioDeCajaToolStripMenuItem";
            this.envioDeCajaToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.envioDeCajaToolStripMenuItem.Text = "Envio De Caja";
            this.envioDeCajaToolStripMenuItem.Click += new System.EventHandler(this.envioDeCajaToolStripMenuItem_Click);
            // 
            // pesoToolStripMenuItem
            // 
            this.pesoToolStripMenuItem.Name = "pesoToolStripMenuItem";
            this.pesoToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.pesoToolStripMenuItem.Text = "Peso";
            this.pesoToolStripMenuItem.Click += new System.EventHandler(this.pesoToolStripMenuItem_Click);
            // 
            // consultasToolStripMenuItem
            // 
            this.consultasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.packingListToolStripMenuItem,
            this.trackingToolStripMenuItem});
            this.consultasToolStripMenuItem.Name = "consultasToolStripMenuItem";
            this.consultasToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.consultasToolStripMenuItem.Text = "&Consultas";
            // 
            // packingListToolStripMenuItem
            // 
            this.packingListToolStripMenuItem.Image = global::Layer.Win.Properties.Resources.reporte;
            this.packingListToolStripMenuItem.Name = "packingListToolStripMenuItem";
            this.packingListToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.packingListToolStripMenuItem.Text = "P&acking List";
            this.packingListToolStripMenuItem.Click += new System.EventHandler(this.packingListToolStripMenuItem_Click);
            // 
            // trackingToolStripMenuItem
            // 
            this.trackingToolStripMenuItem.Image = global::Layer.Win.Properties.Resources.Tracking;
            this.trackingToolStripMenuItem.Name = "trackingToolStripMenuItem";
            this.trackingToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.trackingToolStripMenuItem.Text = "Tracking";
            this.trackingToolStripMenuItem.Click += new System.EventHandler(this.trackingToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.label1.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 23);
            this.label1.TabIndex = 11;
            this.label1.Text = "Movimientos";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.label2.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(304, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 23);
            this.label2.TabIndex = 12;
            this.label2.Text = "Shipping";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.label3.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(476, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 23);
            this.label3.TabIndex = 15;
            this.label3.Text = "Reportes";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.label4.Font = new System.Drawing.Font("Calibri", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 304);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "Versión:";
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblVersion.Font = new System.Drawing.Font("Calibri", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersion.Location = new System.Drawing.Point(63, 304);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(10, 13);
            this.lblVersion.TabIndex = 22;
            this.lblVersion.Text = ".";
            // 
            // MDIMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 348);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnTracking);
            this.Controls.Add(this.btnPackingList);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnEnvio);
            this.Controls.Add(this.btnLlenado);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnPacking);
            this.Controls.Add(this.btnDesgrane);
            this.Controls.Add(this.btnSecado);
            this.Controls.Add(this.btnCosecha);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.mnuBar);
            this.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MaximizeBox = false;
            this.Name = "MDIMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Control Proceso";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MDIMenu_FormClosing);
            this.Load += new System.EventHandler(this.MDIMenu_Load);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.mnuBar.ResumeLayout(false);
            this.mnuBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.MenuStrip mnuBar;
        private System.Windows.Forms.ToolStripMenuItem cosechaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem secadoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem desgraneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem packingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem envioToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel stpUsuario;
        private System.Windows.Forms.ToolStripStatusLabel stpSeparador1;
        private System.Windows.Forms.ToolStripStatusLabel stpLabelPerfil;
        private System.Windows.Forms.ToolStripStatusLabel stPerfil;
        private System.Windows.Forms.ToolStripMenuItem movimientoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem movimientoToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem movimientoToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem envioDeCajaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem packingListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem movimientoToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem movimientoToolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem trackingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pesoToolStripMenuItem;
        private System.Windows.Forms.Button btnCosecha;
        private System.Windows.Forms.Button btnSecado;
        private System.Windows.Forms.Button btnDesgrane;
        private System.Windows.Forms.Button btnPacking;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnLlenado;
        private System.Windows.Forms.Button btnEnvio;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnPackingList;
        private System.Windows.Forms.Button btnTracking;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblVersion;
    }
}



