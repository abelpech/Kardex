using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Kardex;
using Kardex.Layers;
using UX1.Layers;

namespace UX1
{
    public partial class frmResetear : Form
    {
        BL bl = new BL();
        string Usuario = "";
        string maestro = string.Empty;
        

        public frmResetear(string _maestro)
        {
            InitializeComponent();
            maestro = _maestro;
            Usuario = Permisos.usuario;
            txtUsername.Text = maestro;
        }

       

       
        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro de salir?", "Alerta", MessageBoxButtons.YesNo) == DialogResult.Yes)
                Environment.Exit(0);
        }

        
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string contra2 = txtPWD2.Text;
            if (txtPWD1.Text == txtPWD2.Text)
            {
               // bl.modificaContrasena(username, contra2);
            }
            else
            {
                MessageBox.Show("CONTRASEÑAS NO SON IGUALES", "Alerta", MessageBoxButtons.OK);
            }
            
            
            

        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            frmContrasena contrasena = new frmContrasena();
            contrasena.Show();
            this.Hide();
        }
    }
}
