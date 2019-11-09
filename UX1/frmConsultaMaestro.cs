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
    public partial class frmConsultaMaestro : Form
    {
        BL bl = new BL();
        public frmConsultaMaestro()
        {
            InitializeComponent();
        }

        private void BtnConsulta_Click(object sender, EventArgs e)
        {
            int matricula;
            try
            {
                matricula = Convert.ToInt32(txtMatricula.Text);
            }
            catch
            {
                matricula = 0;
            }
            
            string maestro = txtMaestro.Text;
            bool estatus = false;

            //Establece el status activo o inactivo
            if (comboEstatus.SelectedIndex == 0)
                estatus = true;
            else if(comboEstatus.SelectedIndex == 1)
                estatus = false;


            if ((comboEstatus.SelectedIndex == 0 || comboEstatus.SelectedIndex == 1))
            {

                DataTable dt = bl.ConsultaMaestro(matricula, maestro, estatus);
                if (dt.Rows.Count > 0)
                {
                    dgvCarrera.DataSource = dt;
                    //No permitir agregar datos adicionales
                    dgvCarrera.AllowUserToAddRows = false;
                }
                else
                {
                    MessageBox.Show("No hay maestros activos con los datos especificados", "Aviso", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("Favor de especificar el Maestro y/o seleccionar un tipo de ESTATUS", "Aviso", MessageBoxButtons.OK);
            }

        }
    }
}
