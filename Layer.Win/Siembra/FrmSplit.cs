using Layer.Business;
using Layer.Entity;
using Layer.Entity.Dto;
using Layer.Functions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.SqlServer;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Layer.Win.Siembra
{
    public partial class FrmSplit : Form
    {
        #region -------Declaración-------
        string pathFile = "";
        public Usuario usuarioValido = new Usuario();
        List<SplitEuidDto> datos = new List<SplitEuidDto>();
        List<SplitEuidDto> SplitEuid = new List<SplitEuidDto>();
        List<EntryListDto> listData = new List<EntryListDto>();
        EntryList itemO = new EntryList();
        int progreso = 0, porciento = 0, totalEmpleadosProcesar = 0;
        string mensaje = "";
        BackgroundWorker bg = new BackgroundWorker();

        
        #endregion

        #region -------Constructor-------
        public FrmSplit()
        {
            InitializeComponent();
        }
        #endregion

        #region -------Eventos-------
        private void FrmSplit_Load(object sender, EventArgs e)
        {
            ConfiguraFormulario();
        }

        private void btnCarga_Click(object sender, EventArgs e)
        {
            CargaArchivo();
        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            GrabaDatos();
            this.Cursor = Cursors.Default;
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            ExportarData();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }
        private void BtnCargaSplit_Click(object sender, EventArgs e)
        {
            FrmUploadInfoFieldBook frm = new FrmUploadInfoFieldBook
            {
                usuarioValido = this.usuarioValido
            };
            frm.ShowDialog();
        }
        #endregion

        #region -------Funciones-------
        private void ConfiguraFormulario()
        {
            DataGridViewCellStyle style = grdResumen.ColumnHeadersDefaultCellStyle;
            style.Font = new Font(grdResumen.Font.FontFamily, 8.75F, FontStyle.Regular);

            style = grdDetalle.ColumnHeadersDefaultCellStyle;
            style.Font = new Font(grdDetalle.Font.FontFamily, 8.75F, FontStyle.Regular);
            ValidaTemplate();
        }

        private void ValidaTemplate()
        {
            try
            {
                using (var client = new WebClient())
                {
                    client.DownloadFile("http://www.massainursery.cl/Files/InfoFieldBook.xlsx", "C:\\Templates\\InfoFieldBook.xlsx");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Módulo Carga", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void CargaArchivo()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "xlsx files (*.xlsx)|*.xlsx";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pathFile = openFileDialog.FileName;
            }

            if (pathFile != "")
            {
                datos = FuncionesExcel.GetSplitFile(pathFile);
                var resumen = (from splits in datos
                               select splits).OrderBy(e=>e.Euid).ToList();

                grdResumen.AutoGenerateColumns = false;
                grdResumen.DataSource = resumen;
                grdResumen.ClearSelection();

                var listaV = (from splits in datos
                              select new EntryList { Euid = splits.Euid}).ToList();

                var existe = EntryListBusiness.ValidateEuids(listaV);
                if (!existe)
                {
                    btnProcesar.Enabled = false;
                    MessageBox.Show("Euid No Existe " , "Módulo Split", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    btnProcesar.Enabled = true;
                }
                lblEuids.Text = resumen.Count.ToString();
            }
        }

        private void GrabaDatos()
        {
            lblEuids.Text = "";
            grdOpciones.Enabled = false;
            //var mensaje = ValidaDatos();
            if (mensaje == "")
            {
                try
                {
                    bg.WorkerReportsProgress = true;
                    bg.ProgressChanged += bg_ProgressChanged;
                    bg.DoWork += bg_DoWork;
                    bg.RunWorkerCompleted += bg_RunWorkerCompleted;
                    bg.RunWorkerAsync();
                    grpProgreso.Visible = true;
                    btnProcesar.Enabled = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Módulo Carga", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
            else
            {
                MessageBox.Show(mensaje, "Módulo Carga", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void ExportarData()
        {
            if (listData.Count > 0)
            {
                string nombreArchivo = "";

                var book = FuncionesExcel.ExportaTemplateInfoFieldBook(listData);
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.InitialDirectory = @"C:\";
                saveFileDialog1.Title = "Save Excel Files";
                saveFileDialog1.DefaultExt = "xlsx";
                saveFileDialog1.Filter = "Excel files (*.xlsx)|*.xlsx";
                saveFileDialog1.FilterIndex = 2;
                saveFileDialog1.RestoreDirectory = true;

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    nombreArchivo = saveFileDialog1.FileName;
                    try
                    {
                        book.SaveAs(nombreArchivo);
                        MessageBox.Show("Archivo Creado!", "Módulo Split", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: ", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    }

                }
            }
            else
            {
                MessageBox.Show("NO Existe Información Para Exportar!", "Módulo Split", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void LimpiarFormulario()
        {
            grdResumen.DataSource = null;
            grdDetalle.DataSource = null;
            lblEuids.Text = "";
            lblActual.Text = "";
            lbltotal.Text = "";
            btnProcesar.Enabled = false;
            btnExportar.Enabled = false;
            grpProgreso.Visible = false;
        }
        #endregion

        #region -------Rutina Barra de Progreso-------
        private void bg_DoWork(object sender, DoWorkEventArgs e)
        {

            totalEmpleadosProcesar = datos.Sum(s=>s.EuidSplit);

            foreach (var item in datos)
            {
                var num = InfoFieldBookBusiness.GetSecuenciaIndEuid(item.Euid);

                if (num.IsNumeric())
                {
                    EntryListDto row = new EntryListDto();
                    int index = int.Parse(num);

                    for (int i = 1; i <= item.EuidSplit; i++)
                    {
                        itemO = EntryListBusiness.GetEntryList(item.Euid, "Euid")[0];
                        if (itemO != null)
                        {
                            row.Index = i;
                            row.Euid = item.Euid;
                            row.IndEuid = item.Euid + "_" + index.ToString();
                            row.Year = itemO.Year;
                            row.Country = itemO.Country;
                            row.Location = itemO.Location;
                            row.Rng = itemO.Rng;
                            row.Plt = itemO.Plt;
                            row.Ent = itemO.Ent;
                            row.ExpName = itemO.ExpName;
                            row.ProjectLead = itemO.ProjectLead;
                            row.Cc = itemO.Cc;
                            row.Crop = itemO.Crop;
                            row.Obs = itemO.Obs;
                            row.ProjectCode = itemO.ProjectCode;
                            row.GmoEvent = itemO.GmoEvent;
                            row.Sag = itemO.Sag;
                            row.CodInternacion = itemO.CodInternacion;
                            row.CodReception = itemO.CodReception;
                            row.Client = itemO.Client;
                            row.EntName = itemO.EntName;
                            row.EntRole = itemO.EntRole;
                            row.ResImportacion = itemO.ResImportacion;
                            row.GranosHilera = itemO.GranosHilera;
                            row.Bi1 = itemO.Bi1;
                            row.Bi2 = itemO.Bi2;
                            row.Bi3 = itemO.Bi3;
                            row.Bi4 = itemO.Bi4;
                            row.Owner = itemO.Owner;
                            row.CodPermanencia = itemO.CodPermanencia;
                            row.LotId = itemO.LotId;

                            listData.Add(row);
                            index++;
                            row = new EntryListDto();
                        }

                        progreso++; //Aumentando el progreso 
                        porciento = Convert.ToInt16((((double)progreso / (double)totalEmpleadosProcesar) * 100.00)); //Calculo del porcentaje
                        bg.ReportProgress(porciento);
                    }
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void bg_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // Change the value of the ProgressBar to the BackgroundWorker progress.
            prgGraba.Value = e.ProgressPercentage;
            prgGraba.Step = 1;
            prgGraba.Style = ProgressBarStyle.Continuous;
            prgGraba.Minimum = 0;
            prgGraba.Maximum = 100;

            lbltotal.Text = totalEmpleadosProcesar.ToString();
            lblActual.Text = progreso.ToString();


            if (e.ProgressPercentage > 100)
            {
                lblPorcentaje.Text = "100%";
                prgGraba.Value = prgGraba.Maximum;
            }
            else
            {
                lblPorcentaje.Text = Convert.ToString(e.ProgressPercentage) + "%";
                prgGraba.Value = e.ProgressPercentage;
            }
        }

        private void bg_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("Archivo Procesado", "Módulo Carga", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            grpProgreso.Visible = false;
            lblEuids.Text = totalEmpleadosProcesar.ToString();
            grdOpciones.Enabled = true;

            grdDetalle.AutoGenerateColumns = false;
            grdDetalle.DataSource = listData;
            grdDetalle.ClearSelection();
            grpDetalle.Visible = true;
            btnExportar.Enabled = true;
        }
        #endregion
    }
}
