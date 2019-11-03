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
using Kardex;

namespace UX1
{
    public partial class frmConsultaAlumno : Form
    {
        
        BL bl = new BL();
        string data = string.Empty;
        int Row = 0;

        private bool nonNumberEntered = false;
        public frmConsultaAlumno()
        {
            InitializeComponent();
            cbTodos.Checked = true;
            
            
        }

        private void BtnConsulta_Click(object sender, EventArgs e)
        {
            String alumno = txtAlumno.Text.ToString();
            String carrera = txtCarrera.Text.ToString();
            int matricula = 0;
            if (cbTodos.Checked == true)
            {
                
                if (txtMatricula.Text =="")
                {
                    MessageBox.Show("Favor de especificar el id del alumno");
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
                    DataTable dt = bl.ConsultaAlumno(matricula, alumno, carrera);
                    if (dt.Rows.Count > 0)
                    {
                        dgvCarrera.DataSource = dt;
                        //No permitir agregar datos adicionales
                        dgvCarrera.AllowUserToAddRows = false;
                    }
                    else
                    {
                        MessageBox.Show("No hay registros del alumno y la carrera ingresada", "Aviso", MessageBoxButtons.OK);
                    }
                }
                
                
            }
            else
            {
                matricula = 0;
                //txtMatricula.Text = "";


                //MessageBox.Show("Favor de completar el alumno y la carrera", "Aviso", MessageBoxButtons.OK);
                DataTable dt = bl.ConsultaAlumno(matricula, alumno, carrera);
                if (dt.Rows.Count > 0)
                {
                    dgvCarrera.DataSource = dt;
                    //No permitir agregar datos adicionales
                    dgvCarrera.AllowUserToAddRows = false;
                }
                else
                {
                    MessageBox.Show("No registros el alumno y la carrera ingresada", "Aviso", MessageBoxButtons.OK);
                }

            }
        }

        private void CbTodos_CheckedChanged(object sender, EventArgs e)
        {

                if (cbTodos.Checked == true)
                {
                    txtMatricula.Show();
                lbMatricula.Show();

                    txtAlumno.Hide();
                lbAlumno.Hide();
                    txtCarrera.Hide();
                lbCarrera.Hide();
                cbInactivos.Checked = false;

                }
                else
                {
                    txtMatricula.Hide();
                lbMatricula.Hide();

                    txtAlumno.Show();
                lbAlumno.Show();
                    txtCarrera.Show();
                lbCarrera.Show();
                }

        }

        private void txtMatricula_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Checa bandera de metodo descrito abajo
            if (nonNumberEntered == true)
            {
                // Evita que el caracter se escriba con el evento.
                e.Handled = true;
            }
        }

        private void txtMatricula_KeyDown(object sender, KeyEventArgs e)
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

        private void FrmConsultaAlumno_Load(object sender, EventArgs e)
        {
            AutoCompleteStringCollection mycollectionAlumno = new AutoCompleteStringCollection();
            AutoCompleteStringCollection mycollectionCarrera = new AutoCompleteStringCollection();
            mycollectionAlumno = bl.AutoAlumno();
            mycollectionCarrera = bl.AutoCarrera();
            txtAlumno.AutoCompleteCustomSource = mycollectionAlumno;
            txtCarrera.AutoCompleteCustomSource = mycollectionCarrera;
        }

        private void CbInactivos_CheckedChanged(object sender, EventArgs e)
        {
            cbTodos.Checked = false;
            DataTable dt = bl.ConsultaAlumno(0,"inactivos","");
            if (dt.Rows.Count > 0)
            {
                dgvCarrera.DataSource = dt;
                //No permitir agregar datos adicionales
                dgvCarrera.AllowUserToAddRows = false;
            }
            else
            {
                MessageBox.Show("No hay alumnos inactivos", "Aviso", MessageBoxButtons.OK);
            }
            
        }

        private void dgvCarrera_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenu m = new ContextMenu();

                MenuItem menuItem1 = new MenuItem();
                MenuItem menuItem2 = new MenuItem();
                MenuItem menuItem3 = new MenuItem();
                if (cbInactivos.Checked == false)
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
                    //menuItem3.Text = "Reactivar";
                    menuItem2.Text = "Modifica";

                    //m.MenuItems.Add(menuItem3);
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
                data = dgvCarrera["Alumno", e.RowIndex].Value.ToString();
                Row = e.RowIndex;
                //MessageBox.Show(data);
            }
            catch (Exception ex)
            {

            }

            //MessageBox.Show(data);

        }

        private void menuItem1_Click(object sender, System.EventArgs e)
        {
            string carrera = dgvCarrera["Carrera", Row].Value.ToString();
            
            bl.BajaAlumno(data, carrera);
            BtnConsulta_Click(sender, e);
            data = "";
            Row = 0;

        }

        private void menuItem2_Click(object sender, System.EventArgs e)
        {
            // MessageBox.Show("Modifica");
            //pl.BtnModificacionCarrera_Click(sender, e);
            string matricula = dgvCarrera["Matricula", Row].Value.ToString();
            string nombre = dgvCarrera["Alumno", Row].Value.ToString();
            //string direccion = dgvCarrera["Direccion", Row].Value.ToString();
            //string telefono = dgvCarrera["Telefono", Row].Value.ToString();
            string carrera = dgvCarrera["Carrera", Row].Value.ToString();

            frmModificaAlumnoRCM baja = new frmModificaAlumnoRCM(matricula, nombre, carrera);
            baja.Show();
            data = "";
            Row = 0;
        }

        private void menuItem3_Click(object sender, System.EventArgs e)
        {
            //MessageBox.Show(data);
            string matricula = dgvCarrera["Matricula", Row].Value.ToString();
            string nombre = dgvCarrera["Alumno", Row].Value.ToString();
            //string direccion = dgvCarrera["Direccion", Row].Value.ToString();
            //string telefono = dgvCarrera["Telefono", Row].Value.ToString();
            string carrera = dgvCarrera["Carrera", Row].Value.ToString();
            //bl.ModificaAlumno(data, true);
            BtnConsulta_Click(sender, e);
            data = "";
            Row = 0;

        }


        private void cbInactivos_Click(object sender, EventArgs e)
        {
            if (cbInactivos.Checked == false)
            {
                DataTable dt = bl.ConsultaAlumno(0, "inactivos", "");
                if (dt.Rows.Count > 0)
                {
                    dgvCarrera.DataSource = dt;
                    dt.Rows.Clear();
                }
            }
        }

        private void cbTodos_Click(object sender, EventArgs e)
        {
           /* if (cbTodos.Checked == false)
            {
                DataTable dt = bl.ConsultaAlumno(0, "inactivos", "");
                if (dt.Rows.Count > 0)
                {
                    dgvCarrera.DataSource = dt;
                    dt.Rows.Clear();
                }
            }*/
        }
    }
}
