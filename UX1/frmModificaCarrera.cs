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
    public partial class frmModificaCarrera : Form
    {
        BL bl = new BL();
        string carrerabaja1 = "";
        public frmModificaCarrera()
        {
            InitializeComponent();
        }

        public frmModificaCarrera(string carrerabaja)
        {
            InitializeComponent();
            txtCarrera.Text = carrerabaja;
            carrerabaja1 = carrerabaja;
        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label5_Click(object sender, EventArgs e)
        {

        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            string carrera = txtCarrera.Text.ToString();
            //DateTime fechaalta = Convert.ToDateTime(dtpFechaAlta.Value.ToShortDateString());
            //DateTime fechabaja = Convert.ToDateTime(dtpFechaBaja.Value.ToShortDateString());
            bool estatus;
            if(cbEstatus.SelectedIndex == 0)
            {
                estatus = true;
            }
            else
            {
                estatus = false;
            }

            //MessageBox de prueba para ver si manda los datos correctamente.
                //MessageBox.Show(carrerabaja1 + carrera + estatus.ToString());
                bl.ModificaCarrera(carrerabaja1, carrera, estatus);
                txtCarrera.Text = String.Empty;
                cbEstatus.SelectedIndex = -1;
           
            
            

        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmModificaCarrera_Load(object sender, EventArgs e)
        {
            AutoCompleteStringCollection mycollection = new AutoCompleteStringCollection();
            mycollection = bl.AutoCarrera();
            txtCarrera.AutoCompleteCustomSource = mycollection;
        }
    }
}
