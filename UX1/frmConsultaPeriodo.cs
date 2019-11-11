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
using UX1;

namespace Kardex
{
    public partial class frmConsultaPeriodo : Form
    {
        BL bl = new BL();
        Plantilla pl = new Plantilla();

        string data = string.Empty;

        public frmConsultaPeriodo()
        {
            
            InitializeComponent();
        }

        private void TxtCarrera_TextChanged(object sender, EventArgs e)
        {
            
        }
        


        private void BtnConsulta_Click(object sender, EventArgs e)
        {
            string carrera = txtCarrera.Text;

            if (comboEstatus.SelectedIndex == 0 && txtCarrera.Text == "")
            {
                //DataTable dt = bl.ConsultaCarrera("todas", 0);

                DataTable dt = bl.ConsultaCarrera("", 0);
                if (dt.Rows.Count > 0)
                {
                    dgvCarrera.DataSource = dt;
                    //No permitir agregar datos adicionales
                    dgvCarrera.AllowUserToAddRows = false;
                }
                else
                {
                    MessageBox.Show("No hay carreras activas", "Aviso", MessageBoxButtons.OK);
                }
            }
            else if (comboEstatus.SelectedIndex == 1 && txtCarrera.Text == "")
            {
                DataTable dt = bl.ConsultaCarrera("", 1);

                if (dt.Rows.Count > 0)
                {
                    dgvCarrera.DataSource = dt;
                    //No permitir agregar datos adicionales
                    dgvCarrera.AllowUserToAddRows = false;
                }
                else
                {
                    MessageBox.Show("No hay carreras activas", "Aviso", MessageBoxButtons.OK);
                }
            }
            else if (comboEstatus.SelectedIndex == 0 && txtCarrera.Text != "")
            {
                DataTable dt = bl.ConsultaCarrera(carrera, 0);
                if (dt.Rows.Count > 0)
                {
                    dgvCarrera.DataSource = dt;
                    //No permitir agregar datos adicionales
                    dgvCarrera.AllowUserToAddRows = false;
                }
                else
                {
                    MessageBox.Show("No registros con la carrera ingresada", "Aviso", MessageBoxButtons.OK);
                }
            }
            else if (comboEstatus.SelectedIndex == 1 && txtCarrera.Text != "")
            {

                DataTable dt = bl.ConsultaCarrera(carrera, 1);
                if (dt.Rows.Count > 0)
                {
                    dgvCarrera.DataSource = dt;
                    //No permitir agregar datos adicionales
                    dgvCarrera.AllowUserToAddRows = false;
                }
                else
                {
                    MessageBox.Show("No registros con la carrera ingresada", "Aviso", MessageBoxButtons.OK);
                }

            }
            else if (comboEstatus.SelectedIndex == -1 && txtCarrera.Text != "")
            {
                DataTable dt = bl.ConsultaCarrera(carrera, 0);
                if (dt.Rows.Count > 0)
                {
                    dgvCarrera.DataSource = dt;
                    //No permitir agregar datos adicionales
                    dgvCarrera.AllowUserToAddRows = false;
                }
                else
                {
                    MessageBox.Show("No registros con la carrera ingresada", "Aviso", MessageBoxButtons.OK);
                }
            }
            else 
            {
                MessageBox.Show("Favor de especificar la CARRERA y/o seleccionar un tipo de ESTATUS", "Aviso", MessageBoxButtons.OK);
            }
              
            
          
            
        }

      

   

        private void FrmConsultaCarrera_Load(object sender, EventArgs e)
        {
            
            AutoCompleteStringCollection mycollection = new AutoCompleteStringCollection();
            mycollection = bl.AutoCarrera();
            txtCarrera.AutoCompleteCustomSource = mycollection;
          
        }

        private void dgvCarrera_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenu m = new ContextMenu();

                MenuItem menuItem1 = new MenuItem();
                MenuItem menuItem2 = new MenuItem();
                MenuItem menuItem3 = new MenuItem();
                if (comboEstatus.SelectedIndex == 0)
                {
                    menuItem1.Text = "Baja";
                    menuItem2.Text = "Modifica";

                    m.MenuItems.Add(menuItem1);
                    m.MenuItems.Add(menuItem2);

                    menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
                    menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
                }
                else if (comboEstatus.SelectedIndex == 1)
                {
                    menuItem3.Text = "Reactivar";
                    menuItem2.Text = "Modifica";

                    m.MenuItems.Add(menuItem3);
                    m.MenuItems.Add(menuItem2);

                    menuItem3.Click += new System.EventHandler(this.menuItem3_Click);
                    menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
                }
                
                
                m.Show(dgvCarrera, new Point(e.X, e.Y));
            }
        }

        private void dgvCarrera_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                data = dgvCarrera["Carrera", e.RowIndex].Value.ToString();
                //MessageBox.Show(data);
            }
            catch (Exception ex)
            {

            }
            
            //MessageBox.Show(data);

        }

        private void menuItem1_Click(object sender, System.EventArgs e)
        {

            bl.BajaCarrera(data);
            BtnConsulta_Click(sender, e);
            data = "";

        }

        private void menuItem2_Click(object sender, System.EventArgs e)
        {
            // MessageBox.Show("Modifica");
            //pl.BtnModificacionCarrera_Click(sender, e);
            frmModificaCarrera baja = new frmModificaCarrera(data);
            baja.Show();
            data = "";
        }

        private void menuItem3_Click(object sender, System.EventArgs e)
        {
            //MessageBox.Show(data);
            bl.ModificaCarrera(data, data, true);
            BtnConsulta_Click(sender, e);
            data = "";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtCarrera.Text = "";
            comboEstatus.SelectedIndex = -1;
            DataTable dt = bl.ConsultaCarrera("",0);

            if (dt.Rows.Count > 0)
            {
                dgvCarrera.DataSource = dt;
                dt.Rows.Clear();
            }
        }

       
    }
}
