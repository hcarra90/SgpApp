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
using System.Deployment.Application;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Layer.Win
{
    public partial class MDIMenu : Form
    {
        public Usuario usuarioValido { get; set; }

        public MDIMenu()
        {
            InitializeComponent();
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void MDIMenu_Load(object sender, EventArgs e)
        {
            stpSeparador1.Text = " ";
            stpUsuario.Text = usuarioValido.nombre + " " + usuarioValido.apellido;
            stPerfil.Text = usuarioValido.Perfil.nombrePerfil;

            try
            {
                lblVersion.Text = ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString();
            }
            catch (Exception)
            {
                lblVersion.Text ="Desarrollo";
            }
        }

        private void MDIMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void stpUsuario_Click(object sender, EventArgs e)
        {

        }

        private void movimientoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMovCosecha frm = new FrmMovCosecha();
            frm.usuarioValido = this.usuarioValido;
            frm.ShowDialog();
        }

        private void movimientoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmMovPacking frm = new FrmMovPacking();
            //frm.MdiParent = this;
            frm.usuarioValido = this.usuarioValido;
            frm.ShowDialog();
        }

        private void movimientoToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            FrmShipping frm = new FrmShipping();
            //frm.MdiParent = this;
            frm.usuarioValido = this.usuarioValido;
            frm.ShowDialog();
        }

        private void envioToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void envioDeCajasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void envioDeCajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmEnvioCaja frm = new FrmEnvioCaja();
            //frm.MdiParent = this;
            frm.usuarioValido = this.usuarioValido;
            frm.ShowDialog();
        }

        private void packingListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPackingList frm = new FrmPackingList();
            //frm.MdiParent = this;
            frm.usuarioValido = this.usuarioValido;
            frm.ShowDialog();
        }

        private void movimientoToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            FrmMovSecado frm = new FrmMovSecado();
            //frm.MdiParent = this;
            frm.usuarioValido = this.usuarioValido;
            frm.ShowDialog();
        }

        private void movimientoToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            FrmMovDesgrane frm = new FrmMovDesgrane();
            //frm.MdiParent = this;
            frm.usuarioValido = this.usuarioValido;
            frm.ShowDialog();
        }

        private void trackingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmConsulta frm = new FrmConsulta();
            //frm.MdiParent = this;
            frm.usuarioValido = this.usuarioValido;
            frm.ShowDialog();
        }

        private void pesoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPeso frm = new FrmPeso();
            //frm.MdiParent = this;
            
            frm.ShowDialog();
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
            //frm.MdiParent = this;
            frm.usuarioValido = this.usuarioValido;
            frm.ShowDialog();
        }

        private void btnDesgrane_Click(object sender, EventArgs e)
        {
            FrmMovDesgrane frm = new FrmMovDesgrane();
            //frm.MdiParent = this;
            frm.usuarioValido = this.usuarioValido;
            frm.ShowDialog();
        }

        private void btnPacking_Click(object sender, EventArgs e)
        {
            FrmMovPacking frm = new FrmMovPacking();
            //frm.MdiParent = this;
            frm.usuarioValido = this.usuarioValido;
            frm.ShowDialog();
        }

        private void btnLlenado_Click(object sender, EventArgs e)
        {
            FrmShipping frm = new FrmShipping();
            //frm.MdiParent = this;
            frm.usuarioValido = this.usuarioValido;
            frm.ShowDialog();
        }

        private void btnEnvio_Click(object sender, EventArgs e)
        {
            FrmEnvioCaja frm = new FrmEnvioCaja();
            //frm.MdiParent = this;
            frm.usuarioValido = this.usuarioValido;
            frm.ShowDialog();
        }

        private void btnPackingList_Click(object sender, EventArgs e)
        {
            FrmPackingList frm = new FrmPackingList();
            //frm.MdiParent = this;
            frm.usuarioValido = this.usuarioValido;
            frm.ShowDialog();
        }

        private void btnTracking_Click(object sender, EventArgs e)
        {
            FrmConsulta frm = new FrmConsulta();
            //frm.MdiParent = this;
            frm.usuarioValido = this.usuarioValido;
            frm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmPeso frm = new FrmPeso();
            //frm.MdiParent = this;

            frm.ShowDialog();
        }
    }
}
