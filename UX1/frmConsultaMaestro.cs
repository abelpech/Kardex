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
            String maestro = txtMaestro.Text.ToString();
            
            int matricula = 0;
            if (cbTodos.Checked == true)
            {

                if (txtMatricula.Text == "")
                {
                    MessageBox.Show("Favor de especificar la matricula del maestro");
                }
                else
                {
                    try
                    {
                        matricula = Convert.ToInt32(txtMatricula.Text);


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("¡El campo de matricula solo debe contener numeros!", "Alerta", MessageBoxButtons.OK);
                    }
                    DataTable dt = bl.ConsultaMaestro(matricula, maestro);
                    if (dt.Rows.Count > 0)
                    {
                        dgvCarrera.DataSource = dt;
                        //No permitir agregar datos adicionales
                        dgvCarrera.AllowUserToAddRows = false;
                    }
                    else
                    {
                        MessageBox.Show("No hay registros del maestro ingresado", "Aviso", MessageBoxButtons.OK);
                    }
                }


            }
            else
            {
                matricula = 0;
                //txtMatricula.Text = "";


                //MessageBox.Show("Favor de completar el alumno y la carrera", "Aviso", MessageBoxButtons.OK);
                DataTable dt = bl.ConsultaMaestro(matricula, maestro);
                if (dt.Rows.Count > 0)
                {
                    dgvCarrera.DataSource = dt;
                    //No permitir agregar datos adicionales
                    dgvCarrera.AllowUserToAddRows = false;
                }
                else
                {
                    MessageBox.Show("No registros del maestro ingresado", "Aviso", MessageBoxButtons.OK);
                }

            }
        }
    }
}
