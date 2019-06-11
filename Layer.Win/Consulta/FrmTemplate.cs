using Layer.Functions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Layer.Win.Consulta
{
    public partial class FrmTemplate : Form
    {
        public FrmTemplate()
        {
            InitializeComponent();
        }

        private void btnPackingList_Click(object sender, EventArgs e)
        {
            IEnumerable<string> columnas = new List<string>() { "Fecha Envio", "Ship To", "Pallet" };
            List<string[]> titulos = new List<string[]>();

            string[] t1 = new string[]{ "Caja Envio","Euid","Ind Euid","Fecha Packing","Total Weight",
                "Total kernel", "Total Ear","Country","Breeder Code 1", "Breeder Code 2",
                "Breeder Code 3", "Breeder Code 4","Project Lead","Cc","Ship To","Crop" };
            titulos.Add(t1);
            var resultado =FuncionesExcel.CreaTemplate("PackingList",titulos);
        }
    }
}
