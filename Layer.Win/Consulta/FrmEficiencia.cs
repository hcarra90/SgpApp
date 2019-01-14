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
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Layer.Win.Consulta
{
    public partial class FrmEficiencia : Form
    {
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
        string nombreArchivo = "";
        List<DetalleEficienciaDto> detalleEficiencia = new List<DetalleEficienciaDto>();
        EficienciaPorDiaDto eficienciTotal = new EficienciaPorDiaDto();
        string opcion = "";
        string titulo = "";

        public FrmEficiencia()
        {
            InitializeComponent();
        }

        private void FrmEficiencia_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            var fechaInicio = new DateTime(dtpFechaInicio.Value.Year, dtpFechaInicio.Value.Month, dtpFechaInicio.Value.Day, 0, 0, 0);
            var fechaTermino = new DateTime(dtpFechaTermino.Value.Year, dtpFechaTermino.Value.Month, dtpFechaTermino.Value.Day, 23, 59, 59);
            BuscarInfo(fechaInicio, fechaTermino);
            this.Cursor = Cursors.Default;
        }

        private void BuscarInfo(DateTime fechaInicio,DateTime fechaTermino)
        {
            eficienciTotal = new EficienciaPorDiaDto();
            detalleEficiencia = new List<DetalleEficienciaDto>();

            switch (opcion)
            {
                case "Cosecha":
                    eficienciTotal = MovimientoCosechaBusiness.GetEfficiencyPerDay(fechaInicio, fechaTermino);
                    break;
                case "Secado Inicio":
                    eficienciTotal = MovimientoSecadoBusiness.GetEfficiencyPerDay(fechaInicio, fechaTermino,1);
                    break;
                case "Secado Termino":
                    eficienciTotal = MovimientoSecadoBusiness.GetEfficiencyPerDay(fechaInicio, fechaTermino, 2);
                    break;
                case "Desgrane":
                    eficienciTotal = MovimientoDesgraneBusiness.GetEfficiencyPerDay(fechaInicio, fechaTermino);
                    break;
                case "Packing":
                    eficienciTotal = MovimientoPackingBusiness.GetEfficiencyPerDay(fechaInicio, fechaTermino);
                    break;
                case "Shipping":
                    break;
                default:
                    break;
            }

            detalleEficiencia = eficienciTotal.Detalle;
            dataEuid.DataSource = detalleEficiencia;
            dataResumen.DataSource = eficienciTotal.Resumen;
        }

        private void FrmEficiencia_Load(object sender, EventArgs e)
        {
            DataGridViewCellStyle style = dataResumen.ColumnHeadersDefaultCellStyle;
            style.Font = new Font(dataResumen.Font.FontFamily, 14.25F, FontStyle.Bold);

            dataEuid.AutoGenerateColumns = false;
            LlenaComboBox();
        }

        private void LlenaComboBox()
        {
            var emails = EmailBusiness.GetEmails();
            cboEmail.DisplayMember = "EmailUsado";
            cboEmail.ValueMember = "Id";
            cboEmail.DataSource = emails;
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (detalleEficiencia.Count > 0 )
            {
                ExportaDatos();
                this.Cursor = Cursors.Default;
            }
        }

        private void ExportaDatos()
        {
            this.Cursor = Cursors.WaitCursor;
            var wb = FuncionesExcel.ExportaEficiencia(detalleEficiencia, dtpFechaInicio.Value,dtpFechaTermino.Value,opcion);

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
                    MessageBox.Show("Archivo Creado!", "Módulo Eficiencia", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: ", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    this.Cursor = Cursors.Default;
                }

            }
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            if (nombreArchivo != "")
            {
                pnlEmail.Visible = true;
            }
        }

        private void btnEnvio_Click(object sender, EventArgs e)
        {
            if (FuncionesEmail.emailIsValid(txtEmail.Text))
            {
                this.Cursor = Cursors.WaitCursor;
                EnvioEmail();
                this.Cursor = Cursors.Default;
            }
            else
            {
                MessageBox.Show("Email Inválido!", "Módulo Eficiencia", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                this.Cursor = Cursors.Default;
            }
        }

        private void EnvioEmail()
        {
            TransactionalInformation transaccion = new TransactionalInformation();
            var rs = FuncionesEmail.EnvioEmail(nombreArchivo, txtEmail.Text, txtMensaje.Text,"Archivo de Eficiencia");
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

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void LimpiarFormulario()
        {
            dtpFechaInicio.Value = DateTime.Now;
            dtpFechaTermino.Value = DateTime.Now;
            dataEuid.DataSource = null;
            dataResumen.DataSource = null;
            txtEmail.Text = "";
            txtMensaje.Text = "";
            pnlEmail.Visible = false;
            //eficienciTotal = new EficienciaPorDiaDto();
            //detalleEficiencia = new List<DetalleEficienciaDto>();
            nombreArchivo = "";
            dtpFechaInicio.Focus();
            opcion = "";
            cboEmail.SelectedIndex = -1;

            DataGridViewCellStyle style = dataResumen.ColumnHeadersDefaultCellStyle;
            style.Font = new Font(dataResumen.Font.FontFamily, 14.25F, FontStyle.Bold);
        }

        private void cboBusqueda_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboBusqueda.SelectedItem != null && cboBusqueda.SelectedItem.ToString() != "")
            {
                opcion = cboBusqueda.SelectedItem.ToString();
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
