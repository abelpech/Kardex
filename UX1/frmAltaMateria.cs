using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Kardex;
using Kardex.Layers;

namespace UX1
{
    public partial class frmAltaMateria : Form
    {
        BL bl = new BL();
        public frmAltaMateria()
        {
            InitializeComponent();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            string materia = txtMateria.Text.ToString().Trim();
            

            //Validacion para TextBox vacio.

            if(txtMateria.Text == "")
            {
                MessageBox.Show("Favor de ingresar dato solicitado", "Advertencia", MessageBoxButtons.OK);
            }
            else
            {
                bl.AltaMateria(materia);
                txtMateria.Text = String.Empty;
            }
            
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
