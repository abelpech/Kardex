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
using UX1.Validaciones;

namespace UX1
{
    public partial class frmConsultaCalificacion : Form
    {
        KeyPressValidation kpv = new KeyPressValidation();
        BL bl = new BL();
        string data = string.Empty;
        int Row = 0;

        private bool nonNumberEntered = false;
        public frmConsultaCalificacion()
        {
            InitializeComponent();
            //cbTodos.Checked = true;
            
            
        }

        private void BtnConsulta_Click(object sender, EventArgs e)
        {
            String alumno = txtAlumno.Text.ToString().Trim();
            String periodo = txtPeriodo.Text.ToString().Trim();
            int matricula;
            try
            {
                matricula = Convert.ToInt16(txtMatricula.Text);
            }
            catch
            {
                matricula = 0;
            }
            
            if (comboEstatus.SelectedIndex == 0)
            {
                DataTable dt = bl.ConsultaCalificacion(matricula, alumno, periodo, 0);
                if (dt.Rows.Count > 0)
                {
                    dgvCarrera.DataSource = dt;              
                    dgvCarrera.AllowUserToAddRows = false;
                }
                else
                {
                    MessageBox.Show("No hay registros disponibles con este criterio", "Aviso", MessageBoxButtons.OK);
                }
            }
            else if (comboEstatus.SelectedIndex == 1)
            {
                    DataTable dt = bl.ConsultaCalificacion(matricula, alumno, periodo, 1);
                    if (dt.Rows.Count > 0)
                    {
                        dgvCarrera.DataSource = dt;
                        dgvCarrera.AllowUserToAddRows = false;
                    }
                    else
                    {
                        MessageBox.Show("No hay registros disponibles con este criterio", "Aviso", MessageBoxButtons.OK);
                    }
            }
            else if (comboEstatus.SelectedIndex == -1)
            {
                
                    MessageBox.Show("Seleccione un tipo de STATUS", "Aviso", MessageBoxButtons.OK);
            
            }
            txtAlumno.Text = alumno;
            txtPeriodo.Text = periodo;
            

        }
        

        private void txtMatricula_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Evita escribir el caracter si este es diferente a las teclas de control
            // o a algun numero
            if (!char.IsControl(e.KeyChar) && isNumeroValido(e.KeyChar))
            {
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
            AutoCompleteStringCollection mycollectionPeriodo = new AutoCompleteStringCollection();
            mycollectionAlumno = bl.AutoAlumno();
            mycollectionPeriodo = bl.AutoPeriodo();
            txtAlumno.AutoCompleteCustomSource = mycollectionAlumno;
            txtPeriodo.AutoCompleteCustomSource = mycollectionPeriodo;
        }


        private void dgvCarrera_MouseClick(object sender, MouseEventArgs e)
        {   /*
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
                    //menuItem1.Text = "Baja";
                    menuItem2.Text = "Modifica";

                    //m.MenuItems.Add(menuItem1);
                    m.MenuItems.Add(menuItem2);

                   // menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
                    menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
                }
                else if (comboEstatus.SelectedIndex == 1)
                {
                    //menuItem3.Text = "Reactivar";
                    menuItem2.Text = "Modifica";

                    //m.MenuItems.Add(menuItem3);
                    m.MenuItems.Add(menuItem2);

                    //menuItem3.Click += new System.EventHandler(this.menuItem3_Click);
                    menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
                }

                
                m.Show(dgvCarrera, new Point(e.X, e.Y));
            }

            */
        }
        

        private void dgvCarrera_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            /*
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
            */

        }

        /*
        private void menuItem1_Click(object sender, System.EventArgs e)
        {
            string carrera = dgvCarrera["Carrera", Row].Value.ToString();
            
            bl.BajaAlumno(data, carrera);
            BtnConsulta_Click(sender, e);
            data = "";
            Row = 0;

        }*/

        private void menuItem2_Click(object sender, System.EventArgs e)
        {
            //It needs to be rewritten for CALIFICACION
            //TO BE COMPLETED
            
            string nombre = dgvCarrera["Alumno", Row].Value.ToString();
            string materia = dgvCarrera["Materia", Row].Value.ToString();
            string maestro = dgvCarrera["Maestro", Row].Value.ToString();
            string periodo = dgvCarrera["Periodo", Row].Value.ToString();

            //frmModificaCalificacion modifica = new frmModificaCalificacion(nombre, materia, maestro, periodo);
            //modifica.Show();

            //frmModificaAlumnoRCM baja = new frmModificaAlumnoRCM(matricula, nombre, carrera);
            //baja.Show();
            
            //data = "";
            //Row = 0;
        }

        /*
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

        }*/

        private void button1_Click(object sender, EventArgs e)
        {
            txtAlumno.Text = "";
            txtPeriodo.Text = "";
            txtMatricula.Text = "";
            comboEstatus.SelectedIndex = -1;

            DataTable dt = bl.ConsultaCalificacion(0, "", "", 0);
            if (dt.Rows.Count > 0)
            {
                dgvCarrera.DataSource = dt;
                dt.Rows.Clear();
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

        private void dgvCarrera_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvCarrera.CurrentRow.Index >= 0)
                {
                    //MessageBox.Show(Convert.ToInt32(dgvCarrera.CurrentRow.Index).ToString());
                    data = dgvCarrera["Alumno", Convert.ToInt32(dgvCarrera.CurrentRow.Index)].Value.ToString();
                    Row = Convert.ToInt32(dgvCarrera.CurrentRow.Index);
                }


                //MessageBox.Show(data);
            }
            catch (Exception ex)
            {

            }
        }
        private void IsNumberPressed(object sender, KeyPressEventArgs e)
        {
            e.Handled = kpv.IsNumber_KeyPress(sender, e);
        }

        private void IsLetterPressed(object sender, KeyPressEventArgs e)
        {
            e.Handled = kpv.IsLetter_KeyPress(sender, e);
        }

        private void IsLetterOrNumberPressed(object sender, KeyPressEventArgs e)
        {
            e.Handled = kpv.IsLetterOrNumber_KeyPress(sender, e);
        }
    }
}
