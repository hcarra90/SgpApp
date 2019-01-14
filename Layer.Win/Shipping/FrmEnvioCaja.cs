using Layer.Business;
using Layer.Entity;
using Layer.Entity.Dto;
using Layer.Functions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Layer.Win.Shipping
{
    public partial class FrmEnvioCaja : Form
    {
        #region Declaración
        public Usuario usuarioValido { get; set; }
        private decimal correlativoEnvio = 0;
        private decimal totalNetoEnvio = 0;
        private decimal totalBrutoEnvio = 0;
        CultureInfo culture = CultureInfo.CreateSpecificCulture("es-CL");
        SerialPort _serialPort = new SerialPort();
        Shipment shipmentSeleccionado = new Shipment();
        string shipmentCode = "";
        private string estadoShipment = "";

        private delegate void Closure();
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
        #endregion

        public FrmEnvioCaja()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            FrmShipment frm = new FrmShipment();
            frm.usuarioValido = usuarioValido;
            frm.ShowDialog();
            //txtBox.Focus();
        }

        private void BuscaCorrelativoEnvio(int anio)
        {
            var shipmentCode = MovimientoCajaBusiness.GetCorrelativoEnvio(anio);
            lblShipmentCode.Text = shipmentCode.shipmentCode;
            correlativoEnvio = shipmentCode.correlativoEnvio;
            totalBrutoEnvio = 0;
            totalNetoEnvio = 0;
        }

        private void txtBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                if (txtBox.Text.Trim() !="")
                {
                    BuscaInfoCaja(txtBox.Text.Trim());
                }
            }
        }

        private void BuscaInfoCaja(string box)
        {
            var weight = MovimientoShippingBusiness.GetBoxWeight(box);
            if (weight == 0)
            {
                MessageBox.Show("Caja Sin Contenido", "Módulo Envio Caja", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                txtBox.Text = "";
                txtBox.Focus();
            }
            else
            {
                txtNeto.Text = weight.ToString();
                txtBruto.Focus();
            }
        }

        private void GrabaInformacion()
        {
            if (txtBox.Text.ToUpper() !="" && txtBruto.Text!="" & correlativoEnvio > 0 && shipmentCode != "" && shipmentSeleccionado !=null)
            {
                if (shipmentSeleccionado.Id ==0)
                {
                    MessageBox.Show("Falta Shipment Code Para Guardar Envio", "Módulo Envio Caja", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    return;
                }

                var MovCaja = MovimientoShippingBusiness.GetCaja(txtBox.Text.Trim());
                if (MovCaja !=null)
                {
                    TransactionalInformation transaccion = new TransactionalInformation();
                    MovCaja.pesoNeto=decimal.Parse(txtNeto.Text);
                    MovCaja.pesoBruto = decimal.Parse(txtBruto.Text);
                    MovCaja.fechaEnvio = shipmentSeleccionado.FechaEnvio;
                    MovCaja.shipmentCode = shipmentCode;
                    MovCaja.correlativoEnvio = correlativoEnvio;
                    
                    if (txtBulto.Text !="")
                    {
                        MovCaja.bulto = txtBulto.Text;
                        MovCaja.pesoBulto = decimal.Parse(txtPesoBulto.Text);
                    }

                    if (txtPallet.Text !="")
                    {
                        MovCaja.pallet = txtPallet.Text;
                        MovCaja.pesoPallet = decimal.Parse(txtPallet.Text);
                    }

                    MovimientoCajaBusiness.GrabaInformacion(MovCaja, out transaccion);

                    if (transaccion.ReturnStatus)
                    {
                        totalNetoEnvio += Math.Round(decimal.Parse(txtNeto.Text),2);
                        totalBrutoEnvio += Math.Round(decimal.Parse(txtBruto.Text),2);

                        lblTotalKilosNeto.Text = totalNetoEnvio.ToString("N",culture);
                        lblTotalKilosBruto.Text = totalBrutoEnvio.ToString("N",culture);
                        
                        GetEnviosByShipment(shipmentCode);
                        LimpiarFormulario();
                        //MessageBox.Show("Envio Creado!", "Módulo Envio Caja", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    }
                }
            }
            else
            {
                MessageBox.Show("Falta Información Para Guardar Envio", "Módulo Envio Caja", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void txtBruto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                //e.Handled = true;
                GrabaInformacion();
            }
        }

        private void LimpiarFormulario()
        {
            //lblShipmentCode.Text = "";
            txtBox.Text = "";
            txtBruto.Text = "";
            txtNeto.Text = "";
            txtBulto.Text = "";
            txtPesoBulto.Text = "";
            txtPallet.Text = "";
            txtPesoPallet.Text = "";
            txtBox.Focus();
            shipmentSeleccionado = null;
            estadoShipment = "";
        }

        private void FrmEnvioCaja_Load(object sender, EventArgs e)
        {
            totalBrutoEnvio = 0;
            totalNetoEnvio = 0;
            GetShipmentCode();
            //GetEnviosByFecha(dtpFechaEnvio.Value.Date);

            //Configuración del puerto
            //_serialPort.PortName = ConfigurationManager.AppSettings["ComPesaPie"].ToString();
            //_serialPort.BaudRate = 2400;
            //_serialPort.Parity = Parity.Even;
            //_serialPort.StopBits = StopBits.One;
            //_serialPort.DataBits = 7;
            //_serialPort.Handshake = Handshake.XOnXOff;

            //_serialPort.DataReceived += new SerialDataReceivedEventHandler(SerialPortOnDataReceived);

            //var portExists = SerialPort.GetPortNames().Any(x => x == ConfigurationManager.AppSettings["ComPesaPie"].ToString());

            //if (portExists)
            //{
            //    try
            //    {
            //        _serialPort.Open();
            //        File.AppendAllText("LogEnvio.txt", "Apertura De Puerto:" + ConfigurationManager.AppSettings["ComPesaPie"].ToString() + ";");
            //    }
            //    catch (Exception ex)
            //    {
            //        File.AppendAllText("LogEnvio.txt", ex.Message + ";" + ConfigurationManager.AppSettings["ComPesaPie"].ToString() + ";");
            //    }

            //}
            //else
            //{
            //    File.AppendAllText("LogEnvio.txt", "Puerto No existe:" + ConfigurationManager.AppSettings["ComPesaPie"].ToString() + ";");
            //}


            //CheckForIllegalCrossThreadCalls = false;
            //if (File.Exists("BufferEnvio.txt"))
            //{
            //    File.Delete("BufferEnvio.txt");
            //}

            DataGridViewCellStyle style = dataBox.ColumnHeadersDefaultCellStyle;
            style.Font = new Font(dataBox.Font.FontFamily, 9.75F, FontStyle.Bold);

            ToolTip toolTip1 = new ToolTip();
            toolTip1.ShowAlways = true;
            toolTip1.SetToolTip(btnCreate, "Crear Nuevo Shipment");

            txtBox.Focus();
        }

        public void GetShipmentCode()
        {
            var data = ShipmentBusiness.GetShipmentCode();
            cboShipment.DisplayMember = "ShipmentCode";
            cboShipment.ValueMember = "ShipmentCode";
            cboShipment.DataSource = data;
        }

        public void GetEnviosByShipment(string shipmentCode)
        {
            List<EncPackingListDto> data = new List<EncPackingListDto>();
            data = ShipmentBusiness.GetCajasByshipmentCode(shipmentCode);
            dataBox.AutoGenerateColumns = false;
            dataBox.DataSource = data;
            dataBox.ClearSelection();

            
        }

        private void borrarCajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataBox.SelectedCells.Count > 0)
            {
                if (estadoShipment == "C")
                {
                    return;
                }

                int selectedrowindex = dataBox.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataBox.Rows[selectedrowindex];
                var caja = Convert.ToString(selectedRow.Cells["Box"].Value);

                BorrarCaja(caja);
                GetEnviosByShipment(shipmentCode);
                txtBox.Focus();
            }
        }

        private void BorrarCaja(string caja)
        {
            TransactionalInformation transaction = new TransactionalInformation();

            var MovCaja = MovimientoShippingBusiness.GetCaja(caja);
            if (MovCaja != null)
            {
                TransactionalInformation transaccion = new TransactionalInformation();
                MovCaja.pesoNeto = null;
                MovCaja.pesoBruto = null;
                MovCaja.fechaEnvio = null;
                MovCaja.shipmentCode = null;
                MovCaja.correlativoEnvio = null;
                MovimientoCajaBusiness.GrabaInformacion(MovCaja, out transaccion);

                if (transaccion.ReturnStatus)
                {
                    //GetEnviosByFecha(dtpFechaEnvio.Value.Date);
                }

                if (!transaction.ReturnStatus)
                {
                    MessageBox.Show("Error: " + transaction.ReturnMessage, "Módulo Shipping", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
        }

        private void dataBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int currentMouseOverRow = dataBox.HitTest(e.X, e.Y).RowIndex;
                ctxCajaMenu.Show(dataBox, new Point(e.X, e.Y));
            }
        }

        private void cboWeight_Click(object sender, EventArgs e)
        {
            //Rescato Peso de la balanza
            if (File.Exists("BufferEnvio.txt"))
            {
                
            }
        }

        private void SerialPortOnDataReceived(object sender, SerialDataReceivedEventArgs serialDataReceivedEventArgs)
        {
            //if (InvokeRequired)     //<-- Makes sure the function is invoked to work properly in the UI-Thread
            //    BeginInvoke(new Closure(() => { SerialPortOnDataReceived(sender, serialDataReceivedEventArgs); }));     //<-- Function invokes itself
            //else
            //{
            //    int dataLength = _serialPort.BytesToRead;
            //    byte[] data = new byte[dataLength];
            //    int nbrDataRead = _serialPort.Read(data, 0, dataLength);
            //    if (nbrDataRead == 0)
            //        return;
            //    string str = System.Text.Encoding.UTF8.GetString(data);
            //    if (str.Length > 5)
            //    {
            //        var arr = str.Split('\n');
            //        if (arr.Length > 3)
            //        {
            //            File.AppendAllText("LogEnvio.txt", "Proceso Puerto");
            //            str = arr[2];
            //            File.AppendAllText("BufferEnvio.txt", str);

            //            string strnew = File.ReadLines("BufferEnvio.txt").Last();
            //            strnew = DataFunctions.PreparaStringPeso(strnew,2);
            //            File.AppendAllText("LogEnvio.txt", "Peso Grabado En Archivo:" + strnew);

            //            txtBruto.Text = strnew;
            //            txtBruto.Focus();
            //            GrabaInformacion();
            //            File.AppendAllText("LogEnvio.txt", "Grabe");
            //        }
            //    }
            //}
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void FrmEnvioCaja_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void txtBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void cboShipment_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboShipment.SelectedItem != null)
            {
                if (((Shipment)cboShipment.SelectedItem).Id > 0)
                {
                    shipmentSeleccionado = (Shipment)cboShipment.SelectedItem;
                    shipmentCode = shipmentSeleccionado.ShipmentCode;
                    estadoShipment = shipmentSeleccionado.EstadoShipment;
                    correlativoEnvio = shipmentSeleccionado.Correlativo;

                    if (shipmentSeleccionado.EstadoShipment =="C")
                    {
                        MessageBox.Show("Shipment ya fue enviado", "Módulo Envio Caja", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                        shipmentSeleccionado = null;
                    }
                    GetEnviosByShipment(shipmentCode);
                }
            }
        }
    }
}
