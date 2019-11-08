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

namespace UX1
{
   
    public partial class frmBajaMateria : Form
    {
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
            string materia = txtMateria.Text.ToString();
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
    }
}
