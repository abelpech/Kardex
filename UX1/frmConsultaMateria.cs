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
    public partial class frmConsultaMateria : Form
    {
        BL bl = new BL();
        string data = string.Empty;

        public frmConsultaMateria()
        {
            InitializeComponent();
        }

        /*Codigo comentado para evitar conflicto de codigo con comboBox 
         * 
        private void CbTodas_CheckedChanged(object sender, EventArgs e)
        {
            if (cbTodas.Checked == true)
            {
                txtMateria.Enabled = false;
                cbInactivos.Enabled = false;
            }
            else
            {
                txtMateria.Enabled = true;
                cbInactivos.Enabled = true;
            }

        }
        */
        private void BtnConsulta_Click(object sender, EventArgs e)
        {
            string materia = txtMateria.Text.Trim();

            if (comboEstatus.SelectedIndex == 0 && txtMateria.Text == "")
            {
                //DataTable dt = bl.ConsultaCarrera("todas", 0);

                DataTable dt = bl.ConsultaMateria("", 0);
                if (dt.Rows.Count > 0)
                {
                    dgvCarrera.DataSource = dt;
                    //No permitir agregar datos adicionales
                    dgvCarrera.AllowUserToAddRows = false;
                }
                else
                {
                    MessageBox.Show("No hay materias activas", "Aviso", MessageBoxButtons.OK);
                }
            }
            else if (comboEstatus.SelectedIndex == 1 && txtMateria.Text == "")
            {
                DataTable dt = bl.ConsultaMateria("", 1);

                if (dt.Rows.Count > 0)
                {
                    dgvCarrera.DataSource = dt;
                    //No permitir agregar datos adicionales
                    dgvCarrera.AllowUserToAddRows = false;
                }
                else
                {
                    MessageBox.Show("No hay materias activas", "Aviso", MessageBoxButtons.OK);
                }
            }
            else if (comboEstatus.SelectedIndex == 0 && txtMateria.Text != "")
            {
                DataTable dt = bl.ConsultaMateria(materia, 0);
                if (dt.Rows.Count > 0)
                {
                    dgvCarrera.DataSource = dt;
                    //No permitir agregar datos adicionales
                    dgvCarrera.AllowUserToAddRows = false;
                }
                else
                {
                    MessageBox.Show("No registros con la materia ingresada", "Aviso", MessageBoxButtons.OK);
                }
            }
            else if (comboEstatus.SelectedIndex == 1 && txtMateria.Text != "")
            {

                DataTable dt = bl.ConsultaMateria(materia, 1);
                if (dt.Rows.Count > 0)
                {
                    dgvCarrera.DataSource = dt;
                    //No permitir agregar datos adicionales
                    dgvCarrera.AllowUserToAddRows = false;
                }
                else
                {
                    MessageBox.Show("No registros con la materia ingresada", "Aviso", MessageBoxButtons.OK);
                }

            }
            else if (comboEstatus.SelectedIndex == -1 && txtMateria.Text != "")
            {
                DataTable dt = bl.ConsultaMateria(materia, 0);
                if (dt.Rows.Count > 0)
                {
                    dgvCarrera.DataSource = dt;
                    //No permitir agregar datos adicionales
                    dgvCarrera.AllowUserToAddRows = false;
                }
                else
                {
                    MessageBox.Show("No registros con la materia ingresada", "Aviso", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("Favor de especificar la MATERIA y/o seleccionar un tipo de ESTATUS", "Aviso", MessageBoxButtons.OK);
            }
            txtMateria.Text = materia;
        }

        private void FrmConsultaMateria_Load(object sender, EventArgs e)
        {
            AutoCompleteStringCollection mycollection = new AutoCompleteStringCollection();
            mycollection = bl.AutoMateria();
            txtMateria.AutoCompleteCustomSource = mycollection;


        }

        /*Codigo comentado para evitar conflicto de codigo con comboBox 
        private void cbInactivos_CheckedChanged(object sender, EventArgs e)
        {
            if (cbInactivos.Checked == true)
            {
                txtMateria.Enabled = false;
                cbTodas.Enabled = false;
            }
            else
            {
                txtMateria.Enabled = true;
                cbTodas.Enabled = true;
            }
            //BtnConsulta_Click(sender, e);
        }
        */

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

                /*
                int currentMouseOverRow = dgvCarrera.HitTest(e.X, e.Y).RowIndex;
                m.GetContextMenu();

                if (currentMouseOverRow == 0)
                {
                    txtCarrera.Text = data;
                   
                }
                */
                m.Show(dgvCarrera, new Point(e.X, e.Y));
            }
        }

        private void dgvCarrera_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                data = dgvCarrera["Materia", e.RowIndex].Value.ToString();
                //MessageBox.Show(data);
            }
            catch (Exception ex)
            {

            }

            //MessageBox.Show(data);

        }

        private void menuItem1_Click(object sender, System.EventArgs e)
        {

            bl.BajaMateria(data);
            BtnConsulta_Click(sender, e);
            data = "";

        }

        private void menuItem2_Click(object sender, System.EventArgs e)
        {
            // MessageBox.Show("Modifica");
            //pl.BtnModificacionCarrera_Click(sender, e);
            frmModificaMateria baja = new frmModificaMateria(data);
            baja.Show();
            data = "";
        }

        private void menuItem3_Click(object sender, System.EventArgs e)
        {
            //MessageBox.Show(data);
            bl.ModificaMateria(data, data, true);
            BtnConsulta_Click(sender, e);
            data = "";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtMateria.Text = "";
            comboEstatus.SelectedIndex = -1;
            DataTable dt = bl.ConsultaMateria("", 0);

            if (dt.Rows.Count > 0)
            {
                dgvCarrera.DataSource = dt;
                dt.Rows.Clear();
            }
        }

        /*Codigo comentado para evitar conflicto de codigo con comboBox 
        private void cbInactivos_Click(object sender, EventArgs e)
        {
            if (cbInactivos.Checked == false)
            {
                DataTable dt = bl.ConsultaMateria("todas");

                if (dt.Rows.Count > 0)
                {
                    dgvCarrera.DataSource = dt;
                    dt.Rows.Clear();
                }
            }
        }

        private void cbTodas_Click(object sender, EventArgs e)
        {
            if (cbTodas.Checked == false)
            {
                DataTable dt = bl.ConsultaMateria("todas");

                if (dt.Rows.Count > 0)
                {
                    dgvCarrera.DataSource = dt;
                    dt.Rows.Clear();
                }
            }
        }
        */
    }
}
