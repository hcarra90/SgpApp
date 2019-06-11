using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Com.SharpZebra.Printing;
using Layer.Business;
using Layer.Entity;
using Layer.Entity.Dto;
using Layer.Functions;
using Layer.Win.Administrador;
using Microsoft.Win32.SafeHandles;

namespace Layer.Win.Siembra
{
    public partial class FrmTemplateEntryList : Form
    {
        #region Declaración
        public Usuario usuarioValido { get; set; }

        private delegate void Closure();

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
        int idEmpresa = 0;
        string tipo = "";
        InfoLocDto locationSelected = new InfoLocDto();
        #endregion

        public FrmTemplateEntryList()
        {
            InitializeComponent();
        }

        private void FrmSiembra_Load(object sender, EventArgs e)
        {
            ConfiguraFormulario();
        }

        private void ConfiguraFormulario()
        {
            idEmpresa = int.Parse(ConfigurationManager.AppSettings["IdEmpresa"].ToString());

            LlenaComboLocation();
            LlenaComboTipoAgro();
            LlenaOwner();
            LlenaComboEstado();
            LlenaComboCrop();
            LlenaComboSag();
            cboTipo.Focus();

            lblInicio.Text = EntryListBusiness.GetMaxEuid();

            //ValidaTemplate();
        }

        private void ValidaTemplate()
        {
            try
            {
                using (var client = new WebClient())
                {
                    client.DownloadFile("http://www.massainursery.cl/Files/Entry_List.xlsx", "C:\\Templates\\Entry_List.xlsx");
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Módulo Centro Costo", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        #region -----Llenado de Combos-----
        public void LlenaComboLocation()
        {
            cboLocation.DataSource = null;
            cboLocation.Refresh();
            var data= new List<InfoLocDto>();

            data = InfoLocBusiness.GetLocs();
            cboLocation.ValueMember = "Id";
            cboLocation.DisplayMember = "LocationCuartel";
            cboLocation.DataSource = data;
            cboLocation.Refresh();
        }

        private void LlenaComboTipoAgro()
        {
            var data = TipoAgroBusiness.GetDatos(idEmpresa);
            cboTipo.ValueMember = "Id";
            cboTipo.DisplayMember = "Codigo";
            cboTipo.DataSource = data;
        }

        private void LlenaComboEstado()
        {
            var data = EstadoBusiness.GetEstados(idEmpresa);
            cboEstado.ValueMember = "Id";
            cboEstado.DisplayMember = "Descripcion";
            cboEstado.DataSource = data;
        }
        
        private void LlenaComboCrop()
        {
            var data = CropBusiness.GetCrops(idEmpresa);
            cboCrop.ValueMember = "Id";
            cboCrop.DisplayMember = "Descripcion";
            cboCrop.DataSource = data;
        }

        private void LlenaComboSag()
        {
            var data = DataFunctions.GetTipoSag();
            cboSag.ValueMember = "Valor";
            cboSag.DisplayMember = "Nombre";
            cboSag.DataSource = data;
        }

        #endregion

        private void LlenaOwner()
        {
            var data = ParametroBusiness.GetParametroByTipo("OWN");
            lblOwner.Text = data[0].Valor;
        }

        private void CboTipo_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboTipo.SelectedItem !=null)
            {
                var valor = (TipoAgro)cboTipo.SelectedItem;
                if (valor.Codigo != null && valor.Codigo !="")
                {
                    tipo = valor.Codigo;
                    ConfiguraCampos(tipo);
                }
                else
                {
                    HabiltaControles(false);
                }
                txtcc.Focus();
            }
        }
        private void BtnNuevaLoc_Click(object sender, EventArgs e)
        {
            FrmNuevaLocation frm = new FrmNuevaLocation();
            frm.TipoAgro = (TipoAgro)cboTipo.SelectedItem;
            frm.ShowDialog();
        }
        private void BtnProcesar_Click_1(object sender, EventArgs e)
        {
            FrmUploadEntryList frm = new FrmUploadEntryList();
            //frm.usuarioValido = this.usuarioValido;
            frm.ShowDialog();
        }
        #region Configura Controles
        private void ConfiguraCampos(string tipo)
        {
            HabiltaControles(false);
            switch (tipo)
            {
                case "NUR":
                    HabiltaControles(true);
                    break;
                default:
                    ConfiguraNoNur();
                    break;
            }
        }

        private void HabiltaControles(bool estado)
        {
            //Parte Superior Pantall
            this.grpEstado.Enabled = estado;
            this.grpEuid.Enabled = estado;
            this.txtNumEuid.Enabled = estado;
            this.txtCliente.Enabled = estado;

            //Grupo Opciones
            this.btnExportar.Enabled = estado;

            //Location y Centro de Costo
            this.cboLocation.Enabled = estado;
            btnNuevaLoc.Enabled = estado;
            this.txtcc.Enabled = estado;

            //Grupo Medidas
            //this.grpMedidas.Enabled = estado;
            this.txtDistEntreHileras.Enabled = estado;
            this.txtDistSobreHilera.Enabled = estado;
            this.txtLargoHilera.Enabled = estado;
            this.txtGranosPorHilera.Enabled = estado;
            this.txtTotalPlantas.Enabled = estado;
            this.txtSuperficie.Enabled = estado;
            this.txtTotalHilera.Enabled = estado;

            //Grupo Ubicación
            this.grpUbicacion.Enabled = estado;
            this.txtLatitud.Enabled = estado;
            this.txtLongitud.Enabled = estado;
            this.txtCodigoPoligono.Enabled = estado;

            //Grupo Experimento
            this.grpExperimento.Enabled = estado;
            this.cboCrop.Enabled = estado;
            this.txtNombreExperimento.Enabled = estado;
            this.txtVariedad.Enabled = estado;
            this.txtProjectLead.Enabled = estado;
            this.txtProjectCode.Enabled = estado;
            this.txtGmoEvent.Enabled = estado;
            this.txtResolucionImportacion.Enabled = estado;
            this.cboSag.Enabled = estado;
            this.chkGmo.Enabled = estado;
            this.txtCodInternacion.Enabled = estado;
            this.txtCodRecepcion.Enabled = estado;

            //Grupo Instrucciones
            this.grpInstrucciones.Enabled = estado;
            this.txtBi1.Enabled = estado;
            this.txtBi2.Enabled = estado;
            this.txtBi3.Enabled = estado;
            this.txtBi4.Enabled = estado;
        }

        private void ConfiguraNoNur()
        {
            grpEstado.Enabled = true;
            cboLocation.Enabled = true;
            btnNuevaLoc.Enabled = true;
            txtcc.Enabled = true;
            txtCliente.Enabled = true;
            grpEuid.Enabled = true;
            txtNumEuid.Enabled = true;

            //grpMedidas.Enabled = true;
            txtDistEntreHileras.Enabled = true;
            txtDistSobreHilera.Enabled = true;
            txtTotalPlantas.Enabled = true;
            txtSuperficie.Enabled = true;

            grpUbicacion.Enabled = true;
            txtLatitud.Enabled = true;
            txtLongitud.Enabled = true;
            txtCodigoPoligono.Enabled = true;

            grpExperimento.Enabled = true;
            cboCrop.Enabled = true;
            txtVariedad.Enabled = true;
            chkGmo.Enabled = true;
        }
        #endregion

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            HabiltaControles(false);
            cboTipo.SelectedIndex = -1;
            txtCliente.Text = "";
            cboLocation.SelectedIndex = -1;
            txtcc.Text = "";
            cboCrop.SelectedIndex = -1;
            cboEstado.SelectedIndex = -1;
            btnProcesar.Enabled = false;
        }

        private void CboLocation_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboLocation.SelectedItem != null)
            {
                locationSelected = (InfoLocDto)cboLocation.SelectedItem;
                if (locationSelected.Id > 0)
                {
                    LlenaValoresLocalidad(locationSelected);
                    txtVariedad.Focus();
                    btnExportar.Enabled = true;
                }
            }
        }
        private void LlenaValoresLocalidad(InfoLocDto obj)
        {
            txtDistEntreHileras.Text = ((decimal)obj.DistEntreHileraM).ToString("0.00");
            chkGmo.Checked = (bool)obj.Gmo;
            cboCrop.SelectedValue = obj.id_crop;
            txtDistEntreHileras.Enabled = false;
            chkGmo.Enabled = false;
            cboCrop.Enabled = false;
            txtDistEntreHileras.Focus();
        }
        private void btnProcesar_Click(object sender, EventArgs e)
        {
            string mensaje = "";

            switch (tipo)
            {
                case "NUR":
                    mensaje=ValidaControlesNur();
                    break;
                default:
                    mensaje = ValidaControlesNoNur();
                    break;
            }
            if (mensaje == "")
            {
                CreaEntidad();
            }
            else
            {
                MessageBox.Show(mensaje, "Creación De Template", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string ValidaControlesNur()
        {
            StringBuilder mensaje = new StringBuilder();

            mensaje.Append(ValidaControlesNoNur());

            if (txtNombreExperimento.Text == "")
            {
                mensaje.Append("- Ingrese Experimento" + Environment.NewLine);
            }
            if (txtProjectLead.Text == "")
            {
                mensaje.Append("- Ingrese Project Lead" + Environment.NewLine);
            }
            if (txtProjectCode.Text == "")
            {
                mensaje.Append("- Ingrese Project Code" + Environment.NewLine);
            }
            if (txtGmoEvent.Text == "")
            {
                mensaje.Append("- Ingrese Evento" + Environment.NewLine);
            }
            if (cboSag.Text == "")
            {
                mensaje.Append("- Ingrese Sag" + Environment.NewLine);
            }
            if (txtCodInternacion.Text == "")
            {
                mensaje.Append("- Ingrese Código Internación" + Environment.NewLine);
            }
            if (txtCodRecepcion.Text == "")
            {
                mensaje.Append("- Ingrese Código Recepción" + Environment.NewLine);
            }
            if (txtResolucionImportacion.Text == "")
            {
                mensaje.Append("- Ingrese Resolución Importación" + Environment.NewLine);
            }
            if (txtGranosPorHilera.Text == "")
            {
                mensaje.Append("- Ingrese Número De Granos" + Environment.NewLine);
            }
            if (txtTotalHilera.Text == "")
            {
                mensaje.Append("- Ingrese Total De Hileras" + Environment.NewLine);
            }
            if (txtLargoHilera.Text == "")
            {
                mensaje.Append("- Ingrese Largo De Hilera" + Environment.NewLine);
            }
            //if (txtBi1.Text == "")
            //{
            //    mensaje.Append("- Ingrese 1ra Intrucción" + Environment.NewLine);
            //}
            //if (txtBi2.Text == "")
            //{
            //    mensaje.Append("- Ingrese 2da Intrucción" + Environment.NewLine);
            //}
            //if (txtBi3.Text == "")
            //{
            //    mensaje.Append("- Ingrese 3ra Intrucción" + Environment.NewLine);
            //}
            //if (txtBi4.Text == "")
            //{
            //    mensaje.Append("- Ingrese 4ta Intrucción" + Environment.NewLine);
            //}

            return mensaje.ToString();
        }

        private string ValidaControlesNoNur()
        {
            StringBuilder mensaje = new StringBuilder();

            if (lblOwner.Text =="")
            {
                mensaje.Append("- Owner No Asignado" + Environment.NewLine);
            }
            if (cboTipo.Text == "")
            {
                mensaje.Append("- Tipo Agro No Seleccionado" + Environment.NewLine);
            }
            if (locationSelected.Year ==0)
            {
                mensaje.Append("- Ingrese Año" + Environment.NewLine);
            }
            if (locationSelected.InfoFarm==null || locationSelected.InfoFarm.Country == "")
            {
                mensaje.Append("- Country No Asignado" + Environment.NewLine);
            }
            if (txtCliente.Text == "")
            {
                mensaje.Append("- Ingrese Cliente" + Environment.NewLine);
            }
            if (cboEstado.SelectedIndex == -1)
            {
                mensaje.Append("- Seleccione Estado" + Environment.NewLine);
            }
            if (cboLocation.SelectedIndex == -1)
            {
                mensaje.Append("- Seleccione Localidad" + Environment.NewLine);
            }
            if (txtcc.Text == "")
            {
                mensaje.Append("- Ingrese Centro Costo" + Environment.NewLine);
            }
            if (txtDistEntreHileras.Text == "")
            {
                mensaje.Append("- Ingrese Distancia Entre Hileras" + Environment.NewLine);
            }
            if (txtDistSobreHilera.Text == "")
            {
                mensaje.Append("- Ingrese Distancia Sobre Hilera" + Environment.NewLine);
            }
            if (txtTotalPlantas.Text == "")
            {
                mensaje.Append("- Ingrese Total Plantas" + Environment.NewLine);
            }
            if (txtSuperficie.Text == "")
            {
                mensaje.Append("- Ingrese Superficie" + Environment.NewLine);
            }
            if (txtLatitud.Text == "")
            {
                mensaje.Append("- Ingrese Latitud" + Environment.NewLine);
            }
            if (txtLongitud.Text == "")
            {
                mensaje.Append("- Ingrese Longitud" + Environment.NewLine);
            }
            if (txtCodigoPoligono.Text == "")
            {
                mensaje.Append("- Ingrese Código Poligono" + Environment.NewLine);
            }
            if (cboCrop.SelectedIndex == -1)
            {
                mensaje.Append("- Ingrese Crop" + Environment.NewLine);
            }
            if (txtVariedad.Text == "")
            {
                mensaje.Append("- Ingrese Variedad" + Environment.NewLine);
            }
            return mensaje.ToString();
        }

        private void CreaEntidad()
        {
            this.Cursor = Cursors.WaitCursor;
            CentroCostoExperimentoDto centroCosto = new CentroCostoExperimentoDto();
            List<CentroCostoExperimentoDto> items = new List<CentroCostoExperimentoDto>();

            centroCosto.Year = locationSelected.Year;
            centroCosto.Country = locationSelected.InfoFarm.Country;
            centroCosto.Location = locationSelected.LocationCuartel;
            centroCosto.Crop = cboCrop.Text;
            centroCosto.centro_costo = txtcc.Text.ToUpper();
            centroCosto.Variedad = txtVariedad.Text.ToUpper();
            centroCosto.DistEntreHileraM = decimal.Parse(txtDistEntreHileras.Text);
            centroCosto.DistSobreHileraM = decimal.Parse(txtDistSobreHilera.Text);
            centroCosto.TotPlantasHa = decimal.Parse(txtTotalPlantas.Text);
            centroCosto.SuperficieHa = decimal.Parse(txtSuperficie.Text);
            centroCosto.Latitud = txtLatitud.Text;
            centroCosto.Longitud = txtLongitud.Text;
            centroCosto.CodigoPoligono = txtCodigoPoligono.Text;
            centroCosto.Estado = cboEstado.Text;
            centroCosto.TipoAgro = cboTipo.Text;
            centroCosto.EsGmo = (chkGmo.Checked) ? "YES" : "NO";
            centroCosto.NombreOwner = "Massai";
            centroCosto.ExpName = txtNombreExperimento.Text.ToUpper();
            centroCosto.ProjectLead = txtProjectLead.Text;
            centroCosto.ProjectCode = txtProjectCode.Text.ToUpper();
            centroCosto.Event = txtGmoEvent.Text.ToUpper();
            centroCosto.Sag = cboSag.Text;
            centroCosto.CodInternacion = txtCodInternacion.Text.ToUpper();
            centroCosto.CodReception = txtCodRecepcion.Text.ToUpper();
            centroCosto.Cliente = txtCliente.Text.ToUpper();
            centroCosto.ResImportacion = txtResolucionImportacion.Text.ToUpper();

            if (txtGranosPorHilera.Text != "")
            {
                centroCosto.GranosHilera = float.Parse(txtGranosPorHilera.Text);
            }
            
            centroCosto.BreedersInstructions1 = txtBi1.Text;
            centroCosto.BreedersInstructions2 = txtBi2.Text;
            centroCosto.BreedersInstructions3 = txtBi3.Text;
            centroCosto.BreedersInstructions4 = txtBi4.Text;

            if (txtLargoHilera.Text !="")
            {
                centroCosto.LargoHileraM = decimal.Parse(txtLargoHilera.Text);
            }

            if (txtNumEuid.Text !="")
            {
                centroCosto.NumeroEuid = int.Parse(txtNumEuid.Text);
            }

            if (txtTotalHilera.Text != "")
            {
                centroCosto.TotHileras = int.Parse(txtTotalHilera.Text);
            }

            //centroCosto.id_crop = (int)cboCrop.SelectedValue;
            //centroCosto.id_location = locationSelected.Id;
            //centroCosto.id_estado = (int)cboEstado.SelectedValue;
            //centroCosto.id_tipo_agro = (int)cboTipo.SelectedValue;
            //centroCosto.Gmo = (chkGmo.Checked)?"YES":"NO";

            CreaExcel(centroCosto);
            this.Cursor = Cursors.Default;
        }

        private void CreaExcel(CentroCostoExperimentoDto item)
        {
            string nombreArchivo = "";

            var book = FuncionesExcel.ExportaTemplateEntryList(item,lblInicio.Text);
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
                    MessageBox.Show("Archivo Creado!", "Módulo Centro Costo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    btnProcesar.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: ", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    btnProcesar.Enabled = false;
                }

            }
        }

        private void CalculaTotalPlantasHa(object sender, EventArgs e)
        {
            decimal entre = 0;
            decimal sobre = 0;
            decimal total = 0;
            if (txtDistEntreHileras.Text.IsNumeric() && txtDistSobreHilera.Text.IsNumeric())
            {
                entre = decimal.Parse(txtDistEntreHileras.Text);
                sobre = decimal.Parse(txtDistSobreHilera.Text);
                total = Math.Round((100 / entre) * (100 / sobre));
                txtTotalPlantas.Text = total.ToString();
            }
        }

        private void CalculaTotalPlantasHa(object sender, KeyPressEventArgs e)
        {

        }
    }
}
