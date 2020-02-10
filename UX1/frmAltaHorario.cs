using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Kardex.Layers;


namespace UX1
{
    public partial class frmAltaHorario : Form
    {
        dbConn db = new dbConn();
        public frmAltaHorario()
        {
            InitializeComponent();
            ComboBoxCarrera();
            ComboBoxDia1();
            
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

        }

        private void ComboBoxCarrera() 
        {
            DataTableReader reader = db.getInfo("carrera").CreateDataReader();

            while (reader.Read())
            {
                cbFAHCarrera.Items.Add(reader["carrera"].ToString());
            }
        }

        private void ComboBoxMateria()
        {
            //Obtains and reads all the subjects related to a career.
            List<string> parametros = new List<string>();
            parametros.Add(cbFAHCarrera.Text);
            DataTableReader reader = db.ExecSP("SPMateriasDeUnaCarrera",parametros).CreateDataReader();

            //Assigns subjects to combobox.
            while (reader.Read())
            {
                cbFAHMateria.Items.Add(reader["materia"].ToString());
            }
        }

        private void ComboBoxDia1()
        {
            //Obtains and reads all days.
            List<string> parametros = new List<string>();
            parametros.Add(cbFAHCarrera.Text);
            DataTableReader reader = db.getInfo("horario").CreateDataReader();

            //Assigns subjects to combobox.
            while (reader.Read())
            {
                cbFAHMateria.Items.Add(reader["dia"].ToString());
            }
        }

        private void cbFAHCarrera_TextChanged(object sender, EventArgs e)
        {
            ComboBoxMateria();
        }
    }
}
