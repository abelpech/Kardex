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
            bool founded = false;
            //Obtains and reads all days.
            List<string> parametros = new List<string>();
            List<string> Dias = new List<string>();
            DataTableReader reader = db.ExcQryDt("select distinct dia from horario").CreateDataReader();

            //Assigns subjects to combobox.
            while (reader.Read())
            {
                parametros.Add(reader["dia"].ToString());
            }
            Dias = parametros;
            int opcion = 0;
            bool logrado = false;
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
                                cbFAHDia1.Items.Add(day);
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

            

        }

        private void cbFAHCarrera_TextChanged(object sender, EventArgs e)
        {
            ComboBoxMateria();
        }
    }
}