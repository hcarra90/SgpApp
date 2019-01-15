using Layer.Business;
using Layer.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
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
            LlenaGrilla();
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
            DateTime fechafinal = new DateTime(dtpFechaNota.Value.Year, dtpFechaNota.Value.Month, dtpFechaNota.Value.Day, dtpFechaNota.Value.Hour, dtpFechaNota.Value.Minute,0);

            var movFlora = new MovimientoFloracion
            {
                Fecha = fechafinal,
                id_nota = (int)cboNota.SelectedValue,
                Usuario = usuarioValido.nombre_usuario
            };

            if (tipo == 1)
            {
                movFlora.Euid = txtEuid.Text;

                MovimientoFloracionBusiness.Insert(movFlora);
                txtEuid.Text = "";
                txtEuid.Focus();
            }
            else if (tipo == 2)
            {
                var euids = EntryListBusiness.GetEuidByJaula(txtJaula.Text, 1);
                MovimientoFloracionBusiness.Insert(euids,movFlora);
                txtJaula.Text = "";
                txtJaula.Focus();
            }
            LlenaGrilla();
        }

        private void LlenaGrilla()
        {
            DateTime fechaInicio= new DateTime(dtpFechaNota.Value.Year, dtpFechaNota.Value.Month, dtpFechaNota.Value.Day, 0, 0, 0);
            DateTime fechaTermino = new DateTime(dtpFechaNota.Value.Year, dtpFechaNota.Value.Month, dtpFechaNota.Value.Day, 23, 59, 59);

            var data = MovimientoFloracionBusiness.GetFloraciones(fechaInicio, fechaTermino);
            grdDetalle.AutoGenerateColumns = false;
            grdDetalle.DataSource = data;
            grdDetalle.ClearSelection();
        }

        private void LimpiarFormulario()
        {
            dtpFechaNota.Value = DateTime.Now;
            txtEuid.Text = "";
            cboNota.SelectedIndex = -1;
            txtJaula.Text = "";
            dtpFechaNota.Focus();
        }

        private void BorrarEuid(int id)
        {
            TransactionalInformation transaction = new TransactionalInformation();
            MovimientoFloracionBusiness.BorrarEuid(id, out transaction);

            if (transaction.ReturnStatus)
            {
                LlenaGrilla();
            }
            else
            {
                MessageBox.Show("Error: " + transaction.ReturnMessage, "Módulo Floración", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
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

        private void txtJaula_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                //var Euid = EntryList.GetBin(txtBin.Text.ToUpper()); ;
                if (txtJaula.Text.Trim() != "" && NotaSeleccionada != null)
                {
                    GrabaInformacion(2);
                }
                else
                {
                    MessageBox.Show("Datos Inválidos", "Módulo Floración", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                    txtJaula.Text = "";
                    txtJaula.Focus();
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }
        #endregion

        private void grdDetalle_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int currentMouseOverRow = grdDetalle.HitTest(e.X, e.Y).RowIndex;
                ctxEuidMenu.Show(grdDetalle, new Point(e.X, e.Y));
            }
        }

        private void borrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (grdDetalle.SelectedCells.Count > 0)
            {
                int selectedrowindex = grdDetalle.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = grdDetalle.Rows[selectedrowindex];
                var id = Convert.ToInt32(selectedRow.Cells["Id"].Value);

                BorrarEuid(id);
            }
        }
    }
}
