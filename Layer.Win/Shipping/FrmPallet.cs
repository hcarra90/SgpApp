using Layer.Business;
using Layer.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Layer.Win.Shipping
{
    public partial class FrmPallet : Form
    {
        #region Declaración

        #endregion

        #region Constructor

        #endregion

        public FrmPallet()
        {
            InitializeComponent();
        }

        #region Eventos
        private void FrmPallet_Load(object sender, EventArgs e)
        {
            ConfiguraFormulario();
        }
        #endregion

        #region Métodos Públicos
        public void ConfiguraFormulario()
        {
            DataGridViewCellStyle style = grdPallet.ColumnHeadersDefaultCellStyle;
            style.Font = new Font(grdPallet.Font.FontFamily, 9.75F, FontStyle.Bold);

            ToolTip toolTip1 = new ToolTip
            {
                ShowAlways = true
            };
            toolTip1.SetToolTip(btnCrear, "Crear Nuevo Pallet");

            txtCodigo.Focus();
        }
        #endregion

        private void btnCrear_Click(object sender, EventArgs e)
        {
            CrearPallet();
        }

        private void CrearPallet()
        {
            if (txtCodigo.Text =="")
            {
                MessageBox.Show("Debe Ingresar Código De Pallet", "Creación De Pallet", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }
            else if (txtPeso.Text == "" || !(txtPeso.Text.IsNumeric()))
            {
                MessageBox.Show("Peso No Válido", "Creación De Pallet", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }

            var pallet = new Pallet
            {
                Codigo = txtCodigo.Text,
                FechaCarga = DateTime.Now,
                Peso = decimal.Parse(txtPeso.Text)
            };

            PalletBusiness.Insert(pallet);
        }
    }
}
