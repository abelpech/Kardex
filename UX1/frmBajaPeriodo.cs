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
    
    public partial class frmBajaPeriodo : Form
    {
        KeyPressValidation kpv = new KeyPressValidation();
        BL bl = new BL();
        public frmBajaPeriodo()
        {
            InitializeComponent();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            string periodo = txtPeriodo.Text.ToString().Trim();
            bl.BajaPeriodo(periodo);
            txtPeriodo.Text = "";
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmBajaCarrera_Load(object sender, EventArgs e)
        {
            
            AutoCompleteStringCollection mycollectioncarrera = new AutoCompleteStringCollection();

            
            mycollectioncarrera = bl.AutoCarrera();
            
            txtPeriodo.AutoCompleteCustomSource = mycollectioncarrera;
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
