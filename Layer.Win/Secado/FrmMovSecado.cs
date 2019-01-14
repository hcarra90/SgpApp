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

namespace Layer.Win.Secado
{ 
    
    public partial class FrmMovSecado : Form
    {
        public Usuario usuarioValido { get; set; }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        public FrmMovSecado()
        {
            InitializeComponent();
        }

        private void FrmMovimientoSecado_Load(object sender, EventArgs e)
        {
            ConfiguraFormulario();
        }

        private void ConfiguraFormulario()
        {
            DataGridViewCellStyle style = dataEuid.ColumnHeadersDefaultCellStyle;
            style.Font = new Font(dataEuid.Font.FontFamily, 14.25F, FontStyle.Bold);

            ToolTip toolTip1 = new ToolTip();
            toolTip1.ShowAlways = true;
            toolTip1.SetToolTip(btnVer, "Ver Detalle Proceso");

            txtBox.Focus();
        }

        private void LlenaGrilla(string cajaSecador)
        {
            var data = MovimientoSecadoBusiness.GetEuidsByBox(cajaSecador);
            dataEuid.AutoGenerateColumns = false;
            dataEuid.DataSource = data;
            dataEuid.ClearSelection();
            lblTotal.Text = dataEuid.RowCount.ToString();
        }

        private void dataEuid_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int currentMouseOverRow = dataEuid.HitTest(e.X, e.Y).RowIndex;
                ctxEuidMenu.Show(dataEuid, new Point(e.X, e.Y));
            }
        }

        private void txtEuid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                var caja = InfoDryersBusiness.GetDryerBox(txtBox.Text.ToUpper());
                if (txtEuid.Text.Trim() != "" && txtBox.Text != "" && caja != null)
                {
                    GrabaInformacion();
                }
                else
                {
                    MessageBox.Show("Datos Incorrectos", "Módulo Packing", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                    txtEuid.Focus();
                }
            }
        }

        private void GrabaInformacion()
        {
            TransactionalInformation transaccion = new TransactionalInformation();
            MovimientoSecado movimiento = new MovimientoSecado();

            var movimientos = MovimientoSecadoBusiness.GetEuid(txtEuid.Text);
            var movs= movimientos.Where(m => m.fechaTermino == null).ToList();
            var count = movimientos.Count(m => m.fechaTermino != null);

            foreach (var item in movs)
            {
                item.fechaTermino = DateTime.Now;
                MovimientoSecadoBusiness.GrabaInformacion(item, out transaccion);
            }

            if (count > 0)
            {
                if (MessageBox.Show("EUID ya secado, desea ingresarlo al secador nuevamente?", "Módulo Secador", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    movimiento = null;

                    MovimientoSecado mov = new MovimientoSecado
                    {
                        euid = txtEuid.Text,
                        fechaInicio = DateTime.Now,
                        usuario = usuarioValido.nombre_usuario,
                        cajaSecador = txtBox.Text.ToUpper()
                    };
                    MovimientoSecadoBusiness.GrabaInformacion(mov, out transaccion);
                }
            }
            else if(movs.Count == 0)
            {
                movimiento = null;

                MovimientoSecado mov = new MovimientoSecado
                {
                    euid = txtEuid.Text,
                    fechaInicio = DateTime.Now,
                    usuario = usuarioValido.nombre_usuario,
                    cajaSecador = txtBox.Text.ToUpper()
                };
                MovimientoSecadoBusiness.GrabaInformacion(mov, out transaccion);
            }

            if (transaccion.ReturnStatus)
            {
                LlenaGrilla(txtBox.Text);
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
            MovimientoSecadoBusiness.BorrarEuid(id, out transaction);

            if (transaction.ReturnStatus)
            {
                LlenaGrilla(txtBox.Text);
                //MessageBox.Show("Euid Eliminado", "Módulo Shipping", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            else
            {
                MessageBox.Show("Error: " + transaction.ReturnMessage, "Módulo Shipping", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                txtEuid.Text = "";
                txtEuid.Focus();
            }
        }

        private void txtBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (txtBox.Text.Trim() != "")
                {
                    var caja = InfoDryersBusiness.GetDryerBox(txtBox.Text.ToUpper());
                    if (caja == null)
                    {
                        MessageBox.Show("Caja no existe", "Módulo Packing", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                        txtBox.Text = "";
                        txtBox.Focus();
                        dataEuid.DataSource = null;
                        return;
                    }
                    else
                    {
                        LlenaGrilla(txtBox.Text);
                        txtEuid.Focus();
                    }
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void FrmMovSecado_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }
    }
}
