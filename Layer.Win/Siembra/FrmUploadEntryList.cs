using Layer.Business;
using Layer.Entity;
using Layer.Entity.Dto;
using Layer.Functions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;

namespace Layer.Win.Siembra
{
    public partial class FrmUploadEntryList : Form
    {
        #region -------Declaración-------
        string pathFile = "";
        List<EntryList> datos = new List<EntryList>();
        List<SplitEuidDto> SplitEuid = new List<SplitEuidDto>();
        List<InfoFieldBook> listaSplit = new List<InfoFieldBook>();
        InfoFieldBook itemInfoField = new InfoFieldBook();
        int progreso = 0, porciento = 0, totalEmpleadosProcesar = 0;

        BackgroundWorker bg = new BackgroundWorker();


        #endregion

        #region -------Constructor-------
        public FrmUploadEntryList()
        {
            InitializeComponent();
        }
        #endregion

        #region -------Métodos Privados-------
        private void btnCarga_Click(object sender, EventArgs e)
        {
            CargaArchivo();
        }

        private void CargaArchivo()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "xlsx files (*.xlsx)|*.xlsx";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pathFile = openFileDialog.FileName;
                //lblFile.Text = pathFile;
            }

            if (pathFile != "")
            {
                datos = FuncionesExcel.GetEntryListFile(pathFile);
                var resumen = (from EntryList in datos
                               group EntryList by new
                               {
                                   EntryList.Year,
                                   EntryList.Country,
                                   EntryList.Location,
                                   EntryList.ExpName,
                                   EntryList.Client,
                                   EntryList.Crop
                               } into g
                               select new
                               {
                                   g.Key.Year,
                                   g.Key.Country,
                                   N_Euid = g.Count(p => p.Euid != null),
                                   g.Key.Location,
                                   g.Key.ExpName,
                                   g.Key.Client,
                                   g.Key.Crop
                               }).ToList();

                grdResumen.AutoGenerateColumns = false;
                grdResumen.DataSource = resumen;
                grdResumen.ClearSelection();
                grdResumen.Text = "N° Filas : " + grdResumen.RowCount.ToString();

                if (resumen.Count == 1)
                {
                    var existe = InfoLocBusiness.GetLocByCuartel(resumen[0].Location.ToString()).FirstOrDefault();
                    if (existe != null)
                    {
                        grdeuids.AutoGenerateColumns = false;
                        grdeuids.DataSource = datos;
                        grdeuids.ClearSelection();

                        btnProcesar.Enabled = true;
                    }
                }
                else
                {
                    btnProcesar.Enabled = false;
                    grpSplit.Enabled = false;
                }
            }
        }

        private void GrabaDatos()
        {
            lblEuids.Text = "";
            //grdOpciones.Enabled = false;
            var mensaje = ValidaDatos();
            
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

        private string ValidaDatos()
        {
            StringBuilder mensaje = new StringBuilder();

            if (datos.Count == 0)
            {
                mensaje.Append("- No Existe Data Para Procesar" + Environment.NewLine);
            }
            else
            {
                if (!EntryListBusiness.ValidateEuids(datos))
                {
                    btnProcesar.Enabled = true;
                    grpSplit.Enabled = true;
                }
                else
                {
                    mensaje.Append("- Euid(s) Ya Existe(n)");
                    grdOpciones.Enabled = true;
                    btnProcesar.Enabled = false;
                }
            }

            return mensaje.ToString();
        }

        private void FrmUpload_Load(object sender, EventArgs e)
        {
            ConfiguraFormulario();
        }

        private void ConfiguraFormulario()
        {
            DataGridViewCellStyle style = grdResumen.ColumnHeadersDefaultCellStyle;
            style.Font = new Font(grdResumen.Font.FontFamily, 8.75F, FontStyle.Regular);

            style = grdeuids.ColumnHeadersDefaultCellStyle;
            style.Font = new Font(grdeuids.Font.FontFamily, 8.75F, FontStyle.Regular);
            ValidaTemplate();
        }

        private void ValidaTemplate()
        {
            try
            {
                using (var client = new WebClient())
                {
                    client.DownloadFile("http://www.massainursery.cl/Files/Detalle_Entry_List.xlsx", "C:\\Templates\\Detalle_Entry_List.xlsx");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Módulo Carga", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void grdeuids_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 1 && e.FormattedValue.ToString() != "")
            {
                int numberEuid;

                if (!int.TryParse(Convert.ToString(e.FormattedValue), out numberEuid))
                {
                    e.Cancel = true;
                    MessageBox.Show("Sólo Valores Enteros", "Módulo Carga", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    var euid = grdeuids.Rows[e.RowIndex].Cells[0].Value.ToString();

                    var exist = SplitEuid.Find(ex => ex.Euid == euid);

                    if (exist == null)
                    {
                        SplitEuid.Add(new SplitEuidDto
                        {
                            Euid = euid,
                            EuidSplit = numberEuid
                        });
                    }
                }
            }
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            ProcesarEuids();
        }

        private void ProcesarEuids()
        {
            foreach (var item in SplitEuid)
            {

            }
        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            lblInicio.Text = DateTime.Now.ToString();

            this.Cursor = Cursors.WaitCursor;
            GrabaDatos();
            this.Cursor = Cursors.Default;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Cancelar();
        }

        private void Cancelar()
        {
            datos = new List<EntryList>();
            SplitEuid = new List<SplitEuidDto>();
            progreso = 0;
            porciento = 0;
            totalEmpleadosProcesar = 0;
            btnProcesar.Enabled = false;
            grdResumen.DataSource = null;
            grdDetalle.DataSource = null;
            btnExportar.Enabled = false;
            lblEuids.Text = ".";
            lblActual.Text = ".";
            lbltotal.Text = ".";
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            grpProgreso.Visible = false;
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            ExportarDatos(datos);
        }

        private void ExportarDatos(List<EntryList> datos)
        {
            string nombreArchivo = "";

            var book = FuncionesExcel.ExportaDetalleEntryList(datos);
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
                    MessageBox.Show("Archivo Creado!", "Módulo Carga", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: ", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }

            }
        }
        #endregion

        #region -------Rutina Barra de Progreso-------
        private void bg_DoWork(object sender, DoWorkEventArgs e)
        {
            totalEmpleadosProcesar = datos.Count;
            
            //Se debe crear lista de InfoFieldBook para cargarlas
            foreach (var item in datos)
            {
                itemInfoField.BreedersInstructions1 = item.Bi1;
                itemInfoField.BreedersInstructions2 = item.Bi2;
                itemInfoField.BreedersInstructions3 = item.Bi3;
                itemInfoField.BreedersInstructions4 = item.Bi4;
                itemInfoField.cc = item.Cc;
                itemInfoField.client = item.Client;
                itemInfoField.codInternacion = item.CodInternacion;
                itemInfoField.CodPermanencia = item.CodPermanencia;
                itemInfoField.codReception = item.CodReception;
                itemInfoField.country = item.Country;
                itemInfoField.crop = item.Crop;
                itemInfoField.ent = item.Ent;
                itemInfoField.EntName = item.EntName;
                itemInfoField.EntRole = item.EntRole;
                itemInfoField.euid = item.Euid;
                itemInfoField.fechaCarga = DateTime.Now;
                itemInfoField.gmoEvent = item.GmoEvent;
                itemInfoField.GranosHilera = int.Parse(item.GranosHilera);
                itemInfoField.indEuid = "";
                itemInfoField.instructions = "";
                itemInfoField.location = item.Location;
                itemInfoField.LotId = item.LotId;
                itemInfoField.obs = item.Obs;
                itemInfoField.opExpName = item.ExpName;
                itemInfoField.Owner = item.Owner;
                itemInfoField.plt = item.Plt;
                itemInfoField.projecLead = item.ProjectLead;
                itemInfoField.projectCode = item.ProjectCode;
                itemInfoField.ResImportation = item.ResImportacion;
                itemInfoField.rng = item.Rng;
                itemInfoField.sag = item.Sag;
                itemInfoField.year = item.Year;
                listaSplit.Add(itemInfoField);
                itemInfoField = new InfoFieldBook();

                progreso++; //Aumentando el progreso 
                porciento = Convert.ToInt16((((double)progreso / (double)totalEmpleadosProcesar) * 100.00)); //Calculo del porcentaje
                bg.ReportProgress(porciento);

            }
            EntryListBusiness.InsertBulk(datos);
            InfoFieldBookBusiness.InsertBulk(listaSplit);
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
            grdDetalle.DataSource = datos;
            grdDetalle.ClearSelection();
            btnExportar.Enabled = true;
            lblTermino.Text = DateTime.Now.ToString();
        }
        #endregion

    }
}
