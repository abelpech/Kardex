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
using UX1.Validaciones;


namespace UX1
{
    public partial class frmConsultaMaestro : Form
    {
        KeyPressValidation kpv = new KeyPressValidation();
        BL bl = new BL();
        string data = string.Empty;
        int matri = 0;
        public frmConsultaMaestro()
        {
            InitializeComponent();
        }

        private void BtnConsulta_Click(object sender, EventArgs e)
        {
            int matricula;
            try
            {
                matricula = Convert.ToInt32(txtMatricula.Text);
            }
            catch
            {
                matricula = 0;
            }
            
            string maestro = txtMaestro.Text.Trim();
            bool estatus = false;

            //Establece el status activo o inactivo
            if (comboEstatus.SelectedIndex == 0)
                estatus = true;
            else if(comboEstatus.SelectedIndex == 1)
                estatus = false;


            if ((comboEstatus.SelectedIndex == 0 || comboEstatus.SelectedIndex == 1))
            {

                DataTable dt = bl.ConsultaMaestro(matricula, maestro, estatus);
                if (dt.Rows.Count > 0)
                {
                    dgvCarrera.DataSource = dt;
                    //No permitir agregar datos adicionales
                    dgvCarrera.AllowUserToAddRows = false;
                }
                else
                {
                    MessageBox.Show("No hay maestros activos con los datos especificados", "Aviso", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("Favor de especificar el Maestro y/o seleccionar un tipo de ESTATUS", "Aviso", MessageBoxButtons.OK);
            }
            txtMaestro.Text = maestro;
        }

        private void dgvCarrera_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int i = dgvCarrera.CurrentCell.RowIndex;
                dgvCarrera.Rows[i].Selected = true;

                ContextMenu m = new ContextMenu();

                MenuItem menuItem1 = new MenuItem();
                MenuItem menuItem2 = new MenuItem();
                MenuItem menuItem3 = new MenuItem();
                if (comboEstatus.SelectedIndex == 0)
                {
                    menuItem1.Text = "Baja";
                    menuItem2.Text = "Modifica";

                    m.MenuItems.Add(menuItem1);
                    m.MenuItems.Add(menuItem2);

                    menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
                    menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
                }
                else if (comboEstatus.SelectedIndex == 1)
                {
                    menuItem3.Text = "Reactivar";
                    menuItem2.Text = "Modifica";

                    m.MenuItems.Add(menuItem3);
                    m.MenuItems.Add(menuItem2);

                    menuItem3.Click += new System.EventHandler(this.menuItem3_Click);
                    menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
                }

                /*
                int currentMouseOverRow = dgvCarrera.HitTest(e.X, e.Y).RowIndex;
                m.GetContextMenu();

                if (currentMouseOverRow == 0)
                {
                    txtCarrera.Text = data;
                   
                }
                */
                m.Show(dgvCarrera, new Point(e.X, e.Y));
            }
        }

        private void dgvCarrera_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            /*
            try
            {
                matri = Convert.ToInt32(dgvCarrera["Matricula", e.RowIndex].Value);
                data = dgvCarrera["Maestro", e.RowIndex].Value.ToString();
                //MessageBox.Show(data);
            }
            catch (Exception ex)
            {

            }
            */
        }

        private void menuItem1_Click(object sender, System.EventArgs e)
        {

            bl.BajaMaestro(matri, data);
            BtnConsulta_Click(sender, e);
            data = "";

        }

        private void menuItem2_Click(object sender, System.EventArgs e)
        {
            // MessageBox.Show("Modifica");
            //pl.BtnModificacionCarrera_Click(sender, e);
            frmModificaMaestro baja = new frmModificaMaestro(matri, data);
            baja.Show();
            //data = "";
        }

        private void menuItem3_Click(object sender, System.EventArgs e)
        {
            //MessageBox.Show(data);
            bl.ModificaMaestro(matri, data, data,"",true);
            BtnConsulta_Click(sender, e);
            data = "";

        }

        private void txtMatricula_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Evita escribir el caracter si este es diferente a las teclas de control
            // o a algun numero
            if (!char.IsControl(e.KeyChar) && isNumeroValido(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        public bool isNumeroValido(Char c)
        {
            //Regresa verdadero si el caracter es diferente de los numeros entre 0 a 9
            if (!(c >= '0' && c <= '9'))
            {
                return true;
            }
            return false;
        }

        private void dgvCarrera_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvCarrera.CurrentRow.Index >= 0)
                {
                    //MessageBox.Show(Convert.ToInt32(dgvCarrera.CurrentRow.Index).ToString());
                    matri = Convert.ToInt32(dgvCarrera["Matricula", dgvCarrera.CurrentRow.Index].Value);
                    data = dgvCarrera["Maestro", Convert.ToInt32(dgvCarrera.CurrentRow.Index)].Value.ToString();
                    
                }


                //MessageBox.Show(data);
            }
            catch (Exception ex)
            {

            }
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

        private void frmConsultaMaestro_Load(object sender, EventArgs e)
        {
            /*
            //Maestro
            AutoCompleteStringCollection mycollectionMaestro = new AutoCompleteStringCollection();
            mycollectionMaestro = bl.AutoMaestro();
            txtMaestro.AutoCompleteCustomSource = mycollectionMaestro;
            */
        }
    }
}
