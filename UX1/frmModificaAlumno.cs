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
using UX1.Validaciones;

namespace UX1
{
    public partial class frmModificaAlumno : Form
    {
        KeyPressValidation kpv = new KeyPressValidation();
        BL bl = new BL();
        dbConn db = new dbConn();
        
        private bool nonNumberEntered = false;

        public frmModificaAlumno()
        {
            InitializeComponent();
        }

        public frmModificaAlumno(string Matricula, string nombre, string carrera)
        {
            InitializeComponent();
            nudMatricula.Value = Convert.ToInt32(Matricula);
            txtAlumno.Text = nombre;
            //txtDireccion.Text = direccion;
            //txtTelefono.Text = telefono;
            txtCarrera.Text = carrera;
            
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            int matricula = Convert.ToInt32(nudMatricula.Value);
            string alumno = txtAlumno.Text.Trim();
            string direccion = txtDireccion.Text.Trim();
            string telefono = txtTelefono.Text.Trim();
            DateTime fechaNac = Convert.ToDateTime(dtpFechaAlta.Value.ToShortDateString());
            bool estatus = false;
            string carrera = txtCarrera.Text.Trim();
            //string Ncarrera = txtNCarrera.Text;

            if (cbEstatus.SelectedIndex == 0)
            {
                estatus = true;
            }
            else
                estatus = false;

            //validacion campos vacios, nulos o espacios en blanco
            if (!(String.IsNullOrEmpty(nudMatricula.Text) && 
                String.IsNullOrEmpty(txtAlumno.Text)&& 
                String.IsNullOrEmpty(txtDireccion.Text) && 
                String.IsNullOrEmpty(txtTelefono.Text) && 
                String.IsNullOrEmpty(txtCarrera.Text) &&
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

        }

        private void txtTelefono_KeyDown(object sender, KeyEventArgs e)
        {

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
            string maxId = "";
            string carrera = "";
            DataTable reader = db.getInfo("alumno");
            DataTable readerC = db.getInfo("carrera");
            foreach (DataRow row in reader.Rows)
            {
                if (row["id_alumno"].ToString() == nudMatricula.Value.ToString())
                {
                    txtAlumno.Text = row["nombre"].ToString();
                    txtDireccion.Text = row["direccion"].ToString();
                    txtTelefono.Text = row["telefono"].ToString();
                    try
                    {
                        dtpFechaAlta.Value = DateTime.ParseExact(row["fechanac"].ToString(), "dd/mm/yyyy", null);
                    }
                    catch (Exception ex)
                    {

                    }

                    int estatus = Convert.ToInt32(row["activo"]);
                    if (estatus == 1)
                    {
                        cbEstatus.SelectedIndex = 0;
                    }
                    else
                        cbEstatus.SelectedIndex = 1;
                    carrera = row["id_carrera"].ToString();
                    //DateTime da = Convert.ToDateTime ();

                }
                maxId = row["id_alumno"].ToString();
            }
            foreach (DataRow row in readerC.Rows)
            {
                if (row["id_carrera"].ToString() == carrera)
                {
                    txtCarrera.Text = row["carrera"].ToString();
                }
            }
            nudMatricula.Maximum = Convert.ToInt32(maxId);
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
