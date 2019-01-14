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

namespace Layer.Win
{
    public partial class FrmPrincipal : Form
    {
        public Usuario usuarioValido { get; set; }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            ConfiguraFormulario();
            //CargaGraficoDesgrane();
        }

        private void ConfiguraFormulario()
        {
            if (!Directory.Exists("C:\\Templates"))
            {
                Directory.CreateDirectory("C:\\Templates");
                MessageBox.Show(@"Directorio no existe, se crea!", "Menu", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }

            lblUsuario.Text = usuarioValido.nombre + " " + usuarioValido.apellido;
            lblPerfil.Text = usuarioValido.Perfil.nombrePerfil;

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
            toolTip1.SetToolTip(btnEficiencia, "Reporte De Eficiencia");
            toolTip1.SetToolTip(btnRogging, "Registro De Rogging");
            toolTip1.SetToolTip(btnCargaArchivo, "Carga De Archivo");
            toolTip1.SetToolTip(btnSiembra, "Crear Template Carga Entry List");
            toolTip1.SetToolTip(btnUpload, "Subir Archivo Entry List");
            toolTip1.SetToolTip(btnFloracion, "Registrar Nota De Floración");
            //try
            //{
            //    using (var client = new WebClient())
            //    {
            //        client.DownloadFile("http://www.massainursery.cl/Files/TrackingList.xlsx", "C:\\Templates\\TrackingList.xlsx");
            //    }
            //    lblVersion.Text = ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString();
            //}
            //catch (Exception)
            //{
            //    lblVersion.Text = "Desarrollo";
            //}

            LlenaCombos();

        }

        private void LlenaCombos()
        {
            //Combo Project Lead
            var data2 = InfoFieldBookBusiness.GetProjectLead();
            cboProject.DisplayMember = "projectLead";
            cboProject.ValueMember = "projectLead";
            cboProject.DataSource = data2;

            //Combo Anio
            var anios = InfoFieldBookBusiness.GetAnio();
            cboAnio.DisplayMember = "anio";
            cboAnio.ValueMember = "anio";
            cboAnio.DataSource = anios;
        }

        private void CargaGraficoDesgrane()
        {
            //Func<ChartPoint, string> labelPoint = chartPoint =>
            //    string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);

            //pieChart.Series = new SeriesCollection
            //{
            //    new PieSeries
            //    {
            //        Title = "Maria",
            //        Values = new ChartValues<double> {3},
            //        PushOut = 15,
            //        DataLabels = true,
            //        LabelPoint = labelPoint
            //    },
            //    new PieSeries
            //    {
            //        Title = "Charles",
            //        Values = new ChartValues<double> {4},
            //        DataLabels = true,
            //        LabelPoint = labelPoint
            //    },
            //    new PieSeries
            //    {
            //        Title = "Frida",
            //        Values = new ChartValues<double> {6},
            //        DataLabels = true,
            //        LabelPoint = labelPoint
            //    },
            //    new PieSeries
            //    {
            //        Title = "Frederic",
            //        Values = new ChartValues<double> {2},
            //        DataLabels = true,
            //        LabelPoint = labelPoint
            //    }
            //};

            //pieChart.LegendLocation = LegendLocation.Bottom;

        }

        private void CargaGraficoSecado()
        {
            

        }

        private void CargaGraficoPacking()
        {
            //SeriesCollection series = new SeriesCollection();
            //PieSeries row = new PieSeries();
            ////Grilla Rogging
            //DataGridViewCellStyle style = dataPacking.ColumnHeadersDefaultCellStyle;
            //style.Font = new Font(dataPacking.Font.FontFamily, 8.25F, FontStyle.Bold);
            

            ////Grilla Rogging
            //style = datainfoPacking.ColumnHeadersDefaultCellStyle;
            //style.Font = new Font(datainfoPacking.Font.FontFamily, 8.25F, FontStyle.Bold);

            var data = MovimientoPackingBusiness.GetDataGraficoPacking(cboProject.Text, int.Parse(cboAnio.Text));
            grdResumen.AutoGenerateColumns = false;
            grdResumen.DataSource = data;

            if (data.Count > 0)
            {
                lblTotEuid.Text = data[0].TotalEuid.ToString("#,#");
                lblTotIndEuid.Text = data[0].TotalIndEuid.ToString("#,#");
            }
            
            //Func<ChartPoint, string> labelPoint = chartPoint =>
            //    string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);


            //foreach (var item in data)
            //{
            //    row = new PieSeries()
            //    {
            //        Title = item.Experimento,
            //        Values = new ChartValues<double> { (item.PorcentajeProcesado == 0) ? 0 : double.Parse(item.PorcentajeProcesado.ToString("#,#")) },
            //        PushOut = 15,
            //        DataLabels = true,
            //        LabelPoint = labelPoint
            //    };

            //    series.Add(row);
            //}
            //ExpChart.Series = series;
            //ExpChart.LegendLocation = LegendLocation.Bottom;


            //lblTotIndInfoPac.Text = data.NumeroMaestro.ToString("#,#");
            //lblTotIndPac.Text = data.NumeroMovimiento.ToString("#,#");
            //lblPorProcPac.Text = data.PorcentajeProcesado.ToString();


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

        private void btnCargaArchivo_Click(object sender, EventArgs e)
        {
            FrmUploadInfoFieldBook frm = new FrmUploadInfoFieldBook();
            frm.usuarioValido = this.usuarioValido;
            frm.ShowDialog();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (cboProject.Text != "" && cboAnio.Text !="")
            {
                this.Cursor = Cursors.WaitCursor;
                CargaGraficoPacking();
                this.Cursor = Cursors.Default;
            }
        }

        private void btnSiembra_Click(object sender, EventArgs e)
        {
            FrmTemplateEntryList frm = new FrmTemplateEntryList();
            frm.usuarioValido = this.usuarioValido;
            frm.ShowDialog();
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            FrmUploadEntryList frm = new FrmUploadEntryList();
            //frm.usuarioValido = this.usuarioValido;
            frm.ShowDialog();
        }

        private void btnSplit_Click(object sender, EventArgs e)
        {
            FrmSplit frm = new FrmSplit();
            //frm.usuarioValido = this.usuarioValido;
            frm.ShowDialog();
        }

        private void btnFloracion_Click(object sender, EventArgs e)
        {
            FrmFloracion frm = new FrmFloracion();
            frm.usuarioValido = this.usuarioValido;
            frm.ShowDialog();
        }
    }
}
