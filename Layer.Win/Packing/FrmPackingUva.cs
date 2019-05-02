using Layer.Business;
using Layer.Entity;
using Layer.Entity.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Layer.Win.Packing
{
    public partial class FrmPackingUva : Form
    {
        #region -----Declaración-----
        public Usuario usuarioValido { get; set; }
        ProgramaExport palletSeleccionado = new ProgramaExport();
        List<MovimientoDespachoDto> listaPaso = new List<MovimientoDespachoDto>();
        #endregion

        public FrmPackingUva()
        {
            InitializeComponent();
        }

        private void FrmPackingUva_Load(object sender, EventArgs e)
        {
            LlenaCombo();
            grdCajas.AutoGenerateColumns = false;
        }

        private void LlenaCombo()
        {
            var lista = ProgramaExportBusiness.GetProgramaExport(usuarioValido.id_empresa);
            cboPallet.ValueMember = "Id";
            cboPallet.DisplayMember = "Opcion";
            cboPallet.DataSource = lista;
        }

        private void cboPallet_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboPallet.SelectedItem != null)
            {
                if (((ProgramaExport)cboPallet.SelectedItem).Id > 0)
                {
                    palletSeleccionado = (ProgramaExport)cboPallet.SelectedItem;
                    txtId.Text = palletSeleccionado.IdPallet.ToString();
                    txtEspecie.Text = palletSeleccionado.Especie;
                    txtVariedad.Text = palletSeleccionado.Variedad;
                    txtColor.Text = palletSeleccionado.Color;
                    txtEnvase.Text = palletSeleccionado.Envase;
                    txtEmbalaje.Text = palletSeleccionado.Embalaje;
                    txtPeso.Text = palletSeleccionado.PesoEmbalaje.ToString();
                    txtCalibre.Text = palletSeleccionado.Calibre;
                    txtCajaPallet.Text = palletSeleccionado.CajaPallet;
                    txtIdPallet.Focus();
                }
            }
        }

        private void txtIdPallet_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (txtIdPallet.Text != "")
                {
                    BuscaCaja(int.Parse(txtIdPallet.Text));
                } 
            }
        }

        private void BuscaCaja(int id)
        {
            var data = MovimientoDespachoBusiness.GetMovimientoDespachoById(id);
            if (data !=null)
            {
                data.Fecha = DateTime.Now;
                data.Usuario = usuarioValido.nombre_usuario;

                listaPaso.Add(data);
                grdCajas.DataSource = null;
                grdCajas.DataSource = listaPaso;
                txtIdPallet.Text = "";
                txtIdPallet.Focus();
                ValidaGrilla();
            }
            else
            {
                MessageBox.Show("Data No Existe!");
                txtIdPallet.Text = "";
                txtIdPallet.Focus();
            }
           

        }

        private void ValidaGrilla()
        {
            int invalido = 0;

            //Valido Columna Id
            var num = listaPaso.GroupBy(i => i.IdProgramaExport).ToList().Count();
            if (num == 1)
            {
                lblStatusId.Text = "OK";

            }
            else
            {
                lblStatusId.Text = "NOK";
                lblStatusId.ForeColor = Color.DarkRed;
                invalido++;
            }

            //Valido Columna Especie
            num = listaPaso.GroupBy(i => i.Especie).ToList().Count();
            if (num == 1)
            {
                lblStatusEspecie.Text = "OK";

            }
            else
            {
                lblStatusEspecie.Text = "NOK";
                lblStatusEspecie.ForeColor = Color.DarkRed;
                invalido++;
            }

            //Valido Columna Variedad
            num = listaPaso.GroupBy(i => i.Variedad).ToList().Count();
            if (num == 1)
            {
                lblStatusVariedad.Text = "OK";

            }
            else
            {
                lblStatusVariedad.Text = "NOK";
                lblStatusVariedad.ForeColor = Color.DarkRed;
                invalido++;
            }

            //Valido Columna Color
            num = listaPaso.GroupBy(i => i.Color).ToList().Count();
            if (num == 1)
            {
                lblStatusColor.Text = "OK";

            }
            else
            {
                lblStatusColor.Text = "NOK";
                lblStatusColor.ForeColor = Color.DarkRed;
                invalido++;
            }

            //Valido Columna Envase
            num = listaPaso.GroupBy(i => i.Envase).ToList().Count();
            if (num == 1)
            {
                lblStatusEnvase.Text = "OK";

            }
            else
            {
                lblStatusEnvase.Text = "NOK";
                lblStatusEnvase.ForeColor = Color.DarkRed;
                invalido++;
            }

            //Valido Columna Embalaje
            num = listaPaso.GroupBy(i => i.Embalaje).ToList().Count();
            if (num == 1)
            {
                lblStatusEmbalaje.Text = "OK";

            }
            else
            {
                lblStatusEmbalaje.Text = "NOK";
                lblStatusEmbalaje.ForeColor = Color.DarkRed;
                invalido++;
            }

            //Valido Columna PesoEmbalaje
            num = listaPaso.GroupBy(i => i.PesoEmbalaje).ToList().Count();
            if (num == 1)
            {
                lblStatusPeso.Text = "OK";

            }
            else
            {
                lblStatusPeso.Text = "NOK";
                lblStatusPeso.ForeColor = Color.DarkRed;
                invalido++;
            }

            //Valido Columna Calibre
            num = listaPaso.GroupBy(i => i.Calibre).ToList().Count();
            if (num == 1)
            {
                lblStatusCalibre.Text = "OK";

            }
            else
            {
                lblStatusCalibre.Text = "NOK";
                lblStatusCalibre.ForeColor = Color.DarkRed;
                invalido++;
            }

            //Valido Columna CajaPallet
            num = listaPaso.GroupBy(i => i.CajaPallet).ToList().Count();
            if (num == 1)
            {
                lblStatusCaja.Text = "OK";

            }
            else
            {
                lblStatusCaja.Text = "NOK";
                lblStatusCaja.ForeColor = Color.DarkRed;
                invalido++;
            }

            //Configuración de Botones
            if (lblStatusId.Text=="OK" && lblStatusEspecie.Text=="OK" && lblStatusVariedad.Text == "OK" && lblStatusColor.Text == "OK" 
                && lblStatusEnvase.Text == "OK" && lblStatusEmbalaje.Text=="OK" && lblStatusPeso.Text == "OK" 
                && lblStatusCalibre.Text == "OK" && lblStatusCaja.Text=="OK") 
            {
                btnCrearFolio.Enabled = false;
                btnCrearTarja.Enabled = true;
                btnBorrar.Enabled = true;
            }
            else if (lblStatusId.Text == "OK" && lblStatusEspecie.Text == "OK" && lblStatusVariedad.Text == "OK" && lblStatusColor.Text == "OK"
                && lblStatusEnvase.Text == "OK" && lblStatusEmbalaje.Text == "OK" && lblStatusPeso.Text == "OK"
                && lblStatusCalibre.Text == "OK" && lblStatusCaja.Text == "OK" && lblStatusPeso.Text == "OK" && listaPaso.Count.ToString() == txtCajaPallet.Text)
            {
                btnCrearFolio.Enabled = true;
                btnCrearTarja.Enabled = true;
                btnBorrar.Enabled = true;
            }
            else
            {
                btnCrearFolio.Enabled = false;
                btnCrearTarja.Enabled = false;
                btnBorrar.Enabled = true;
            }

        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            LimpiaCajas();
        }

        private void LimpiaCajas()
        {
            listaPaso = null;
            grdCajas.DataSource = listaPaso;
            lblStatusId.Text = "...";
            lblStatusEspecie.Text = "...";
            lblStatusVariedad.Text = "...";
            lblStatusColor.Text = "...";
            lblStatusEnvase.Text = "...";
            lblStatusEmbalaje.Text = "...";
            lblStatusPeso.Text = "...";
            lblStatusCalibre.Text = "...";
            lblStatusCaja.Text = "...";
            txtIdPallet.Focus();
        }

        private void btnCrearTarja_Click(object sender, EventArgs e)
        {
            CrearTarja();
        }

        private void CrearTarja()
        {
            var res = MovimientoDespachoBusiness.GrabaTarja(listaPaso);
        }

        private void btnCrearFolio_Click(object sender, EventArgs e)
        {
            CrearPallet();
        }

        private void CrearPallet()
        {
            var res = MovimientoDespachoBusiness.GrabaPallet(listaPaso);
        }
    }
}
