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
    
    public partial class frmBajaCarrera : Form
    {
        BL bl = new BL();
        public frmBajaCarrera()
        {
            InitializeComponent();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            string carrera = txtCarrera.Text.ToString().Trim();
            bl.BajaCarrera(carrera);
            txtCarrera.Text = "";
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmBajaCarrera_Load(object sender, EventArgs e)
        {
            
            AutoCompleteStringCollection mycollectioncarrera = new AutoCompleteStringCollection();

            
            mycollectioncarrera = bl.AutoCarrera();
            
            txtCarrera.AutoCompleteCustomSource = mycollectioncarrera;
        }
    }
}
