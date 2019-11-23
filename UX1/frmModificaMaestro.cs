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
using System.Data.SqlClient;


namespace UX1
{
    public partial class frmModificaMaestro : Form
    {
        BL bl = new BL();
        dbConn db = new dbConn();
        public frmModificaMaestro()
        {
            InitializeComponent();
            nudMatricula.Enabled = true;
        }

        public frmModificaMaestro(int matri, string maestrobaja)
        {
            InitializeComponent();
            txtMaestro.Text = maestrobaja;
            nudMatricula.Value = matri;
            DataTable reader = db.getInfo("maestro");
            foreach (DataRow row in reader.Rows)
            {
                if (row["id_maestro"].ToString() == matri.ToString())
                {
                    txtMaestro.Text = row["nombre"].ToString();
                    txtDireccion.Text = row["direccion"].ToString();
                    txtTelefono.Text = row["telefono"].ToString();
                    int estatus = Convert.ToInt32(row["activo"]);
                    if (estatus == 1)
                    {
                        cbEstatus.SelectedIndex = 0;
                    }
                    else
                        cbEstatus.SelectedIndex = 1;
                }
            }
            nudMatricula.Enabled = false;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            int matricula = Convert.ToInt32(nudMatricula.Value);
            string maestro = txtMaestro.Text.Trim();
            string direccion = txtDireccion.Text.Trim();
            string telefono = txtTelefono.Text.Trim();
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
            int maxId = 0;
            DataTable reader = db.getInfo("maestro");
            foreach (DataRow row in reader.Rows)
            {
                if (row["id_maestro"].ToString() == nudMatricula.Value.ToString())
                {
                    txtMaestro.Text = row["nombre"].ToString();
                    txtDireccion.Text = row["direccion"].ToString();
                    txtTelefono.Text = row["telefono"].ToString();
                    int estatus = Convert.ToInt32(row["activo"]);
                    if (estatus == 1)
                    {
                        cbEstatus.SelectedIndex = 0;
                    }
                    else
                        cbEstatus.SelectedIndex = 1;
                }
                maxId = Convert.ToInt32(row["id_maestro"]);
            }
            nudMatricula.Maximum = maxId;
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

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Evita escribir el caracter si este es diferente a las teclas de control
            // o a algun numero
            if (!char.IsControl(e.KeyChar) && isNumeroValido(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
