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

namespace Layer.Win.Consulta
{
    public partial class FrmReportes : Form
    {
        #region -----Declaraciones-----

        List<ListaComboDto> anios = new List<ListaComboDto>();
        List<ListaComboDto> locations = new List<ListaComboDto>();
        List<EntryList> data = new List<EntryList>();
        List<EntryList> filtrado = new List<EntryList>();
        List<EntryList> datosCargados = new List<EntryList>();
        public Usuario usuarioValido { get; set; }
        BackgroundWorker bg = new BackgroundWorker();
        
        #endregion

        #region -----Constructores-----

        public FrmReportes()
        {
            InitializeComponent();
        }

        #endregion

        #region -----Funciones-----

        private void FrmReportes_Load(object sender, EventArgs e)
        {
            ConfiguraFormulario();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (cboAnio.SelectedItem != null && cboLocation.SelectedItem != null)
            {
                var anio = ((ListaComboDto)cboAnio.SelectedItem).Nombre;
                var location = ((ListaComboDto)cboLocation.SelectedItem).Nombre;

                BuscarInfo(anio, location);
            }
        }

        private void BtnExportar_Click(object sender, EventArgs e)
        {
            if (filtrado.Count > 0)
            {
                ExportaEtiquetas();
            }
        }

        #endregion

        #region -----Funciones-----

        private void ConfiguraFormulario()
        {
            LlenaComboAnio();
            LlenaComboLocation();

            DataGridViewCellStyle style = grdData.ColumnHeadersDefaultCellStyle;
            style.Font = new Font(grdData.Font.FontFamily, 8.25F, FontStyle.Regular);

            style = grdDefault.ColumnHeadersDefaultCellStyle;
            style.Font = new Font(grdDefault.Font.FontFamily, 8.25F, FontStyle.Regular);
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

        private void BuscarInfo(string anio,string location)
        {
            filtrado = EntryListBusiness.GetDataByYearLoc(int.Parse(anio), location);
            grdDefault.AutoGenerateColumns = false;
            grdDefault.DataSource = filtrado;
            grdDefault.ClearSelection();

            lblEuids.Text = filtrado.Count.ToString("0,0");
        }

        private void LimpiarFormulario()
        {
            cboAnio.SelectedIndex = -1;
            cboLocation.SelectedIndex = -1;
            grdDefault.DataSource = null;
            lblEuids.Text = ".";
            cboAnio.Focus();
        }

        private void ExportaEtiquetas()
        {
            string nombreArchivo = "";
            List<string> titulos = new List<string>();
            titulos.AddRange(new string[] { "Euid", "Rng", "Plt", "Ent", "Ent Name", "Location", "Exp Name" });
            var wb=FuncionesExcel.ExportaRowsTags(titulos,filtrado);

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
                    wb.SaveAs(nombreArchivo);
                    MessageBox.Show("Archivo Creado!", "Reporte Rows Tags", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Reporte Rows Tags", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
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

        private void ConfiguracionAutoFill(ComboBox cbo)
        {
            AutoCompleteStringCollection autoCompleteSource = new AutoCompleteStringCollection();
            cbo.AutoCompleteSource = AutoCompleteSource.CustomSource;
            foreach (ListaComboDto tempStr in cbo.Items)
                autoCompleteSource.Add(tempStr.Nombre);
            cbo.AutoCompleteCustomSource = autoCompleteSource;
            cbo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        }

        #endregion
    }
}
