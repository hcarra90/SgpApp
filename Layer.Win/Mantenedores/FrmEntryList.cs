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
    public partial class FrmEntryList : Form
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
        List<EntryList> data = new List<EntryList>();
        List<EntryList> filtrado = new List<EntryList>();
        List<EntryList> datosCargados = new List<EntryList>();
        public Usuario usuarioValido { get; set; }

        double totalRows = 0;
        int progreso = 0, porciento = 0;
        int modificados = 0, nomodificados = 0;

        BackgroundWorker bg = new BackgroundWorker();
        #endregion

        #region -----Constructores-----

        public FrmEntryList()
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
                DataGridViewCell cell = grdDet[e.ColumnIndex, e.RowIndex];
                grdDet.CurrentCell = cell;
                grdDet.BeginEdit(true);
            }
        }

        private void GrdData_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int columna = e.ColumnIndex;
            int fila = e.RowIndex;
            var id = int.Parse((grdDet[0, e.RowIndex].Value).ToString());
            ModificaData(id, columna, fila);
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

        #endregion

        #region -----Funciones-----

        private void ConfiguraFormulario()
        {
            //LlenaComboAnio();
            //LlenaComboPais();
            //LlenaComboLocation();
            //LlenaComboExperiment();
            //LlenaComboProjectLead();
            //LlenaComboCrop();
            //LlenaComboClient();
            //LlenaComboCc();
            LlenaGrilla();

            DataGridViewCellStyle style = grdDet.ColumnHeadersDefaultCellStyle;
            style.Font = new Font(grdDet.Font.FontFamily, 8.25F, FontStyle.Regular);
        }

        private void LlenaComboAnio()
        {
            anios = EntryListBusiness.GetAnio();
            cboAnio.DisplayMember = "Nombre";
            cboAnio.ValueMember = "Nombre";
            cboAnio.DataSource = anios;

            //Configuración para autocompletar
            ConfiguracionAutoFill(cboAnio);
        }

        private void LlenaComboPais()
        {
            paises = EntryListBusiness.GetCountry();
            cboPais.DisplayMember = "Nombre";
            cboPais.ValueMember = "Nombre";
            cboPais.DataSource = paises;

            //Configuración para autocompletar
            ConfiguracionAutoFill(cboPais);
        }

        private void LlenaComboLocation()
        {
            locations = EntryListBusiness.GetLocation();
            cboLocation.DisplayMember = "Nombre";
            cboLocation.ValueMember = "Nombre";
            cboLocation.DataSource = locations;

            //Configuración para autocompletar
            ConfiguracionAutoFill(cboLocation);
        }

        private void LlenaComboExperiment()
        {
            experiments = EntryListBusiness.GetExperiment();
            cboExperiment.DisplayMember = "Nombre";
            cboExperiment.ValueMember = "Nombre";
            cboExperiment.DataSource = experiments;

            //Configuración para autocompletar
            ConfiguracionAutoFill(cboExperiment);
        }

        private void LlenaComboProjectLead()
        {
            leads = EntryListBusiness.GetProjectLead();
            cboProjectLead.DisplayMember = "Nombre";
            cboProjectLead.ValueMember = "Nombre";
            cboProjectLead.DataSource = leads;

            //Configuración para autocompletar
            ConfiguracionAutoFill(cboProjectLead);
        }

        private void LlenaComboCrop()
        {
            crops = EntryListBusiness.GetCrop();
            cboCrop.DisplayMember = "Nombre";
            cboCrop.ValueMember = "Nombre";
            cboCrop.DataSource = crops;

            //Configuración para autocompletar
            ConfiguracionAutoFill(cboCrop);
        }

        private void LlenaComboClient()
        {
            clients = EntryListBusiness.GetClient();
            cboClient.DisplayMember = "Nombre";
            cboClient.ValueMember = "Nombre";
            cboClient.DataSource = clients;

            //Configuración para autocompletar
            ConfiguracionAutoFill(cboClient);
        }

        private void LlenaComboCc()
        {
            ccs = EntryListBusiness.GetCc();
            cboCc.DisplayMember = "Nombre";
            cboCc.ValueMember = "Nombre";
            cboCc.DataSource = ccs;

            //Configuración para autocompletar
            ConfiguracionAutoFill(cboCc);
        }

        private void ConfiguracionAutoFill(ComboBox cbo)
        {
            AutoCompleteStringCollection autoCompleteSource = new AutoCompleteStringCollection();
            cbo.AutoCompleteSource = AutoCompleteSource.CustomSource;
            foreach (ListaComboDto tempStr in cbo.Items)
                autoCompleteSource.Add(tempStr.Nombre);
            cbo.AutoCompleteCustomSource = autoCompleteSource;
            cbo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        }

        private void LlenaGrilla()
        {
            data = EntryListBusiness.GetEntryList("", "");
            //grdData.AutoGenerateColumns = false;
            //grdData.DataSource = data;
            //grdData.ClearSelection();

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
                filtrado = filtrado.Where(p => p.Euid == euid).ToList();
            }
            else
            {
                if (anio != "")
                {
                    filtrado = filtrado.Where(p => p.Year == int.Parse(anio)).ToList();
                }
                if (country != "")
                {
                    filtrado = filtrado.Where(p => p.Country == country).ToList();
                }
                if (location != "")
                {
                    filtrado = filtrado.Where(p => p.Location == location).ToList();
                }
                if (experiment != "")
                {
                    filtrado = filtrado.Where(p => p.ExpName == experiment).ToList();
                }
                if (lead != "")
                {
                    filtrado = filtrado.Where(p => p.ProjectLead == lead).ToList();
                }
                if (crop != "")
                {
                    filtrado = filtrado.Where(p => p.Crop == crop).ToList();
                }
                if (client != "")
                {
                    filtrado = filtrado.Where(p => p.Client == client).ToList();
                }
                if (cc != "")
                {
                    filtrado = filtrado.Where(p => p.Cc == cc).ToList();
                }
            }

            grdData.AutoGenerateColumns = false;
            grdData.DataSource = filtrado;
            grdData.ClearSelection();
            lblEuids.Text = filtrado.Count.ToString("0,0");
        }

        private void ModificaData(int id, int columna, int fila)
        {
            var info = EntryListBusiness.GetEuidById(id);
            

            string valor = (grdDet[columna, fila].Value).ToString();

            switch (columna)
            {
                case 2:
                    info.Year = int.Parse(valor);
                    break;
                case 3:
                    info.Country = valor;
                    break;
                case 4:
                    info.Location = valor;
                    break;
                case 5:
                    info.Rng = valor;
                    break;
                case 6:
                    info.Year = int.Parse(valor);
                    break;
                case 7:
                    info.Ent = valor;
                    break;
                case 8:
                    info.ExpName = valor;
                    break;
                case 9:
                    info.ProjectLead = valor;
                    break;
                case 10:
                    info.Cc = valor;
                    break;
                case 11:
                    info.Crop = valor;
                    break;
                case 12:
                    info.Obs = valor;
                    break;
                case 13:
                    info.ProjectCode = valor;
                    break;
                case 14:
                    info.GmoEvent = valor;
                    break;
                case 15:
                    info.Sag = valor;
                    break;
                case 16:
                    info.CodInternacion = valor;
                    break;
                case 17:
                    info.CodReception = valor;
                    break;
                case 18:
                    info.Client = valor;
                    break;
                case 19:
                    info.EntName = valor;
                    break;
                case 20:
                    info.EntRole = valor;
                    break;
                case 21:
                    info.ResImportacion = valor;
                    break;
                case 22:
                    info.GranosHilera = valor;
                    break;
                case 23:
                    info.Bi1 = valor;
                    break;
                case 24:
                    info.Bi2 = valor;
                    break;
                case 25:
                    info.Bi3 = valor;
                    break;
                case 26:
                    info.Bi4 = valor;
                    break;
                case 27:
                    info.Owner = valor;
                    break;
                case 28:
                    info.CodPermanencia = valor;
                    break;
                case 29:
                    info.LotId = valor;
                    break;
                default:
                    break;
            }
            info.FechaModificacion = DateTime.Now;
            info.UsuarioModificacion = usuarioValido.nombre_usuario;

            try
            {
                EntryListBusiness.GrabaDatos(info);
                ModificaInfoFieldBook(info);
                MessageBox.Show("Registro Modificado!", "Mantención EntryList", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Al Modificar: " + ex.Message, "Mantención EntryList", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void ModificaInfoFieldBook(EntryList item)
        {
            var items = InfoFieldBookBusiness.GetEuid(item.Euid, "Euid");
            foreach (var info in items)
            {
                info.year = item.Year;
                info.country = item.Country;
                info.location = item.Location;
                info.rng = item.Rng;
                info.plt = item.Plt;
                info.ent = item.Ent;
                info.opExpName = item.ExpName;
                info.projecLead = item.ProjectLead;
                info.cc = item.Cc;
                info.crop = item.Crop;
                info.obs = item.Obs;
                info.projectCode = item.ProjectCode;
                info.gmoEvent = item.GmoEvent;
                info.sag = item.Sag;
                info.codInternacion = item.CodInternacion;
                info.codReception = item.CodReception;
                info.client = item.Client;
                info.EntName = item.EntName;
                info.EntRole = item.EntRole;
                info.ResImportation = item.ResImportacion;
                info.GranosHilera = int.Parse(item.GranosHilera);
                info.BreedersInstructions1 = item.Bi1;
                info.BreedersInstructions2 = item.Bi2;
                info.BreedersInstructions3 = item.Bi3;
                info.BreedersInstructions4 = item.Bi4;
                info.Owner = item.Owner;
                info.CodPermanencia = item.CodPermanencia;
                info.LotId = item.LotId;
                info.fechaModificacion = DateTime.Now;
                info.UsuarioModificacion = usuarioValido.nombre_usuario;
                InfoFieldBookBusiness.GrabaInformacion(info);
            }
        }

        private void BtnExportar_Click(object sender, EventArgs e)
        {
            CreaExcel(filtrado);

        }

        private void CreaExcel(List<EntryList> data)
        {
            string nombreArchivo = "";

            var book = FuncionesExcel.ExportaEntryList(filtrado);
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
                    MessageBox.Show("Error: " + ex.Message, "Mantención EntryList", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
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

        private void CargaArchivo()
        {
            string pathFile = "";
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "xlsx files (*.xlsx)|*.xlsx";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pathFile = openFileDialog.FileName;
                datosCargados = FuncionesExcel.GetEntryListFile(pathFile);
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

        #endregion

        #region -------Rutina Barra de Progreso-------
        private void bg_DoWork(object sender, DoWorkEventArgs e)
        {
            totalRows = datosCargados.Count;

            //Se debe crear lista de InfoFieldBook para cargarlas
            foreach (var item in datosCargados)
            {
                var itemEntry = EntryListBusiness.GetEntryList(item.Euid,"Euid")[0];
                if (itemEntry != null && itemEntry.Id > 0)
                {
                    //itemEntry.Id = item.Id;
                    itemEntry.Year = item.Year;
                    itemEntry.Country = item.Country;
                    itemEntry.Location = item.Location;
                    itemEntry.Rng = item.Rng;
                    itemEntry.Plt = item.Plt;
                    itemEntry.Ent = item.Ent;
                    itemEntry.ExpName = item.ExpName;
                    itemEntry.ProjectLead = item.ProjectLead;
                    itemEntry.Cc = item.Cc;
                    itemEntry.Crop = item.Crop;
                    itemEntry.Obs = item.Obs;
                    itemEntry.ProjectCode = item.ProjectCode;
                    itemEntry.GmoEvent = item.GmoEvent;
                    itemEntry.Sag = item.Sag;
                    itemEntry.CodInternacion = item.CodInternacion;
                    itemEntry.CodReception = item.CodReception;
                    itemEntry.Client = item.Client;
                    itemEntry.EntName = item.EntName;
                    itemEntry.EntRole = item.EntRole;
                    itemEntry.ResImportacion = item.ResImportacion;
                    itemEntry.GranosHilera = item.GranosHilera;
                    itemEntry.Bi1 = item.Bi1;
                    itemEntry.Bi2 = item.Bi2;
                    itemEntry.Bi3 = item.Bi3;
                    itemEntry.Bi4 = item.Bi4;
                    itemEntry.Owner = item.Owner;
                    itemEntry.CodPermanencia = item.CodPermanencia;
                    itemEntry.LotId = item.LotId;
                    itemEntry.FechaModificacion = DateTime.Now;
                    itemEntry.UsuarioModificacion = usuarioValido.nombre_usuario;
                    modificados++;
                }
                else
                {
                    nomodificados++;
                }

                EntryListBusiness.GrabaDatos(itemEntry);
                ModificaInfoFieldBook(itemEntry);

                progreso++; //Aumentando el progreso 
                porciento = Convert.ToInt16((((double)progreso / (double)totalRows) * 100.00)); //Calculo del porcentaje
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