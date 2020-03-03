using Kardex.Layers;
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

namespace UX1
{
    public partial class frmAltaHorarioMaestro : Form
    {
        BL bl = new BL();
        //string usuarioLogin = Permisos.usuario;
        string usuarioLogin = "Ray Parra";

        public frmAltaHorarioMaestro()
        {
            InitializeComponent();
            lbUsuario.Text = usuarioLogin;
            ComboBoxCampus();
        }


        public void ComboBoxCampus()
        {
            SqlConnection conn;
            //Obtiene el hostname de la computadora que utiliza el programa para adecuar la instancia
            //a la correcta de cada quien
            string host = Dns.GetHostName();
            //Se le asigna al objeto de SqlConnection la direccion de la instancia de la BD
            conn = new SqlConnection("server =  " + host + "; database=kardex ; integrated security = true");
            //Clear ComboBox and Open Connection
            cbCampus.Items.Clear();
            conn.Open();
            //Send Stored Procedure Name
            string query = "SPComboBoxCampus '" + usuarioLogin + "'";
            SqlCommand comando = new SqlCommand(query, conn);

            SqlDataReader reader = comando.ExecuteReader();

            //Validation is READER is EMPTY then show a Message
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    cbCampus.Items.Add(reader["Campus"].ToString());

                }
            }
            else
            {
                cbCampus.Items.Add("No existe CAMPUS disponible");
            }

            conn.Close();
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

        }

        private void ObtenerMateriasDisponibles()
        {

        }

        private void btnConsulta_Click(object sender, EventArgs e)
        {
            if (cbCampus.SelectedIndex == -1)
            {
                MessageBox.Show("Selecciona un Campus Disponible", "Aviso", MessageBoxButtons.OK);
            }
            else
            {
                string campus = this.cbCampus.GetItemText(this.cbCampus.SelectedItem);
                DataTable dt = bl.SPdgvMaterias(campus);
                if (dt.Rows.Count > 0)
                {
                    dgvMaterias.DataSource = dt;
                    dgvMaterias.AllowUserToAddRows = false;
                }
                else
                {
                    // btnLimpiar_Click(sender, e);
                    MessageBox.Show("No hay horarios disponibles", "Aviso", MessageBoxButtons.OK);
                }
            }

        }

      

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (this.dgvHorario.DataSource != null)
            {
                this.dgvHorario.DataSource = null;
            }
            else
            {
                //this.dgvHorario.Rows.Clear();
            }

            dgvHorario.Columns.Add("Materia", "Materia");
            dgvHorario.Columns.Add("Dia 1", "Dia 1");
            dgvHorario.Columns.Add("Inicio 1", "Inicio 1");
            dgvHorario.Columns.Add("Final 1", "Final 1");
            dgvHorario.Columns.Add("Dia 2", "Dia 2");
            dgvHorario.Columns.Add("Inicio 2", "Inicio 2");
            dgvHorario.Columns.Add("Final 2", "Final 2");
            dgvHorario.Columns.Add("Grupo", "Grupo");
            dgvHorario.Columns.Add("Carrera", "Carrera");
            dgvHorario.Columns.Add("Periodo", "Periodo");


            for (int i = 0; i < dgvMaterias.SelectedRows.Count; i++)
            {

                int index = dgvHorario.Rows.Add();
                dgvHorario.Rows[index].Cells[0].Value = dgvMaterias.SelectedRows[i].Cells[0].Value.ToString();
                dgvHorario.Rows[index].Cells[1].Value = dgvMaterias.SelectedRows[i].Cells[1].Value.ToString();
                dgvHorario.Rows[index].Cells[2].Value = dgvMaterias.SelectedRows[i].Cells[2].Value.ToString();
                dgvHorario.Rows[index].Cells[3].Value = dgvMaterias.SelectedRows[i].Cells[3].Value.ToString();
                dgvHorario.Rows[index].Cells[4].Value = dgvMaterias.SelectedRows[i].Cells[4].Value.ToString();
                dgvHorario.Rows[index].Cells[5].Value = dgvMaterias.SelectedRows[i].Cells[5].Value.ToString();
                dgvHorario.Rows[index].Cells[6].Value = dgvMaterias.SelectedRows[i].Cells[6].Value.ToString();
                dgvHorario.Rows[index].Cells[7].Value = dgvMaterias.SelectedRows[i].Cells[7].Value.ToString();
                dgvHorario.Rows[index].Cells[8].Value = dgvMaterias.SelectedRows[i].Cells[8].Value.ToString();
                dgvHorario.Rows[index].Cells[9].Value = dgvMaterias.SelectedRows[i].Cells[9].Value.ToString();

                dgvMaterias.Rows.RemoveAt(dgvMaterias.SelectedRows[i].Index);

            }

        }

        public void actualizarDGV()
        {
            string data = string.Empty;
            int indexOfYourColumn = 2;
            foreach (DataGridViewRow row in dgvMaterias.Rows)
            {

                data = row.Cells[indexOfYourColumn].Value.ToString();
                //if(data = )

            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //Limpiar DataGridView
        }
    }
}
