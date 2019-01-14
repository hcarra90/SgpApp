using Layer.Business;
using Layer.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Layer.Win.Desgrane
{
    public partial class FrmMovDesgrane : Form
    {
        public Usuario usuarioValido { get; set; }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        public FrmMovDesgrane()
        {
            InitializeComponent();
        }

        private void FrmMovDesgrane_Load(object sender, EventArgs e)
        {
            ConfiguraFormulario();
        }

        private void ConfiguraFormulario()
        {
            DataGridViewCellStyle style = dataEuid.ColumnHeadersDefaultCellStyle;
            style.Font = new Font(dataEuid.Font.FontFamily, 14.25F, FontStyle.Bold);

            style = dataEuids.ColumnHeadersDefaultCellStyle;
            style.Font = new Font(dataEuids.Font.FontFamily, 14.25F, FontStyle.Bold);
            txtDes.Focus();
        }

        private void LlenaGrilla(string sheller)
        {
            var data = MovimientoDesgraneBusiness.GetEuidsBySheller(sheller);
            dataEuids.AutoGenerateColumns = false;
            dataEuids.DataSource = data;
            dataEuids.ClearSelection();
            lblTotalE.Text = dataEuids.RowCount.ToString();
        }

        private void txtEuid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                var caja = InfoDryersBusiness.GetSheller(txtDes.Text);

                if (txtEuid.Text.Trim() != "" && txtDes.Text != "" && caja != null)
                {
                    BuscaInfo();
                    GrabaInformacion();
                }
                else
                {
                    MessageBox.Show("Datos Inválidos", "Módulo Desgrane", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                    txtEuid.Focus();
                }
            }
        }

        private void BuscaInfo()
        {
            var data = InfoFieldBookBusiness.GetEuid(txtEuid.Text,"");
            dataEuid.AutoGenerateColumns = false;
            dataEuid.DataSource = data;
            dataEuid.ClearSelection();
            lblTotal.Text = dataEuid.RowCount.ToString();
        }

        private void GrabaInformacion()
        {
            TransactionalInformation transaccion = new TransactionalInformation();

            var movi = MovimientoDesgraneBusiness.GetEuid(txtEuid.Text, txtDes.Text);
            if (movi != null)
            {
                if (MessageBox.Show("Desea desgranar nuevamente? ", "Módulo Desgrane", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    pctInfo.Visible = true;
                    pctBad.Visible = false;
                    pctGood.Visible = false;

                    movi.fechaDesgrane = DateTime.Now;
                    MovimientoDesgraneBusiness.GrabaInformacion(movi,out transaccion);
                    
                }
            }
            else
            {
                movi = null;
                MovimientoDesgrane mov = new MovimientoDesgrane();
                mov.fechaDesgrane = DateTime.Now;
                mov.euid = txtEuid.Text;
                mov.sheller = txtDes.Text;
                mov.usuario = usuarioValido.nombre_usuario;
                MovimientoDesgraneBusiness.GrabaInformacion(mov, out transaccion);
                
                LlenaGrilla(txtDes.Text.ToUpper());
                

                if (transaccion.ReturnStatus)
                {
                    pctGood.Visible = true;
                    pctBad.Visible = false;
                }
                else
                {
                    pctGood.Visible = false;
                    pctBad.Visible = true;
                }
            }

            lblEuid.Text = txtEuid.Text;
            txtEuid.Text = "";
            txtEuid.Focus();
        }

        private void txtDes_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (txtDes.Text.Trim() != "")
                {
                    var caja = InfoDryersBusiness.GetSheller(txtDes.Text.ToUpper());

                    if (caja == null)
                    {
                        MessageBox.Show("Sheller no existe", "Módulo Packing", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                        txtDes.Text = "";
                        txtDes.Focus();
                        dataEuid.DataSource = null;
                        dataEuids.DataSource = null;
                        return;
                    }
                    else
                    {
                        LlenaGrilla(txtDes.Text.ToUpper());
                        txtEuid.Focus();
                    }
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void FrmMovDesgrane_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
