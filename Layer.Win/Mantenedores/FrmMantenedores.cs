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

namespace Layer.Win.Mantenedores
{
    public partial class FrmMantenedores : Form
    {
        #region -----Declaraciones-----
        public Usuario usuarioValido { get; set; }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
        #endregion

        #region -----Constructores-----
        public FrmMantenedores()
        {
            InitializeComponent();
        }
        #endregion

        #region -----Eventos-----
        private void FrmMantenedores_Load(object sender, EventArgs e)
        {
            ConfiguraFormulario();
        }

        private void BtnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void FrmMantenedores_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void BtnEntryList_Click(object sender, EventArgs e)
        {
            FrmEntryList frm = new FrmEntryList
            {
                usuarioValido = this.usuarioValido
            };
            frm.ShowDialog();
        }

        private void BtnInfoField_Click(object sender, EventArgs e)
        {
            FrmInfoFieldBook frm = new FrmInfoFieldBook
            {
                usuarioValido = this.usuarioValido
            };
            frm.ShowDialog();
        }

        private void BtnInfoShipping_Click(object sender, EventArgs e)
        {
            FrmDireccion frm = new FrmDireccion
            {
                usuarioValido = this.usuarioValido
            };
            frm.ShowDialog();
        }

        #endregion

        #region -----Funciones-----

        private void ConfiguraFormulario()
        {
            ToolTip toolTip1 = new ToolTip();
            toolTip1.ShowAlways = true;
            toolTip1.SetToolTip(btnEntryList, "Mantención Entry List");
            toolTip1.SetToolTip(btnInfoField, "Mantención InfoFieldBook");
            toolTip1.SetToolTip(btnInfoShipping, "Mantención Direcciones");

            lblUsuario.Text = usuarioValido.nombre + " " + usuarioValido.apellido;
            lblPerfil.Text = usuarioValido.Perfil.nombrePerfil;
            lblAmbiente.Text = usuarioValido.Ambiente;
            lblConexion.Text = usuarioValido.Servidor.ToUpper();
        }

        private void BtnMouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void BtnMouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        #endregion

        
    }
}
