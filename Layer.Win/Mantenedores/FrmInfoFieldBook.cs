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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq.Dynamic;

namespace Layer.Win.Mantenedores
{
    public partial class FrmInfoFieldBook : Form
    {
        #region -----Declaraciones-----

        List<ListaComboDto> anios = new List<ListaComboDto>();
        List<ListaComboDto> paises = new List<ListaComboDto>();
        List<ListaComboDto> locations = new List<ListaComboDto>();
        List<ListaComboDto> experiments = new List<ListaComboDto>();
        List<ListaComboDto> leads = new List<ListaComboDto>();
        List<ListaComboDto> crops = new List<ListaComboDto>();
        List<ListaComboDto> clients = new List<ListaComboDto>();
        List<ListaComboDto> ccs = new List<ListaComboDto>();
        List<InfoFieldBook> data = new List<InfoFieldBook>();
        List<InfoFieldBook> filtrado = new List<InfoFieldBook>();
        List<InfoFieldBook> datosCargados = new List<InfoFieldBook>();
        public Usuario usuarioValido { get; set; }

        double totalRows = 0;
        int progreso = 0, porciento = 0;
        int modificados = 0, nomodificados = 0;

        BackgroundWorker bg = new BackgroundWorker();
        #endregion

        #region -----Constructores-----

        public FrmInfoFieldBook()
        {
            InitializeComponent();
        }

        #endregion

        #region -----Eventos-----

        private void FrmEntryList_Load(object sender, EventArgs e)
        {
            ConfiguraFormulario();
            txtEuid.Focus();
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            if (cboPais.SelectedItem != null || cboAnio.SelectedItem != null || cboLocation.SelectedItem != null || cboExperiment.SelectedItem != null
               || cboProjectLead.SelectedItem != null || cboCrop.SelectedItem != null || cboClient.SelectedItem != null || cboCc.SelectedItem != null)
            {
                var anio = ((ListaComboDto)cboAnio.SelectedItem).Nombre;
                var country = ((ListaComboDto)cboPais.SelectedItem).Nombre;
                var location = ((ListaComboDto)cboLocation.SelectedItem).Nombre;
                var experiment = ((ListaComboDto)cboExperiment.SelectedItem).Nombre;
                var lead = ((ListaComboDto)cboProjectLead.SelectedItem).Nombre;
                var crop = ((ListaComboDto)cboCrop.SelectedItem).Nombre;
                var client = ((ListaComboDto)cboClient.SelectedItem).Nombre;
                var cc = ((ListaComboDto)cboCc.SelectedItem).Nombre;
                var euid = txtEuid.Text;

                FiltrarData(euid, anio, country, location, experiment, lead, crop, client, cc);
            }
        }

        private void GrdData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 1 && e.RowIndex >= 0)
            {
                DataGridViewCell cell = grdData[e.ColumnIndex, e.RowIndex];
                grdData.CurrentCell = cell;
                grdData.BeginEdit(true);
            }
        }

        private void GrdData_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int columna = e.ColumnIndex;
            int fila = e.RowIndex;
            var id = int.Parse((grdDet[0, e.RowIndex].Value).ToString());
            ModificaData(id, columna, fila);
        }

        #endregion

        #region -----Funciones-----

        private void ConfiguraFormulario()
        {
            LlenaGrilla();

            DataGridViewCellStyle style = grdDet.ColumnHeadersDefaultCellStyle;
            style.Font = new Font(grdDet.Font.FontFamily, 8.25F, FontStyle.Regular);
        }

        private void LlenaGrilla()
        {
            data = InfoFieldBookBusiness.GetEuid("","Todo");

            grdDet.AutoGenerateColumns = false;
            grdDet.DataSource = data;
            grdDet.ClearSelection();

            lblTotalEuids.Text = data.Count.ToString("0,0");
            filtrado = data;
        }

        private void FiltrarData(string euid, string anio, string country, string location, string experiment, string lead, string crop, string client, string cc)
        {
            filtrado = data;
            if (euid != "")
            {
                filtrado = filtrado.Where(p => p.euid == euid).ToList();
            }
            else
            {
                if (anio != "")
                {
                    filtrado = filtrado.Where(p => p.year == int.Parse(anio)).ToList();
                }
                if (country != "")
                {
                    filtrado = filtrado.Where(p => p.country == country).ToList();
                }
                if (location != "")
                {
                    filtrado = filtrado.Where(p => p.location == location).ToList();
                }
                if (experiment != "")
                {
                    filtrado = filtrado.Where(p => p.opExpName == experiment).ToList();
                }
                if (lead != "")
                {
                    filtrado = filtrado.Where(p => p.projecLead == lead).ToList();
                }
                if (crop != "")
                {
                    filtrado = filtrado.Where(p => p.crop == crop).ToList();
                }
                if (client != "")
                {
                    filtrado = filtrado.Where(p => p.client == client).ToList();
                }
                if (cc != "")
                {
                    filtrado = filtrado.Where(p => p.cc == cc).ToList();
                }
            }

            grdData.AutoGenerateColumns = false;
            grdData.DataSource = filtrado;
            grdData.ClearSelection();
            lblEuids.Text = filtrado.Count.ToString("0,0");
        }

        private void ModificaData(int id, int columna, int fila)
        {
            var info = InfoFieldBookBusiness.GetRowById(id);
            string valor = (grdDet[columna, fila].Value).ToString();

            switch (columna)
            {
                case 3:
                    info.order = int.Parse(valor);
                    break;
                case 4:
                    info.breedersCode1 = valor;
                    break;
                case 5:
                    info.breedersCode2 = valor;
                    break;
                case 6:
                    info.breedersCode3 = valor;
                    break;
                case 7:
                    info.breedersCode4 = valor;
                    break;
                case 8:
                    info.shelling = valor;
                    break;
                case 9:
                    info.instructions = valor;
                    break;
                case 10:
                    info.targears = valor;
                    break;
                case 11:
                    info.targetKern = valor;
                    break;
                case 12:
                    info.targetWg = decimal.Parse(valor);
                    break;
                case 13:
                    info.shipTo = valor;
                    break;
                default:
                    break;
            }
            info.fechaModificacion = DateTime.Now;
            info.UsuarioModificacion = usuarioValido.nombre_usuario;

            try
            {
                InfoFieldBookBusiness.GrabaInformacion(info);
                MessageBox.Show("Registro Modificado!", "Mantención EntryList", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Al Modificar: " + ex.Message, "Mantención EntryList", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        #endregion

        private void btnExportar_Click(object sender, EventArgs e)
        {
            CreaExcel(filtrado);
           
        }

        private void CreaExcel(List<InfoFieldBook> data)
        {
            List<string> titulos = new List<string>();
            titulos.AddRange(new string[] { "Euid", "Ind Euid", "Order", "Breeder Code I", "Breeder Code II", "Breeder Code III", "Breeder Code IV", "Shelling", "Instructions", "Ears", "Kernels", "Weight", "Ship To" });
            string nombreArchivo = "";

            var book = FuncionesExcel.ExportaInfoFieldBook(filtrado,titulos);
            SaveFileDialog saveFileDialog1 = new SaveFileDialog
            {
                InitialDirectory = @"C:\",
                Title = "Save Excel Files",
                DefaultExt = "xlsx",
                Filter = "Excel files (*.xlsx)|*.xlsx",
                FilterIndex = 2,
                RestoreDirectory = true
            };

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                nombreArchivo = saveFileDialog1.FileName;
                try
                {
                    book.SaveAs(nombreArchivo);
                    MessageBox.Show("Archivo Creado!", "Mantención EntryList", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Mantención EntryList",MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }

            }

        }

        private string FilterStringconverter(string filter)
        {
            string newColFilter = "";

            // get rid of all the parenthesis 
            filter = filter.Replace("(", "").Replace(")", "");

            // now split the string on the 'and' (each grid column)
            var colFilterList = filter.Split(new string[] { "AND" }, StringSplitOptions.None);

            string andOperator = "";

            foreach (var colFilter in colFilterList)
            {
                newColFilter += andOperator;

                // split string on the 'in'
                var temp1 = colFilter.Trim().Split(new string[] { "IN" }, StringSplitOptions.None);

                // get string between square brackets
                var colName = temp1[0].Split('[', ']')[1].Trim();

                // prepare beginning of linq statement
                newColFilter += string.Format("({0} != null && (", colName);

                string orOperator = "";

                var filterValsList = temp1[1].Split(',');

                foreach (var filterVal in filterValsList)
                {
                    // remove any single quotes before testing if filter is a num or not
                    var cleanFilterVal = filterVal.Replace("'", "").Trim();

                    double tempNum = 0;
                    if (Double.TryParse(cleanFilterVal, out tempNum))
                        newColFilter += string.Format("{0} {1} = {2}", orOperator, colName, cleanFilterVal.Trim());
                    else
                        newColFilter += string.Format("{0} {1}.Contains('{2}')", orOperator, colName, cleanFilterVal.Trim());

                    orOperator = " OR ";
                }

                newColFilter += "))";

                andOperator = " AND ";
            }

            // replace all single quotes with double quotes
            return newColFilter.Replace("'", "\"");
        }

        private void GrdDet_SortStringChanged(object sender, Zuby.ADGV.AdvancedDataGridView.SortEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(grdDet.SortString) == true)
                    return;

                var sortStr = grdDet.SortString.Replace("[", "").Replace("]", "");

                if (string.IsNullOrEmpty(grdDet.FilterString) == true)
                {
                    // the grid is not filtered!
                    filtrado = data.OrderBy(sortStr).ToList();
                    grdDet.DataSource = filtrado;
                }
                else
                {
                    // the grid is filtered!
                    filtrado = filtrado.OrderBy(sortStr).ToList();
                    grdDet.DataSource = filtrado;
                }

                //textBox_sort.Text = sortStr;
            }
            catch (Exception ex)
            {
            }
        }

        private void GrdDet_FilterStringChanged(object sender, Zuby.ADGV.AdvancedDataGridView.FilterEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(grdDet.FilterString) == true)
                {
                    filtrado = data;
                    grdDet.DataSource = data;
                }
                else
                {
                    var listfilter = FilterStringconverter(grdDet.FilterString);

                    filtrado = filtrado.Where(listfilter).ToList();

                    grdDet.DataSource = filtrado;
                }
                lblEuids.Text = filtrado.Count.ToString();
            }
            catch (Exception ex)
            {
                //Log.Error(ex, MethodBase.GetCurrentMethod().Name);
            }
        }

        private void BtnCarga_Click(object sender, EventArgs e)
        {
            CargaArchivo();
        }

        private void CargaArchivo()
        {
            string pathFile = "";
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "xlsx files (*.xlsx)|*.xlsx";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pathFile = openFileDialog.FileName;
                datosCargados = FuncionesExcel.GetInfoFieldBookFile(pathFile);
            }

            GrabaDatos();
        }

        private void GrabaDatos()
        {
            try
            {
                lblInicio.Text = DateTime.Now.ToString();
                pnlProceso.Visible = true;
                grdDet.Enabled = false;
                bg.WorkerReportsProgress = true;
                bg.ProgressChanged += bg_ProgressChanged;
                bg.DoWork += bg_DoWork;
                bg.RunWorkerCompleted += bg_RunWorkerCompleted;
                bg.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Módulo Carga", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        #region -------Rutina Barra de Progreso-------
        private void bg_DoWork(object sender, DoWorkEventArgs e)
        {
            totalRows = datosCargados.Count;

            //Se debe crear lista de InfoFieldBook para cargarlas
            foreach (var item in datosCargados)
            {
                var items = InfoFieldBookBusiness.GetEuid(item.euid, "Euid");
                if (items.Count > 0)
                {
                    foreach (var row in items)
                    {
                        row.order = item.order;
                        row.breedersCode1 = item.breedersCode1;
                        row.breedersCode2 = item.breedersCode2;
                        row.breedersCode3 = item.breedersCode3;
                        row.breedersCode4 = item.breedersCode4;
                        row.shelling = item.shelling;
                        row.instructions = item.instructions;
                        row.targears = item.targears;
                        row.targetKern = item.targetKern;
                        row.targetWg = item.targetWg;
                        row.shipTo = item.shipTo;
                        row.fechaModificacion = DateTime.Now;
                        row.UsuarioModificacion = usuarioValido.nombre_usuario;
                        modificados++;

                        InfoFieldBookBusiness.GrabaInformacion(row);
                        progreso++; //Aumentando el progreso 
                        porciento = Convert.ToInt16((((double)progreso / (double)totalRows) * 100.00)); //Calculo del porcentaje
                        bg.ReportProgress(porciento);
                    }
                }
                else
                {
                    nomodificados++;
                }
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

            lbltotal.Text = totalRows.ToString();
            lblActual.Text = progreso.ToString();
            lblModificados.Text = modificados.ToString();
            lblNoModificados.Text = nomodificados.ToString();

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

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            pnlProceso.Visible = false;
        }

        private void bg_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("Archivo Procesado", "Módulo Carga", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            lblEuids.Text = totalRows.ToString();
            lblModificados.Text = modificados.ToString();
            lblNoModificados.Text = nomodificados.ToString();
            lblTermino.Text = DateTime.Now.ToString();
            btnAceptar.Enabled = true;
            grdDet.Enabled = true;
        }

        #endregion
    }
}