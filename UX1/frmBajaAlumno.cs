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
    public partial class frmBajaAlumno : Form
    {
        KeyPressValidation kpv = new KeyPressValidation();
        BL bl = new BL();
        public frmBajaAlumno()
        {
            InitializeComponent();
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            string alumno = txtAlumno.Text.ToString().Trim();
            string carrera = txtCarrera.Text.ToString().Trim();
            bl.BajaAlumno(alumno, carrera);
        }

        private void FrmBajaAlumno_Load(object sender, EventArgs e)
        {
            AutoCompleteStringCollection mycollectionalumno = new AutoCompleteStringCollection();
            AutoCompleteStringCollection mycollectioncarrera = new AutoCompleteStringCollection();

            mycollectionalumno = bl.AutoAlumno();
            mycollectioncarrera = bl.AutoCarrera();
            txtAlumno.AutoCompleteCustomSource = mycollectionalumno;
            txtCarrera.AutoCompleteCustomSource = mycollectioncarrera;

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
