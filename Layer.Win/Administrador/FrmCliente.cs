using Layer.Business;
using Layer.Entity;
using Layer.Win.Siembra;
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

namespace Layer.Win.Administrador
{
    public partial class FrmCliente : Form
    {
        int idEmpresa = 0;
        public FrmCliente()
        {
            InitializeComponent();
        }

        private void FrmCliente_Load(object sender, EventArgs e)
        {
            ConfiguraFormulario();
        }

        private void ConfiguraFormulario()
        {
            idEmpresa = int.Parse(ConfigurationManager.AppSettings["IdEmpresa"].ToString());
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarCerrar();
        }

        private void LimpiarCerrar()
        {
            txtNombre.Text = "";
            this.Close();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            CrearCliente();
        }

        private void CrearCliente()
        {
            if (txtNombre.Text !="")
            {
                Cliente clienteNuevo = new Cliente
                {
                    id_empresa = idEmpresa,
                    Nombre = txtNombre.Text
                };

                try
                {
                    ClienteBusiness.Insert(clienteNuevo);
                    LimpiarCerrar();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
