using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UX1.Layers;
using Kardex.Layers;
using UX1.Validaciones;

namespace UX1
{
    public partial class frmAltaMaestro : Form
    {
        KeyPressValidation kpv = new KeyPressValidation();
        BL bl = new BL();
        private bool nonNumberEntered = false;
        public frmAltaMaestro()
        {
            InitializeComponent();
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            string maestro = txtMaestro.Text.ToString().Trim();
            string direccion = txtDireccion.Text.ToString().Trim();
            string telefono = txtTelefono.Text.ToString().Trim();


            bl.AltaMaestro(maestro, direccion, telefono);

            txtMaestro.Text = String.Empty;
            txtDireccion.Text = String.Empty;
            txtTelefono.Text = String.Empty;

        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Checa bandera de metodo descrito abajo
            if (nonNumberEntered == true)
            {
                // Evita que el caracter se escriba con el evento.
                e.Handled = true;
            }
        }

        private void txtTelefono_KeyDown(object sender, KeyEventArgs e)
        {
            nonNumberEntered = false;

            // Tecla presionada corresponde a KEYS en la parte superior
            if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
            {
                // Tecla presionada en el KEYPAD de la derecha
                if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                {
                    // Tecla presionada es BACKSPACE
                    if (e.KeyCode != Keys.Back)
                    {
                        //Bandera a Verdadero para evaluar
                        nonNumberEntered = true;
                    }
                }
            }
            //Si SHIFT fue presionado, no es una numero

            if (Control.ModifierKeys == Keys.Shift)
            {
                nonNumberEntered = true;
            }
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
