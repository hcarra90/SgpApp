using Layer.Business;
using Layer.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Com.SharpZebra.Printing;
using System.Runtime.InteropServices;

namespace Layer.Win.Shipping
{
    public partial class FrmCaja : Form
    {
        public Usuario usuarioValido { get; set; }
        private StringBuilder zebraInstructions = new StringBuilder();
        private string impresora = "";
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        public FrmCaja()
        {
            InitializeComponent();
        }

        private void FrmCaja_Load(object sender, EventArgs e)
        {
            ConfiguraFormulario();
        }

        private void ConfiguraFormulario()
        {
            DataGridViewCellStyle style = dataCajasNuevas.ColumnHeadersDefaultCellStyle;
            style.Font = new Font(dataCajasNuevas.Font.FontFamily, 9.75F, FontStyle.Bold);
            LlenaComboBox();
            impresora = ParametroBusiness.GetParametroByTipo("PRT")[0].Valor;
        }

        //LLeno Grillas de Cajas
        private void LlenaGrillaCajas(string shipTo)
        {
            var dataCajas = MovimientoCajaBusiness.GetCajasByShipTo(shipTo);
            dataCajasNuevas.AutoGenerateColumns = false;
            dataCajasNuevas.DataSource = dataCajas;
            dataCajasNuevas.ClearSelection();
        }

        private void LlenaComboBox()
        {
            var data = InfoShippingBusiness.GetAll();
            cboShipTo.DisplayMember = "shipTo";
            cboShipTo.ValueMember = "shipTo";
            cboShipTo.DataSource = data;

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (cboShipTo.SelectedValue.ToString() != "")
            {
                TransactionalInformation transaccion = new TransactionalInformation();
                var caja = MovimientoCajaBusiness.GetNumeroCaja(cboShipTo.SelectedValue.ToString());
                MovimientoCaja nuevaCaja = new MovimientoCaja();

                nuevaCaja.correlativo = caja.correlativo;
                nuevaCaja.cajaEnvio = caja.nuevaCaja;
                nuevaCaja.usuario = usuarioValido.nombre_usuario;
                nuevaCaja.shipTo = cboShipTo.SelectedValue.ToString();
                nuevaCaja.fechaCreacion = (DateTime)DateTime.Now.Date;

                MovimientoCajaBusiness.GrabaInformacion(nuevaCaja, out transaccion);
                if (transaccion.ReturnStatus)
                {
                    ImprimirEtiqueta(cboShipTo.SelectedValue.ToString(), nuevaCaja.cajaEnvio);
                    LlenaGrillaCajas(cboShipTo.SelectedValue.ToString());
                    MessageBox.Show("Caja Creada!", "Módulo Packing", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
            }
        }

        private void cboShipTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            if (cb.SelectedValue.ToString() != "")
            {
                LlenaGrillaCajas(cb.SelectedValue.ToString());
            }
        }

        private void dataCajasNuevas_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int currentMouseOverRow = dataCajasNuevas.HitTest(e.X, e.Y).RowIndex;
                ctxCajaMenu.Show(dataCajasNuevas, new Point(e.X, e.Y));
            }
        }

        private void ImprimirEtiqueta(string shipTo,string caja)
        {
            var info = InfoShippingBusiness.GetInfoShipping(shipTo);
            if (info !=null && impresora !="")
            {
                zebraInstructions = new StringBuilder();
                zebraInstructions.Append("^XA");

                zebraInstructions.Append("^FT413,153^A0N,39,38^FH\\^FDCountry:^FS");
                zebraInstructions.Append("^FT572,153^A0N,39,38^FH\\^FD" + info.country + "^FS" + Environment.NewLine);

                zebraInstructions.Append("^FT21,371^A0N,39,38^FH\\^FDState:^FS");
                zebraInstructions.Append("^FT192,367^A0N,28,28^FH\\^FD" + info.state + "^FS" + Environment.NewLine);

                zebraInstructions.Append("^FT21,270^A0N,39,38^FH\\^FDCity:^FS");
                zebraInstructions.Append("^FT167,263^A0N,25,24^FH\\^FD" + info.city + "^FS" + Environment.NewLine);

                zebraInstructions.Append("^FT21,219^A0N,39,38^FH\\^FDAddress:^FS");
                zebraInstructions.Append("^FT165,213^A0N,25,24^FH\\^FD" + info.address + "^FS" + Environment.NewLine);

                zebraInstructions.Append("^FT23,420^A0N,39,38^FH\\^FDClient:^FS");
                zebraInstructions.Append("^FT175,420^A0N,39,30^FH\\^FD" + info.client + "^FS" + Environment.NewLine);

                zebraInstructions.Append("^FT23,465^A0N,39,38^FH\\^FDContact:^FS");
                zebraInstructions.Append("^FT175,465^A0N,39,38^FH\\^FD" + info.contact + "^FS" + Environment.NewLine);

                zebraInstructions.Append("^FT22,153^A0N,39,38^FH\\^FDShip To:^FS");
                zebraInstructions.Append("^^FT184,153^A0N,39,38^FH\\^FD" + info.shipTo + "^FS" + Environment.NewLine);

                zebraInstructions.Append("^FT195,66^A0N,39,38^FH\\^FDBOXID:^FS" + Environment.NewLine);
                zebraInstructions.Append("^BY3,3,56^FT327,76^BCN,,Y,N");
                zebraInstructions.Append("^FD>:" + caja + "^FS" + Environment.NewLine);

                //Codigo QR
                zebraInstructions.Append("^FT687,112^BQN,2,4" + Environment.NewLine);
                zebraInstructions.Append(@"^FH\^FDLA" + caja + "^FS");

                zebraInstructions.Append("^FT21,320^A0N,39,38^FH\\^FDZip Code:^FS");
                zebraInstructions.Append("^FT192,316^A0N,28,28^FH\\^FD" + info.zipcode + "^FS" + Environment.NewLine);

                zebraInstructions.Append("^FT23,506^A0N,39,38^FH\\^FDEmail:^FS");
                zebraInstructions.Append("^FT175,505^A0N,39,38^FH\\^FD" + info.email + "^FS" + Environment.NewLine);
                zebraInstructions.Append("^PQ1,0,1,Y^XZ");

                string selectedPrinterName = impresora;
                var z = new ZebraPrinter(selectedPrinterName);
                z.Print(zebraInstructions.ToString());
                z.Print(zebraInstructions.ToString());
            }
        }

        private void imprimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataCajasNuevas.SelectedCells.Count > 0)
            {
                int selectedrowindex = dataCajasNuevas.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataCajasNuevas.Rows[selectedrowindex];
                var caja = Convert.ToString(selectedRow.Cells["nuevaCaja"].Value);

                ImprimirEtiqueta(cboShipTo.SelectedValue.ToString(),caja);
            }
        }

        private void FrmCaja_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }
    }
}
