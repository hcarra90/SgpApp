using Layer.Business;
using Layer.Entity;
using Layer.Entity.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Layer.Functions;

namespace Layer.Win.Consulta
{
    public partial class FrmConsulta : Form
    {
        public Usuario usuarioValido { get; set; }
        List<InfoFieldBook> detailPackingList = new List<InfoFieldBook>();
        List<MovimientoRoggingDto> movRogging = new List<MovimientoRoggingDto>();
        List<MovimientoCosechaDto> movCosecha = new List<MovimientoCosechaDto>();
        List<MovimientoSecadoDto> movSecado = new List<MovimientoSecadoDto>();
        List<MovimientoDesgraneDto> movDesgrane = new List<MovimientoDesgraneDto>();
        List<MovimientoPackingDto> movPacking = new List<MovimientoPackingDto>();
        List<MovimientoShippingDto> movShipping = new List<MovimientoShippingDto>();
        List<EnvioCajaDto> movCaja = new List<EnvioCajaDto>();
        List<EntryList> entryList = new List<EntryList>();
        TrackingDto tracking = new TrackingDto();
        string opcion = "";
        string valor = "";
        string nombreArchivo = "";

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
        public FrmConsulta()
        {
            InitializeComponent();
        }

        private void FrmConsulta_Load(object sender, EventArgs e)
        {
            ConfiguraFormulario();
        }

        private void ConfiguraFormulario()
        {
            DataGridViewCellStyle style = dataDetail.ColumnHeadersDefaultCellStyle;
            style.Font = new Font(dataDetail.Font.FontFamily, 9.25F, FontStyle.Bold);

            //Grilla Rogging
            style = dataRogging.ColumnHeadersDefaultCellStyle;
            style.Font = new Font(dataRogging.Font.FontFamily, 9.25F, FontStyle.Bold);

            //Grilla Cosecha
            style = dataCosecha.ColumnHeadersDefaultCellStyle;
            style.Font = new Font(dataCosecha.Font.FontFamily, 9.25F, FontStyle.Bold);

            //Grilla Secado
            style = dataSecado.ColumnHeadersDefaultCellStyle;
            style.Font = new Font(dataSecado.Font.FontFamily, 9.25F, FontStyle.Bold);

            //Grilla Desagrane
            style = dataDesgrane.ColumnHeadersDefaultCellStyle;
            style.Font = new Font(dataDesgrane.Font.FontFamily, 9.25F, FontStyle.Bold);

            //Grilla Packing
            style = dataPacking.ColumnHeadersDefaultCellStyle;
            style.Font = new Font(dataPacking.Font.FontFamily, 9.25F, FontStyle.Bold);

            //Grilla Preparacion
            style = dataBoxes.ColumnHeadersDefaultCellStyle;
            style.Font = new Font(dataBoxes.Font.FontFamily, 9.25F, FontStyle.Bold);

            //Grilla Envio
            style = dataEnvio.ColumnHeadersDefaultCellStyle;
            style.Font = new Font(dataEnvio.Font.FontFamily, 9.25F, FontStyle.Bold);

            ToolTip toolTip1 = new ToolTip();
            toolTip1.ShowAlways = true;
            toolTip1.SetToolTip(btnBuscar, "Buscar Información");
            toolTip1.SetToolTip(btnLimpiar, "Limpiar Formulario");
            toolTip1.SetToolTip(btnExportar, "Exportar Información");
            toolTip1.SetToolTip(btnEnviar, "Enviar Información Por Email");
            toolTip1.SetToolTip(btnEnvio, "Enviar Mensaje");

            LlenaComboBox();
            txtEuid.Focus();
        }

        private void LlenaComboBox()
        {
            //Combo Ship To
            var data = InfoShippingBusiness.GetAll();
            cboShipTo.DisplayMember = "shipTo";
            cboShipTo.ValueMember = "shipTo";
            cboShipTo.DataSource = data;

            //Combo Project Lead
            var data2 = InfoFieldBookBusiness.GetProjectLead();
            cboProject.DisplayMember = "projectLead";
            cboProject.ValueMember = "projectLead";
            cboProject.DataSource = data2;

            //Combo Emails
            var emails = EmailBusiness.GetEmails();
            cboEmail.DisplayMember = "EmailUsado";
            cboEmail.ValueMember = "Id";
            cboEmail.DataSource = emails;

            //Combo Anio
            var anios = InfoFieldBookBusiness.GetAnio();
            cboAnio.DisplayMember = "anio";
            cboAnio.ValueMember = "anio";
            cboAnio.DataSource = anios;

            //Combo CC
            var ccs = InfoFieldBookBusiness.GetCC();
            cboCC.DisplayMember = "cc";
            cboCC.ValueMember = "cc";
            cboCC.DataSource = ccs;

            //Combo ExpName
            var expNames = InfoFieldBookBusiness.GetExpName();
            cboExpName.DisplayMember = "expName";
            cboExpName.ValueMember = "expName";
            cboExpName.DataSource = expNames;
        }

        private void txtEuid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Enter))
            {
                e.Handled = true;
                return;
            }
            else
            {
                if (e.KeyChar == (char)13)
                {
                    if (txtEuid.Text.Trim() != "")
                    {
                        BuscarInfo(txtEuid.Text.Trim());
                    }
                    else
                    {
                        MessageBox.Show("Debe Ingresar Euid Para Continuar", "Módulo Consulta", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                        txtEuid.Focus();
                    }
                }
            }
        }

        private void BuscarInfo(string valor)
        {
            LlenaGrillaInfo(valor);
            LlenaGrillaEntry(valor);
            LlenaGrillaRogging(valor);
            LlenaGrillaCosecha(valor);
            LlenaGrillaSecador(valor);
            LlenaGrillaDesgrane(valor);
            LlenaGrillaPacking(valor);
            LlenaGrillaBoxes(valor);
            LlenaEnvio(valor);
        }

        private void LlenaGrillaInfo(string valor)
        {
            detailPackingList = InfoFieldBookBusiness.GetEuid(valor,opcion);
            dataDetail.AutoGenerateColumns = false;
            dataDetail.DataSource = detailPackingList;
            dataDetail.ClearSelection();

            var euid = detailPackingList.GroupBy(c => c.euid).Count().ToString();
            var indEuid = detailPackingList.Count(c => c.indEuid != "").ToString();
            lblTotalEuid.Text = euid;
            lblTotalInd.Text = indEuid;

        }

        private void LlenaGrillaEntry(string valor)
        {
            entryList = EntryListBusiness.GetEntryList(valor, opcion);
        }

        private void LlenaGrillaRogging(string valor)
        {
            movRogging = MovimientoRoggingBusiness.GetEuids(valor, opcion);
            dataRogging.AutoGenerateColumns = false;
            dataRogging.DataSource = movRogging;
            dataRogging.ClearSelection();
            lblTotalRogging.Text = dataRogging.RowCount.ToString();
        }

        private void LlenaGrillaCosecha(string valor)
        {
            movCosecha = MovimientoCosechaBusiness.GetEuids(valor, opcion);
            dataCosecha.AutoGenerateColumns = false;
            dataCosecha.DataSource = movCosecha;
            dataCosecha.ClearSelection();
            lblTotalCosecha.Text = dataCosecha.RowCount.ToString();
        }

        private void LlenaGrillaSecador(string valor)
        {
            movSecado = MovimientoSecadoBusiness.GetEuids(valor, opcion);
            dataSecado.AutoGenerateColumns = false;
            dataSecado.DataSource = movSecado;
            dataSecado.ClearSelection();
            lblTotalSecado.Text = dataSecado.RowCount.ToString();
        }

        private void LlenaGrillaDesgrane(string valor)
        {
            movDesgrane = MovimientoDesgraneBusiness.GetEuids(valor,opcion);
            dataDesgrane.AutoGenerateColumns = false;
            dataDesgrane.DataSource = movDesgrane;
            dataDesgrane.ClearSelection();
            lblTotalDesgrane.Text = dataDesgrane.RowCount.ToString();
        }

        private void LlenaGrillaPacking(string valor)
        {
            movPacking = MovimientoPackingBusiness.GetEuids(valor, opcion);
            dataPacking.AutoGenerateColumns = false;
            dataPacking.DataSource = movPacking;
            dataPacking.ClearSelection();
            lblTotalPacking.Text = dataPacking.RowCount.ToString();
        }

        private void LlenaGrillaBoxes(string valor)
        {
            movShipping = MovimientoShippingBusiness.GetEuids(valor, opcion);
            dataBoxes.AutoGenerateColumns = false;
            dataBoxes.DataSource = movShipping;
            dataBoxes.ClearSelection();
            lblTotalLlenado.Text = dataBoxes.RowCount.ToString();
        }

        private void LlenaEnvio(string valor)
        {
            movCaja = MovimientoCajaBusiness.GetDataByEuid(valor, opcion);
            dataEnvio.AutoGenerateColumns = false;
            dataEnvio.DataSource = movCaja;
            dataEnvio.ClearSelection();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (opcion == "Euid" && txtEuid.Text != "")
            {
                valor = txtEuid.Text;
                BuscarInfo(valor);
            }
            else  if (opcion == "Ship To" && cboShipTo.SelectedValue.ToString() !="")
            {
                valor = cboShipTo.SelectedValue.ToString();
                BuscarInfo(valor);
            }
            else if (opcion == "Project Lead" && cboProject.SelectedValue.ToString() != "")
            {
                valor = cboProject.SelectedValue.ToString();
                BuscarInfo(valor);
            }
            else if (opcion == "Exp Name" && cboExpName.SelectedValue.ToString() != "")
            {
                valor = cboExpName.SelectedValue.ToString();
                BuscarInfo(valor);
            }
            else if (opcion == "CC" && cboCC.SelectedValue.ToString() != "")
            {
                valor = cboCC.SelectedValue.ToString();
                BuscarInfo(valor);
            }
            else if (opcion == "Año" && cboAnio.SelectedValue.ToString() != "")
            {
                valor = cboAnio.SelectedValue.ToString();
                BuscarInfo(valor);
            }
            this.Cursor = Cursors.Default;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void LimpiarFormulario()
        {
            txtEuid.Text = "";
            detailPackingList = null;
            movCosecha = null;
            movSecado = null;
            movDesgrane = null;
            movPacking = null;
            movShipping = null;
            movCaja = null;
            movRogging = null;
            entryList = null;
            valor = "";

            dataDetail.DataSource = detailPackingList;
            dataCosecha.DataSource = movCosecha;
            dataSecado.DataSource = movSecado;
            dataDesgrane.DataSource = movDesgrane;
            dataPacking.DataSource = movPacking;
            dataBoxes.DataSource = movShipping;
            dataEnvio.DataSource = movCaja;
            dataRogging.DataSource = movRogging;

            txtEmail.Text = "";
            txtMensaje.Text = "";
            pnlEmail.Visible = false;
            nombreArchivo = "";

            cboProject.SelectedIndex = -1;
            cboShipTo.SelectedIndex = -1;
            cboAnio.SelectedIndex = -1;
            cboExpName.SelectedIndex = -1;
            cboCC.SelectedIndex = -1;

            txtEuid.Visible = false;
            cboShipTo.Visible = false;
            cboProject.Visible = false;
            cboCC.Visible = false;
            cboExpName.Visible = false;
            cboAnio.Visible = false;
            cboBusqueda.SelectedIndex = -1;

            lblTotalDesgrane.Text = "0";
            lblTotalEuid.Text="0";
            lblTotalInd.Text = "0";
            lblTotalLlenado.Text = "0";
            lblTotalPacking.Text = "0";
            lblTotalSecado.Text = "0";
            lblTotalCosecha.Text = "0";
            lblTotalRogging.Text = "0";

            cboBusqueda.Focus();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void FrmConsulta_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void cboBusqueda_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void cboBusqueda_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboBusqueda.SelectedItem != null && cboBusqueda.SelectedItem.ToString() != "")
            {
                opcion = cboBusqueda.SelectedItem.ToString();
                MuestraBusqueda(opcion);
            }
        }

        private void MuestraBusqueda(string opcion)
        {
            switch (opcion)
            {
                case "Euid":
                    txtEuid.Visible = true;
                    cboShipTo.Visible = false;
                    cboProject.Visible = false;
                    cboCC.Visible = false;
                    cboExpName.Visible = false;
                    cboAnio.Visible = false;
                    break;
                case "Ship To":
                    txtEuid.Visible = false;
                    cboShipTo.Visible = true;
                    cboProject.Visible = false;
                    cboCC.Visible = false;
                    cboExpName.Visible = false;
                    cboAnio.Visible = false;
                    break;
                case "Project Lead":
                    txtEuid.Visible = false;
                    cboShipTo.Visible = false;
                    cboProject.Visible = true;
                    cboCC.Visible = false;
                    cboExpName.Visible = false;
                    cboAnio.Visible = false;
                    break;
                case "Exp Name":
                    txtEuid.Visible = false;
                    cboShipTo.Visible = false;
                    cboProject.Visible = false;
                    cboCC.Visible = false;
                    cboExpName.Visible = true;
                    cboAnio.Visible = false;
                    break;
                case "CC":
                    txtEuid.Visible = false;
                    cboShipTo.Visible = false;
                    cboProject.Visible = false;
                    cboCC.Visible = true;
                    cboExpName.Visible = false;
                    cboAnio.Visible = false;
                    break;
                case "Año":
                    txtEuid.Visible = false;
                    cboShipTo.Visible = false;
                    cboProject.Visible = false;
                    cboCC.Visible = false;
                    cboExpName.Visible = false;
                    cboAnio.Visible = true;
                    break;
            }
            
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (detailPackingList.Count > 0 || movCosecha.Count > 0 || movSecado.Count > 0 || movDesgrane.Count > 0 
                || movPacking.Count > 0 || movShipping.Count > 0 || movCaja.Count > 0 || entryList.Count > 0)
            {
                ExportaDatos();
                this.Cursor = Cursors.Default;
            }
        }

        private void ExportaDatos()
        {
            this.Cursor = Cursors.WaitCursor;
            tracking.Info = detailPackingList;
            tracking.Cosecha = movCosecha;
            tracking.Desgrane = movDesgrane;
            tracking.Secado = movSecado;
            tracking.Packing = movPacking;
            tracking.Shipping = movShipping;
            tracking.Caja = movCaja;
            tracking.Rogging = movRogging;
            tracking.EntryList = entryList;

            var wb = FuncionesExcel.ExportaTracking(tracking,opcion,valor);

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
                    wb.SaveAs(nombreArchivo);
                    MessageBox.Show("Archivo Creado!", "Módulo Packing", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: ", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }

            }
        }

        private void btnEnvio_Click(object sender, EventArgs e)
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

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            if (nombreArchivo != "")
            {
                pnlEmail.Visible = true;
                tabData.SelectedIndex = 0;
            }
        }

        private void EnvioEmail()
        {
            TransactionalInformation transaccion = new TransactionalInformation();
            var rs = FuncionesEmail.EnvioEmail(nombreArchivo, txtEmail.Text, txtMensaje.Text,"Archivo de Tracking");
            if (rs)
            {
                MessageBox.Show("Archivo Enviado!", "Módulo Packing List", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                var email = EmailBusiness.GetEmail(txtEmail.Text);
                if (email == null)
                {
                    EmailBusiness.GrabaInformacion(new Email { EmailUsado = txtEmail.Text }, out transaccion);
                }
            }
            else
            {
                MessageBox.Show("Problemas al enviar el archivo!", "Módulo Packing List", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void cboEmail_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboEmail.Text != "")
            {
                txtEmail.Text = cboEmail.Text;
            }
        }
    }
}
