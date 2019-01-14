using Layer.Business;
using Layer.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Layer.Win.Shipping
{
    public partial class FrmShipment : Form
    {
        #region Declaración
        public Usuario usuarioValido { get; set; }
        private int correlativoEnvio = 0;
        CultureInfo culture = CultureInfo.CreateSpecificCulture("es-CL");

        private delegate void Closure();
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
        #endregion
        public FrmShipment()
        {
            InitializeComponent();
        }

        private void FrmShipment_Load(object sender, EventArgs e)
        {
            ConfiguraFormulario();
        }

        private void LlenaGrilla(DateTime fechaEnvio)
        {
            List<Shipment> data = new List<Shipment>();
            data = ShipmentBusiness.GetShipmentByFecha(fechaEnvio);
            dataBox.AutoGenerateColumns = false;
            dataBox.DataSource = data;
            dataBox.ClearSelection();
        }

        private void ConfiguraFormulario()
        {
            ToolTip toolTip1 = new ToolTip();
            toolTip1.ShowAlways = true;
            toolTip1.SetToolTip(btnCreate, "Crear Nuevo Shipment");
            dtpFechaEnvio.Value = DateTime.Now;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            TransactionalInformation transaccion = new TransactionalInformation();
            Shipment shipment = new Shipment();

            if (lblShipmentCode.Text =="")
            {
                BuscaCorrelativoEnvio(dtpFechaEnvio.Value.Year);
            }
            
            shipment.Correlativo = correlativoEnvio;
            shipment.FechaCreacion = DateTime.Now.Date;
            shipment.FechaEnvio = dtpFechaEnvio.Value.Date;
            shipment.Usuario = usuarioValido.nombre_usuario;
            shipment.ShipmentCode = lblShipmentCode.Text;
            shipment.EstadoShipment = (cboEstado.Text == "") ? "A" : "C";
            ShipmentBusiness.GrabaInformacion(shipment, out transaccion);

            if (transaccion.ReturnStatus)
            {
                GetEnviosByFecha(dtpFechaEnvio.Value.Date);
                LimpiarFormulario();
            }
            else
            {
                MessageBox.Show("Error: " + transaccion.ReturnMessage, "Módulo Creación Shipment", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }

        private void borrarShipmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var obj = BuscaShipment();
            var id = Convert.ToInt32(obj.Cells["Id"].Value);
            var shipmentCode = Convert.ToString(obj.Cells["Code"].Value);
            var count = ShipmentBusiness.GetCajasByshipmentCode(shipmentCode).Count;
            if (count > 0)
            {
                MessageBox.Show("Shipment posee cajas asignadas, imposible eliminar!", "Módulo Creación Shipment", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }

            BorrarShipment(id);
            LlenaGrilla(dtpFechaEnvio.Value.Date);
            dtpFechaEnvio.Focus();
        }

        private DataGridViewRow BuscaShipment()
        {
            if (dataBox.SelectedCells.Count > 0)
            {
                int selectedrowindex = dataBox.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataBox.Rows[selectedrowindex];
                return selectedRow;
            }

            return null;
        }

        private void BorrarShipment(int id)
        {
            TransactionalInformation transaccion = new TransactionalInformation();
            ShipmentBusiness.BorrarShipment(id,out transaccion);

            if (!transaccion.ReturnStatus)
            {
                MessageBox.Show("Error: " + transaccion.ReturnMessage, "Módulo Shipment", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void dataBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int currentMouseOverRow = dataBox.HitTest(e.X, e.Y).RowIndex;
                ctxShipment.Show(dataBox, new Point(e.X, e.Y));
            }
        }

        private void FrmShipment_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void dtpFechaEnvio_ValueChanged(object sender, EventArgs e)
        {
            GetEnviosByFecha(dtpFechaEnvio.Value.Date);
        }

        private void BuscaCorrelativoEnvio(int anio)
        {
            var shipmentCode = ShipmentBusiness.GetCorrelativoEnvio(anio);
            lblShipmentCode.Text = shipmentCode.shipmentCode;
            correlativoEnvio = (int)shipmentCode.correlativoEnvio;
        }

        private void LimpiarFormulario()
        {
            lblShipmentCode.Text = "";
            cboEstado.SelectedIndex = -1;
            //dtpFechaEnvio.Value = DateTime.Now;
            dtpFechaEnvio.Focus();
        }

        public void GetEnviosByFecha(DateTime fechaEnvio)
        {
            var data = ShipmentBusiness.GetShipmentByFecha(fechaEnvio);
            dataBox.AutoGenerateColumns = false;
            dataBox.DataSource = data;
            dataBox.ClearSelection();
        }

        private void cerrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var obj = BuscaShipment();
            var id = Convert.ToInt32(obj.Cells["Id"].Value);
            var shipmentCode = Convert.ToString(obj.Cells["Code"].Value);

            CambioEstado(id,"C");
            LlenaGrilla(dtpFechaEnvio.Value.Date);
            dtpFechaEnvio.Focus();
        }

        private void CambioEstado(int id,string estado)
        {
            TransactionalInformation transaction = new TransactionalInformation();

            var shipment = ShipmentBusiness.GetShipmentById(id);
            if (shipment != null)
            {
                TransactionalInformation transaccion = new TransactionalInformation();
                shipment.EstadoShipment = estado;
                ShipmentBusiness.GrabaInformacion(shipment, out transaccion);

                if (!transaction.ReturnStatus)
                {
                    MessageBox.Show("Error: " + transaction.ReturnMessage, "Módulo Shipping", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
        }

        private void btnShipment_Click(object sender, EventArgs e)
        {
            BuscaCorrelativoEnvio(dtpFechaEnvio.Value.Year);
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var obj = BuscaShipment();
            var id = Convert.ToInt32(obj.Cells["Id"].Value);
            var shipmentCode = Convert.ToString(obj.Cells["Code"].Value);

            CambioEstado(id, "A");
            LlenaGrilla(dtpFechaEnvio.Value.Date);
            dtpFechaEnvio.Focus();
        }
    }
}
