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
    public partial class frmAltaAlumno : Form
    {
        BL bl = new BL();

        private bool nonNumberEntered = false;

        public frmAltaAlumno()
        {
            InitializeComponent();
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            string alumno = txtAlumno.Text.ToString();
            string direccion = txtDireccion.Text.ToString();
            string telefono = txtTelefono.Text.ToString();
            DateTime fechaNac = Convert.ToDateTime(dtpFechaAlta.Value.ToShortDateString());
            string carrera = txtCarrera.Text.ToString();


            bl.AltaAlumno(alumno, direccion, telefono, fechaNac, carrera);

            txtAlumno.Text = String.Empty;
            txtDireccion.Text = String.Empty;
            txtTelefono.Text = String.Empty;
            dtpFechaAlta.ResetText();
            txtCarrera.Text = String.Empty;


        }

        private void TxtTelefono_TextChanged(object sender, EventArgs e)
        {
            string Tel = txtTelefono.Text;
            long parsedValue;
            if (!long.TryParse(Tel, out parsedValue))
            {
                //Tel = Tel.Substring(0, Tel.Length - 1);
                //txtTelefono.Text = Tel;
                if (Tel.Length == 10)
                {
                    if (!long.TryParse(Tel, out parsedValue))
                    {
                        epTelefono.SetError(txtTelefono, "El campo deberia contener solo numeros.");
                    }
                    else
                        epTelefono.Clear();
                }
                else if (Tel.Length == 0)
                {
                    epTelefono.Clear();
                }
                    
                else
                    epTelefono.SetError(txtTelefono, "El campo deberia contener solo numeros.");
                return;
            }
            else
                epTelefono.Clear();
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
    }
}
