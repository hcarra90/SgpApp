using System;
using System.Configuration;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Com.SharpZebra.Printing;
using Layer.Business;
using Layer.Entity;
using Layer.Functions;
using Microsoft.Win32.SafeHandles;

namespace Layer.Win.Packing
{
    public partial class FrmMovPacking : Form
    {
        #region Declaración
        MovimientoPacking movimientoPacking = new MovimientoPacking();
        public Usuario usuarioValido { get; set; }
        private bool primeraCarga = true;
        private string crop = "";
        private PrintDocument printDocument1 = new PrintDocument();

        private StringBuilder zebraInstructions = new StringBuilder();
        private string impresora = "";
        SerialPort _serialPort = new SerialPort();

        private delegate void Closure();

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        #endregion

        public FrmMovPacking()
        {
            InitializeComponent();
        }

        private void FrmMovPacking_Load(object sender, EventArgs e)
        {
            ConfiguracionFormulario();
        }

        private void ConfiguracionFormulario()
        {
            this.dataEuid.Columns["IndEuid"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dataEuid.Columns["BreedersCode1"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataEuid.Columns["BreedersCode1"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dataEuid.Columns["BreedersCode2"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dataEuid.Columns["BreedersCode2"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dataEuid.Columns["BreedersCode3"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dataEuid.Columns["BreedersCode3"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dataEuid.Columns["BreedersCode4"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dataEuid.Columns["BreedersCode4"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dataEuid.Columns["Crop_"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dataEuid.Columns["Crop_"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            lblFechaPacking.Text = DateTime.Now.Date.ToShortDateString();
            impresora = ParametroBusiness.GetParametroByTipo("PRT")[0].Valor;

            //Configuración del puerto
            _serialPort.PortName = ConfigurationManager.AppSettings["ComPesaChica"].ToString();
            _serialPort.BaudRate = 2400;
            _serialPort.Parity = Parity.None;
            _serialPort.StopBits = StopBits.One;
            _serialPort.DataBits = 7;
            //_serialPort.Handshake = Handshake.None;

            _serialPort.DataReceived += new SerialDataReceivedEventHandler(SerialPortOnDataReceived);

            var portExists = SerialPort.GetPortNames().Any(x => x == ConfigurationManager.AppSettings["ComPesaChica"].ToString());
            if (portExists)
            {
                File.AppendAllText("LogPacking.txt", "Apertura De Puerto");
                try
                {
                    _serialPort.Open();
                }
                catch (Exception ex)
                {
                    File.AppendAllText("LogPacking.txt", ex.Message);
                }
                
            }
            else
            {
                File.AppendAllText("LogPacking.txt", "Puerto No se abrio");
            }

            CheckForIllegalCrossThreadCalls = false;
            if (File.Exists("BufferPacking.txt"))
            {
                File.Delete("BufferPacking.txt");
            }

            txtEuid.Focus();
            
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtEuid.Text.Trim() !="")
            {
                BuscarInfo(txtEuid.Text.Trim());
            }
            else
            {
                MessageBox.Show("Debe Ingresar Euid Para Continuar", "Módulo Packing", MessageBoxButtons.OK, MessageBoxIcon.Asterisk , MessageBoxDefaultButton.Button1);
            }
        }

        private void BuscarInfo(string euid)
        {
            dataEuid.DataSource = null;

            var euidData=InfoFieldBookBusiness.GetEuid(euid,"");
            dataEuid.AutoGenerateColumns = false;
            dataEuid.DataSource = euidData;
            dataEuid.ClearSelection();
            primeraCarga = false;
        }

        private void txtEuid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (txtEuid.Text.Trim() != "")
                {
                    BuscarInfo(txtEuid.Text.Trim());
                }
                else
                {
                    MessageBox.Show("Debe Ingresar Euid Para Continuar", "Módulo Packing", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                    txtEuid.Focus();
                }
            }
        }

        private void dataEuid_SelectionChanged(object sender, EventArgs e)
        {
            if (primeraCarga == false)
            {
                if (dataEuid.SelectedCells.Count > 0)
                {
                    int selectedrowindex = dataEuid.SelectedCells[0].RowIndex;
                    DataGridViewRow selectedRow = dataEuid.Rows[selectedrowindex];
                    LlenaDataIngresada(selectedRow);
                }
            }
        }

        private void LlenaDataIngresada(DataGridViewRow row)
        {
            txtTotalWeight.Text = "";
            txtTotalKernels.Text = "";
            txtTotalEars.Text = "";

            txtTotalWeight.Focus();
            txtIndEuid.Text = Convert.ToString(row.Cells["IndEuid"].Value);
            txtShelling.Text = Convert.ToString(row.Cells["Shelling"].Value);
            txtInstructions.Text = Convert.ToString(row.Cells["Instructions"].Value);
            txtTargetWg.Text = Convert.ToString(row.Cells["TargetWg"].Value);
            txtTargetKern.Text = Convert.ToString(row.Cells["TargetKern"].Value);
            txtTargEars.Text = Convert.ToString(row.Cells["TargEars"].Value);
            txtShipTo.Text = Convert.ToString(row.Cells["ShipTo"].Value);
            crop= Convert.ToString(row.Cells["Crop_"].Value);
            txtClient.Text= Convert.ToString(row.Cells["client"].Value);
            txtProjectLead.Text = Convert.ToString(row.Cells["ProjectLead"].Value);
            txtSag.Text = Convert.ToString(row.Cells["Sag"].Value);
            txtEvent.Text = Convert.ToString(row.Cells["Event"].Value);

            movimientoPacking = MovimientoPackingBusiness.GetEuid(txtIndEuid.Text,txtEuid.Text);

            if (movimientoPacking != null)
            {
                txtTotalWeight.Text = movimientoPacking.totalWeight.ToString();
                txtTotalKernels.Text = movimientoPacking.totalKernels.ToString();
                txtTotalEars.Text = movimientoPacking.totalEars.ToString();
            }

            txtTotalWeight.Enabled = true;
            txtTotalKernels.Enabled = true;
            txtTotalEars.Enabled = true;
            txtTotalWeight.Focus();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario(2);
        }

        private void LimpiarFormulario(int tipo)
        {
            if (tipo==1)
            {
                txtIndEuid.Text = "";
                txtShelling.Text = "";
                txtInstructions.Text = "";
                txtTargetWg.Text = "";
                txtTargetKern.Text = "";
                txtTargEars.Text = "";
                txtShipTo.Text = "";
                txtTotalWeight.Text = "";
                txtTotalKernels.Text = "";
                txtTotalEars.Text = "";
                txtClient.Text = "";
                txtProjectLead.Text = "";
                txtSag.Text = "";
                txtEvent.Text = "";
                txtTotalWeight.Enabled = false;
                txtTotalKernels.Enabled = false;
                txtTotalEars.Enabled = false;
                dataEuid.DataSource = null;
                txtEuid.Text = "";
                txtEuid.Focus();
                primeraCarga = true;
                
            }
            else if (tipo==2)
            {
                txtEuid.Text = "";
                txtIndEuid.Text = "";
                txtShelling.Text = "";
                txtInstructions.Text = "";
                txtTargetWg.Text = "";
                txtTargetKern.Text = "";
                txtTargEars.Text = "";
                txtShipTo.Text = "";
                txtTotalWeight.Text = "";
                txtTotalKernels.Text = "";
                txtTotalEars.Text = "";
                txtClient.Text = "";
                txtProjectLead.Text = "";
                txtSag.Text = "";
                txtEvent.Text = "";
                //btnImprimir.Enabled = false;
                txtTotalWeight.Enabled = false;
                txtTotalKernels.Enabled = false;
                txtTotalEars.Enabled = false;
                dataEuid.DataSource = null;
                txtEuid.Focus();
            }
            
            if (File.Exists("BufferPacking.txt"))
            {
                File.Delete("BufferPacking.txt");
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            //Rescato Peso de la balanza
            if (File.Exists("BufferPacking.txt"))
            {
                string strnew = File.ReadLines("BufferPacking.txt").Last();
                strnew = DataFunctions.PreparaStringPeso(strnew, 1);
                txtTotalWeight.Text = strnew;
                File.AppendAllText("LogPacking.txt", "Peso Leido:" + txtTotalWeight.Text);
            }

            if (txtTotalWeight.Text == "")
            {
                MessageBox.Show("Debe Ingresar Peso Para Continuar", "Módulo Packing", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                txtTotalWeight.Focus();
                return;
            }

            if (txtTotalKernels.Text == "" || txtTotalKernels.Text == "0")
            {
                double totalKernels = 0;
                if (crop == "Soya" || crop == "Soybean" || crop == "Soybeans")
                {
                    totalKernels = (double.Parse(txtTotalWeight.Text) * 6);
                }
                else
                {
                    totalKernels = (double.Parse(txtTotalWeight.Text) * 4);
                }
                txtTotalKernels.Text = Math.Round(totalKernels).ToString();
            }

            if (txtTotalEars.Text == "" || txtTotalEars.Text == "0")
            {
                txtTotalEars.Text = "0";
            }
            else
            {
                txtTotalKernels.Text = "0";
            }

            if (txtTotalEars.Text != "" || txtTotalWeight.Text != "" || txtTotalKernels.Text != "")
            {
                GrabaInformacion();
            }
        }

        private void GrabaInformacion()
        {
            TransactionalInformation transaction;
                       

            if (movimientoPacking ==null)
            {
                movimientoPacking = new MovimientoPacking();

                movimientoPacking.euid = txtEuid.Text;
                movimientoPacking.indEuid = txtIndEuid.Text;
                movimientoPacking.fechaPacking = DateTime.Now;
                movimientoPacking.usuario = usuarioValido.nombre_usuario;
                movimientoPacking.totalEars = int.Parse(txtTotalEars.Text);
                movimientoPacking.totalKernels = int.Parse(txtTotalKernels.Text);
                movimientoPacking.totalWeight = decimal.Parse(txtTotalWeight.Text);
            }
            else
            {
                movimientoPacking.totalEars = int.Parse(txtTotalEars.Text);
                movimientoPacking.totalKernels = int.Parse(txtTotalKernels.Text);
                movimientoPacking.totalWeight = decimal.Parse(txtTotalWeight.Text);
            }

            MovimientoPackingBusiness.GrabaInformacion(movimientoPacking, out transaction);

            if (transaction.ReturnStatus)
            {
                ImprimeEtiqueta();
                //LimpiarFormulario(2);
            }
            else
            {
                MessageBox.Show("Error: " + transaction.ReturnMessage, "Módulo Packing", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                txtEuid.Text = "";
                txtEuid.Focus();
            }
        }

        private void dataEuid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtTotalWeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != ','))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario(1);
        }

        private void ImprimeEtiqueta()
        {
            string euidC = "";
            if (txtEuid.Text != "")
            {
                euidC = txtEuid.Text;
            }

            var infoField = InfoFieldBookBusiness.GetIndEuid(txtIndEuid.Text, euidC);
            if (infoField != null && impresora != "")
            {
                zebraInstructions = new StringBuilder();

                string bc1 = infoField.breedersCode1 ?? "";
                string bc2 = infoField.breedersCode2 ?? "";
                string bc3 = infoField.breedersCode3 ?? "";
                string bc4 = infoField.breedersCode4 ?? "";
                string euid = txtEuid.Text;
                string shipTo = infoField.shipTo;
                string order = infoField.order.ToString() ?? "";
                string tw = movimientoPacking.totalWeight.ToString();
                string tk = movimientoPacking.totalKernels.ToString();
                string te = movimientoPacking.totalEars.ToString();
                string year = (infoField.year == null) ? "" : infoField.year.ToString();
                string location = infoField.location ?? "";
                string rng = (infoField.rng == null) ? "" : infoField.rng.ToString();
                string plt = (infoField.plt == null) ? "" : infoField.plt.ToString();
                string ent = (infoField.ent == null) ? "" : infoField.ent.ToString();

                zebraInstructions.Append("^XA\n");
                //Codigo Barra Euid
                zebraInstructions.Append("^BY2,3,60" + Environment.NewLine);
                zebraInstructions.Append("^FO20,20^BC^FD" + euid + "^FS" + Environment.NewLine);
                //QR Euid
                zebraInstructions.Append("^FT687,112^BQN,2,4" + Environment.NewLine);
                zebraInstructions.Append(@"^FH\^FDLA," + euid + "^FS" + Environment.NewLine );

                zebraInstructions.Append(@"^FT36,155^A0N,39,38^FH\^FDShip To^FS" + Environment.NewLine);
                zebraInstructions.Append(@"^FT63,208^A0N,39,38^FH\^FD" + shipTo + "^FS" + Environment.NewLine);
                zebraInstructions.Append(@"^FT290,155^A0N,39,38^FH\^FD" + bc1 + "^FS" + Environment.NewLine);
                zebraInstructions.Append(@"^FT694,155^A0N,39,38^FH\^FDOrder^FS" + Environment.NewLine);
                zebraInstructions.Append(@"^FT723,208^A0N,39,38^FH\^FD" + order + "^FS" + Environment.NewLine);
                zebraInstructions.Append(@"^FT369,231^A0N,39,38^FH\^FD" + bc2 + "^FS" + Environment.NewLine);
                zebraInstructions.Append(@"^FT36,273^A0N,25,31^FH\^FD" + bc3 + "^FS" + Environment.NewLine);
                zebraInstructions.Append(@"^FT36,311^A0N,25,31^FH\^FD" + bc4 + "^FS" + Environment.NewLine);


                if (movimientoPacking.indEuid !="")
                {
                    //Codigo Barra IndEuid
                    zebraInstructions.Append("^BY2,3,60" + Environment.NewLine);
                    zebraInstructions.Append("^FO20,320^BC^FD" + movimientoPacking.indEuid + "^FS" + Environment.NewLine);
                    //QR IndEuid
                    zebraInstructions.Append("^FT687,389^BQN,2,4" + Environment.NewLine);
                    zebraInstructions.Append(@"^FH\^FDLA," + movimientoPacking.indEuid + "^FS" + Environment.NewLine);
                }

                zebraInstructions.Append(@"^FT40,423^A0N,28,28^FH\^FDWeight (gr):^FS" + Environment.NewLine);
                zebraInstructions.Append(@"^FT85,461^A0N,28,28^FH\^FD" + tw + "^FS" + Environment.NewLine);
                zebraInstructions.Append(@"^FT352,423^A0N,28,28^FH\^FDKernels:^FS" + Environment.NewLine);
                zebraInstructions.Append(@"^FT384,461^A0N,28,28^FH\^FD" + tk + "^FS" + Environment.NewLine);
                zebraInstructions.Append(@"^FT665,423^A0N,28,28^FH\^FDEars:^FS" + Environment.NewLine);
                zebraInstructions.Append(@"^FT685,461^A0N,28,28^FH\^FD" + te + "^FS" + Environment.NewLine);

                zebraInstructions.Append(@"^FT32,500^A0N,28,28^FH\^FDYear:^FS" + Environment.NewLine);
                zebraInstructions.Append(@"^FT105,499^A0N,27,28^FH\^FD" + year + "^FS" + Environment.NewLine);
                zebraInstructions.Append(@"^FT289,500^A0N,28,28^FH\^FDLoc:^FS" + Environment.NewLine);
                zebraInstructions.Append(@"^FT348,499^A0N,27,28^FH\^FD" + location + "^FS" + Environment.NewLine);
                zebraInstructions.Append(@"^FT32,544^A0N,28,28^FH\^FDRNG:^FS" + Environment.NewLine);
                zebraInstructions.Append(@"^FT114,543^A0N,27,28^FH\^FD" + rng + "^FS" + Environment.NewLine);
                zebraInstructions.Append(@"^FT355,544^A0N,28,28^FH\^FDPLT:^FS" + Environment.NewLine);
                zebraInstructions.Append(@"^FT445,543^A0N,27,28^FH\^FD" + plt + "^FS" + Environment.NewLine);
                zebraInstructions.Append(@"^FT636,544^A0N,28,28^FH\^FDENT:^FS" + Environment.NewLine);
                zebraInstructions.Append(@"^FT707,543^A0N,27,28^FH\^FD" + ent + "^FS" + Environment.NewLine);
                zebraInstructions.Append("^PQ1,0,1,Y" + Environment.NewLine);
                zebraInstructions.Append("^XZ");

                //Habilitar en la casa
                string selectedPrinterName = impresora;//"ZDesigner ZM400 200 dpi (ZPL)";
                new ZebraPrinter(selectedPrinterName).Print(zebraInstructions.ToString());
            }
        }

        private void SerialPortOnDataReceived(object sender, SerialDataReceivedEventArgs serialDataReceivedEventArgs)
        {
            if (InvokeRequired)     //<-- Makes sure the function is invoked to work properly in the UI-Thread
                BeginInvoke(new Closure(() => { SerialPortOnDataReceived(sender, serialDataReceivedEventArgs); }));     //<-- Function invokes itself
            else
            {
                int dataLength = _serialPort.BytesToRead;
                byte[] data = new byte[dataLength];
                int nbrDataRead = _serialPort.Read(data, 0, dataLength);
                if (nbrDataRead == 0)
                    return;
                string str = System.Text.Encoding.UTF8.GetString(data);

                File.AppendAllText("BufferPacking.txt", str);
                File.AppendAllText("LogPacking.txt", "Peso Grabado En Archivo:" + str);
            }
        }

        private void FrmMovPacking_MouseDown(object sender, MouseEventArgs e)
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
