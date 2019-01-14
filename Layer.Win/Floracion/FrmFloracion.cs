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

namespace Layer.Win.Floracion
{
    public partial class FrmFloracion : Form
    {
        #region -----Declaración-----
        public Usuario usuarioValido { get; set; }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
        Nota NotaSeleccionada = new Nota();
        #endregion

        #region -----Constructor-----
        public FrmFloracion()
        {
            InitializeComponent();
        } 
        #endregion
                
        #region -----Funciones-----
        private void ConfiguraFormulario()
        {
            DataGridViewCellStyle style = grdDetalle.ColumnHeadersDefaultCellStyle;
            style.Font = new Font(grdDetalle.Font.FontFamily, 14.25F, FontStyle.Bold);
            dtpFechaNota.Value = DateTime.Now;
            LlenaCombo();
            txtEuid.Focus();
        }

        private void LlenaCombo()
        {
            var data = NotaBusiness.GetNotas(1);
            cboNota.DisplayMember = "Nombre";
            cboNota.ValueMember = "Id";
            cboNota.DataSource = data;
        }

        private void GrabaInformacion(int tipo)
        {
            if (tipo == 1)
            {
                var movFlora = new MovimientoFloracion();
                movFlora.Euid = txtEuid.Text;
                movFlora.Fecha = dtpFechaNota.Value + DateTime.Now.TimeOfDay;
                movFlora.id_nota = (int)cboNota.SelectedValue;
                movFlora.Usuario = usuarioValido.nombre_usuario;
               
                MovimientoFloracionBusiness.Insert(movFlora);
            }
            else if(tipo == 2)
            {

            }
        }
        #endregion

        #region -----Eventos-----
        private void FrmFloracion_Load(object sender, EventArgs e)
        {
            ConfiguraFormulario();
        }

        private void cboNota_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboNota.SelectedItem != null)
            {
                if (((Nota)cboNota.SelectedItem).Id > 0)
                {
                    NotaSeleccionada = (Nota)cboNota.SelectedItem;
                    txtEuid.Focus();
                }
            }
        }

        private void txtEuid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                //var Euid = EntryList.GetBin(txtBin.Text.ToUpper()); ;
                if (txtEuid.Text.Trim() != "" && NotaSeleccionada != null)
                {
                    GrabaInformacion(1);
                }
                else
                {
                    MessageBox.Show("Datos Inválidos", "Módulo Floración", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                    txtEuid.Text = "";
                    txtEuid.Focus();
                }
            }
        }
        #endregion
        
    }
}
