﻿using System;
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
            HabilitarODeshabilitarBoton();


        }

        private void CambiarGuardarABorrar()
        {
            btnGuardar.Text = "Borrar";
            btnGuardar.Enabled = true;
        }
        private void CambiarBorrarAGuardar()
        {
            btnGuardar.Text = "Guardar";
            btnGuardar.Enabled = true;
        }
        private void HabilitarODeshabilitarBoton()
        {
            if (cbFAHCampus.Text != "" && cbFAHHora2.Text != "" && cbFAHHora4.Text != "")
            {
                btnGuardar.Enabled = true;
                switch (btnGuardar.Text)
                {
                    case "Guardar":
                        btnGuardar.BackColor = Color.Green;
                        break;

                    case "Borrar":
                        btnGuardar.BackColor = Color.Red;
                        break;
                }
            }
            else
            {
                btnGuardar.Enabled = false;
                btnGuardar.BackColor = Color.Gray;
            }
        }
        private void LimpiarTodo()
        {
            cbFAHCampus.Items.Clear();
            cbFAHPeriodo.Items.Clear();
            cbFAHCarrera.Items.Clear();
            cbFAHGrupo.Items.Clear();
            cbFAHMateria.Items.Clear();
            cbFAHDia1.Items.Clear();
            cbFAHDia2.Items.Clear();
            cbFAHHora1.Items.Clear();
            cbFAHHora2.Items.Clear();
            cbFAHHora3.Items.Clear();
            cbFAHHora4.Items.Clear();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (btnGuardar.Text == "Guardar")
            {
                if ((cbFAHDia1.Text == cbFAHDia2.Text) && (cbFAHHora1.Text == cbFAHHora3.Text) && (cbFAHHora2.Text == cbFAHHora4.Text))
                {
                    MessageBox.Show("Alerta: No se puede establecer dos dias en iguales en el mismo horario para la materia.");
                }
                else
                {
                    //Creates a parameters list to send into SP
                    List<string> parametros = new List<string>();
                    parametros.Add(cbFAHCampus.Text);
                    parametros.Add(cbFAHPeriodo.Text);
                    parametros.Add(cbFAHCarrera.Text);
                    parametros.Add(cbFAHGrupo.Text);
                    parametros.Add(cbFAHMateria.Text);
                    parametros.Add(ObtenerNombreDeDiasCompleto(cbFAHDia1.Text, 2));
                    parametros.Add(ObtenerNombreDeDiasCompleto(cbFAHDia2.Text, 2));
                    parametros.Add(cbFAHHora1.Text);
                    parametros.Add(cbFAHHora2.Text);
                    parametros.Add(cbFAHHora3.Text);
                    parametros.Add(cbFAHHora4.Text);

                    db.ExecSP("SPAltaHorario", parametros);

                    cbFAHMateria.Text = "";
                }
            }
            else if(btnGuardar.Text == "Borrar")
            {
                //Creates a parameters list to send into SP
                List<string> parametros = new List<string>();
                parametros.Add(cbFAHCampus.Text);
                parametros.Add(cbFAHPeriodo.Text);
                parametros.Add(cbFAHCarrera.Text);
                parametros.Add(cbFAHGrupo.Text);
                parametros.Add(cbFAHMateria.Text);
                parametros.Add(ObtenerNombreDeDiasCompleto(cbFAHDia1.Text, 2));
                parametros.Add(ObtenerNombreDeDiasCompleto(cbFAHDia2.Text, 2));
                parametros.Add(cbFAHHora1.Text);
                parametros.Add(cbFAHHora2.Text);
                parametros.Add(cbFAHHora3.Text);
                parametros.Add(cbFAHHora4.Text);

                db.ExecSP("SPBajaHorario", parametros);

                cbFAHMateria.Text = "";
            }
        }

        private void ComboBoxCarrera() 
        {
            //Obtains and reads all the subjects related to a career.
            List<string> parametros = new List<string>();
            parametros.Add(cbFAHGrupo.Text);
            DataTableReader reader = db.SCAN_WHERE("carrera",1,"where activo=1").CreateDataReader();

            while (reader.Read())
            {
                cbFAHCarrera.Items.Add(reader["carrera"].ToString());
            }
        }

        private void ComboBoxHora1()
        {
            bool activo1 = false;
            //Obtains and reads all the subjects related to a career.
            List<string> parametros = new List<string>();
            parametros.Add(cbFAHCampus.Text);
            parametros.Add(cbFAHPeriodo.Text);
            parametros.Add(cbFAHGrupo.Text);
            parametros.Add(cbFAHCarrera.Text);
            parametros.Add(cbFAHMateria.Text);
            switch (cbFAHDia1.Text)
            {
                case "Lunes":
                    parametros.Add("LUN");
                    break;
                case "Martes":
                    parametros.Add("MAR");
                    break;
                case "Miercoles":
                    parametros.Add("MIE");
                    break;
                case "Jueves":
                    parametros.Add("JUE");
                    break;
                case "Viernes":
                    parametros.Add("VIE");
                    break;
                case "Sabado":
                    parametros.Add("SAB");
                    break;
            }
            
            DataTableReader reader = db.ExecSP("SPHoras_Dias_Materia_Carrera_Campus", parametros).CreateDataReader();

            if (reader.HasRows)
            {
                cbFAHHora1.Enabled = false;
                //Assigns subjects to combobox.
                while (reader.Read())
                {
                    cbFAHHora1.Items.Add(reader["horainicio1"].ToString());
                    cbFAHHora2.Items.Add(reader["horafinal1"].ToString());

                }
                if (cbFAHHora1.Items.Count > 0 && cbFAHHora2.Items.Count > 0)
                {
                    cbFAHHora1.SelectedIndex = 0;
                    cbFAHHora2.SelectedIndex = 0;
                }
            }
            else
            {
                
                cbFAHHora1.Enabled = true;
                parametros.Clear();
                parametros.Add(cbFAHGrupo.Text);
                parametros.Add(ObtenerNombreDeDiasCompleto(cbFAHDia1.Text,2));
                parametros.Add("1");
                DataTableReader reader3 = db.ExecSP("SPHorarioHabilGrupo1", parametros).CreateDataReader();
                if (reader3.HasRows)
                {
                    while (reader3.Read())
                    {

                        cbFAHHora1.Items.Add(reader3["horainicio"].ToString());
                        cbFAHHora2.Items.Add(reader3["horafinal"].ToString());

                    }
                    
                }
                reader3.Close();
            }
        }
        private void ComboBoxHora2()
        {
            //Obtains and reads all the subjects related to a career.
            List<string> parametros = new List<string>();
            parametros.Add(cbFAHCampus.Text);
            parametros.Add(cbFAHPeriodo.Text);
            parametros.Add(cbFAHGrupo.Text);
            parametros.Add(cbFAHCarrera.Text);
            parametros.Add(cbFAHMateria.Text);
            switch (cbFAHDia2.Text)
            {
                case "Lunes":
                    parametros.Add("LUN");
                    break;
                case "Martes":
                    parametros.Add("MAR");
                    break;
                case "Miercoles":
                    parametros.Add("MIE");
                    break;
                case "Jueves":
                    parametros.Add("JUE");
                    break;
                case "Viernes":
                    parametros.Add("VIE");
                    break;
                case "Sabado":
                    parametros.Add("SAB");
                    break;
            }
            
            DataTableReader reader = db.ExecSP("SPHoras_Dias_Materia_Carrera_Campus", parametros).CreateDataReader();
            if (reader.HasRows)
            {
                cbFAHHora3.Enabled = false;

                //Establece el boton de Guardar a Borrar
                CambiarGuardarABorrar();
                //Assigns subjects to combobox.
                while (reader.Read())
                {

                    cbFAHHora3.Items.Add(reader["horainicio2"].ToString());
                    cbFAHHora4.Items.Add(reader["horafinal2"].ToString());

                }
                if (cbFAHHora3.Items.Count > 0 && cbFAHHora4.Items.Count > 0)
                {
                    cbFAHHora3.SelectedIndex = 0;
                    cbFAHHora4.SelectedIndex = 0;
                }
            }
            else
            {
                CambiarBorrarAGuardar();
                cbFAHHora3.Enabled = true;
                parametros.Clear();
                parametros.Add(cbFAHGrupo.Text);
                parametros.Add(ObtenerNombreDeDiasCompleto(cbFAHDia2.Text, 2));
                parametros.Add("1");
                DataTableReader reader3 = db.ExecSP("SPHorarioHabilGrupo1", parametros).CreateDataReader();
                if (reader3.HasRows)
                {
                    while (reader3.Read())
                    {

                        cbFAHHora3.Items.Add(reader3["horainicio"].ToString());
                        cbFAHHora4.Items.Add(reader3["horafinal"].ToString());

                    }
                }
                
                reader3.Close();
            }
            
        }

        private void ComboBoxMateria()
        {
            //Obtains and reads all the subjects related to a career.
            List<string> parametros = new List<string>();
            parametros.Add(cbFAHGrupo.Text);
            DataTableReader reader = db.ExecSP("SPMat_Ca_Gru_Pe_Cam", parametros).CreateDataReader();

            //Assigns subjects to combobox.
            while (reader.Read())
            {
                
                cbFAHMateria.Items.Add(reader["materia"].ToString());
            }
        }

        private void ComboBoxPeriodo()
        {
            //Obtains and reads all the subjects related to a career.
            List<string> parametros = new List<string>();
            DataTableReader reader = db.ExecSP("SPPeriodo_Campus", parametros).CreateDataReader();

            //Assigns subjects to combobox.
            while (reader.Read())
            {
                cbFAHPeriodo.Items.Add(reader["periodo"].ToString());
            }
            cbFAHPeriodo.SelectedIndex = 0;
            
        }
        private void ComboBoxGrupo()
        {
            //Obtains and reads all the subjects related to a career.
            List<string> parametros = new List<string>();
            parametros.Add(cbFAHCarrera.Text);
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

        /// <summary>
        /// 
        /// Obtiene el Dia completo o acorta el dia con acronimo<br/>
        /// 1: Obtener el dia completo <br/>
        /// 2: Acortar a acronimo
        /// </summary>
        /// <param name="dia">Dia para afectar.</param>
        /// <param name="opcion">Int para saber como afectar el dia (1 o 2).</param>
        private string ObtenerNombreDeDiasCompleto(string dia, int opcion)
        {
            
            switch (opcion)
            {
                case 1:
                    switch (dia)
                    {
                        case "LUN":
                            dia = "Lunes";
                            break;
                        case "MAR":
                            dia = "Martes";
                            break;
                        case "MIE":
                            dia = "Miercoles";
                            break;
                        case "JUE":
                            dia = "Jueves";
                            break;
                        case "VIE":
                            dia = "Viernes";
                            break;
                        case "SAB":
                            dia = "Sabado";
                            break;
                    }
                    break;
                case 2:
                    switch (dia)
                    {
                        case "Lunes":
                            dia = "LUN";
                            break;
                        case "Martes":
                            dia = "MAR";
                            break;
                        case "Miercoles":
                            dia = "MIE";
                            break;
                        case "Jueves":
                            dia = "JUE";
                            break;
                        case "Viernes":
                            dia = "VIE";
                            break;
                        case "Sabado":
                            dia = "SAB";
                            break;
                    }
                    break;
            }
            return dia;
        }
        private void ComboBoxDia1()
        {
            //Obtains and reads all days.
            List<string> parametros = new List<string>();
            parametros.Add(cbFAHGrupo.Text);
            parametros.Add(cbFAHMateria.Text);
            DataTableReader DiasOcup = db.ExecSP("SPDiasHorasDeUnaMateria",parametros).CreateDataReader();

            if (DiasOcup.HasRows)
            //If no more days can be added do this:
            {
                //Assigns occupied days to combobox
                while (DiasOcup.Read())
                {
                    cbFAHDia1.Items.Add(ObtenerNombreDeDiasCompleto(DiasOcup["Dia1"].ToString(), 1));
                    cbFAHDia2.Items.Add(ObtenerNombreDeDiasCompleto(DiasOcup["Dia2"].ToString(), 1));
                }
                cbFAHDia1.SelectedIndex = 0;
                cbFAHDia2.SelectedIndex = 0;
                cbFAHDia1.Enabled = false;
                cbFAHDia2.Enabled = false;
            }
            else
            //If more days can be added do this
            {
                cbFAHDia1.Enabled = true;
                cbFAHDia2.Enabled = true;

                //Establish days for cbDia1 and cbDia2
                parametros.Clear();
                parametros.Add(cbFAHGrupo.Text);
                parametros.Add("");
                parametros.Add("2");

                DataTableReader d1 = db.ExecSP("SPHorarioHabilGrupo1", parametros).CreateDataReader();

                while (d1.Read())
                {
                    cbFAHDia1.Items.Add(ObtenerNombreDeDiasCompleto(d1["dia"].ToString(), 1));
                    cbFAHDia2.Items.Add(ObtenerNombreDeDiasCompleto(d1["dia"].ToString(), 1));
                }
            }
        }

        private void cbFAHCarrera_TextChanged(object sender, EventArgs e)
        {
            cbFAHGrupo.Items.Clear();
            cbFAHMateria.Items.Clear();
            cbFAHDia1.Items.Clear();
            cbFAHHora1.Items.Clear();
            cbFAHHora2.Items.Clear();
            cbFAHDia2.Items.Clear();
            cbFAHHora3.Items.Clear();
            cbFAHHora4.Items.Clear();
            ComboBoxGrupo();
            HabilitarODeshabilitarBoton();

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
            HabilitarODeshabilitarBoton();
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
            ComboBoxCarrera();
            HabilitarODeshabilitarBoton();
        }

        private void cbFAHGrupo_TextChanged(object sender, EventArgs e)
        {
            cbFAHMateria.Items.Clear();
            cbFAHDia1.Items.Clear();
            cbFAHHora1.Items.Clear();
            cbFAHHora2.Items.Clear();
            cbFAHDia2.Items.Clear();
            cbFAHHora3.Items.Clear();
            cbFAHHora4.Items.Clear();
            ComboBoxMateria();
            HabilitarODeshabilitarBoton();
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
            HabilitarODeshabilitarBoton();
        }

        private void cbFAHDia1_TextChanged(object sender, EventArgs e)
        {
            cbFAHHora1.Items.Clear();
            cbFAHHora2.Items.Clear();
            ComboBoxHora1();
            HabilitarODeshabilitarBoton();
        }

        private void cbFAHDia2_TextChanged(object sender, EventArgs e)
        {
            cbFAHHora3.Items.Clear();
            cbFAHHora4.Items.Clear();
            ComboBoxHora2();
            HabilitarODeshabilitarBoton();
        }

        private void cbFAHHora1_TextChanged(object sender, EventArgs e)
        {
            cbFAHHora2.SelectedIndex = cbFAHHora1.SelectedIndex;
            HabilitarODeshabilitarBoton();
        }

        private void cbFAHHora3_TextChanged(object sender, EventArgs e)
        {
            cbFAHHora4.SelectedIndex = cbFAHHora3.SelectedIndex;
            HabilitarODeshabilitarBoton();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
