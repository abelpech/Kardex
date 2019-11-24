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
    public partial class frmModificaPeriodo : Form
    {
        KeyPressValidation kpv = new KeyPressValidation();
        BL bl = new BL();
        dbConn db = new dbConn();
        string periodobaja1 = "";
        public frmModificaPeriodo()
        {
            InitializeComponent();
        }

        public frmModificaPeriodo(string periodobaja)
        {
            InitializeComponent();
            txtPeriodo.Text = periodobaja;
            periodobaja1 = periodobaja;
       
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            string periodo = txtPeriodo.Text.ToString().Trim();
            
            bool estatus;
            if(cbEstatus.SelectedIndex == 0)
            {
                estatus = true;
            }
            else
            {
                estatus = false;
            }
      
                bl.ModificaPeriodo(periodobaja1, periodo, estatus);
                txtPeriodo.Text = String.Empty;
                cbEstatus.SelectedIndex = -1;

        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmConsultaCarrera_Load(object sender, EventArgs e)
        {
            AutoCompleteStringCollection mycollection = new AutoCompleteStringCollection();
            mycollection = bl.AutoPeriodo();
            txtPeriodo.AutoCompleteCustomSource = mycollection;
        }

        private void IsNumberPressed(object sender, KeyPressEventArgs e)
        {
            e.Handled = kpv.IsNumber_KeyPress(sender, e);
        }

        private void IsLetterPressed(object sender, KeyPressEventArgs e)
        {
            e.Handled = kpv.IsLetter_KeyPress(sender, e);
        }
    }
}
