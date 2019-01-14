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
    public partial class FrmPackingList : Form
    {
        public Usuario usuarioValido { get; set; }
        List<DetailPackingListDto> detailPackingList = new List<DetailPackingListDto>();
        List<EncPackingListDto> dataCajas = new List<EncPackingListDto>();
        string nombreArchivo = "";
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        public FrmPackingList()
        {
            InitializeComponent();
        }

        private void FrmPackingList_Load(object sender, EventArgs e)
        {
            ConfiguraFormulario();
        }

        private void ConfiguraFormulario()
        {
            DataGridViewCellStyle style = dataBox.ColumnHeadersDefaultCellStyle;
            style.Font = new Font(dataBox.Font.FontFamily, 9.25F, FontStyle.Bold);

            style = dataDetail.ColumnHeadersDefaultCellStyle;
            style.Font = new Font(dataDetail.Font.FontFamily, 9.25F, FontStyle.Bold);

            ToolTip toolTip1 = new ToolTip();
            toolTip1.ShowAlways = true;
            toolTip1.SetToolTip(btnBuscar, "Buscar Información");
            toolTip1.SetToolTip(btnExportar, "Exportar Información");
            toolTip1.SetToolTip(btnEnviar, "Enviar Información Por Email");
            toolTip1.SetToolTip(btnLimpiar, "Limpiar Formulario");
            toolTip1.SetToolTip(btnEnvio, "Enviar Mensaje");
            LlenaComboBox();
            nombreArchivo = "";
        }

        private void LlenaComboBox()
        {
            var data = MovimientoCajaBusiness.GetshipmentsCode();
            cboShipment.DisplayMember = "shipmentCode";
            cboShipment.ValueMember = "shipmentCode";
            cboShipment.DataSource = data;

            var emails = EmailBusiness.GetEmails();
            cboEmail.DisplayMember = "EmailUsado";
            cboEmail.ValueMember = "Id";
            cboEmail.DataSource = emails;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (cboShipment.SelectedValue != null && cboShipment.SelectedValue.ToString() !="")
            {
                this.Cursor = Cursors.WaitCursor;
                BuscarInfo(cboShipment.SelectedValue.ToString());
                this.Cursor = Cursors.Default;
            }
        }

        private void BuscarInfo(string shipmentCode)
        {
            dataCajas = MovimientoCajaBusiness.GetCajasByshipmentCode(shipmentCode);
            dataBox.AutoGenerateColumns = false;
            dataBox.DataSource = dataCajas;
            dataBox.ClearSelection();
            lblTotalResumen.Text = dataBox.RowCount.ToString();

            detailPackingList = MovimientoCajaBusiness.GetDetailsByshipmentCode(shipmentCode);
            dataDetail.AutoGenerateColumns = false;
            dataDetail.DataSource = detailPackingList;
            dataDetail.ClearSelection();
            lblTotalDetalle.Text = dataDetail.RowCount.ToString();
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (detailPackingList.Count > 0)
            {
                ExportarData();
                this.Cursor = Cursors.Default;
            }
        }

        private void ExportarData()
        {
            this.Cursor = Cursors.WaitCursor;
            //List<string[]> titulos = new List<string[]>();

            //string[] t1=new string[]{ "Caja Envio","Euid","Ind Euid","Fecha Packing","Total Weight",
            //    "Total kernel", "Total Ear","Country","Breeder Code 1", "Breeder Code 2",
            //    "Breeder Code 3", "Breeder Code 4","Project Lead","Cc","Ship To","Crop" };
            //titulos.Add(t1);
            var wb=FuncionesExcel.ExportaPackingList(dataCajas,detailPackingList, cboShipment.SelectedValue.ToString());

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

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void LimpiarFormulario()
        {
            cboShipment.SelectedIndex = -1;
            cboEmail.SelectedIndex = -1;
            cboEmail.SelectedIndex = -1;
            dataBox.DataSource = null;
            dataDetail.DataSource = null;
            txtEmail.Text = "";
            txtMensaje.Text = "";
            pnlEmail.Visible = false;
            nombreArchivo = "";
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            if (nombreArchivo != "")
            { 
                pnlEmail.Visible = true;
            }
        }

        private void EnvioEmail()
        {
            TransactionalInformation transaccion = new TransactionalInformation();
            var rs = FuncionesEmail.EnvioEmail(nombreArchivo, txtEmail.Text,txtMensaje.Text,"Archivo de PackingList");
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

        private void FrmPackingList_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void dataBox_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void cboEmail_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboEmail.Text !="")
            {
                txtEmail.Text = cboEmail.Text;
            }
        }
    }
}
