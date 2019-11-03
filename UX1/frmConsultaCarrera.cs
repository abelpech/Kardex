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
    public partial class frmConsultaCarrera : Form
    {
        SqlConnection conn = new SqlConnection("server = PECH\\SQLEXPRESS; database=kardex ; integrated security = true");
        BL bl = new BL();
        Plantilla pl = new Plantilla();

        string data = string.Empty;

        public frmConsultaCarrera()
        {
            
            InitializeComponent();
        }

        private void TxtCarrera_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void CbTodas_CheckedChanged(object sender, EventArgs e)
        {
            if (cbTodas.Checked == true)
            {
                txtCarrera.Enabled = false;
                cbInactivos.Enabled = false;
            }
            else
            {
                txtCarrera.Enabled = true;
                cbInactivos.Enabled = true;
            }
            
           


        }

        private void BtnConsulta_Click(object sender, EventArgs e)
        {
            if (cbTodas.Checked == true)
            {
                DataTable dt = bl.ConsultaCarrera("todas");

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
            else if (cbInactivos.Checked == true)
            {
                DataTable dt = bl.ConsultaCarrera("inactivos");

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
            else{
                String carrera = txtCarrera.Text.ToString();
                
                if(carrera == "")
                {
                    MessageBox.Show("Favor de especificar la carrera", "Aviso", MessageBoxButtons.OK);
                }
                else
                {
                    DataTable dt = bl.ConsultaCarrera(carrera);
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
                
            }
        }

      

        private void frmConsultaCarrera_TextChanged(object sender, EventArgs e)
        {
            /*
            AutoCompleteStringCollection autolist = new AutoCompleteStringCollection();
            String carrera = txtCarrera.Text.ToString();
            DataTable dt = bl.ConsultaCarrera(carrera);

            foreach (DataRow r in dt.Rows)
            {
                autolist.Add(r[0].ToString());
            }
            txtCarrera.AutoCompleteMode = AutoCompleteMode.Suggest;

            txtCarrera.AutoCompleteSource = AutoCompleteSource.CustomSource;

            txtCarrera.AutoCompleteCustomSource = autolist;
            */
        }

        private void FrmConsultaCarrera_Load(object sender, EventArgs e)
        {
            
            AutoCompleteStringCollection mycollection = new AutoCompleteStringCollection();
            mycollection = bl.AutoCarrera();
            txtCarrera.AutoCompleteCustomSource = mycollection;
            /*
            conn.Open();
            SqlCommand cmd = new SqlCommand("select [carrera] from [carrera]", conn);
            
            SqlDataReader registros = cmd.ExecuteReader();
            AutoCompleteStringCollection mycollection = new AutoCompleteStringCollection();

            while (registros.Read())
            {
                txtCarrera.AutoCompleteCustomSource.Add(registros["carrera"].ToString());
                //MessageBox.Show(registros["carrera"].ToString());
            }
            txtCarrera.AutoCompleteCustomSource = mycollection;
            conn.Close();
            */
        }

        private void dgvCarrera_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenu m = new ContextMenu();

                MenuItem menuItem1 = new MenuItem();
                MenuItem menuItem2 = new MenuItem();
                MenuItem menuItem3 = new MenuItem();
                if (cbTodas.Checked)
                {
                    menuItem1.Text = "Baja";
                    menuItem2.Text = "Modifica";

                    m.MenuItems.Add(menuItem1);
                    m.MenuItems.Add(menuItem2);

                    menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
                    menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
                }
                else if (cbInactivos.Checked)
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

        private void cbInactivos_CheckedChanged(object sender, EventArgs e)
        {
            if (cbInactivos.Checked == true)
            {
                txtCarrera.Enabled = false;
                cbTodas.Enabled = false;
            }
            else
            {
                txtCarrera.Enabled = true;
                cbTodas.Enabled = true;
            }
            //BtnConsulta_Click(sender, e);

        }

        private void cbInactivos_Click(object sender, EventArgs e)
        {
            if (cbInactivos.Checked == false)
            {
                DataTable dt = bl.ConsultaCarrera("todas");

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
                DataTable dt = bl.ConsultaCarrera("todas");

                if (dt.Rows.Count > 0)
                {
                    dgvCarrera.DataSource = dt;
                    dt.Rows.Clear();
                }
            }
        }
    }
}
