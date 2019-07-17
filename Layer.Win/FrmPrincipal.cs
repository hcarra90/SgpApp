using Layer.Entity;
using Layer.Win.Consulta;
using Layer.Win.Cosecha;
using Layer.Win.Desgrane;
using Layer.Win.Packing;
using Layer.Win.Secado;
using Layer.Win.Shipping;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LiveCharts;
using LiveCharts.Wpf;
using Layer.Business;
using Layer.Entity.Dto;
using System.Deployment.Application;
using Layer.Win.Rogging;
using Layer.Win.Administrador;
using System.Globalization;
using System.Net;
using Layer.Win.Siembra;
using Layer.Win.Floracion;
using Layer.Win.Reserva;
using Layer.Win.Mantenedores;
using System.Diagnostics;
using System.Reflection;

namespace Layer.Win
{
    public partial class FrmPrincipal : Form
    {
        #region -----Declaraciones-----
        public Usuario usuarioValido { get; set; }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam); 
        #endregion

        #region -----Constructores-----
        public FrmPrincipal()
        {
            InitializeComponent();
        } 
        #endregion

        #region -----Eventos-----
        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            ConfiguraFormulario();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void FrmPrincipal_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnCosecha_Click(object sender, EventArgs e)
        {
            FrmMovCosecha frm = new FrmMovCosecha();
            frm.usuarioValido = this.usuarioValido;
            frm.ShowDialog();
        }

        private void btnSecado_Click(object sender, EventArgs e)
        {
            FrmMovSecado frm = new FrmMovSecado();
            frm.usuarioValido = this.usuarioValido;
            frm.ShowDialog();
        }

        private void btnDesgrane_Click(object sender, EventArgs e)
        {
            FrmMovDesgrane frm = new FrmMovDesgrane();
            frm.usuarioValido = this.usuarioValido;
            frm.ShowDialog();
        }

        private void btnPacking_Click(object sender, EventArgs e)
        {
            FrmMovPacking frm = new FrmMovPacking();
            frm.usuarioValido = this.usuarioValido;
            frm.ShowDialog();
        }

        private void btnShipping_Click(object sender, EventArgs e)
        {
            FrmShipping frm = new FrmShipping();
            frm.usuarioValido = this.usuarioValido;
            frm.ShowDialog();
        }

        private void btnEnvio_Click(object sender, EventArgs e)
        {
            FrmEnvioCaja frm = new FrmEnvioCaja();
            frm.usuarioValido = this.usuarioValido;
            frm.ShowDialog();
        }

        private void btnPlist_Click(object sender, EventArgs e)
        {
            FrmPackingList frm = new FrmPackingList();
            frm.usuarioValido = this.usuarioValido;
            frm.ShowDialog();
        }

        private void btnTracking_Click(object sender, EventArgs e)
        {
            FrmConsulta frm = new FrmConsulta();
            frm.usuarioValido = this.usuarioValido;
            frm.ShowDialog();
        }

        private void btnEficiencia_Click(object sender, EventArgs e)
        {
            FrmEficiencia frm = new FrmEficiencia();
            //frm.usuarioValido = this.usuarioValido;
            frm.ShowDialog();
        }

        private void btnRogging_Click(object sender, EventArgs e)
        {
            FrmRogging frm = new FrmRogging();
            frm.usuarioValido = this.usuarioValido;
            frm.ShowDialog();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSiembra_Click(object sender, EventArgs e)
        {
            FrmTemplateEntryList frm = new FrmTemplateEntryList();
            frm.usuarioValido = this.usuarioValido;
            frm.ShowDialog();
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            FrmSplit frm = new FrmSplit();
            //frm.usuarioValido = this.usuarioValido;
            frm.ShowDialog();
        }

        private void btnSplit_Click(object sender, EventArgs e)
        {
            FrmUploadInfoFieldBook frm = new FrmUploadInfoFieldBook();
            frm.usuarioValido = this.usuarioValido;
            frm.ShowDialog();
        }

        private void btnFloracion_Click(object sender, EventArgs e)
        {
            FrmFloracion frm = new FrmFloracion();
            frm.usuarioValido = this.usuarioValido;
            frm.ShowDialog();
        }

        private void btnPackingUva_Click(object sender, EventArgs e)
        {
            FrmPackingUva frm = new FrmPackingUva();
            frm.usuarioValido = this.usuarioValido;
            frm.ShowDialog();
        }

        private void btnInfoField_Click(object sender, EventArgs e)
        {
            FrmUploadInfoFieldBook frm = new FrmUploadInfoFieldBook();
            frm.usuarioValido = this.usuarioValido;
            frm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmSplit frm = new FrmSplit
            {
                usuarioValido = this.usuarioValido
            };
            frm.ShowDialog();
        }

        private void btnSplit_Click_1(object sender, EventArgs e)
        {

        }

        private void btnMouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnMouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnAereo_Click(object sender, EventArgs e)
        {
            FrmReservaEspacioAereo frm = new FrmReservaEspacioAereo
            {
                usuarioValido = this.usuarioValido
            };
            frm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmTemplate frm = new FrmTemplate();
            frm.ShowDialog();
        }

        private void btnGuia_Click(object sender, EventArgs e)
        {
            FrmGuiaDespacho frm = new FrmGuiaDespacho
            {
                usuarioValido = this.usuarioValido
            };
            frm.ShowDialog();
        }

        private void btnEntryList_Click(object sender, EventArgs e)
        {
            FrmUploadEntryList frm = new FrmUploadEntryList
            {
                usuarioValido = this.usuarioValido
            };
            frm.ShowDialog();
        }

        private void btnTablas_Click(object sender, EventArgs e)
        {
            FrmDireccion frm = new FrmDireccion
            {
                usuarioValido = this.usuarioValido
            };
            frm.ShowDialog();
        }

        private void BtnEtiquetas_Click(object sender, EventArgs e)
        {
            FrmReportes frm = new FrmReportes
            {
                usuarioValido = usuarioValido
            };
            frm.ShowDialog();
        }
        #endregion

        #region -----Funciones-----
        private void ConfiguraFormulario()
        {
            string version = "";

            if (!Directory.Exists("C:\\Templates"))
            {
                Directory.CreateDirectory("C:\\Templates");
                MessageBox.Show(@"Directorio no existe, se crea!", "Menu", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }

            lblUsuario.Text = usuarioValido.nombre + " " + usuarioValido.apellido;
            lblPerfil.Text = usuarioValido.Perfil.nombrePerfil;
            lblAmbiente.Text = usuarioValido.Ambiente;
            lblConexion.Text = usuarioValido.Servidor.ToUpper();

            ToolTip toolTip1 = new ToolTip();
            toolTip1.ShowAlways = true;
            toolTip1.SetToolTip(btnCosecha, "Registro De Cosecha");
            toolTip1.SetToolTip(btnSecado, "Registro De Secado");
            toolTip1.SetToolTip(btnDesgrane, "Registro De Desgrane");
            toolTip1.SetToolTip(btnPacking, "Registro De Packing");
            toolTip1.SetToolTip(btnShipping, "Registro De Shipping");
            toolTip1.SetToolTip(btnEnvio, "Registro De Envios");
            toolTip1.SetToolTip(btnTracking, "Consulta De Tracking");
            toolTip1.SetToolTip(btnPlist, "Packing List");
            toolTip1.SetToolTip(btnRogging, "Registro De Rogging");
            toolTip1.SetToolTip(btnSiembra, "Crear Experimento");
            toolTip1.SetToolTip(btnInfoField, "Crea Archivo Split");
            toolTip1.SetToolTip(btnSplit, "Carga Archivo Split");
            toolTip1.SetToolTip(btnFloracion, "Registrar Nota De Floración");
            toolTip1.SetToolTip(btnPackingUva, "Packing Uva");
            toolTip1.SetToolTip(btnAereo, "Reserva Espacio");
            toolTip1.SetToolTip(btnGuia, "Datos Guía Despacho");
            toolTip1.SetToolTip(btnEntryList, "Carga Archivo Entry List");
            toolTip1.SetToolTip(btnMantencion, "Tablas De Sistema");
            toolTip1.SetToolTip(btnEtiquetas, "Generar Etiquetas");
            //
            try
            {
                //using (var client = new WebClient())
                //{
                //    client.DownloadFile("http://www.massainursery.cl/Files/PackingList.xlsx", "C:\\Templates\\PackingList.xlsx");
                //}
                Assembly executingAssembly = System.Reflection.Assembly.GetExecutingAssembly();
                var fieVersionInfo = FileVersionInfo.GetVersionInfo(executingAssembly.Location);
                version = fieVersionInfo.FileVersion;
                
                lblVersion.Text = ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString();

            }
            catch (Exception)
            {
                lblVersion.Text = version;
            }
        }
        #endregion

        private void btnInfo_Click(object sender, EventArgs e)
        {
            FrmInfoFieldBook frm = new FrmInfoFieldBook
            {
                usuarioValido = this.usuarioValido
            };
            frm.ShowDialog();
        }

        private void BtnMantencion_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            FrmMantenedores frm = new FrmMantenedores
            {
                usuarioValido = this.usuarioValido
            };
            frm.ShowDialog();
        }
    }
}
