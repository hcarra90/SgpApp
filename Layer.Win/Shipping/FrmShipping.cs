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

namespace Layer.Win.Shipping
{
    public partial class FrmShipping : Form
    {
        public Usuario usuarioValido { get; set; }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        public FrmShipping()
        {
            InitializeComponent();
        }

        private void FrmShipping_Load(object sender, EventArgs e)
        {
            ConfiguracionFormulario();
        }

        #region Proceso Cajas

        private void ConfiguracionFormulario()
        {
            DataGridViewCellStyle style = dataEuid.ColumnHeadersDefaultCellStyle;
            style.Font = new Font(dataEuid.Font.FontFamily, 9.75F, FontStyle.Bold);
            txtBox.Focus();
        }

        private void txtBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (txtBox.Text.Trim() != "")
                {
                    //Validación que la caja este creada
                    var caja = MovimientoCajaBusiness.GetCaja(txtBox.Text);
                    if (caja == null)
                    {
                        MessageBox.Show("Caja no existe", "Módulo Packing", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                        txtBox.Focus();
                        return;
                    }
                    else
                    {
                        BuscarInfo(txtBox.Text.Trim());
                        txtEuid.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Debe Ingresar Box Para Continuar", "Módulo Packing", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                }
            }
        }

        private void BuscarInfo(string box)
        {
            var euidData = MovimientoShippingBusiness.GetEuidByBox(box.ToUpper());
            dataEuid.AutoGenerateColumns = false;
            dataEuid.DataSource = euidData;
            dataEuid.ClearSelection();
            lblTotal.Text = dataEuid.RowCount.ToString();
        }

        private void txtEuid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (txtEuid.Text.Trim() != "")
                {
                    GrabaEuid(1);
                }
            }
        }

        private void txtIndEuid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (txtIndEuid.Text.Trim() != "" && txtIndEuid.Text.Contains("_"))
                {
                    GrabaEuid(2);
                }
                else
                {
                    MessageBox.Show("Debe Ingresar Individual Euid Válido", "Módulo Shipping", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                    txtIndEuid.Text = "";
                    txtIndEuid.Focus();
                }
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

        private void GrabaEuid(int tipo)
        {
            MovimientoShipping movimientoShipping = new MovimientoShipping();
            TransactionalInformation transaccion = new TransactionalInformation();

            if (txtBox.Text.Trim() != "")
            {
                if (tipo == 1)
                {
                    movimientoShipping.euid = txtEuid.Text;
                }
                else if (tipo == 2)
                {
                    var euid = txtIndEuid.Text.Split('_');

                    movimientoShipping.indEuid = txtIndEuid.Text.Trim();
                    movimientoShipping.euid = euid[0];
                }

                //Validación del Euid cuando posee un Individual Euid
                var dataEuid = InfoFieldBookBusiness.GetEuid(movimientoShipping.euid.ToString(),"");
                if (tipo==1 && dataEuid.Count > 1 && txtIndEuid.Text == "")
                {
                    MessageBox.Show("Debe Ingresar Individual Euid", "Módulo Packing", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                    txtIndEuid.Focus();
                    return;
                }

                //Validación que nos indica que un euid no puede ir a un destino distinto al cuál ya esta seteado en la tabla InfoFieldBook
                if (tipo == 2)
                {
                    if (txtEuid.Text == "")
                    {
                        var posicion = txtIndEuid.Text.IndexOf("_");
                        var euid = txtIndEuid.Text.Substring(0, posicion);
                        txtEuid.Text = euid;
                    }

                    //Valido que IndEuid no exista en la misma caja
                    var boxE = MovimientoShippingBusiness.GetBoxByIndEuid(txtIndEuid.Text, txtBox.Text);
                    if (boxE != null)
                    {
                        MessageBox.Show("Individual Euid no puede ser ingresar nuevamente en la misma caja", "Módulo Packing", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                        txtEuid.Text = "";
                        txtIndEuid.Text = "";
                        txtIndEuid.Focus();
                        return;
                    }

                    var ie = dataEuid.Where(d => d.euid == txtEuid.Text && d.indEuid == txtIndEuid.Text).FirstOrDefault();
                    if (ie != null)
                    {
                        if (ie.shipTo != txtBox.Text.Substring(0, 2).ToUpper())
                        {
                            MessageBox.Show("Euid no puede ser enviado a un destino distinto", "Módulo Packing", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                            txtIndEuid.Text = "";
                            txtEuid.Text = "";
                            txtIndEuid.Focus();
                            return;
                        }
                    }
                }
                else if (tipo == 1)
                {
                    if (dataEuid.Count > 0)
                    {
                        if (dataEuid[0].shipTo != txtBox.Text.Substring(0, 2).ToUpper())
                        {
                            MessageBox.Show("Euid no puede ser enviado a un destino distinto", "Módulo Packing", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                            txtEuid.Text = "";
                            txtIndEuid.Focus();
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Debe Ingresar Euid Válido", "Módulo Shipping", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                        txtEuid.Text = "";
                        txtEuid.Focus();
                        return;
                    }
                    
                }

                //Validación que comprueba que un euid o indivual euid no vaya en cajas distintas
                var movShipping = MovimientoShippingBusiness.GetBoxesByEuid(txtEuid.Text,txtIndEuid.Text,txtBox.Text);

                if (movShipping.Count > 0)
                {
                    MessageBox.Show("Euid no puede ser ingresado en cajas distintas", "Módulo Packing", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                    return;
                }
                //if (txtBox.Text.Substring(0,2) != )
                //{

                //}
                movimientoShipping.cajaEnvio = txtBox.Text.Trim().ToUpper();
                movimientoShipping.fechaPreparacion = DateTime.Now;
                movimientoShipping.usuario = usuarioValido.nombre_usuario;

                MovimientoShippingBusiness.GrabaInformacion(movimientoShipping, out transaccion);
                if (transaccion.ReturnStatus)
                {
                    txtIndEuid.Text = "";
                    txtEuid.Text = "";
                    if (tipo ==1)
                    {
                        txtEuid.Focus();
                    }
                    else
                    {
                        txtIndEuid.Focus();
                    }
                    
                    BuscarInfo(txtBox.Text.Trim());
                }
                else
                {
                    MessageBox.Show("Error: " + transaccion.ReturnMessage, "Módulo Packing", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                } 
            }
            else
            {
                MessageBox.Show("Debe Ingresar Una Caja", "Módulo Shipping", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (dataEuid.SelectedCells.Count > 0)
            {
                int selectedrowindex = dataEuid.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataEuid.Rows[selectedrowindex];
                var Id = Convert.ToInt32(selectedRow.Cells["Id"].Value);

                BorrarEuid(Id);
            }
        }

        private void BorrarEuid(int id)
        {
            TransactionalInformation transaction = new TransactionalInformation();
            MovimientoShippingBusiness.BorrarEuid(id,out transaction);

            if (transaction.ReturnStatus)
            {
                BuscarInfo(txtBox.Text);
                //MessageBox.Show("Euid Eliminado", "Módulo Shipping", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            else
            {
                MessageBox.Show("Error: " + transaction.ReturnMessage, "Módulo Shipping", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        #endregion

        private void btnCaja_Click(object sender, EventArgs e)
        {
            FrmCaja frmCaja = new FrmCaja();
            frmCaja.usuarioValido = usuarioValido;
            frmCaja.ShowDialog();
        }

        private void dataEuid_MouseClick_1(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int currentMouseOverRow = dataEuid.HitTest(e.X, e.Y).RowIndex;
                ctxEuidMenu.Show(dataEuid, new Point(e.X, e.Y));
            }
        }

        private void FrmShipping_MouseDown(object sender, MouseEventArgs e)
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
