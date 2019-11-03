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
    public partial class frmContrasena : Form
    {
        BL bl = new BL();
        Permisos pm = new Permisos();
        int randomnumber = 0;
        string Usuario = string.Empty;

        public frmContrasena()
        {
            InitializeComponent();
        }

       

       
        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro de salir?", "Alerta", MessageBoxButtons.YesNo) == DialogResult.Yes)
                Environment.Exit(0);
        }

        private void instancia(string maestro) {
            this.Hide();
            frmResetear reseteo = new frmResetear(maestro);
            reseteo.Show();

        }

        public int aleatorio() {

            Random rnd = new Random();
            int aleatorio = rnd.Next(1000, 9999);
            randomnumber = aleatorio;
            return aleatorio;
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {

            int dt = 0;
            Usuario = txtUsername.Text;
            
            dt = bl.LoginValidationPR(Usuario);

            if (dt != 0)
            {

                try
                {

                    pm.setUsuario(Usuario);
                    MailMessage mail = new MailMessage();
                    SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                    mail.From = new MailAddress("cesununiversidad2019@gmail.com");
                    mail.To.Add("cesununiversidad2019@gmail.com");
                    mail.Subject = "Actualiza tu Contraseña de KARDEX";
                    //Random Number 
                    
                    mail.Body = "El usuario: " + txtUsername.Text + " ha solicitado actualizar su contraseña." + System.Environment.NewLine + System.Environment.NewLine + "El codigo de autorizacion es: " + aleatorio();

                    SmtpServer.Port = 587;
                    SmtpServer.Credentials = new System.Net.NetworkCredential("cesununiversidad2019@gmail.com", "Cesun2019");
                    SmtpServer.EnableSsl = true;

                    SmtpServer.Send(mail);
                    MessageBox.Show("FAVOR DE CONTACTAR A COORDINACION PARA FOLIO DE AUTORIZACION", "Aviso", MessageBoxButtons.OK);
                    //instancia();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                MessageBox.Show("USUARIO NO DADO DE ALTA - FAVOR DE CONTACTAR A COORDINACION", "Alerta", MessageBoxButtons.OK);
            }

           

        }

        private void BtnRegresar_Click(object sender, EventArgs e)
        {
            Login lg = new Login();
            lg.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == Convert.ToString(randomnumber))
            {
                instancia(Usuario);
            }
            else
            {
                MessageBox.Show("FOLIO INCORRECTO - SOLICITARLO NUEVAMENTE", "Alerta", MessageBoxButtons.OK);
                textBox1.Text = "";
                //txtUsername.Text = "";
            }
        }
    }
}
