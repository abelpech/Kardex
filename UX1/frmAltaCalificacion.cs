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
using UX1.Validaciones;

namespace Kardex
{
    public partial class frmAltaCalificacion : Form
    {
        KeyPressValidation kpv = new KeyPressValidation();
        BL bl = new BL();
        public frmAltaCalificacion()
        {
            InitializeComponent();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            string alumno = txtAlumno.Text.ToString().Trim();
            string materia = txtMateria.Text.ToString().Trim();
            string carrera = txtCarrera.Text.ToString().Trim();
            string maestro = txtMaestro.Text.ToString().Trim();
            string periodo = txtPeriodo.Text.ToString().Trim();
            int calificacion = Convert.ToInt32(nudCalificacion.Value);
            int unidad = Convert.ToInt32(nudUnidad.Value);

            bl.AltaCalificacion(calificacion, unidad,alumno,materia,carrera,maestro,periodo);

            txtAlumno.Text = "";
            txtMateria.Text = "";
            txtCarrera.Text = "";
            txtMaestro.Text = "";
            txtPeriodo.Text = "";
            nudCalificacion.Value = 1;
            nudUnidad.Value = 1;

            //Validacion a TxtBox y ComboBox
            /*
                    if(txtAlumno.Text =="" || cbEstatus.SelectedIndex == -1)
                    {
                        MessageBox.Show("Favor de llenar toda la informacion solicitada", "Advertencia", MessageBoxButtons.OK);
                    }
                    else
                    {
                        if (cbEstatus.SelectedIndex == 0)
                        {
                            estatus = true;
                        }
                        else
                        {
                            estatus = false;
                        }
                        bl.AltaCarrera(carrera, estatus);

                        txtAlumno.Text = String.Empty;
                        cbEstatus.SelectedIndex = -1;
                    }  
            */
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TxtCarrera_TextChanged(object sender, EventArgs e)
        {
            if (txtAlumno.Text.Length >50)
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

        private void frmAltaCalificacion_Load(object sender, EventArgs e)
        {
            //Alumno y Carrera
            AutoCompleteStringCollection mycollectionAlumno = new AutoCompleteStringCollection();
            AutoCompleteStringCollection mycollectionCarrera = new AutoCompleteStringCollection();
            mycollectionAlumno = bl.AutoAlumno();
            mycollectionCarrera = bl.AutoCarrera();
            txtAlumno.AutoCompleteCustomSource = mycollectionAlumno;
            
            txtCarrera.AutoCompleteCustomSource = mycollectionCarrera;
            //Materia
            AutoCompleteStringCollection mycollectionMateria = new AutoCompleteStringCollection();
            mycollectionMateria = bl.AutoMateria();
            txtMateria.AutoCompleteCustomSource = mycollectionMateria;
            //Periodo
            AutoCompleteStringCollection mycollectionPeriodo = new AutoCompleteStringCollection();
            mycollectionPeriodo = bl.AutoPeriodo();
            txtPeriodo.AutoCompleteCustomSource = mycollectionPeriodo;
            //Maestro
            AutoCompleteStringCollection mycollectionMaestro = new AutoCompleteStringCollection();
            mycollectionMaestro = bl.AutoMaestro();
            txtMaestro.AutoCompleteCustomSource = mycollectionMaestro;

        }
    }
}
