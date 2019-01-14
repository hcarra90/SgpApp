using Layer.Business;
using Layer.Entity;
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

namespace Layer.Win.Rogging
{
    public partial class FrmRogging : Form
    {
        public Usuario usuarioValido { get; set; }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
        public DiscardReason Reason { get; set; }

        public FrmRogging()
        {
            InitializeComponent();
        }

        private void FrmRogging_Load(object sender, EventArgs e)
        {
            ConfiguraFormulario();
        }

        private void ConfiguraFormulario()
        {
            DataGridViewCellStyle style = dataEuid.ColumnHeadersDefaultCellStyle;
            style.Font = new Font(dataEuid.Font.FontFamily, 14.25F, FontStyle.Bold);
            LlenaCombo();
            txtEuid.Focus();
        }

        private void LlenaCombo()
        {
            var data = DiscardReasonBusiness.GetAllData();
            cboReason.DisplayMember = "Reason";
            cboReason.ValueMember = "Reason";
            cboReason.DataSource = data;
        }

        private void FrmRogging_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void txtEuid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                //var Euid = EntryList.GetBin(txtBin.Text.ToUpper()); ;
                if (txtEuid.Text.Trim() != "" && Reason != null)
                {
                    GrabaInformacion();
                }
                else
                {
                    MessageBox.Show("Datos Inválidos", "Módulo Rogging", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                    txtEuid.Text = "";
                    txtEuid.Focus();
                }
            }
        }

        private void cboReason_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboReason.SelectedItem != null)
            {
                if (((DiscardReason)cboReason.SelectedItem).Id > 0)
                {
                    Reason = (DiscardReason)cboReason.SelectedItem;
                    LlenaGrilla(Reason.Reason);
                }
            }
        }

        private void LlenaGrilla(string reason)
        {
            var data = MovimientoRoggingBusiness.GetMovimientoRogging(reason);
            dataEuid.AutoGenerateColumns = false;
            dataEuid.DataSource = data;
            dataEuid.ClearSelection();
            lblTotal.Text = dataEuid.RowCount.ToString();
        }

        private void cboReason_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void GrabaInformacion()
        {
            TransactionalInformation transaccion = new TransactionalInformation();
            MovimientoRogging mov = new MovimientoRogging();

            mov.Euid = txtEuid.Text;
            mov.FechaRogging = DateTime.Now;
            mov.UsuarioRogging = usuarioValido.nombre_usuario;
            mov.Reason = Reason.Reason;

            MovimientoRoggingBusiness.GrabaInformacion(mov, out transaccion);
            if (transaccion.ReturnStatus)
            {
                LlenaGrilla(Reason.Reason);
                txtEuid.Text = "";
                txtEuid.Focus();
                //MessageBox.Show("Caja Creada!", "Módulo Packing", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }

        private void borrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataEuid.SelectedCells.Count > 0)
            {
                int selectedrowindex = dataEuid.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataEuid.Rows[selectedrowindex];
                var id = Convert.ToInt32(selectedRow.Cells["Id"].Value);

                BorrarEuid(id);
            }
        }

        private void BorrarEuid(int id)
        {
            TransactionalInformation transaction = new TransactionalInformation();
            MovimientoRoggingBusiness.BorrarEuid(id, out transaction);

            if (transaction.ReturnStatus)
            {
                LlenaGrilla(Reason.Reason);
                //MessageBox.Show("Euid Eliminado", "Módulo Shipping", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            else
            {
                MessageBox.Show("Error: " + transaction.ReturnMessage, "Módulo Shipping", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void dataEuid_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int currentMouseOverRow = dataEuid.HitTest(e.X, e.Y).RowIndex;
                ctxEuidMenu.Show(dataEuid, new Point(e.X, e.Y));
            }
        }
    }
}
