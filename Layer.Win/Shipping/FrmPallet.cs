using Layer.Business;
using Layer.Entity;
using Layer.Entity.Dto;
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

namespace Layer.Win.Shipping
{
    public partial class FrmPallet : Form
    {
        #region -----Declaración-----
        public Usuario usuarioValido { get; set; }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
        ListaComboDto tipoSelected = new ListaComboDto();
        EnvaseSecuenciaDto secuencia = new EnvaseSecuenciaDto();
        #endregion

        #region -----Constructor-----

        public FrmPallet()
        {
            InitializeComponent();
        }

        #endregion
        
        #region -----Eventos-----

        private void FrmPallet_Load(object sender, EventArgs e)
        {
            ConfiguraFormulario();
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }
        private void BtnCrear_Click(object sender, EventArgs e)
        {
            CrearPallet();
        }
        private void FrmPallet_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void CboTipo_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboTipo.SelectedItem != null)
            {
                tipoSelected = (ListaComboDto)cboTipo.SelectedItem;

                if (tipoSelected.Valor > 0)
                {
                    secuencia = PalletBusiness.GetSecuenciaPallet(usuarioValido.id_empresa, tipoSelected.Valor);
                    txtCodigo.Text = tipoSelected.Nombre + secuencia.CodigoNum;
                    txtMaterial.Focus();
                }
                else
                {
                    secuencia = null;
                    tipoSelected = null;
                    txtCodigo.Text = "";
                }
            }
        }
        private void GrdPallet_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int currentMouseOverRow = grdPallet.HitTest(e.X, e.Y).RowIndex;
                ctxShipment.Show(grdPallet, new Point(e.X, e.Y));
            }
        }
        private void BorrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var obj = BuscaEnvase();
            var id = Convert.ToInt32(obj.Cells["Id"].Value);
            var envase = Convert.ToString(obj.Cells["Envase"].Value);
            var count = ShipmentBusiness.GetCajasByEnvase(envase).Count;
            if (count > 0)
            {
                MessageBox.Show("Envase posee cajas asignadas, imposible eliminar!", "Módulo Pallet", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }

            BorrarEnvase(id);
            LlenaGrilla();
            ActualizaPalletsBultos();
        }

        #endregion

        #region -----Métodos Públicos-----

        public void ConfiguraFormulario()
        {
            DataGridViewCellStyle style = grdPallet.ColumnHeadersDefaultCellStyle;
            style.Font = new Font(grdPallet.Font.FontFamily, 9.75F, FontStyle.Bold);

            ToolTip toolTip1 = new ToolTip
            {
                ShowAlways = true
            };
            toolTip1.SetToolTip(btnCrear, "Crear Nuevo Pallet");
            LlenaGrilla();
            LlenaComboTipo();
            txtCodigo.Focus();
        }
        private void CrearPallet()
        {
            if (txtCodigo.Text == "")
            {
                MessageBox.Show("Debe Ingresar Código De Pallet", "Creación De Pallet", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }
            else if (txtPeso.Text == "" || !(txtPeso.Text.IsNumeric()))
            {
                MessageBox.Show("Peso No Válido", "Creación De Pallet", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }
            else if (txtMedida.Text == "")
            {
                MessageBox.Show("Medidas No Válidas", "Creación De Pallet", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }
            else if (txtMaterial.Text == "")
            {
                MessageBox.Show("Materiales No Válidos", "Creación De Pallet", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }
            var pallet = new Pallet
            {
                Codigo = txtCodigo.Text,
                FechaCarga = DateTime.Now,
                Peso = decimal.Parse(txtPeso.Text),
                Material = txtMaterial.Text,
                Medidas = txtMedida.Text,
                id_empresa = usuarioValido.id_empresa,
                Secuencia = secuencia.Secuencia,
                Tipo = tipoSelected.Valor
            };

            try
            {
                PalletBusiness.Insert(pallet);
                ActualizaPalletsBultos();
                MessageBox.Show("Pallet-Bulto Creado!", "Creación De Pallet", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                LlenaGrilla();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Creación De Pallet", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            }
        }
        private void ActualizaPalletsBultos()
        {
            FrmEnvioCaja frm = (FrmEnvioCaja)Application.OpenForms["FrmEnvioCaja"];
            Panel pnl = (Panel)frm.Controls["pnlEmail"];
            ComboBox cb = (ComboBox)pnl.Controls["cboPallet"];

            //Pallets
            var data = PalletBusiness.GetPallet(usuarioValido.id_empresa,false);
            var filtrado = data.Where(p => p.Tipo == 1).ToList();
            cb.ValueMember = "Codigo";
            cb.DisplayMember = "Codigo";
            cb.DataSource = filtrado;

            //Bultos
            cb = (ComboBox)pnl.Controls["cboBulto"];
            filtrado = data.Where(p => p.Tipo == 2).ToList();
            filtrado.Insert(0, new Pallet { Codigo = "" });
            cb.ValueMember = "Codigo";
            cb.DisplayMember = "Codigo";
            cb.DataSource = filtrado;
        }
        private void LlenaGrilla()
        {
            var items = PalletBusiness.GetPallet(usuarioValido.id_empresa,true);
            grdPallet.AutoGenerateColumns = false;
            grdPallet.DataSource = items;
        }
        private void LlenaComboTipo()
        {
            var data = DataFunctions.GetTipoEnvase();
            cboTipo.ValueMember = "Valor";
            cboTipo.DisplayMember = "Nombre";
            cboTipo.DataSource = data;
        }
        private DataGridViewRow BuscaEnvase()
        {
            if (grdPallet.SelectedCells.Count > 0)
            {
                int selectedrowindex = grdPallet.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = grdPallet.Rows[selectedrowindex];
                return selectedRow;
            }

            return null;
        }
        private void BorrarEnvase(int id)
        {
            TransactionalInformation transaccion = new TransactionalInformation();
            PalletBusiness.Borrar(id, out transaccion);

            if (!transaccion.ReturnStatus)
            {
                MessageBox.Show("Error: " + transaccion.ReturnMessage, "Módulo Pallet", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        #endregion
    }
}
