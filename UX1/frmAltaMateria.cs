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
    public partial class frmAltaMateria : Form
    {
        BL bl = new BL();
        public frmAltaMateria()
        {
            InitializeComponent();
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
            bl.AltaMateria(materia);

            txtMateria.Text = String.Empty;
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
