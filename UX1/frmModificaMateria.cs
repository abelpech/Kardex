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
    public partial class frmModificaMateria : Form
    {
        KeyPressValidation kpv = new KeyPressValidation();
        BL bl = new BL();
        string materiabaja1 = "";
        public frmModificaMateria()
        {
            InitializeComponent();
        }
        public frmModificaMateria(string materiabaja)
        {
            InitializeComponent();
            txtMateria.Text = materiabaja;
            materiabaja1 = materiabaja;
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            string materia = txtMateria.Text.ToString().Trim();
            //DateTime fechaalta = Convert.ToDateTime(dtpFechaAlta.Value.ToShortDateString());
            //DateTime fechabaja = Convert.ToDateTime(dtpFechaBaja.Value.ToShortDateString());
            bool estatus;
            if (cbEstatus.SelectedIndex == 0)
            {
                estatus = true;
            }
            else
            {
                estatus = false;
            }
            //MessageBox.Show(materiabaja1 + materia + estatus.ToString());
            bl.ModificaMateria(materiabaja1, materia, estatus);

            txtMateria.Text = String.Empty;
            cbEstatus.SelectedIndex = -1;
        }

        private void FrmModificaMateria_Load(object sender, EventArgs e)
        {
            
            AutoCompleteStringCollection mycollectionmateria = new AutoCompleteStringCollection();

           
            mycollectionmateria = bl.AutoMateria();
           
            txtMateria.AutoCompleteCustomSource = mycollectionmateria;
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
