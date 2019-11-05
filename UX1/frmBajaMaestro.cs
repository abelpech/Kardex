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

namespace UX1
{
    public partial class frmBajaMaestro : Form
    {
        BL bl = new BL();
        public frmBajaMaestro()
        {
            InitializeComponent();
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            int matricula = Convert.ToInt32(nudMatricula.Value);
            string maestro = txtMaestro.Text.ToString();
            
            bl.BajaMaestro(matricula, maestro);
        }
    }
}
