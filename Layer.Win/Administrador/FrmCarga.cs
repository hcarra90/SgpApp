using Layer.Entity;
using Layer.Functions;
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

namespace Layer.Win.Administrador
{
    public partial class FrmCarga : Form
    {
        public Usuario usuarioValido { get; set; }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private List<InfoFieldBook> datos = new List<InfoFieldBook>();
        string pathFile = "";

        public FrmCarga()
        {
            InitializeComponent();
        }

        private void FrmCarga_Load(object sender, EventArgs e)
        {
            DataGridViewCellStyle style = dataRows.ColumnHeadersDefaultCellStyle;
            style.Font = new Font(dataRows.Font.FontFamily, 8.75F, FontStyle.Regular);
        }

        private void FrmCarga_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);

            ToolTip toolTip1 = new ToolTip();
            toolTip1.ShowAlways = true;
            toolTip1.SetToolTip(btnFile, "Cargar Datos");
            toolTip1.SetToolTip(btnProceso, "Procesar Datos");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CargaArchivo();
        }

        private void CargaArchivo()
        {
            
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "xlsx files (*.xlsx)|*.xlsx";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pathFile = openFileDialog.FileName;
                lblFile.Text = pathFile;
            }

            if (pathFile != "")
            {
                datos = FuncionesExcel.GetData(pathFile);
                dataRows.AutoGenerateColumns = true;
                dataRows.DataSource = datos;
                dataRows.ClearSelection();
                lblRows.Text = "N° Filas : " + dataRows.RowCount.ToString();
            }
        }

        private void pctFile_Click(object sender, EventArgs e)
        {
            CargaArchivo();
        }

        private void btnProceso_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            ProcesaDatos();
            LimpiarFormulario();
        }

        private void ProcesaDatos()
        {
            if (datos.Count > 0)
            {
                string mensaje = "";

                var resultado = FuncionesExcel.SaveExcelData(datos);
                lblTotalFilas.Text = resultado.TotalRows.ToString();
                lblModificadas.Text = resultado.NumeroActualizados.ToString();
                lblInsertadas.Text = resultado.NumeroInsertados.ToString();

                if (resultado.Error != null && resultado.Error != "")
                {
                    mensaje = resultado.Error;
                }
                else
                {
                    mensaje = "Proceso Finalizado!";
                }

                MessageBox.Show(mensaje,"Módulo De Carga", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }

            this.Cursor = Cursors.Default;
        }

        private void LimpiarFormulario()
        {
            lblTotalFilas.Text = "";
            lblModificadas.Text = "";
            lblInsertadas.Text = "";
            lblFile.Text = "";
            pathFile = "";
            datos = null;
            dataRows.DataSource = datos;
        }
    }
}
