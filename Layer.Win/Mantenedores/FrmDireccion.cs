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

namespace Layer.Win.Mantenedores
{
    public partial class FrmDireccion : Form
    {
        #region -----Declaraciones-----
        public Usuario usuarioValido { get; set; }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
        List<InfoShipping> data = new List<InfoShipping>();
        int rowIndex = 0;
        Pais countrySelected = new Pais();
        #endregion

        #region -----Constructores-----
        public FrmDireccion()
        {
            InitializeComponent();
        }
        #endregion

        #region -----Eventos-----
        private void FrmDireccion_Load(object sender, EventArgs e)
        {
            ConfiguraFormulario();
        }

        private void FrmDireccion_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void GrdDirecciones_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                DataGridViewCell cell = grdDirecciones[e.ColumnIndex, e.RowIndex];
                grdDirecciones.CurrentCell = cell;
                grdDirecciones.BeginEdit(true);
            }
        }

        private void GrdDirecciones_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var id = (grdDirecciones[0, e.RowIndex].Value).ToString();
            var info = InfoShippingBusiness.GetInfoById(int.Parse(id));
            int columna = e.ColumnIndex;
            string valor = (grdDirecciones[columna, e.RowIndex].Value).ToString();

            switch (columna)
            {
                case 5:
                    info.address = valor;
                    break;
                case 7:
                    info.contact = valor;
                    break;
                case 8:
                    info.email = valor;
                    break;
                case 9:
                    info.phone = valor;
                    break;
                default:
                    break;
            }

            try
            {
                InfoShippingBusiness.GrabaDatos(info);
                MessageBox.Show("Registro Modificado!", "Mantención Info Shipping", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Al Modificar: " + ex.Message, "Mantención Info Shipping", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            AgregarFila();
        }

        private void GrdDirecciones_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            //if (e.Button == MouseButtons.Right)
            //{
            //    this.grdDirecciones.Rows[e.RowIndex].Selected = true;
            //    this.rowIndex = e.RowIndex;
            //    this.grdDirecciones.CurrentCell = this.grdDirecciones.Rows[e.RowIndex].Cells[1];
            //    this.ctxMenu.Show(this.grdDirecciones, e.Location);
            //    ctxMenu.Show(Cursor.Position);
            //}
        }

        private void EliminarFilaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!this.grdDirecciones.Rows[this.rowIndex].IsNewRow)
            {
                data.RemoveAt(this.rowIndex);
                grdDirecciones.DataSource = null;
                grdDirecciones.DataSource = data;
            }
        }

        private void BtnAgregar_Click_1(object sender, EventArgs e)
        {
            pblNuevo.Visible = !pblNuevo.Visible;
            txtShipTo.Focus();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            pblNuevo.Visible = false;
        }

        private void BtnGrabar_Click(object sender, EventArgs e)
        {
            string resultado = ValidarFormulario();

            if (resultado == "")
            {
                GrabaRegistro();
                MessageBox.Show("Registro Creado Correctamente!", "Mantención Info Shipping", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            else
            {
                MessageBox.Show("Debe Ingresar Los Siguientes Datos: " + Environment.NewLine + Environment.NewLine + resultado, "Mantención Info Shipping", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            }
        }

        private void CboCountry_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboCountry.SelectedItem != null)
            {
                countrySelected = (Pais)cboCountry.SelectedItem;
                if (countrySelected.Id < 0)
                {
                    countrySelected = null;
                }
            }
        }
        #endregion

        #region -----Funciones-----
        private void ConfiguraFormulario()
        {
            DataGridViewCellStyle style = grdDirecciones.ColumnHeadersDefaultCellStyle;
            style.Font = new Font(grdDirecciones.Font.FontFamily, 9.75F, FontStyle.Bold);
            LlenaGrilla();
            LlenaComboCountry();
        }

        private void LlenaGrilla()
        {
            data = InfoShippingBusiness.GetInfoByEmpresa(usuarioValido.id_empresa);
            grdDirecciones.AutoGenerateColumns = false;
            grdDirecciones.DataSource = data;
            grdDirecciones.ClearSelection();
        }

        private void LlenaComboCountry()
        {
            var data = PaisBusiness.GetPais(usuarioValido.id_empresa);
            cboCountry.ValueMember = "Id";
            cboCountry.DisplayMember = "Nombre";
            cboCountry.DataSource = data;
        }

        private void AgregarFila()
        {
            data.Insert(data.Count(), new InfoShipping { });
            grdDirecciones.AutoGenerateColumns = false;
            grdDirecciones.DataSource = null;
            grdDirecciones.DataSource = data;
            grdDirecciones.Refresh();
            grdDirecciones.CurrentCell = grdDirecciones.Rows[data.Count() - 1].Cells[1];

        }

        private void GrabaRegistro()
        {
            try
            {
                if (countrySelected == null || countrySelected.Id == 0)
                {
                    GrabaPais();
                }

                var newItem = new InfoShipping
                {
                    address = txtAddress.Text.ToUpper(),
                    city = txtCity.Text.ToUpper(),
                    client = txtClient.Text.ToUpper(),
                    contact = txtContact.Text.ToUpper(),
                    country = countrySelected.Nombre,
                    email = txtEmail.Text.ToUpper(),
                    id_empresa = usuarioValido.id_empresa,
                    phone = txtPhone.Text.ToUpper(),
                    shipTo = txtShipTo.Text.ToUpper(),
                    state = txtState.Text.ToUpper(),
                    zipcode = txtZipCode.Text.ToUpper()
                };
                InfoShippingBusiness.GrabaDatos(newItem);
                LimpiarFormulario();
                LlenaGrilla();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private string ValidarFormulario()
        {
            StringBuilder resultado = new StringBuilder();

            if (countrySelected == null)
            {
                resultado.Append("- Country");
                resultado.Append(Environment.NewLine);
            }
            if (txtShipTo.Text == "")
            {
                resultado.Append("- Ship To");
                resultado.Append(Environment.NewLine);
            }
            if (txtState.Text == "")
            {
                resultado.Append("- State");
                resultado.Append(Environment.NewLine);
            }
            if (txtCity.Text == "")
            {
                resultado.Append("- City");
                resultado.Append(Environment.NewLine);
            }
            if (txtAddress.Text == "")
            {
                resultado.Append("- Address");
                resultado.Append(Environment.NewLine);
            }
            if (txtZipCode.Text == "")
            {
                resultado.Append("- ZipCode");
                resultado.Append(Environment.NewLine);
            }
            if (txtContact.Text == "")
            {
                resultado.Append("- Contact");
                resultado.Append(Environment.NewLine);
            }
            if (txtClient.Text == "")
            {
                resultado.Append("- Client");
                resultado.Append(Environment.NewLine);
            }
            return resultado.ToString();
        }

        private void GrabaPais()
        {
            countrySelected = new Pais
            {
                id_empresa = usuarioValido.id_empresa,
                FechaCarga = DateTime.Now,
                Nombre = cboCountry.Text.ToUpper(),
                UsuarioCarga = usuarioValido.nombre_usuario,
                Codigo = cboCountry.Text.Substring(0,3).ToUpper()
            };
            PaisBusiness.Insert(countrySelected);
        }

        private void LimpiarFormulario()
        {
            txtShipTo.Text = "";
            cboCountry.SelectedIndex = -1;
            txtState.Text = "";
            txtCity.Text = "";
            txtAddress.Text = "";
            txtClient.Text = "";
            txtContact.Text = "";
            txtEmail.Text = "";
            txtPhone.Text = "";
            txtZipCode.Text = "";
            pblNuevo.Visible = false;
        } 
        #endregion
    }
}
