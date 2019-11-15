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
    public partial class frmModificaAlumnoRCM : Form
    {
        BL bl = new BL();
        dbConn db = new dbConn();
        private bool nonNumberEntered = false;

        public frmModificaAlumnoRCM()
        {
            InitializeComponent();
        }

        public frmModificaAlumnoRCM(string Matricula, string nombre,  string carrera)
        {
            InitializeComponent();
            nudMatricula.Value = Convert.ToInt32(Matricula);
            txtAlumno.Text = nombre;
            //txtDireccion.Text = direccion;
            //txtTelefono.Text = telefono;
            txtCarrera.Text = carrera;
            DataTable reader = db.getInfo("alumno");
            foreach (DataRow row in reader.Rows)
            {
                if (row["id_alumno"].ToString() == Matricula.ToString())
                {
                    txtDireccion.Text = row["direccion"].ToString();
                    txtTelefono.Text = row["telefono"].ToString();
                    dtpFechaAlta.Value = DateTime.ParseExact(row["fechanac"].ToString(), "dd/mm/yyyy", null);
                    int estatus = Convert.ToInt32(row["activo"]);
                    if (estatus ==1)
                    {
                        cbEstatus.SelectedIndex = 0;
                    }
                    else
                        cbEstatus.SelectedIndex = 1;
                    //DateTime da = Convert.ToDateTime ();

                }
            }
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            int matricula = Convert.ToInt32(nudMatricula.Value);
            string alumno = txtAlumno.Text;
            string direccion = txtDireccion.Text;
            string telefono = txtTelefono.Text;
            DateTime fechaNac = Convert.ToDateTime(dtpFechaAlta.Value.ToShortDateString());
            bool estatus = false;
            string carrera = txtCarrera.Text;
            
            
            if (cbEstatus.SelectedIndex == 0)
            {
                estatus = true;
            }
            else
                estatus = false;

            //validacion campos vacios, nulos o espacios en blanco
            if (!(String.IsNullOrEmpty(nudMatricula.Text) || String.IsNullOrWhiteSpace(nudMatricula.Text) &&
                String.IsNullOrEmpty(txtAlumno.Text) || String.IsNullOrWhiteSpace(txtAlumno.Text) &&
                String.IsNullOrEmpty(txtDireccion.Text) || String.IsNullOrWhiteSpace(txtDireccion.Text) &&
                String.IsNullOrEmpty(txtTelefono.Text) || String.IsNullOrWhiteSpace(txtTelefono.Text) &&
                String.IsNullOrEmpty(txtCarrera.Text) || String.IsNullOrWhiteSpace(txtCarrera.Text) &&
                cbEstatus.SelectedIndex > 0))
            {
                bl.ModificaAlumno(matricula, alumno, direccion, telefono, fechaNac, estatus, carrera);
                nudMatricula.Text = String.Empty;
                txtAlumno.Text = String.Empty;
                txtDireccion.Text = String.Empty;
                txtTelefono.Text = String.Empty;
                cbEstatus.SelectedIndex = -1;
                txtCarrera.Text = String.Empty;
                //txtNCarrera.Text = String.Empty;
                dtpFechaAlta.ResetText();
            }
            else
            {
                MessageBox.Show("Favor de ingresar todos los datos solicitado", "Advertencia", MessageBoxButtons.OK);
            }
        }

        private void TxtTelefono_TextChanged(object sender, EventArgs e)
        {
            string Tel = txtTelefono.Text;
            long parsedValue;
            if (!long.TryParse(Tel, out parsedValue))
            {
                //Tel = Tel.Substring(0, Tel.Length - 1);
                //txtTelefono.Text = Tel;
                if (Tel.Length == 10)
                {
                    if (!long.TryParse(Tel, out parsedValue))
                    {
                        epTelefono.SetError(txtTelefono, "El campo deberia contener solo numeros.");
                    }
                    else
                        epTelefono.Clear();
                }
                else if (Tel.Length == 0)
                {
                    epTelefono.Clear();
                }

                else
                    epTelefono.SetError(txtTelefono, "El campo deberia contener solo numeros.");
                return;
            }
            else
                epTelefono.Clear();
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Checa bandera de metodo descrito abajo
            if (nonNumberEntered == true)
            {
                // Evita que el caracter se escriba con el evento.
                e.Handled = true;
            }
        }

        private void txtTelefono_KeyDown(object sender, KeyEventArgs e)
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

        private void FrmModificaAlumno_Load(object sender, EventArgs e)
        {
            //AutoCompleteStringCollection mycollectionalumno = new AutoCompleteStringCollection();
            AutoCompleteStringCollection mycollectioncarrera = new AutoCompleteStringCollection();

            //mycollectionalumno = bl.AutoAlumno();
            mycollectioncarrera = bl.AutoCarrera();
            //txtAlumno.AutoCompleteCustomSource = mycollectionalumno;
            txtCarrera.AutoCompleteCustomSource = mycollectioncarrera;
            //txtNCarrera.AutoCompleteCustomSource = mycollectioncarrera;
        }

        private void nudMatricula_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
