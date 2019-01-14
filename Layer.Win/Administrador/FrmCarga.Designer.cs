namespace Layer.Win.Administrador
{
    partial class FrmCarga
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label2 = new System.Windows.Forms.Label();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.label3 = new System.Windows.Forms.Label();
            this.lblFile = new System.Windows.Forms.Label();
            this.dataRows = new System.Windows.Forms.DataGridView();
            this.lblRows = new System.Windows.Forms.Label();
            this.btnProceso = new System.Windows.Forms.PictureBox();
            this.btnFile = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlEmail = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.lineShape1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.lblModificadas = new System.Windows.Forms.Label();
            this.lblTotalFilas = new System.Windows.Forms.Label();
            this.lblInsertadas = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataRows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnProceso)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnFile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlEmail.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Franklin Gothic Medium", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(38, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 24);
            this.label2.TabIndex = 12;
            this.label2.Text = "Carga Archivo";
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(46, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 15);
            this.label3.TabIndex = 19;
            this.label3.Text = "Archivo :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFile
            // 
            this.lblFile.AutoSize = true;
            this.lblFile.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFile.Location = new System.Drawing.Point(107, 60);
            this.lblFile.Name = "lblFile";
            this.lblFile.Size = new System.Drawing.Size(10, 15);
            this.lblFile.TabIndex = 20;
            this.lblFile.Text = ".";
            this.lblFile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dataRows
            // 
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(176)))), ((int)(((byte)(62)))));
            this.dataRows.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle11;
            this.dataRows.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(176)))), ((int)(((byte)(62)))));
            this.dataRows.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataRows.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(176)))), ((int)(((byte)(62)))));
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataRows.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.dataRows.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(176)))), ((int)(((byte)(62)))));
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataRows.DefaultCellStyle = dataGridViewCellStyle13;
            this.dataRows.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(176)))), ((int)(((byte)(62)))));
            this.dataRows.Location = new System.Drawing.Point(7, 136);
            this.dataRows.Name = "dataRows";
            this.dataRows.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.AppWorkspace;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataRows.RowHeadersDefaultCellStyle = dataGridViewCellStyle14;
            this.dataRows.RowHeadersVisible = false;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(176)))), ((int)(((byte)(62)))));
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataRows.RowsDefaultCellStyle = dataGridViewCellStyle15;
            this.dataRows.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataRows.Size = new System.Drawing.Size(972, 355);
            this.dataRows.TabIndex = 21;
            // 
            // lblRows
            // 
            this.lblRows.AutoSize = true;
            this.lblRows.Font = new System.Drawing.Font("Calibri", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRows.Location = new System.Drawing.Point(559, 60);
            this.lblRows.Name = "lblRows";
            this.lblRows.Size = new System.Drawing.Size(10, 15);
            this.lblRows.TabIndex = 22;
            this.lblRows.Text = ".";
            this.lblRows.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnProceso
            // 
            this.btnProceso.Image = global::Layer.Win.Properties.Resources.proceso_32;
            this.btnProceso.Location = new System.Drawing.Point(682, 51);
            this.btnProceso.Name = "btnProceso";
            this.btnProceso.Size = new System.Drawing.Size(37, 34);
            this.btnProceso.TabIndex = 23;
            this.btnProceso.TabStop = false;
            this.btnProceso.Click += new System.EventHandler(this.btnProceso_Click);
            // 
            // btnFile
            // 
            this.btnFile.Image = global::Layer.Win.Properties.Resources.carpeta_32;
            this.btnFile.Location = new System.Drawing.Point(3, 51);
            this.btnFile.Name = "btnFile";
            this.btnFile.Size = new System.Drawing.Size(37, 34);
            this.btnFile.TabIndex = 16;
            this.btnFile.TabStop = false;
            this.btnFile.Click += new System.EventHandler(this.pctFile_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Layer.Win.Properties.Resources.carpeta_2_32;
            this.pictureBox2.Location = new System.Drawing.Point(3, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(29, 31);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 14;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Layer.Win.Properties.Resources.if_icon_close_round_211651;
            this.pictureBox1.Location = new System.Drawing.Point(969, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(15, 15);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pnlEmail
            // 
            this.pnlEmail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(176)))), ((int)(((byte)(62)))));
            this.pnlEmail.Controls.Add(this.lblInsertadas);
            this.pnlEmail.Controls.Add(this.lblTotalFilas);
            this.pnlEmail.Controls.Add(this.lblModificadas);
            this.pnlEmail.Controls.Add(this.label6);
            this.pnlEmail.Controls.Add(this.label1);
            this.pnlEmail.Controls.Add(this.label4);
            this.pnlEmail.Controls.Add(this.label5);
            this.pnlEmail.Controls.Add(this.shapeContainer1);
            this.pnlEmail.Location = new System.Drawing.Point(725, 5);
            this.pnlEmail.Name = "pnlEmail";
            this.pnlEmail.Size = new System.Drawing.Size(237, 117);
            this.pnlEmail.TabIndex = 55;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(76, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 14);
            this.label1.TabIndex = 29;
            this.label1.Text = "Resumen Carga";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 14);
            this.label4.TabIndex = 24;
            this.label4.Text = "N° Filas Insertadas";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(118, 14);
            this.label5.TabIndex = 22;
            this.label5.Text = "N° Filas Modificadas";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(3, 46);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 14);
            this.label6.TabIndex = 30;
            this.label6.Text = "N° Total Filas";
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.lineShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(237, 117);
            this.shapeContainer1.TabIndex = 31;
            this.shapeContainer1.TabStop = false;
            // 
            // lineShape1
            // 
            this.lineShape1.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            this.lineShape1.Name = "lineShape1";
            this.lineShape1.X1 = 75;
            this.lineShape1.X2 = 161;
            this.lineShape1.Y1 = 26;
            this.lineShape1.Y2 = 26;
            // 
            // lblModificadas
            // 
            this.lblModificadas.AutoSize = true;
            this.lblModificadas.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModificadas.Location = new System.Drawing.Point(127, 68);
            this.lblModificadas.Name = "lblModificadas";
            this.lblModificadas.Size = new System.Drawing.Size(10, 14);
            this.lblModificadas.TabIndex = 32;
            this.lblModificadas.Text = ".";
            // 
            // lblTotalFilas
            // 
            this.lblTotalFilas.AutoSize = true;
            this.lblTotalFilas.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalFilas.Location = new System.Drawing.Point(127, 46);
            this.lblTotalFilas.Name = "lblTotalFilas";
            this.lblTotalFilas.Size = new System.Drawing.Size(10, 14);
            this.lblTotalFilas.TabIndex = 33;
            this.lblTotalFilas.Text = ".";
            // 
            // lblInsertadas
            // 
            this.lblInsertadas.AutoSize = true;
            this.lblInsertadas.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInsertadas.Location = new System.Drawing.Point(127, 89);
            this.lblInsertadas.Name = "lblInsertadas";
            this.lblInsertadas.Size = new System.Drawing.Size(10, 14);
            this.lblInsertadas.TabIndex = 34;
            this.lblInsertadas.Text = ".";
            // 
            // FrmCarga
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(176)))), ((int)(((byte)(62)))));
            this.ClientSize = new System.Drawing.Size(987, 495);
            this.Controls.Add(this.pnlEmail);
            this.Controls.Add(this.btnProceso);
            this.Controls.Add(this.lblRows);
            this.Controls.Add(this.dataRows);
            this.Controls.Add(this.lblFile);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnFile);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmCarga";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmCarga";
            this.Load += new System.EventHandler(this.FrmCarga_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FrmCarga_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.dataRows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnProceso)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnFile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlEmail.ResumeLayout(false);
            this.pnlEmail.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.PictureBox btnFile;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblFile;
        private System.Windows.Forms.DataGridView dataRows;
        private System.Windows.Forms.Label lblRows;
        private System.Windows.Forms.PictureBox btnProceso;
        private System.Windows.Forms.Panel pnlEmail;
        private System.Windows.Forms.Label lblInsertadas;
        private System.Windows.Forms.Label lblTotalFilas;
        private System.Windows.Forms.Label lblModificadas;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape1;
    }
}