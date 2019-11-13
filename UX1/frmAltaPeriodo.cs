using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Kardex.Layers;

namespace Kardex
{
    public partial class frmAltaPeriodo : Form
    {
        BL bl = new BL();
        public frmAltaPeriodo()
        {
            InitializeComponent();
        }

        private void BtnAltaPeriodo_Click(object sender, EventArgs e)
        {
            string anio = Convert.ToString(nudPeriodoAnio.Value);
            string unidad = Convert.ToString(nudPeriodoUnidad.Value);

            if(cbEstatus.SelectedIndex == -1)
            {
                MessageBox.Show("Favor de seleccionar ESTATUS", "Advertencia", MessageBoxButtons.OK);
            }
            else
            {
                bool estatus;

                if (cbEstatus.SelectedIndex == 0)
                {
                    estatus = true;
                }
                else
                {
                    estatus = false;
                }
                bl.AltaPeriodo(anio +"-"+ unidad, estatus);
                nudPeriodoAnio.Value = 2019;
                nudPeriodoUnidad.Value = 1;
                cbEstatus.SelectedIndex = -1;
            }



        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
