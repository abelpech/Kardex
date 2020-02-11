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
            ComboBoxCampus();
            
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
            parametros.Add(cbFAHCampus.Text);
            parametros.Add(cbFAHPeriodo.Text);
            parametros.Add(cbFAHGrupo.Text);
            parametros.Add(cbFAHCarrera.Text);
            DataTableReader reader = db.ExecSP("SPMat_Ca_Gru_Pe_Cam", parametros).CreateDataReader();

            //Assigns subjects to combobox.
            while (reader.Read())
            {
                cbFAHMateria.Items.Add(reader["materia"].ToString());
            }
        }
        private void ComboBoxDia2()
        {

        }

        private void ComboBoxPeriodo()
        {
            //Obtains and reads all the subjects related to a career.
            List<string> parametros = new List<string>();
            parametros.Add(cbFAHCampus.Text);
            DataTableReader reader = db.ExecSP("SPPeriodo_Campus", parametros).CreateDataReader();

            //Assigns subjects to combobox.
            while (reader.Read())
            {
                cbFAHPeriodo.Items.Add(reader["periodo"].ToString());
            }
        }
        private void ComboBoxGrupo()
        {
            //Obtains and reads all the subjects related to a career.
            List<string> parametros = new List<string>();
            parametros.Add(cbFAHCampus.Text);
            parametros.Add(cbFAHPeriodo.Text);
            DataTableReader reader = db.ExecSP("SPGrupo_Periodo_Campus", parametros).CreateDataReader();

            //Assigns subjects to combobox.
            while (reader.Read())
            {
                cbFAHGrupo.Items.Add(reader["grupo"].ToString());
            }
        }

        private void ComboBoxCampus()
        {
            //Obtains and reads all the subjects related to a career.
            List<string> parametros = new List<string>();
            parametros.Add(cbFAHCampus.Text);
            DataTableReader reader = db.ExcQryDt("select * from campus").CreateDataReader();

            //Assigns subjects to combobox.
            while (reader.Read())
            {
                cbFAHCampus.Items.Add(reader["nombre"].ToString());
            }
        }

        private void ComboBoxDia1()
        {
            int LUN = 0;
            int MAR = 0;
            int MIE = 0;
            int JUE = 0;
            int VIE = 0;
            int SAB = 0;

            int opcion = 0;
            bool founded = false;
            bool logrado = false;
            //Obtains and reads all days.
            List<string> parametros = new List<string>();
            parametros.Add(cbFAHCampus.Text);
            parametros.Add(cbFAHPeriodo.Text);
            parametros.Add(cbFAHGrupo.Text);
            parametros.Add(cbFAHCarrera.Text);
            parametros.Add(cbFAHMateria.Text);
            parametros.Add("LUN");
            
            DataTableReader reader = db.ExcQryDt("select distinct dia from horario").CreateDataReader();
            LUN = db.ExecSPReturnInt("SPDias_Materia_Carrera_Campus", parametros);
            parametros[5] = "MAR";
            MAR = db.ExecSPReturnInt("SPDias_Materia_Carrera_Campus", parametros);
            parametros[5] = "MIE";
            MIE = db.ExecSPReturnInt("SPDias_Materia_Carrera_Campus", parametros);
            parametros[5] = "JUE";
            JUE = db.ExecSPReturnInt("SPDias_Materia_Carrera_Campus", parametros);
            parametros[5] = "VIE";
            VIE = db.ExecSPReturnInt("SPDias_Materia_Carrera_Campus", parametros);
            parametros[5] = "SAB";
            SAB = db.ExecSPReturnInt("SPDias_Materia_Carrera_Campus", parametros);
            MessageBox.Show("LUN:"+LUN+" MAR:"+MAR+" MIE:"+MIE+" JUE:"+JUE +" VIE:" + VIE + " SAB:" + SAB);

            if (LUN <2)
            {
                cbFAHDia1.Items.Add("Lunes");
            }
            if (MAR < 2)
            {
                cbFAHDia1.Items.Add("Martes");
            }
            if (MIE < 2)
            {
                cbFAHDia1.Items.Add("Miercoles");
            }
            if (JUE < 2)
            {
                cbFAHDia1.Items.Add("Jueves");
            }
            if (VIE < 2)
            {
                cbFAHDia1.Items.Add("Viernes");
            }
            if (SAB < 2)
            {
                cbFAHDia1.Items.Add("Sabado");
            }
            /*
            //Assigns subjects to combobox.
            while (reader.Read())
            {
                parametros.Add(reader["dia"].ToString());
            }
            
            //Order Number of Days
            while(!logrado)
            {
                
                foreach (string day in parametros)
                {
                    switch (opcion)
                    {
                        case 0:
                            if (day == "LUN") 
                            {
                                cbFAHDia1.Items.Add("Lunes"); 
                                founded = true;
                            }
                            break;
                        case 1:
                            if (day == "MAR")
                            {
                                cbFAHDia1.Items.Add("Martes");
                                founded = true;
                            }
                            break;
                        case 2:
                            if (day == "MIE")
                            {
                                cbFAHDia1.Items.Add("Miercoles");
                                founded = true;
                            }
                            break;
                        case 3:
                            if (day == "JUE")
                            {
                                cbFAHDia1.Items.Add("Jueves");
                                founded = true;
                            }
                            break;
                        case 4:
                            if (day == "VIE")
                            {
                                cbFAHDia1.Items.Add("Viernes");
                                founded = true;
                            }
                            break;
                        case 5:
                            if (day == "SAB")
                            {
                                cbFAHDia1.Items.Add("Sabado");
                                founded = true;
                            }
                            break;
                        default:
                            logrado = true;
                            break;
                    }

                }
                if (founded) { opcion++; founded = false; }
            }
            */
        }

        private void cbFAHCarrera_TextChanged(object sender, EventArgs e)
        {
            cbFAHMateria.Items.Clear();
            cbFAHDia1.Items.Clear();
            cbFAHHora1.Items.Clear();
            cbFAHHora2.Items.Clear();
            cbFAHDia2.Items.Clear();
            cbFAHHora3.Items.Clear();
            cbFAHHora4.Items.Clear();
            ComboBoxMateria();
        }

        private void cbFAHCampus_TextChanged(object sender, EventArgs e)
        {
            cbFAHPeriodo.Items.Clear();
            cbFAHGrupo.Items.Clear();
            cbFAHCarrera.Items.Clear();
            cbFAHMateria.Items.Clear();
            cbFAHDia1.Items.Clear();
            cbFAHHora1.Items.Clear();
            cbFAHHora2.Items.Clear();
            cbFAHDia2.Items.Clear();
            cbFAHHora3.Items.Clear();
            cbFAHHora4.Items.Clear();
            ComboBoxPeriodo();
        }

        private void cbFAHPeriodo_TextChanged(object sender, EventArgs e)
        {
            cbFAHGrupo.Items.Clear();
            cbFAHCarrera.Items.Clear();
            cbFAHMateria.Items.Clear();
            cbFAHDia1.Items.Clear();
            cbFAHHora1.Items.Clear();
            cbFAHHora2.Items.Clear();
            cbFAHDia2.Items.Clear();
            cbFAHHora3.Items.Clear();
            cbFAHHora4.Items.Clear();
            ComboBoxGrupo();
        }

        private void cbFAHGrupo_TextChanged(object sender, EventArgs e)
        {
            cbFAHCarrera.Items.Clear();
            cbFAHMateria.Items.Clear();
            cbFAHDia1.Items.Clear();
            cbFAHHora1.Items.Clear();
            cbFAHHora2.Items.Clear();
            cbFAHDia2.Items.Clear();
            cbFAHHora3.Items.Clear();
            cbFAHHora4.Items.Clear();
            ComboBoxCarrera();
        }

        private void cbFAHMateria_TextChanged(object sender, EventArgs e)
        {

            cbFAHDia1.Items.Clear();
            cbFAHHora1.Items.Clear();
            cbFAHHora2.Items.Clear();
            cbFAHDia2.Items.Clear();
            cbFAHHora3.Items.Clear();
            cbFAHHora4.Items.Clear();
            ComboBoxDia1();
        }
    }
}
