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

namespace UX1
{
    public partial class frmBajaMaestro : Form
    {
        BL bl = new BL();
        public frmBajaMaestro()
        {
            InitializeComponent();
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            int matricula = Convert.ToInt32(nudMatricula.Value);
            string maestro = txtMaestro.Text.ToString().Trim();
            
            bl.BajaMaestro(matricula, maestro);
        }

        private void nudMatricula_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Evita escribir el caracter si este es diferente a las teclas de control
            // o a algun numero
            if (!char.IsControl(e.KeyChar) && isNumeroValido(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        public bool isNumeroValido(Char c)
        {
            //Regresa verdadero si el caracter es diferente de los numeros entre 0 a 9
            if (!(c >= '0' && c <= '9'))
            {
                return true;
            }
            return false;
        }


    }
}
