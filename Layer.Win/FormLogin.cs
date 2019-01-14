using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Layer.Entity;
using System.Configuration;
using Layer.Business;

namespace Layer.Win
{
    public partial class FormLogin : Form
    {
        string Usuario = "";
        string Password = "";
        Usuario usuarioValido = new Usuario();

        public FormLogin()
        {
            InitializeComponent();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void txtUser_Enter(object sender, EventArgs e)
        {
            if (txtUser.Text == "Usuario")
            {
                txtUser.Text = "";
                txtUser.ForeColor = Color.LightGray;
            }
        }

        private void txtUser_Leave(object sender, EventArgs e)
        {
            if (txtUser.Text == "")
            {
                txtUser.Text = "Usuario";
                txtUser.ForeColor = Color.DimGray;
            }
        }

        private void txtPass_Enter(object sender, EventArgs e)
        {
            if (txtPass.Text == "Password")
            {
                txtPass.Text = "";
                txtPass.ForeColor = Color.LightGray;
                txtPass.UseSystemPasswordChar = true;
            }
        }

        private void txtPass_Leave(object sender, EventArgs e)
        {
            if (txtPass.Text == "")
            {
                txtPass.Text = "Password";
                txtPass.ForeColor = Color.DimGray;
                txtPass.UseSystemPasswordChar = false;
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void FormLogin_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUser.Text != "")
            {
                Usuario = txtUser.Text.Trim();
            }
            else
            {
                MessageBox.Show("Debe Ingresar Usuario", "Acceso Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }

            if (txtPass.Text.Trim() != "")
            {
                Password = txtPass.Text.Trim();
            }
            else
            {
                MessageBox.Show("Debe Ingresar Password", "Acceso Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }

            ValidaUsuario(Usuario, Password);
        }

        private void ValidaUsuario(string usuario, string password)
        {
            string cadena = ConfigurationManager.AppSettings["StringPassword"].ToString();
            TransactionalInformation transaction;
            var passEncriptada = Functions.Encrypt.EncryptString(password, cadena);

            usuarioValido = UsuarioBusiness.ValidaUsuario(usuario, passEncriptada, out transaction);
            if (transaction.ReturnMessage != "")
            {
                MessageBox.Show("Error: " + transaction.ReturnMessage, "Acceso Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            else if (usuarioValido == null)
            {
                MessageBox.Show("Usuario Inválido", "Acceso Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                txtUser.Focus();
            }
            else
            {
                MessageBox.Show("Bienvenido " + usuarioValido.nombre + " " + usuarioValido.apellido, "Acceso Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                this.Hide();
                //MDIMenu frm = new MDIMenu();
                FrmPrincipal frm = new FrmPrincipal();
                frm.usuarioValido = usuarioValido;
                frm.Show();
            }

        }

        private void txtUser_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (txtUser.Text.Trim() != "")
                {
                    txtPass.Focus();
                }
                else
                {
                    MessageBox.Show("Debe Ingresar Euid Para Continuar", "Módulo Packing", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                    txtUser.Focus();
                }
            }
        }

        private void txtPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (txtUser.Text.Trim() != "" && txtPass.Text.Trim() != "")
                {
                    ValidaUsuario(txtUser.Text, txtPass.Text);
                }
                else
                {
                    MessageBox.Show("Debe Ingresar Euid Para Continuar", "Módulo Packing", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                    txtUser.Focus();
                }
            }
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
