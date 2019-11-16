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
    public partial class frmModificaMaestro : Form
    {
        BL bl = new BL();
        public frmModificaMaestro()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            int matricula = Convert.ToInt32(nudMatricula.Value);
            string maestro = txtMaestro.Text;
            string direccion = txtDireccion.Text;
            string telefono = txtTelefono.Text;
            bool estatus = false;


            if (cbEstatus.SelectedIndex == 0)
            {
                estatus = true;
            }
            else
                estatus = false;

            //validacion campos vacios, nulos o espacios en blanco
            if (nudMatricula.Value ==0 || !(cbEstatus.SelectedIndex == 0 || cbEstatus.SelectedIndex == 1) || txtMaestro.Text =="")
            {
                MessageBox.Show("Favor de ingresar la Matricula, Maestro Y/O Estatus correctos", "Advertencia", MessageBoxButtons.OK);
            }
            else
            {
                bl.ModificaMaestro(matricula, maestro, direccion, telefono, estatus);
                nudMatricula.Value = 0;
                txtMaestro.Text = String.Empty;
                txtDireccion.Text = String.Empty;
                txtTelefono.Text = String.Empty;
                cbEstatus.SelectedIndex = -1;
            }
            
        }

        private void nudMatricula_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
