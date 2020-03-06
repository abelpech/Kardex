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
using UX1.Layers;

namespace UX1
{
    public partial class Login : Form
    {
        BL bl = new BL();
        dbConn db = new dbConn();
        Permisos pm = new Permisos();
        public Login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            int idCarrera = 0;
            int dt = 0;
            string Usuario = txtUsername.Text;
            string Password = txtPassword.Text;
            dt = bl.LoginValidation(Usuario, Password);
            pm.setUsuario(Usuario);

            if (dt != 0)
            {
                
                MessageBox.Show("Bienvenido " + Usuario, "Inicio de sesión", MessageBoxButtons.OK);
                pm.setPermiso(dt);
                pm.setPeriodo(bl.ExcQryReturnString("periodo","control"));
                pm.setCampus(bl.ExcQryReturnString("campus","control"));
                
                List<string> parametros = new List<string>();
                parametros.Add(Permisos.usuario);
                idCarrera = db.ExecSPReturnInt("SPLogin_SeleccionaCarreraDeAlumno",parametros);
                Plantilla pl = new Plantilla();

                pm.setCarrera(bl.ExcQryReturnString("carrera", "carrera where carrera.id_carrera = " + idCarrera.ToString()));

                this.Hide();
                
                pl.Closed += (s, args) => this.Close();
                pl.Show();
                
                

            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos.", "Alerta", MessageBoxButtons.OK);
                txtPassword.Text = "";
            }

            // Si dt = 1, entonces el usuario es alumno
            // Si dt = 2, entonces el usuario es maestro
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro de salir?", "Alerta", MessageBoxButtons.YesNo) == DialogResult.Yes)
                Environment.Exit(0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmContrasena contra = new frmContrasena();
            contra.Show();
            this.Hide();
            
        }

        private void TxtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                BtnLogin_Click(sender, e);
            }
        }
    }
}
