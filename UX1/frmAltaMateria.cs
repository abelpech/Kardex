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
using UX1.Validaciones;

namespace UX1
{
    public partial class frmAltaMateria : Form
    {
        KeyPressValidation kpv = new KeyPressValidation();
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

        private void IsNumberPressed(object sender, KeyPressEventArgs e)
        {
            e.Handled = kpv.IsNumber_KeyPress(sender, e);
        }

        private void IsLetterPressed(object sender, KeyPressEventArgs e)
        {
            e.Handled = kpv.IsLetter_KeyPress(sender, e);
        }

        private void IsLetterOrNumberPressed(object sender, KeyPressEventArgs e)
        {
            e.Handled = kpv.IsLetterOrNumber_KeyPress(sender, e);
        }
    }
}
