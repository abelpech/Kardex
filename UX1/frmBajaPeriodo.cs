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

namespace Kardex
{
    
    public partial class frmBajaPeriodo : Form
    {
        BL bl = new BL();
        public frmBajaPeriodo()
        {
            InitializeComponent();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            string periodo = txtPeriodo.Text.ToString();
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
    }
}
