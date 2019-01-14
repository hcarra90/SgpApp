using Layer.Business;
using Layer.Entity;
using Layer.Entity.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Layer.Win.Siembra
{
    public partial class FrmNuevaLocation : Form
    {
        #region -----Declaración-----
        public Usuario UsuarioValido { get; set; }
        public TipoAgro TipoAgro { get; set; }

        private delegate void Closure();

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
        int idEmpresa = 0;
        string tipo = "";
        int idOwner = 0;
        InfoFarmDto FarmSelected = new InfoFarmDto();
        FarmDto SubFarmSelected = new FarmDto();
        #endregion

        #region -----Constructor-----
        public FrmNuevaLocation()
        {
            InitializeComponent();
        }
        #endregion

        #region -----Eventos-----
        private void FrmNuevaLocation_Load(object sender, EventArgs e)
        {
            ConfiguraFormulario();
        }

        private void cboTipo_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboTipo.SelectedItem != null)
            {
                var valor = (TipoAgro)cboTipo.SelectedItem;
                if (valor.Codigo != null && valor.Codigo != "")
                {
                    tipo = valor.Codigo;
                    HabilitaControles(tipo, true);
                }
                else
                {
                    HabilitaControles("", false);
                }
            }
        }

        private void cboFarm_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboFarm.SelectedItem != null)
            {
                var valor = (FarmDto)cboFarm.SelectedItem;
                if (valor.CodFarm != "" && valor.FullName != "")
                {
                    cboSubFarm.Enabled = true;
                    LlenaComboSubFarm(valor.CodFarm);
                }
                else
                {
                    cboSubFarm.Enabled = false;
                }
            }
            else
            {
                cboFarm.ValueMember = "CodFarm";
                cboFarm.DisplayMember = "FullName";
                cboFarm.DataSource = null;
            }
        }

        private void cboSubFarm_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboSubFarm.SelectedItem != null)
            {
                SubFarmSelected = (FarmDto)cboSubFarm.SelectedItem;
                if (SubFarmSelected.CodFarm != "" && SubFarmSelected.FullName != "")
                {
                    txtDireccionGd.Text = SubFarmSelected.DireccionGd;
                }
                else
                {
                    txtDireccionGd.Text = "";
                }
            }
            else
            {
                cboFarm.ValueMember = "CodFarm";
                cboFarm.DisplayMember = "FullName";
                cboFarm.DataSource = null;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            HabilitaControles("", false);
        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            string mensaje = "";

            mensaje=ValidaControles("");

            if (mensaje == "")
            {
                CreaEntidad();
            }
            else
            {
                MessageBox.Show(mensaje, "Creación De Template", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region -----Métodos Privados-----
        private void ConfiguraFormulario()
        {
            idEmpresa = int.Parse(ConfigurationManager.AppSettings["IdEmpresa"].ToString());

            LlenaComboTipoAgro();
            LlenaComboEstado();
            LlenaComboFarm();
            LlenaOwner();
            LlenaComboEstado();
            LlenaComboCrop();
            cboTipo.Focus();

            ValidaTemplate();
            txtAnio.Text = DateTime.Now.Year.ToString();
        }
        #endregion

        #region -----Llenado de Combos-----
        private void LlenaComboTipoAgro()
        {
            var data = TipoAgroBusiness.GetDatos(idEmpresa);
            cboTipo.ValueMember = "Id";
            cboTipo.DisplayMember = "Codigo";
            cboTipo.DataSource = data;

            if (TipoAgro.Id > 0)
            {
                cboTipo.SelectedValue = TipoAgro.Id;
            }
        }

        private void LlenaComboEstado()
        {
            var data = EstadoBusiness.GetEstados(idEmpresa);
            cboEstado.ValueMember = "Id";
            cboEstado.DisplayMember = "Descripcion";
            cboEstado.DataSource = data;
        }

        private void LlenaComboFarm()
        {
            var data = InfoFarmBusiness.GetFarmsByEmpresa(idEmpresa);
            cboFarm.ValueMember = "CodFarm";
            cboFarm.DisplayMember = "FullName";
            cboFarm.DataSource = data;
        }

        private void LlenaComboSubFarm(string codFarm)
        {
            var data = InfoFarmBusiness.GetSubFarmsByFarm(codFarm);
            cboSubFarm.ValueMember = "Id";
            cboSubFarm.DisplayMember = "FullName";
            cboSubFarm.DataSource = data;
        }

        private void LlenaComboCrop()
        {
            var data = CropBusiness.GetCrops(idEmpresa);
            cboCrop.ValueMember = "Id";
            cboCrop.DisplayMember = "Descripcion";
            cboCrop.DataSource = data;
        }
        #endregion

        #region -----Otras Configuraciones-----
        private void LlenaOwner()
        {
            var data = ParametroBusiness.GetParametroByTipo("OWN");
            lblOwner.Text = data[0].Valor;
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

        private void HabilitaControles(string tipo, bool estado)
        {
            //Parte Superior Pantalla
            this.grpEstado.Enabled = estado;
            this.grpAnio.Enabled = estado;
            this.txtAnio.Enabled = estado;

            //Grupo Farm
            grpFarm.Enabled = estado;
            cboFarm.Enabled = estado;

            //Grupo Opciones
            this.btnProcesar.Enabled = estado;

            //Grupo Location
            grpLocation.Enabled = estado;
            txtLocation.Enabled = estado;
            txtDireccionGd.Enabled = estado;
            txtJaula.Enabled = estado;

            //Grupo Cultivo
            grpCultivo.Enabled = estado;
            cboCrop.Enabled = estado;
            chkGmo.Enabled = estado;

            //Grupo Ubicación
            this.grpUbicacion.Enabled = estado;
            this.txtLatitud.Enabled = estado;
            this.txtLongitud.Enabled = estado;
            this.txtCodigoPoligono.Enabled = estado;

            //Grupo Fechas
            grpFechas.Enabled = estado;
            dtpSiembra.Enabled = estado;
            dtpTransplante.Enabled = estado;
            dtpCosecha.Enabled = estado;
            dtpPlantacion.Enabled = estado;

            //Grupo Medidas
            this.grpMedidas.Enabled = estado;
            this.txtDistEntreHileras.Enabled = estado;
            this.txtDistSobreHilera.Enabled = estado;
            this.txtSuperficie.Enabled = estado;


            //Grupo Riego
            grpRiego.Enabled = estado;
            txtSemillero.Enabled = estado;
            txtLineaRiego.Enabled = estado;
            txtDistGoteros.Enabled = estado;
            txtCaudalGoteros.Enabled = estado;
            txtTotalLineaRiego.Enabled = estado;

            switch (tipo)
            {
                case "FRUT":
                    txtJaula.Enabled = !estado;
                    dtpTransplante.Enabled = !estado;
                    dtpSiembra.Enabled = !estado;
                    chkGmo.Enabled = !estado;
                    txtSemillero.Enabled = !estado;
                    break;
                case "NUR":
                    dtpPlantacion.Enabled = !estado;
                    break;
                case "CULT":
                    txtJaula.Enabled = !estado;
                    dtpPlantacion.Enabled = !estado;
                    chkGmo.Enabled = !estado;
                    txtSemillero.Enabled = !estado;
                    break;
            }
        }

        private string ValidaControles(string tipo)
        {
            StringBuilder mensaje = new StringBuilder();

            if (lblOwner.Text == "")
            {
                mensaje.Append("- Debes Asiganr Owner" + Environment.NewLine);
            }
            if (cboTipo.Text == "")
            {
                mensaje.Append("- Debes Seleccionar Tipo Agro De La Localidad" + Environment.NewLine);
            }
            if (cboEstado.Text == "")
            {
                mensaje.Append("- Debes Seleccionar Estado De La Localidad" + Environment.NewLine);
            }
            if (txtLocation.Text == "")
            {
                mensaje.Append("- Debes Ingresar Nombre De La Localidad" + Environment.NewLine);
            }
            if (txtAnio.Text == "")
            {
                mensaje.Append("- Debes Ingresar Año De La Localidad" + Environment.NewLine);
            }
            if (FarmSelected == null)
            {
                mensaje.Append("- Debes Seleccionar Farm De La Localidad" + Environment.NewLine);
            }
            else
            {
                if (FarmSelected.Country == "")
                {
                    mensaje.Append("- Debes Asignar País A La Farm Seleccionada" + Environment.NewLine);
                }
                if (FarmSelected.Farm == "")
                {
                    mensaje.Append("- Debes Asignar Nombre De Farm A La Farm Seleccionada" + Environment.NewLine);
                }
                if (FarmSelected.CodFarm == "")
                {
                    mensaje.Append("- Debes Asignar Código A La Farm Seleccionada" + Environment.NewLine);
                }
            }
            if (txtDireccionGd.Text == "")
            {
                mensaje.Append("- Debes Ingresar Dirección De La Localidad" + Environment.NewLine);
            }
            if (cboTipo.Text == "NUR" && txtJaula.Text == "")
            {
                mensaje.Append("- Debes Ingresar Nombre De Jaula" + Environment.NewLine);
            }
            if (cboCrop.Text == "")
            {
                mensaje.Append("- Debes Seleccionar Crop De La Localidad" + Environment.NewLine);
            }
            if (txtDistEntreHileras.Text == "")
            {
                mensaje.Append("- Debes Ingresar Distancia Entre Hileras De La Localidad" + Environment.NewLine);
            }
            if (txtDistSobreHilera.Text == "")
            {
                mensaje.Append("- Debes Ingresar Distancia Sobre Hileras De La Localidad" + Environment.NewLine);
            }
            if (txtSuperficie.Text == "")
            {
                mensaje.Append("- Debes Ingresar Superficie(Ha) De La Localidad" + Environment.NewLine);
            }
            if (cboTipo.Text == "NUR" && txtSemillero.Text == "")
            {
                mensaje.Append("- Debes Ingresar Semillero De La Localidad" + Environment.NewLine);
            }
            if (txtLineaRiego.Text == "")
            {
                mensaje.Append("- Debes Ingresar Línea De Riego De La Localidad" + Environment.NewLine);
            }
            if (txtDistGoteros.Text == "")
            {
                mensaje.Append("- Debes Ingresar Distancia De Goteros De La Localidad" + Environment.NewLine);
            }
            if (txtCaudalGoteros.Text == "")
            {
                mensaje.Append("- Debes Ingresar Caudal De Goteros De La Localidad" + Environment.NewLine);
            }
            if (txtTotalLineaRiego.Text == "")
            {
                mensaje.Append("- Debes Ingresar Total Línea Riego De La Localidad" + Environment.NewLine);
            }
            if (txtLatitud.Text == "")
            {
                mensaje.Append("- Debes Ingresar Latitud De Localidad" + Environment.NewLine);
            }
            if (txtLongitud.Text == "")
            {
                mensaje.Append("- Debes Ingresar Longitud De La Localidad" + Environment.NewLine);
            }
            if (txtCodigoPoligono.Text == "")
            {
                mensaje.Append("- Debes Ingresar Código Polígono De La Localidad" + Environment.NewLine);
            }
            if (cboTipo.Text == "FRUT")
            {

            }
            return mensaje.ToString();
        }

        private void CreaEntidad()
        {
            InfoLoc NewLoc = new InfoLoc
            {
                CaudalGoterosLtsSeg = txtCaudalGoteros.Text,
                CodigoPoligono = txtCodigoPoligono.Text,
                DireccionGd = txtDireccionGd.Text,
                DistEntreHileraM = decimal.Parse(txtDistEntreHileras.Text),
                DistGoterosM = txtDistGoteros.Text,
                DistSobreHileraM = decimal.Parse(txtDistSobreHilera.Text),
                FechaCarga = DateTime.Now,
                FechaEstCosecha = dtpCosecha.Value,
                id_crop = (int)cboCrop.SelectedValue,
                id_estado = (int)cboCrop.SelectedValue,
                id_farm = SubFarmSelected.Id,
                id_tipo_agro = (int)cboTipo.SelectedValue,
                Jaula = txtJaula.Text.ToUpper(),
                Latitud = txtLatitud.Text,
                LineaRiego = txtLineaRiego.Text,
                LocationCuartel = txtLocation.Text.ToUpper(),
                Longitud = txtLongitud.Text,
                Owner = 5,
                SuperficieHa = decimal.Parse(txtSuperficie.Text),
                TotLineaRiegoM = txtTotalLineaRiego.Text,
                Year = int.Parse(txtAnio.Text),
                Gmo = chkGmo.Checked
            };

            if (txtSemillero.Text == "")
            {
                NewLoc.CodSemillero = null;
            }
            else
            {
                NewLoc.CodSemillero = txtSemillero.Text.ToUpper();
            }

            if (cboTipo.Text == "FRUT")
            {
                NewLoc.FechaPlantacion = dtpPlantacion.Value;
                NewLoc.FechaSiembra = null;
                NewLoc.FechaTransplante = null;
            }
            else
            {
                NewLoc.FechaPlantacion = null;
                NewLoc.FechaSiembra = dtpSiembra.Value;
                NewLoc.FechaTransplante = dtpTransplante.Value;
            } 

            try
            {
                InfoLocBusiness.Insert(NewLoc);
                MessageBox.Show("Localidad Creada ", "Módulo Nueva Localidad", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

                ActualizaLocalidades();

                Thread.Sleep(1500);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Módulo Nueva Localidad", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            
        }

        private void ActualizaLocalidades()
        {
            FrmTemplateEntryList frm = (FrmTemplateEntryList)Application.OpenForms["FrmTemplateEntryList"];
            GroupBox grp = (GroupBox)frm.Controls["grpLocation"];
            ComboBox cb = (ComboBox)grp.Controls["cboLocation"];
            var data = InfoLocBusiness.GetLocs();
            cb.ValueMember = "Id";
            cb.DisplayMember = "LocationCuartel";
            cb.DataSource = data;
        }
        #endregion
    }
}
