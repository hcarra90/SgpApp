using Layer.Business;
using Layer.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Layer.Win
{
    public partial class FrmLogin : Form
    {
        string Usuario = "";
        string Password = "";
        Usuario usuarioValido = new Usuario();
        

        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text !="")
            {
                Usuario = txtUsuario.Text.Trim();
            }
            else
            {
                MessageBox.Show("Debe Ingresar Usuario", "Acceso Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }

            if (txtPassword.Text.Trim() !="")
            {
                Password = txtPassword.Text.Trim();
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
            if (transaction.ReturnMessage !="")
            {
                MessageBox.Show("Error: " + transaction.ReturnMessage, "Acceso Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            else if (usuarioValido == null)
            {
                MessageBox.Show("Usuario Inválido", "Acceso Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                txtUsuario.Focus();
            }
            else
            {
                MessageBox.Show("Bienvenido " + usuarioValido.nombre + " " + usuarioValido.apellido, "Acceso Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                this.Hide();
                MDIMenu frm = new MDIMenu();
                frm.usuarioValido = usuarioValido;
                frm.Show();
            }
            
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void LimpiarFormulario()
        {
            txtUsuario.Text = "";
            txtPassword.Text = "";
            txtUsuario.Focus();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            txtUsuario.Focus();
        }

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (txtUsuario.Text.Trim() != "")
                {
                    txtPassword.Focus();
                }
                else
                {
                    MessageBox.Show("Debe Ingresar Euid Para Continuar", "Módulo Packing", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                    txtUsuario.Focus();
                }
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (txtUsuario.Text.Trim() != "" && txtPassword.Text.Trim() !="")
                {
                    ValidaUsuario(txtUsuario.Text, txtPassword.Text);
                }
                else
                {
                    MessageBox.Show("Debe Ingresar Euid Para Continuar", "Módulo Packing", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                    txtUsuario.Focus();
                }
            }
        }
    }
}
