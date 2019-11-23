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

  
        private void BtnConsulta_Click(object sender, EventArgs e)
        {
            string carrera = txtPeriodo.Text.Trim();

            if (comboEstatus.SelectedIndex == 0 && txtPeriodo.Text == "")
            {
                //DataTable dt = bl.ConsultaCarrera("todas", 0);

                DataTable dt = bl.ConsultaPeriodo("", 0);
                if (dt.Rows.Count > 0)
                {
                    dgvCarrera.DataSource = dt;
                    //No permitir agregar datos adicionales
                    dgvCarrera.AllowUserToAddRows = false;
                }
                else
                {
                    MessageBox.Show("No hay periodos activos", "Aviso", MessageBoxButtons.OK);
                }
            }
            else if (comboEstatus.SelectedIndex == 1 && txtPeriodo.Text == "")
            {
                DataTable dt = bl.ConsultaPeriodo("", 1);

                if (dt.Rows.Count > 0)
                {
                    dgvCarrera.DataSource = dt;
                    //No permitir agregar datos adicionales
                    dgvCarrera.AllowUserToAddRows = false;
                }
                else
                {
                    MessageBox.Show("No hay periodos activos", "Aviso", MessageBoxButtons.OK);

                }
            }
            else if (comboEstatus.SelectedIndex == 0 && txtPeriodo.Text != "")
            {
                DataTable dt = bl.ConsultaPeriodo(carrera, 0);
                if (dt.Rows.Count > 0)
                {
                    dgvCarrera.DataSource = dt;
                    //No permitir agregar datos adicionales
                    dgvCarrera.AllowUserToAddRows = false;
                }
                else
                {
                    MessageBox.Show("No existen registros con el periodo ingresado", "Aviso", MessageBoxButtons.OK);
                }
            }
            else if (comboEstatus.SelectedIndex == 1 && txtPeriodo.Text != "")
            {

                DataTable dt = bl.ConsultaPeriodo(carrera, 1);
                if (dt.Rows.Count > 0)
                {
                    dgvCarrera.DataSource = dt;
                    //No permitir agregar datos adicionales
                    dgvCarrera.AllowUserToAddRows = false;
                }
                else
                {
                    MessageBox.Show("No existen registros con el periodo ingresado", "Aviso", MessageBoxButtons.OK);
                }

            }
            else if (comboEstatus.SelectedIndex == -1 && txtPeriodo.Text != "")
            {
                DataTable dt = bl.ConsultaPeriodo(carrera, 0);
                if (dt.Rows.Count > 0)
                {
                    dgvCarrera.DataSource = dt;
                    //No permitir agregar datos adicionales
                    dgvCarrera.AllowUserToAddRows = false;
                }
                else
                {
                    MessageBox.Show("No existen registros con el periodo ingresado", "Aviso", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("Favor de especificar el PERIODO y/o seleccionar un tipo de ESTATUS", "Aviso", MessageBoxButtons.OK);
            }


            txtPeriodo.Text = carrera;
            
        }


        private void FrmConsultaCarrera_Load(object sender, EventArgs e)
        {
            
            AutoCompleteStringCollection mycollection = new AutoCompleteStringCollection();
            mycollection = bl.AutoPeriodo();
            txtPeriodo.AutoCompleteCustomSource = mycollection;
          
        }

        private void dgvCarrera_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int i = dgvCarrera.CurrentCell.RowIndex;
                dgvCarrera.Rows[i].Selected = true;

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
            /*
            try
            {
                data = dgvCarrera["Periodo", e.RowIndex].Value.ToString();
                //MessageBox.Show(data);
            }
            catch (Exception ex)
            {

            }
            */
            //MessageBox.Show(data);

        }

        private void menuItem1_Click(object sender, System.EventArgs e)
        {

            bl.BajaPeriodo(data);
            BtnConsulta_Click(sender, e);
            data = "";

        }

        private void menuItem2_Click(object sender, System.EventArgs e)
        {
            // MessageBox.Show("Modifica");
            //pl.BtnModificacionCarrera_Click(sender, e);
            frmModificaPeriodo baja = new frmModificaPeriodo(data);
            baja.Show();
            BtnConsulta_Click(sender, e);
            //data = "";
        }

        private void menuItem3_Click(object sender, System.EventArgs e)
        {
            //MessageBox.Show(data);
            bl.ModificaPeriodo(data, data, true);
            BtnConsulta_Click(sender, e);
            data = "";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtPeriodo.Text = "";
            comboEstatus.SelectedIndex = -1;
            DataTable dt = bl.ConsultaPeriodo("",0);

            if (dt.Rows.Count > 0)
            {
                dgvCarrera.DataSource = dt;
                dt.Rows.Clear();
            }
        }

        private void dgvCarrera_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvCarrera.CurrentRow.Index >= 0)
                {
                    //MessageBox.Show(Convert.ToInt32(dgvCarrera.CurrentRow.Index).ToString());
                    data = dgvCarrera["Periodo", Convert.ToInt32(dgvCarrera.CurrentRow.Index)].Value.ToString();

                }


                //MessageBox.Show(data);
            }
            catch (Exception ex)
            {

            }
        }
    }
}
