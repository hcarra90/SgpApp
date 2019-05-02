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
using System.Windows.Forms;

namespace Layer.Win.Siembra
{
    public partial class FrmUploadInfoFieldBook : Form
    {
        #region -------Declaración-------
        public Usuario usuarioValido = new Usuario();
        string pathFile = "";
        List<InfoFieldBook> datos = new List<InfoFieldBook>();
        List<SplitEuidDto> SplitEuid = new List<SplitEuidDto>();
        InfoFieldBook infoF = new InfoFieldBook();
        int progreso = 0, porciento = 0, totalEmpleadosProcesar = 0;
        int modificados = 0, insertados = 0;
        int euidNoProcesables = 0;
        List<InfoFieldBook> nuevos = new List<InfoFieldBook>();
        List<InfoFieldBook> existentes = new List<InfoFieldBook>();

        BackgroundWorker bg = new BackgroundWorker();

        public object itemF { get; private set; }


        #endregion

        #region -------Constructor-------
        public FrmUploadInfoFieldBook()
        {
            InitializeComponent();
        }
        #endregion

        #region -----Eventos-----
        private void FrmUploadInfoFieldBook_Load(object sender, EventArgs e)
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
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Cancelar();
        }
        private void btnExportar_Click(object sender, EventArgs e)
        {
            //ExportarDatos(datos);
        }
        #endregion

        #region -----Funciones-----
        private void ValidaTemplate()
        {
            try
            {
                //using (var client = new WebClient())
                //{
                //    client.DownloadFile("http://www.massainursery.cl/Files/InfoFieldBook.xlsx.xlsx", "C:\\Templates\\InfoFieldBook.xlsx");
                //}

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Módulo Carga Field Book", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
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
                try
                {
                    datos = FuncionesExcel.GetData(pathFile);
                    //Validación Inicial
                    foreach (var item in datos)
                    {
                        infoF = InfoFieldBookBusiness.GetIndEuid(item.indEuid, item.euid);
                        if (infoF != null)
                        {
                            //infoF.Id = infoF.Id;
                            //infoF.cc = item.cc;
                            //infoF.client = item.client;
                            //infoF.codInternacion = item.codInternacion;
                            //infoF.CodPermanencia = item.CodPermanencia;
                            //infoF.codReception = item.codReception;
                            //infoF.country = item.country;
                            //infoF.crop = item.crop;
                            //infoF.ent = item.ent;
                            //infoF.EntName = item.EntName;
                            //infoF.EntRole = item.EntRole;
                            //infoF.gmoEvent = item.gmoEvent;
                            //infoF.GranosHilera = item.GranosHilera;
                            //infoF.instructions = item.instructions;
                            //infoF.location = item.location;
                            //infoF.LotId = item.LotId;
                            //infoF.opExpName = item.opExpName;
                            //infoF.order = item.order;
                            //infoF.Owner = item.Owner;
                            //infoF.plt = item.plt;
                            //infoF.ResImportation = item.ResImportation;
                            //infoF.rng = item.rng;
                            //infoF.sag = item.sag;
                            //infoF.year = item.year;

                            infoF.breedersCode1 = item.breedersCode1;
                            infoF.breedersCode2 = item.breedersCode2;
                            infoF.breedersCode3 = item.breedersCode3;
                            infoF.breedersCode4 = item.breedersCode4;
                            infoF.BreedersInstructions1 = item.BreedersInstructions1;
                            infoF.BreedersInstructions2 = item.BreedersInstructions2;
                            infoF.BreedersInstructions3 = item.BreedersInstructions3;
                            infoF.BreedersInstructions4 = item.BreedersInstructions4;
                            infoF.fechaModificacion = (DateTime?)DateTime.Now;
                            infoF.projecLead = item.projecLead;
                            infoF.projectCode = item.projectCode;
                            infoF.shelling = item.shelling;
                            infoF.shipTo = item.shipTo;
                            infoF.targears = item.targears;
                            infoF.targetKern = item.targetKern;
                            infoF.targetWg = item.targetWg;
                            infoF.obs = item.obs;
                            existentes.Add(infoF);

                            modificados++;
                        }
                        else
                        {
                            infoF = new InfoFieldBook();
                            infoF = item;
                            infoF.fechaCarga = DateTime.Now;
                            nuevos.Add(infoF);

                            insertados++;
                        }
                    }

                    grdDetalle.AutoGenerateColumns = false;
                    grdDetalle.DataSource = datos;
                    grdDetalle.ClearSelection();

                    lblEuids.Text = "N° Filas : " + grdDetalle.RowCount.ToString();
                    btnProcesar.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Módulo Carga Field Book", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
                
            }
        }

        private void ConfiguraFormulario()
        {
            DataGridViewCellStyle style = grdDetalle.ColumnHeadersDefaultCellStyle;
            style.Font = new Font(grdDetalle.Font.FontFamily, 8.75F, FontStyle.Regular);
            
            ValidaTemplate();
        }

        private void Cancelar()
        {
            datos = new List<InfoFieldBook>();
            SplitEuid = new List<SplitEuidDto>();
            progreso = 0;
            porciento = 0;
            totalEmpleadosProcesar = 0;
            btnProcesar.Enabled = false;
            grdDetalle.DataSource = null;
            btnExportar.Enabled = false;
            lblEuids.Text = ".";
            lblActual.Text = ".";
            lbltotal.Text = ".";
            lblNuevos.Text = ".";
            lblModificados.Text = ".";
            grpResumen.Visible = false;
        }

        private void GrabaDatos()
        {
            lblEuids.Text = "";
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
                //if (!EntryListBusiness.ValidateEuids(datos))
                //{
                //    btnProcesar.Enabled = true;
                //}
                //else
                //{
                //    mensaje.Append("- Euid(s) Ya Existe(n)");
                //    grdOpciones.Enabled = true;
                //    btnProcesar.Enabled = false;
                //}
            }

            return mensaje.ToString();
        }

        //private void ExportarDatos(List<InfoFieldBook> datos)
        //{
        //    string nombreArchivo = "";

        //    var book = FuncionesExcel.ExportaDetalleEntryList(datos);
        //    SaveFileDialog saveFileDialog1 = new SaveFileDialog();
        //    saveFileDialog1.InitialDirectory = @"C:\";
        //    saveFileDialog1.Title = "Save Excel Files";
        //    saveFileDialog1.DefaultExt = "xlsx";
        //    saveFileDialog1.Filter = "Excel files (*.xlsx)|*.xlsx";
        //    saveFileDialog1.FilterIndex = 2;
        //    saveFileDialog1.RestoreDirectory = true;

        //    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
        //    {
        //        nombreArchivo = saveFileDialog1.FileName;
        //        try
        //        {
        //            book.SaveAs(nombreArchivo);
        //            MessageBox.Show("Archivo Creado!", "Módulo Carga", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show("Error: ", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
        //        }

        //    }
        //}
        #endregion

        #region -------Rutina Barra de Progreso-------
        private void bg_DoWork(object sender, DoWorkEventArgs e)
        {
            totalEmpleadosProcesar = datos.Count;

            foreach (var item in datos)
            {
                infoF = InfoFieldBookBusiness.GetIndEuid(item.indEuid, item.euid);
                if (infoF != null)
                {
                    //infoF.Id = infoF.Id;
                    //infoF.cc = item.cc;
                    //infoF.client = item.client;
                    //infoF.codInternacion = item.codInternacion;
                    //infoF.CodPermanencia = item.CodPermanencia;
                    //infoF.codReception = item.codReception;
                    //infoF.country = item.country;
                    //infoF.crop = item.crop;
                    //infoF.ent = item.ent;
                    //infoF.EntName = item.EntName;
                    //infoF.EntRole = item.EntRole;
                    //infoF.gmoEvent = item.gmoEvent;
                    //infoF.GranosHilera = item.GranosHilera;
                    //infoF.instructions = item.instructions;
                    //infoF.location = item.location;
                    //infoF.LotId = item.LotId;
                    //infoF.opExpName = item.opExpName;
                    //infoF.order = item.order;
                    //infoF.Owner = item.Owner;
                    //infoF.plt = item.plt;
                    //infoF.ResImportation = item.ResImportation;
                    //infoF.rng = item.rng;
                    //infoF.sag = item.sag;
                    //infoF.year = item.year;

                    infoF.breedersCode1 = item.breedersCode1;
                    infoF.breedersCode2 = item.breedersCode2;
                    infoF.breedersCode3 = item.breedersCode3;
                    infoF.breedersCode4 = item.breedersCode4;
                    infoF.BreedersInstructions1 = item.BreedersInstructions1;
                    infoF.BreedersInstructions2 = item.BreedersInstructions2;
                    infoF.BreedersInstructions3 = item.BreedersInstructions3;
                    infoF.BreedersInstructions4 = item.BreedersInstructions4;
                    infoF.fechaModificacion = (DateTime?)DateTime.Now;
                    infoF.projecLead = item.projecLead;
                    infoF.projectCode = item.projectCode;
                    infoF.shelling = item.shelling;
                    infoF.shipTo = item.shipTo;
                    infoF.targears = item.targears;
                    infoF.targetKern = item.targetKern;
                    infoF.targetWg = item.targetWg;
                    infoF.obs = item.obs;

                    modificados++;
                }
                else
                {
                    infoF = new InfoFieldBook();
                    infoF = item;
                    infoF.fechaCarga = DateTime.Now;
                    insertados++;
                }
                InfoFieldBookBusiness.GrabaInformacion(infoF);

                progreso++; //Aumentando el progreso 
                porciento = Convert.ToInt16((((double)progreso / (double)totalEmpleadosProcesar) * 100.00)); //Calculo del porcentaje
                bg.ReportProgress(porciento);
                
            }
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

            lblNuevos.Text = insertados.ToString();
            lblModificados.Text = modificados.ToString();

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
            grpResumen.Visible = true;
        }
        #endregion
    }
}
