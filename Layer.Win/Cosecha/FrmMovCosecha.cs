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

namespace Layer.Win.Cosecha
{
    public partial class FrmMovCosecha : Form
    {
        public Usuario usuarioValido { get; set; }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        public FrmMovCosecha()
        {
            InitializeComponent();
        }

        private void FrmMovCosecha_Load(object sender, EventArgs e)
        {
            ConfiguraFormulario();
        }

        private void ConfiguraFormulario()
        {
            DataGridViewCellStyle style = dataEuid.ColumnHeadersDefaultCellStyle;
            style.Font = new Font(dataEuid.Font.FontFamily, 14.25F,FontStyle.Bold);

            ToolTip toolTip1 = new ToolTip();
            toolTip1.ShowAlways = true;
            txtBin.Focus();
        }

        private void txtEuid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                var caja = InfoDryersBusiness.GetBin(txtBin.Text.ToUpper()); ;
                if (txtEuid.Text.Trim() != "" && txtBin.Text != "" && caja != null)
                {
                    GrabaInformacion();
                }
                else
                {
                    MessageBox.Show("Datos Inválidos", "Módulo Cosecha", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                    txtEuid.Text = "";
                    txtEuid.Focus();
                }
            }
        }

        private void GrabaInformacion()
        {
            TransactionalInformation transaccion = new TransactionalInformation();
            MovimientoCosecha mov = new MovimientoCosecha();

            mov.euid = txtEuid.Text;
            mov.fechaCosecha = DateTime.Now;
            mov.usuario = usuarioValido.nombre_usuario;
            mov.Bin = txtBin.Text;

            MovimientoCosechaBusiness.GrabaInformacion(mov, out transaccion);
            if (transaccion.ReturnStatus)
            {
                LlenaGrilla(txtBin.Text);
                txtEuid.Text = "";
                txtEuid.Focus();
                //MessageBox.Show("Caja Creada!", "Módulo Packing", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }

        private void LlenaGrilla(string bin)
        {
            var data = MovimientoCosechaBusiness.GetEuidsByBin(bin);
            dataEuid.AutoGenerateColumns = false;
            dataEuid.DataSource = data;
            dataEuid.ClearSelection();
            lblTotal.Text = dataEuid.RowCount.ToString();
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
            MovimientoCosechaBusiness.BorrarEuid(id, out transaction);

            if (transaction.ReturnStatus)
            {
                LlenaGrilla(txtBin.Text);
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

        private void txtBin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (txtBin.Text.Trim() != "")
                {
                    var caja = InfoDryersBusiness.GetBin(txtBin.Text.ToUpper());

                    if (caja == null)
                    {
                        MessageBox.Show("Bin no existe", "Módulo Packing", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                        txtBin.Text = "";
                        txtBin.Focus();
                        dataEuid.DataSource = null;
                        return;
                    }
                    else
                    {
                        LlenaGrilla(txtBin.Text);
                        txtEuid.Focus();
                    }
                    
                }
            }
        }

        private void FrmMovCosecha_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void txtEuid_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
