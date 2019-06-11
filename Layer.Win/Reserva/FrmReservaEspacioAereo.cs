using Layer.Business;
using Layer.Entity;
using Layer.Entity.Dto;
using Layer.Functions;
using Layer.Win.Constantes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Layer.Win.Reserva
{
    public partial class FrmReservaEspacioAereo : Form
    {
        #region -----Declaraciones-----
        public Usuario usuarioValido { get; set; }
        List<ReservaEspacioDto> reservas = new List<ReservaEspacioDto>();
        ListaComboDto tipoReserva = new ListaComboDto();
        Pais pais = new Pais();
        InfoShipping shipTo = new InfoShipping();
        Puerto puerto = new Puerto();
        InfoShipping direccion = new InfoShipping();
        TipoEnvase tipoEnvase = new TipoEnvase();
        StringBuilder mensaje = new StringBuilder();
        ReservaEspacio reservaEspacio = new ReservaEspacio();
        #endregion

        #region -----Constructores-----
        public FrmReservaEspacioAereo()
        {
            InitializeComponent();
        }
        #endregion

        #region -----Eventos-----
        private void FrmReservaEspacioAereo_Load(object sender, EventArgs e)
        {
            ConfiguraFormulario();
        }
        private void CboTipoReserva_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboTipoReserva.SelectedItem != null)
            {
                tipoReserva = ((ListaComboDto)cboTipoReserva.SelectedItem);

                if (tipoReserva.Valor > 1)
                {
                    ConfiguraControles(true);
                    
                }
                else
                {
                    ConfiguraControles(false);
                }
                brnGrabar.Enabled = true;
            }
            else
            {
                ConfiguraControles(false);
                brnGrabar.Enabled = false;
            }
        }
        private void CboPais_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboPais.SelectedItem != null)
            {
                pais= (Pais)cboPais.SelectedItem;
                if (pais.Id > 0)
                {
                    LlenaComboBox(pais.Nombre);
                    LlenaComboPuerto(pais.Id);
                }
                else
                {
                    LlenaComboBox("");
                    LlenaComboPuerto(0);
                }
            }
            else
            {
                LlenaComboBox("");
                LlenaComboPuerto(0);
                LlenaComboDireccion("");

            }
        }
        private void CboShipTo_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboShipTo.SelectedItem != null)
            {
                shipTo = (InfoShipping)cboShipTo.SelectedItem;
                if (shipTo.Id > 0)
                {
                    LlenaComboDireccion(shipTo.shipTo);
                }
                else
                {
                    LlenaComboDireccion("");
                }
            }
            else
            {
                LlenaComboDireccion("");
            }
        }
        private void CboTipoEnvase_SelectedValueChanged(object sender, EventArgs e)
        {
            tipoEnvase = (TipoEnvase)cboTipoEnvase.SelectedItem;
        }
        private void CboPuerto_SelectedValueChanged(object sender, EventArgs e)
        {
            puerto = (Puerto)cboPuerto.SelectedItem;
        }
        private void CboDireccion_SelectedValueChanged(object sender, EventArgs e)
        {
            direccion = (InfoShipping)cboDireccion.SelectedItem;
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }
        private void brnGrabar_Click(object sender, EventArgs e)
        {
            GrabarReserva();
        }
        private void CboEmail_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboEmail.Text != "")
            {
                txtEmail.Text = cboEmail.Text;
            }
        }
        private void BtnEnvio_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (FuncionesEmail.emailIsValid(txtEmail.Text))
            {
                EnvioEmail();
            }
            else
            {
                MessageBox.Show("Email Inválido!", "Módulo Packing List", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                this.Cursor = Cursors.Default;
            }
            this.Cursor = Cursors.Default;
        }
        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            LlenaGrilla();
        }
        #endregion

        #region -----Funciones-----
        private void ConfiguraFormulario()
        {
            DataGridViewCellStyle style = grdReservas.ColumnHeadersDefaultCellStyle;
            style.Font = new Font(grdReservas.Font.FontFamily, 8.75F, FontStyle.Bold);

            LlenaComboTipo();
            LlenaComboTipoEnvase();
            LlenaComboPais();
            LlenaComboCantidad();
            LlenaComboEmails();
            cboCantidad.SelectedIndex=1;
            cboCantidad.Focus();
        }
        private void LlenaGrilla()
        {
            reservas = ReservaEspacioBusiness.GetReservaEspacio(usuarioValido.id_empresa,dtpInicio.Value,dtpFin.Value);
            
            grdReservas.AutoGenerateColumns = false;
            grdReservas.DataSource = reservas;
            grdReservas.ClearSelection();
        }
        private void LlenaComboBox(string pais)
        {
            List<InfoShipping> data = new List<InfoShipping>();
            if (pais !="")
            {
                data = InfoShippingBusiness.GetShipToByCountry(pais);
            }
            else
            {
                data = null;
            }
            
            cboShipTo.DisplayMember = "shipTo";
            cboShipTo.ValueMember = "shipTo";
            cboShipTo.DataSource = data;
        }
        private void LlenaComboTipo()
        {
            var data = DataFunctions.GetTipoReserva();
            cboTipoReserva.DisplayMember = "Nombre";
            cboTipoReserva.ValueMember = "Valor";
            cboTipoReserva.DataSource = data;
        }
        private void LlenaComboTipoEnvase()
        {
            var data = TipoEnvaseBusiness.GetTipoEnvase(usuarioValido.id_empresa);
            cboTipoEnvase.DisplayMember = "Nombre";
            cboTipoEnvase.ValueMember = "Id";
            cboTipoEnvase.DataSource = data;
        }
        private void LlenaComboPais()
        {
            var data = PaisBusiness.GetPais(usuarioValido.id_empresa);
            cboPais.DisplayMember = "Nombre";
            cboPais.ValueMember = "Id";
            cboPais.DataSource = data;
        }
        private void LlenaComboPuerto(int idPais)
        {
            List<Puerto> data = new List<Puerto>();
            if (idPais > 0)
            {
                data = PuertoBusiness.GetPuertoByPais(usuarioValido.id_empresa, idPais);
            }
            else
            {
                data = null;
            }
            
            cboPuerto.DisplayMember = "Nombre";
            cboPuerto.ValueMember = "Id";
            cboPuerto.DataSource = data;
        }
        private void LlenaComboDireccion(string shipTo)
        {
            List<InfoShipping> data = new List<InfoShipping>();
            if (shipTo != "")
            {
                data = InfoShippingBusiness.GetAdressByShipTo(shipTo);
            }
            else
            {
                data = null;
            }

            cboDireccion.DisplayMember = "address";
            cboDireccion.ValueMember = "address";
            cboDireccion.DataSource = data;
        }
        private void LlenaComboCantidad()
        {
            var data = DataFunctions.GetCantidad();
            cboCantidad.DisplayMember = "Nombre";
            cboCantidad.ValueMember = "Valor";
            cboCantidad.DataSource = data;
        }
        private void LlenaComboEmails()
        {
            //Combo Emails
            var emails = EmailBusiness.GetEmails();
            cboEmail.DisplayMember = "EmailUsado";
            cboEmail.ValueMember = "Id";
            cboEmail.DataSource = emails;
        }

        private void ConfiguraControles(bool enabled)
        {
            dtpFechaLlegada.Enabled = enabled;
            cboPuerto.Enabled = enabled;
            cboDireccion.Enabled = enabled;
        }
        private void LimpiarFormulario()
        {
            cboTipoReserva.SelectedIndex = -1;
            cboPais.SelectedIndex = -1;
            cboPuerto.SelectedIndex = -1;
            cboShipTo.SelectedIndex = -1;
            cboTipoEnvase.SelectedIndex = -1;
            cboDireccion.SelectedIndex = -1;
            txtLargo.Text = "";
            txtAncho.Text = "";
            txtAlto.Text = "";
            txtNeto.Text = "";
            txtBruto.Text = "";
            dtpFechaEnvio.Value = DateTime.Now.Date;
            dtpFechaLlegada.Value = DateTime.Now.Date;
            pnlEmail.Visible = false;
            cboTipoReserva.Focus();
        }
        private bool ValidaFormulario()
        {
            bool valido = true;   
            mensaje.Append("Debe Ingresar Los Siguientes Datos: ");
            mensaje.Append(Environment.NewLine);

            if (tipoReserva.Valor == 0)
            {
                mensaje.Append("- Cantidad");
                mensaje.Append(Environment.NewLine);
                valido = false;
            }

            if (tipoReserva.Valor == 0)
            {
                mensaje.Append("- Tipo Reserva");
                mensaje.Append(Environment.NewLine);
                valido = false;
            }
            if (pais.Id == 0)
            {
                mensaje.Append("- País");
                mensaje.Append(Environment.NewLine);
                valido = false;
            }
            //if (shipTo.Id == 0)
            //{
            //    mensaje.Append("- Ship To");
            //    mensaje.Append(Environment.NewLine);
            //    valido = false;
            //}
            if (tipoEnvase.Id == 0)
            {
                mensaje.Append("- Tipo De Envase");
                mensaje.Append(Environment.NewLine);
                valido = false;
            }

            if (tipoReserva.Valor == 2)
            {
                if ( puerto.Id == 0)
                {
                    mensaje.Append("- Puerto");
                    mensaje.Append(Environment.NewLine);
                    valido = false;
                }
                //if (direccion.Id == 0)
                //{
                //    mensaje.Append("- Dirección");
                //    mensaje.Append(Environment.NewLine);
                //    valido = false;
                //}
                if (dtpFechaLlegada.Value > dtpFechaEnvio.Value)
                {
                    mensaje.Append("- Fecha LLegada No Puede Ser Mayor A Fecha De Envío");
                    mensaje.Append(Environment.NewLine);
                    valido = false;
                }
            }
            if (!txtLargo.Text.IsNumeric())
            {
                mensaje.Append("- Largo Inválido");
                mensaje.Append(Environment.NewLine);
                valido = false;
            }
            if (!txtAlto.Text.IsNumeric())
            {
                mensaje.Append("- Alto Inválido");
                mensaje.Append(Environment.NewLine);
                valido = false;
            }
            if (!txtAncho.Text.IsNumeric())
            {
                mensaje.Append("- Ancho Inválido");
                mensaje.Append(Environment.NewLine);
                valido = false;
            }
            if (!txtNeto.Text.IsNumeric())
            {
                mensaje.Append("- Kilos Netos Inválido");
                mensaje.Append(Environment.NewLine);
                valido = false;
            }
            if (!txtBruto.Text.IsNumeric())
            {
                mensaje.Append("- Kilos Brutos Inválido");
                mensaje.Append(Environment.NewLine);
                valido = false;
            }

            return valido;
        }
        private void GrabarReserva()
        {
            bool valido = ValidaFormulario();
            if (!valido)
            {
                MessageBox.Show(mensaje.ToString(), Mensajes.TitReservaEspacio, MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            }
            else
            {
                try
                {
                    reservaEspacio.Alto = decimal.Parse(txtAlto.Text);
                    reservaEspacio.Ancho = decimal.Parse(txtAncho.Text);
                    reservaEspacio.Direccion = direccion.address;
                    reservaEspacio.FechaCarga = DateTime.Now;
                    reservaEspacio.FechaReserva = dtpFechaEnvio.Value.Date;
                    reservaEspacio.IdTipoReserva = tipoReserva.Valor;
                    reservaEspacio.Cantidad = int.Parse(cboCantidad.Text);
                    reservaEspacio.id_empresa = usuarioValido.id_empresa;
                    reservaEspacio.id_pais = pais.Id;
                    reservaEspacio.id_puerto = (puerto.Id == 0) ? null: puerto.Id;
                    reservaEspacio.id_tipo_envase = tipoEnvase.Id;
                    reservaEspacio.KilosBrutos = decimal.Parse(txtBruto.Text);
                    reservaEspacio.KilosNetos = decimal.Parse(txtNeto.Text);
                    reservaEspacio.Largo = decimal.Parse(txtLargo.Text);
                    reservaEspacio.ShipTo = shipTo.shipTo;
                    reservaEspacio.UsuarioCarga = usuarioValido.nombre_usuario;
                    ReservaEspacioBusiness.Insert(reservaEspacio);
                    MessageBox.Show(Mensajes.MjeCorrecto + "Reserva Creada!", Mensajes.TitReservaEspacio, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    txtMensaje.Text = "Por Favor Solicitar Espacio " + tipoReserva.Nombre + " Para " + pais.Nombre + " y Tipo De Carga " + tipoEnvase.Nombre;
                    pnlEmail.Visible = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(Mensajes.MjeError + ex.Message, Mensajes.TitReservaEspacio, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
        }
        private void EnvioEmail()
        {
            TransactionalInformation transaccion = new TransactionalInformation();
            var rs = FuncionesEmail.EnvioEmail("", txtEmail.Text, txtMensaje.Text, "Solicitud De Reserva De Espacio " + tipoReserva.Nombre);
            if (rs)
            {
                MessageBox.Show("Archivo Enviado!", "Módulo Packing List", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                var email = EmailBusiness.GetEmail(txtEmail.Text);
                if (email == null)
                {
                    EmailBusiness.GrabaInformacion(new Email { EmailUsado = txtEmail.Text }, out transaccion);
                }
                txtEmail.Text = "";
                pnlEmail.Visible = false;
            }
            else
            {
                MessageBox.Show("Problemas al enviar el archivo!", "Módulo Packing List", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }
        #endregion

        
    }
}
