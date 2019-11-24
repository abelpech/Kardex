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
    public partial class frmBajaMateria : Form
    {
        KeyPressValidation kpv = new KeyPressValidation();
        BL bl = new BL();

        public frmBajaMateria()
        {
            InitializeComponent();
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            string materia = txtMateria.Text.ToString().Trim();
            /*DateTime fechaalta = Convert.ToDateTime(dtpFechaAlta.ToString());
            bool estatus;

            if (cbEstatus.SelectedValue.ToString() == "Activo")
            {
                estatus = true;
            }
            else
            {
                estatus = false;
            }*/
            bl.BajaMateria(materia);
            txtMateria.Text = "";
        }

        private void FrmBajaMateria_Load(object sender, EventArgs e)
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
