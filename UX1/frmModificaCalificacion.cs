﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Kardex.Layers;

namespace Kardex
{
    public partial class frmModificaCalificacion : Form
    {
        BL bl = new BL();
        public frmModificaCalificacion()
        {
            InitializeComponent();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            string carrera = txtAlumno.Text.ToString().Trim();
            
            bool estatus;

            //Validacion a TxtBox y ComboBox
            /*
            if(txtAlumno.Text =="" || cbEstatus.SelectedIndex == -1)
            {
                MessageBox.Show("Favor de llenar toda la informacion solicitada", "Advertencia", MessageBoxButtons.OK);
            }
            else
            {
                if (cbEstatus.SelectedIndex == 0)
                {
                    estatus = true;
                }
                else
                {
                    estatus = false;
                }
                bl.AltaCarrera(carrera, estatus);

                txtAlumno.Text = String.Empty;
                cbEstatus.SelectedIndex = -1;
            }  
            */
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TxtCarrera_TextChanged(object sender, EventArgs e)
        {
            if (txtAlumno.Text.Length >50)
            {

            }
        }
    }
}
