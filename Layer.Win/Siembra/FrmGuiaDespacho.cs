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

namespace Layer.Win.Siembra
{
    public partial class FrmGuiaDespacho : Form
    {
        #region -----Declaraciones-----
        public Usuario usuarioValido = new Usuario();
        InfoLocDto locationSelected = new InfoLocDto();
        CropDto cropSelected = new CropDto();
        List<DataGuiaDespachoDto> detalle = new List<DataGuiaDespachoDto>();
        List<DatosGuia> datosGuia = new List<DatosGuia>();
        DatosGuia itemGuia = new DatosGuia();
        Conductor conductorSelected = new Conductor();
        Vehiculo vehiculoSelected = new Vehiculo();
        FarmDto origenSelected = new FarmDto();
        FarmDto destinoSelected = new FarmDto();
        #endregion
        #region -----Constructores-----
        public FrmGuiaDespacho()
        {
            InitializeComponent();
        }
        #endregion

        #region -----Eventos-----

        private void FrmGuiaDespacho_Load(object sender, EventArgs e)
        {
            ConfiguraFormulario();
        }

        private void CboLocation_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboLocation.SelectedItem != null)
            {
                locationSelected = (InfoLocDto)cboLocation.SelectedItem;
                if (locationSelected.Id > 0)
                {
                    LlenaComboTipoConversion(locationSelected);
                }
            }
            else
            {
                locationSelected = new InfoLocDto();
            }
        }

        private void CboConversion_SelectedValueChanged(object sender, EventArgs e)
        {
            cropSelected = (CropDto)cboConversion.SelectedItem;
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            if (locationSelected.Id == 0)
            {
                MessageBox.Show("Debe Seleccionar Location", "Módulo Guía Despacho", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }
            if (cropSelected.TipoConversion == "")
            {
                MessageBox.Show("Debe Seleccionar Tipo De Conversión", "Módulo Guía Despacho", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }

            BuscarInformacion(locationSelected.LocationCuartel);
            if (detalle.Count > 0)
            {
                lblTotalKilos.Text = detalle.Sum(p => p.Peso).ToString();
                grpConductor.Enabled = true;
                grpLocalidad.Enabled = true;
                cboOrigen.Focus();
            }
        }

        private void CboConductor_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboConductor.SelectedItem != null)
            {
                conductorSelected = (Conductor)cboConductor.SelectedItem;
                if (conductorSelected.Id > 0)
                {
                    txtRut.Text = conductorSelected.Rut;
                    txtRut.Focus();
                }
                else
                {
                    txtRut.Text = "";
                    conductorSelected = null;
                }
            }
        }

        private void CboPatente_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboPatente.SelectedItem != null)
            {
                vehiculoSelected = (Vehiculo)cboPatente.SelectedItem;
                if (vehiculoSelected.Id > 0)
                {
                    btnGenerar.Focus();
                }
                else
                {
                    vehiculoSelected = null;
                }
            }
        }

        private void BtnGenerar_Click(object sender, EventArgs e)
        {
            string resultado = ValidarFormulario();

            if (resultado =="")
            {
                GeneraDatosGuia();
                MessageBox.Show("Datos Generados Correctamente!", "Módulo Guías", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            else
            {
                MessageBox.Show("Debe Ingresar Los Siguientes Datos: " + Environment.NewLine + Environment.NewLine + resultado, "Módulo Guías", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            }
            
            
        }

        private void CboOrigen_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboOrigen.SelectedItem != null)
            {
                origenSelected = (FarmDto)cboOrigen.SelectedItem;
            }
            else
            {
                origenSelected = null;
            }
        }

        private void CboDestino_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboDestino.SelectedItem != null)
            {
                destinoSelected = (FarmDto)cboDestino.SelectedItem;
            }
            else
            {
                destinoSelected = null;
            }
        }

        #endregion

        #region -----Funciones-----

        private void ConfiguraFormulario()
        {
            LlenaComboOrigen();
            LlenaComboDestino();
            LlenaComboLocation();
            LlenaComboConductor();
            LlenaComboVehiculo();

            DataGridViewCellStyle style = grdDetalle.ColumnHeadersDefaultCellStyle;
            style.Font = new Font(grdDetalle.Font.FontFamily, 8.75F, FontStyle.Regular);
        }

        private void LlenaComboOrigen()
        {
            var data = new List<FarmDto>();

            data = InfoFarmBusiness.GetDirByEmpresa(usuarioValido.id_empresa);
            cboOrigen.ValueMember = "Id";
            cboOrigen.DisplayMember = "DireccionGd";
            cboOrigen.DataSource = data;
            cboOrigen.Refresh();
        }

        private void LlenaComboDestino()
        {
            var data = new List<FarmDto>();

            data = InfoFarmBusiness.GetDirByEmpresa(usuarioValido.id_empresa);
            cboDestino.ValueMember = "Id";
            cboDestino.DisplayMember = "DireccionGd";
            cboDestino.DataSource = data;
            cboDestino.Refresh();
        }

        private void LlenaComboLocation()
        {
            var data = new List<InfoLocDto>();

            data = InfoLocBusiness.GetLocsByEmpresa(usuarioValido.id_empresa);
            cboLocation.ValueMember = "Id";
            cboLocation.DisplayMember = "LocationCuartel";
            cboLocation.DataSource = data;
            cboLocation.Refresh();
        }

        private void LlenaComboTipoConversion(InfoLocDto locationSelected)
        {
            var data = new List<CropDto>();

            data = EntryListBusiness.GetTipoConversion(usuarioValido.id_empresa, locationSelected.LocationCuartel);
            cboConversion.ValueMember = "Crop";
            cboConversion.DisplayMember = "TipoConversion";
            cboConversion.DataSource = data;
            cboConversion.Refresh();
        }

        private void LlenaComboConductor()
        {
            var data = new List<Conductor>();

            data = ConductorBusiness.GetConductores(usuarioValido.id_empresa);
            cboConductor.ValueMember = "Id";
            cboConductor.DisplayMember = "Nombre";
            cboConductor.DataSource = data;
            cboConductor.Refresh();
        }

        private void LlenaComboVehiculo()
        {
            var data = new List<Vehiculo>();

            data = VehiculoBusiness.GetVehiculos(usuarioValido.id_empresa);
            cboPatente.ValueMember = "Id";
            cboPatente.DisplayMember = "Patente";
            cboPatente.DataSource = data;
            cboPatente.Refresh();
        }

        private void BuscarInformacion(string location)
        {
            detalle = EntryListBusiness.GetDataGuiaDespacho(location);
            grdDetalle.AutoGenerateColumns = false;
            grdDetalle.DataSource = detalle;
            grdDetalle.ClearSelection();
        }

        private string ValidarFormulario()
        {
            StringBuilder resultado = new StringBuilder();

            if (detalle.Count == 0)
            {
                resultado.Append("- Detalle De Siembra");
                resultado.Append(Environment.NewLine);
            }
            if (origenSelected == null || origenSelected.DireccionGd =="")
            {
                resultado.Append("- Origen");
                resultado.Append(Environment.NewLine);
            }
            if (destinoSelected == null || destinoSelected.DireccionGd =="")
            {
                resultado.Append("- Destino");
                resultado.Append(Environment.NewLine);
            }
            if (conductorSelected == null)
            {
                resultado.Append("- Conductor");
                resultado.Append(Environment.NewLine);
            }
            if (txtRut.Text == "")
            {
                resultado.Append("- Rut");
                resultado.Append(Environment.NewLine);
            }
            if (vehiculoSelected == null)
            {
                resultado.Append("- Patente");
                resultado.Append(Environment.NewLine);
            }
            return resultado.ToString();
        }

        private void GeneraDatosGuia()
        {
            try
            {
                //Validar Si Existe Conductor
                if (conductorSelected == null)
                {
                    conductorSelected = new Conductor
                    {
                        id_empresa = usuarioValido.id_empresa,
                        FechaCreacion = DateTime.Now,
                        Nombre = cboConductor.Text,
                        Rut = txtRut.Text,
                        UsuarioCreacion = usuarioValido.nombre_usuario
                    };
                    ConductorBusiness.Insert(conductorSelected);
                }

                //Validar Si Existe Vehiculo
                if (vehiculoSelected == null)
                {
                    vehiculoSelected = new Vehiculo
                    {
                        id_empresa = usuarioValido.id_empresa,
                        FechaCreacion = DateTime.Now,
                        UsuarioCreacion = usuarioValido.nombre_usuario,
                        Patente = cboPatente.Text
                    };
                    VehiculoBusiness.Insert(vehiculoSelected);
                }

                //Generar Datos Guía Despacho
                foreach (var item in detalle)
                {
                    itemGuia = new DatosGuia
                    {
                        FechaGuia = dtpGuia.Value.Date,
                        Origen = origenSelected.DireccionGd,
                        Destino = destinoSelected.DireccionGd,
                        Location = item.Location,
                        Crop = item.Crop,
                        Experimento = item.Experiment,
                        Evento = item.Event,
                        Gmo = (item.Event == "NOGMO") ? false : true,
                        Sag = item.Sag,
                        Cc = item.CentroCosto,
                        CodInternacion = item.CodInternacion,
                        NumeroEuid = item.NumeroEuid,
                        Kilos = item.Peso,
                        Conductor = conductorSelected.Nombre,
                        Rut = txtRut.Text,
                        Patente = vehiculoSelected.Patente,
                        FechaCreacion = DateTime.Now,
                        UsuarioCreacion = usuarioValido.nombre_usuario
                        //id_empresa = usuarioValido.id_empresa,
                    };
                    datosGuia.Add(itemGuia);
                }
                DatosGuiaBusiness.InsertBulk(datosGuia);
                GeneraExcel();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void GeneraExcel()
        {
            List<string[]> titulos = new List<string[]>();

            string[] t1 = new string[]{ "Fecha","Origen","Destino","Location","Crop",
                "Experiment", "Evento","Gmo","Sag", "Cc",
                "Internación", "N°Euid","Kilos","Conductor","Rut","Patente","Creación","Usuario" };
            titulos.Add(t1);
            var archivo = FuncionesExcel.ExportaGuiaDespacho(datosGuia,"Detalle Guía Despacho", titulos);
            archivo.SaveAs(@"C:\Template\Test.xlsx");
        }

        #endregion

        
    }
}
