using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Kardex.Layers;
using UX1.Validaciones;

namespace Kardex
{
    public partial class frmModificaCalificacion : Form
    {
        KeyPressValidation kpv = new KeyPressValidation();
        BL bl = new BL();
        public frmModificaCalificacion()
        {
            InitializeComponent();
            
            ComboBoxPeriodo();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            string periodo = cbPeriodo.GetItemText(cbPeriodo.SelectedItem);
            string alumno = cbAlumno.GetItemText(cbAlumno.SelectedItem);
            string materia = cbMateria.GetItemText(cbMateria.SelectedItem);
            int calificacion = Convert.ToInt32(nudCalificacion.Value);
            int unidad = Convert.ToInt32(cbUnidad.GetItemText(cbUnidad.SelectedItem));

            bl.ModificaCalificacion(calificacion, unidad, alumno, materia, periodo);

            this.Hide();
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

     

        private void IsNumberPressed(object sender, KeyPressEventArgs e)
        {
            e.Handled = kpv.IsNumber_KeyPress(sender, e);
        }

        private void IsLetterPressed(object sender, KeyPressEventArgs e)
        {
            e.Handled = kpv.IsLetter_KeyPress(sender, e);
        }

        private void IsLetterOrNumberPressed(object sender, KeyPressEventArgs e)
        {
            e.Handled = kpv.IsLetterOrNumber_KeyPress(sender, e);
        }

        

        public void ComboBoxPeriodo()
        {
            SqlConnection conn;
            //Obtiene el hostname de la computadora que utiliza el programa para adecuar la instancia
            //a la correcta de cada quien
            string host = Dns.GetHostName();
            //Se le asigna al objeto de SqlConnection la direccion de la instancia de la BD
            conn = new SqlConnection("server =  " + host + "; database=kardex ; integrated security = true");
            //Clear ComboBox and Open Connection
            cbPeriodo.Items.Clear();
            conn.Open();
            //Send Stored Procedure Name
            string query = "ComboBoxPeriodo";
            SqlCommand comando = new SqlCommand(query, conn);

            SqlDataReader reader = comando.ExecuteReader();

            //Validation is READER is EMPTY then show a Message
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    cbPeriodo.Items.Add(reader["periodo"].ToString());

                }
            }
            else
            {
                cbPeriodo.Items.Add("No existe PERIODO disponible");
            }    

            conn.Close();
        }
        public void ComboBoxAlumno()
        { 
                string periodo = "";
                SqlConnection conn;
                //It acquires Host Name from Local PC
                string host = Dns.GetHostName();
                //Creating a new SQL Connection instance
                conn = new SqlConnection("server =  " + host + "; database=kardex ; integrated security = true");
                cbAlumno.Items.Clear();
                //It gets TEXT from selectedItem in ComboBox
                periodo = cbPeriodo.GetItemText(cbPeriodo.SelectedItem);
                conn.Open();
                //Sending Stored Procedure Name with its parameter
                string query = "ComboBoxAlumno '" + periodo + "'";
                SqlCommand comando = new SqlCommand(query, conn);
                SqlDataReader reader = comando.ExecuteReader();
                //Validation is READER is EMPTY then show a Message
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        cbAlumno.Items.Add(reader["nombre"].ToString());

                    }
                }
                else
                {
                    cbAlumno.Items.Add("No existen ALUMNOS con dicho PERIODO");
                }
                
                conn.Close();
        }

        private void cbPeriodo_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Activating Method when cbPeriodo selected index is different from -1
            //ComboBox are taken back to INDEX -1 and ITEMS are cleared
            ComboBoxAlumno();
            cbAlumno.SelectedIndex = -1;
            cbMateria.SelectedIndex = -1;
            nudCalificacion.Value = 1;
            //nudUnidad.Value = 1;
            //cbAlumno.Items.Clear();
            cbMateria.Items.Clear();
        }

        public void ComboBoxMateria()
        {
            string alumno = "";
            SqlConnection conn;
            //It acquires Host Name from Local PC
            string host = Dns.GetHostName();
            //Creating a new SQL Connection instance
            conn = new SqlConnection("server =  " + host + "; database=kardex ; integrated security = true");
            cbMateria.Items.Clear();
            //It gets TEXT from selectedItem in ComboBox
            alumno = cbAlumno.GetItemText(cbAlumno.SelectedItem);
            conn.Open();
            //Sending Stored Procedure Name with its parameter
            string query = "ComboBoxMateria '" + alumno + "'";
            SqlCommand comando = new SqlCommand(query, conn);
            SqlDataReader reader = comando.ExecuteReader();
            //Validation is READER is EMPTY then show a Message
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    cbMateria.Items.Add(reader["materia"].ToString());

                }
            }
            else
            {
                cbMateria.Items.Add("No hay MATERIA registrada con dicho alumno");
            }
                
            conn.Close();
        }

        private void cbAlumno_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ComboBox are taken back to INDEX -1 and ITEMS are cleared
            ComboBoxMateria();
            cbMateria.SelectedIndex = -1;
            nudCalificacion.Value = 1;
            //nudUnidad.Value = 1;
            //cbMateria.Items.Clear();
        }

        private void cbMateria_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBoxUnidad();
            nudCalificacion.Value = 1;
            //nudUnidad.Value = 1;
            //cbUnidad.Items.Clear();
            cbUnidad.SelectedIndex = -1;
        }

        public void ComboBoxUnidad()
        {
            string alumno = "";
            string periodo = "";
            string materia = "";
            SqlConnection conn;
            //It acquires Host Name from Local PC
            string host = Dns.GetHostName();
            //Creating a new SQL Connection instance
            conn = new SqlConnection("server =  " + host + "; database=kardex ; integrated security = true");
            cbUnidad.Items.Clear();
            //It gets TEXT from selectedItem in ComboBox
            alumno = cbAlumno.GetItemText(cbAlumno.SelectedItem);
            periodo = cbPeriodo.GetItemText(cbPeriodo.SelectedItem);
            materia = cbMateria.GetItemText(cbMateria.SelectedItem);
            conn.Open();
            //Sending Stored Procedure Name with its parameter
            string query = "ComboBoxUnidad '" + alumno + "', '" + periodo + "', '" + materia + "'";
            SqlCommand comando = new SqlCommand(query, conn);
            SqlDataReader reader = comando.ExecuteReader();
            //Validation is READER is EMPTY then show a Message
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    cbUnidad.Items.Add(reader["unidad"].ToString());

                }
            }
            else
            {
                cbUnidad.Items.Add("No hay UNIDAD registrada con dicha MATERIA");
            }

            conn.Close();
        }

        private void cbUnidad_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
