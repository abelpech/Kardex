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
        dbConn db = new dbConn();
        //string usuarioLogin = Permisos.usuario;
        string usuarioLogin = "Ray Parra";

        public frmAltaHorarioMaestro()
        {
            InitializeComponent();
            lbUsuario.Text = usuarioLogin;
            ComboBoxCampus();

        }

        #region Function returning Campus available for specific user

        public void ComboBoxCampus()
        {
            SqlConnection conn;
            string host = Dns.GetHostName();
            conn = new SqlConnection("server =  " + host + "; database=kardex ; integrated security = true");
            cbCampus.Items.Clear();
            conn.Open();
            string query = "SPComboBoxCampus '" + usuarioLogin + "'";
            SqlCommand comando = new SqlCommand(query, conn);
            SqlDataReader reader = comando.ExecuteReader();

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
        #endregion


        #region Function returning Maestro available for specific Campus

        public void ComboBoxCampusMaestro()
        {
            if (cbCampus.SelectedIndex == -1)
            {
                cbMaestro.Items.Add("Seleccione Campus");
            }
            else
            {
                SqlConnection conn;
                string host = Dns.GetHostName();
                conn = new SqlConnection("server =  " + host + "; database=kardex ; integrated security = true");
                string campus = cbCampus.GetItemText(cbCampus.SelectedItem);
                cbMaestro.Items.Clear();
                conn.Open();
                string query = "SPComboBoxCampusMaestro '" + campus + "'";
                SqlCommand comando = new SqlCommand(query, conn);
                SqlDataReader reader = comando.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        cbMaestro.Items.Add(reader["Maestro"].ToString());

                    }
                }
                else
                {
                    cbMaestro.Items.Add("No existe MAESTROS disponibles");
                }

                conn.Close();
            }

        }
        #endregion


        #region Function to close current window

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion


        #region Consult Button brings SPdvgHorarios and SPdvgMaterias and sends information to UpdateMateria to update dgvMaterias accordingly

        private void btnConsulta_Click(object sender, EventArgs e)
        {
            if (cbCampus.SelectedIndex == -1 || cbMaestro.SelectedIndex == -1)
            {
                MessageBox.Show("Selecciona Campus y Maestro", "Aviso", MessageBoxButtons.OK);
            }
            else
            {
                string campus = this.cbCampus.GetItemText(this.cbCampus.SelectedItem);
                string maestro = this.cbMaestro.GetItemText(this.cbMaestro.SelectedItem);

                //DVGMaterias - Materias PENDIENTE por asignar MAESTROS
                DataTable dt2 = bl.SPdgvMaterias(campus, maestro);
                if (dt2.Rows.Count > 0)
                {
                    dgvMaterias.DataSource = dt2;
                    dgvMaterias.AllowUserToAddRows = false;
                }
                else
                {
                    dgvMaterias.DataSource = dt2;
                    dt2.Rows.Clear();
                    MessageBox.Show("No hay materias sin maestro disponibles", "Aviso", MessageBoxButtons.OK);
                }

                //DVGHorario - ACTUALMENTE asignadas al MAESTRO
                DataTable dt = bl.SPdgvHorarios(campus, maestro);
                if (dt.Rows.Count > 0)
                {
                    dgvHorario.DataSource = dt;
                    dgvHorario.AllowUserToAddRows = false;

                    //Validacion Materias PENDIENTE por asignar MAESTRO para especifico MAESTRO

                    #region Declaration of Variables

                    string materia1 = String.Empty, dia1 = String.Empty, inicio1 = String.Empty, dia2 = String.Empty, inicio2 = String.Empty, grupo1 = String.Empty, carrera1 = String.Empty;
                    string materia2 = String.Empty, dia3 = String.Empty, inicio3 = String.Empty, dia4 = String.Empty, inicio4 = String.Empty, grupo2 = String.Empty, carrera2 = String.Empty;
                    string materia3 = String.Empty, dia5 = String.Empty, inicio5 = String.Empty, dia6 = String.Empty, inicio6 = String.Empty, grupo3 = String.Empty, carrera3 = String.Empty;
                    string materia4 = String.Empty, dia7 = String.Empty, inicio7 = String.Empty, dia8 = String.Empty, inicio8 = String.Empty, grupo4 = String.Empty, carrera4 = String.Empty;
                    string materia5 = String.Empty, dia9 = String.Empty, inicio9 = String.Empty, dia10 = String.Empty, inicio10 = String.Empty, grupo5 = String.Empty, carrera5 = String.Empty;
                    string materia6 = String.Empty, dia11 = String.Empty, inicio11 = String.Empty, dia12 = String.Empty, inicio12 = String.Empty, grupo6 = String.Empty, carrera6 = String.Empty;
                    string materia7 = String.Empty, dia13 = String.Empty, inicio13 = String.Empty, dia14 = String.Empty, inicio14 = String.Empty, grupo7 = String.Empty, carrera7 = String.Empty;
                    string materia8 = String.Empty, dia15 = String.Empty, inicio15 = String.Empty, dia16 = String.Empty, inicio16 = String.Empty, grupo8 = String.Empty, carrera8 = String.Empty;
                    string materia9 = String.Empty, dia17 = String.Empty, inicio17 = String.Empty, dia18 = String.Empty, inicio18 = String.Empty, grupo9 = String.Empty, carrera9 = String.Empty;
                    string materia10 = String.Empty, dia19 = String.Empty, inicio19 = String.Empty, dia20 = String.Empty, inicio20 = String.Empty, grupo10 = String.Empty, carrera10 = String.Empty;
                    #endregion


                    string indexdgvHorario = dgvHorario.Rows.Count.ToString();
                    switch (Convert.ToInt32(indexdgvHorario))
                    {
                        #region CASES for SWITCH
                        case 0:
                            
                            break;
                        case 1:
                            materia1 = dgvHorario.Rows[0].Cells[0].Value.ToString();
                            dia1 = dgvHorario.Rows[0].Cells[1].Value.ToString();
                            inicio1 = dgvHorario.Rows[0].Cells[2].Value.ToString();
                            dia2 = dgvHorario.Rows[0].Cells[4].Value.ToString();
                            inicio2 = dgvHorario.Rows[0].Cells[5].Value.ToString();
                            grupo1 = dgvHorario.Rows[0].Cells[7].Value.ToString();
                            carrera1 = dgvHorario.Rows[0].Cells[8].Value.ToString();

                            updateMateria(materia1, dia1, inicio1, dia2, inicio2, grupo1, carrera1,
                                            materia2, dia3, inicio3, dia4, inicio4, grupo2, carrera2,
                                            materia3, dia5, inicio5, dia6, inicio6, grupo3, carrera3,
                                            materia4, dia7, inicio7, dia8, inicio8, grupo4, carrera4,
                                            materia5, dia9, inicio9, dia10, inicio10, grupo5, carrera5,
                                            materia6, dia11, inicio11, dia12, inicio12, grupo6, carrera6,
                                            materia7, dia13, inicio13, dia14, inicio14, grupo7, carrera7,
                                            materia8, dia15, inicio15, dia16, inicio16, grupo8, carrera8,
                                            materia9, dia17, inicio17, dia18, inicio18, grupo9, carrera9,
                                            materia10, dia19, inicio19, dia20, inicio20, grupo10, carrera10
                                           );
                            break;
                        case 2:

                            materia1 = dgvHorario.Rows[0].Cells[0].Value.ToString();
                            dia1 = dgvHorario.Rows[0].Cells[1].Value.ToString();
                            inicio1 = dgvHorario.Rows[0].Cells[2].Value.ToString();
                            dia2 = dgvHorario.Rows[0].Cells[4].Value.ToString();
                            inicio2 = dgvHorario.Rows[0].Cells[5].Value.ToString();
                            grupo1 = dgvHorario.Rows[0].Cells[7].Value.ToString();
                            carrera1 = dgvHorario.Rows[0].Cells[8].Value.ToString();

                            materia2 = dgvHorario.Rows[1].Cells[0].Value.ToString();
                            dia3 = dgvHorario.Rows[1].Cells[1].Value.ToString();
                            inicio3 = dgvHorario.Rows[1].Cells[2].Value.ToString();
                            dia4 = dgvHorario.Rows[1].Cells[4].Value.ToString();
                            inicio4 = dgvHorario.Rows[1].Cells[5].Value.ToString();
                            grupo2 = dgvHorario.Rows[1].Cells[7].Value.ToString();
                            carrera2 = dgvHorario.Rows[1].Cells[8].Value.ToString();

                            updateMateria(materia1, dia1, inicio1, dia2, inicio2, grupo1, carrera1,
                                            materia2, dia3, inicio3, dia4, inicio4, grupo2, carrera2,
                                            materia3, dia5, inicio5, dia6, inicio6, grupo3, carrera3,
                                            materia4, dia7, inicio7, dia8, inicio8, grupo4, carrera4,
                                            materia5, dia9, inicio9, dia10, inicio10, grupo5, carrera5,
                                            materia6, dia11, inicio11, dia12, inicio12, grupo6, carrera6,
                                            materia7, dia13, inicio13, dia14, inicio14, grupo7, carrera7,
                                            materia8, dia15, inicio15, dia16, inicio16, grupo8, carrera8,
                                            materia9, dia17, inicio17, dia18, inicio18, grupo9, carrera9,
                                            materia10, dia19, inicio19, dia20, inicio20, grupo10, carrera10
                                           );
                            break;

                        case 3:

                            materia1 = dgvHorario.Rows[0].Cells[0].Value.ToString();
                            dia1 = dgvHorario.Rows[0].Cells[1].Value.ToString();
                            inicio1 = dgvHorario.Rows[0].Cells[2].Value.ToString();
                            dia2 = dgvHorario.Rows[0].Cells[4].Value.ToString();
                            inicio2 = dgvHorario.Rows[0].Cells[5].Value.ToString();
                            grupo1 = dgvHorario.Rows[0].Cells[7].Value.ToString();
                            carrera1 = dgvHorario.Rows[0].Cells[8].Value.ToString();

                            materia2 = dgvHorario.Rows[1].Cells[0].Value.ToString();
                            dia3 = dgvHorario.Rows[1].Cells[1].Value.ToString();
                            inicio3 = dgvHorario.Rows[1].Cells[2].Value.ToString();
                            dia4 = dgvHorario.Rows[1].Cells[4].Value.ToString();
                            inicio4 = dgvHorario.Rows[1].Cells[5].Value.ToString();
                            grupo2 = dgvHorario.Rows[1].Cells[7].Value.ToString();
                            carrera2 = dgvHorario.Rows[1].Cells[8].Value.ToString();

                            materia3 = dgvHorario.Rows[2].Cells[0].Value.ToString();
                            dia5 = dgvHorario.Rows[2].Cells[1].Value.ToString();
                            inicio5 = dgvHorario.Rows[2].Cells[2].Value.ToString();
                            dia6 = dgvHorario.Rows[2].Cells[4].Value.ToString();
                            inicio6 = dgvHorario.Rows[2].Cells[5].Value.ToString();
                            grupo3 = dgvHorario.Rows[2].Cells[7].Value.ToString();
                            carrera3 = dgvHorario.Rows[2].Cells[8].Value.ToString();

                            updateMateria(materia1, dia1, inicio1, dia2, inicio2, grupo1, carrera1,
                                            materia2, dia3, inicio3, dia4, inicio4, grupo2, carrera2,
                                            materia3, dia5, inicio5, dia6, inicio6, grupo3, carrera3,
                                            materia4, dia7, inicio7, dia8, inicio8, grupo4, carrera4,
                                            materia5, dia9, inicio9, dia10, inicio10, grupo5, carrera5,
                                            materia6, dia11, inicio11, dia12, inicio12, grupo6, carrera6,
                                            materia7, dia13, inicio13, dia14, inicio14, grupo7, carrera7,
                                            materia8, dia15, inicio15, dia16, inicio16, grupo8, carrera8,
                                            materia9, dia17, inicio17, dia18, inicio18, grupo9, carrera9,
                                            materia10, dia19, inicio19, dia20, inicio20, grupo10, carrera10
                                           );
                            break;

                        case 4:

                            materia1 = dgvHorario.Rows[0].Cells[0].Value.ToString();
                            dia1 = dgvHorario.Rows[0].Cells[1].Value.ToString();
                            inicio1 = dgvHorario.Rows[0].Cells[2].Value.ToString();
                            dia2 = dgvHorario.Rows[0].Cells[4].Value.ToString();
                            inicio2 = dgvHorario.Rows[0].Cells[5].Value.ToString();
                            grupo1 = dgvHorario.Rows[0].Cells[7].Value.ToString();
                            carrera1 = dgvHorario.Rows[0].Cells[8].Value.ToString();

                            materia2 = dgvHorario.Rows[1].Cells[0].Value.ToString();
                            dia3 = dgvHorario.Rows[1].Cells[1].Value.ToString();
                            inicio3 = dgvHorario.Rows[1].Cells[2].Value.ToString();
                            dia4 = dgvHorario.Rows[1].Cells[4].Value.ToString();
                            inicio4 = dgvHorario.Rows[1].Cells[5].Value.ToString();
                            grupo2 = dgvHorario.Rows[1].Cells[7].Value.ToString();
                            carrera2 = dgvHorario.Rows[1].Cells[8].Value.ToString();

                            materia3 = dgvHorario.Rows[2].Cells[0].Value.ToString();
                            dia5 = dgvHorario.Rows[2].Cells[1].Value.ToString();
                            inicio5 = dgvHorario.Rows[2].Cells[2].Value.ToString();
                            dia6 = dgvHorario.Rows[2].Cells[4].Value.ToString();
                            inicio6 = dgvHorario.Rows[2].Cells[5].Value.ToString();
                            grupo3 = dgvHorario.Rows[2].Cells[7].Value.ToString();
                            carrera3 = dgvHorario.Rows[2].Cells[8].Value.ToString();

                            materia4 = dgvHorario.Rows[3].Cells[0].Value.ToString();
                            dia7 = dgvHorario.Rows[3].Cells[1].Value.ToString();
                            inicio7 = dgvHorario.Rows[3].Cells[2].Value.ToString();
                            dia8 = dgvHorario.Rows[3].Cells[4].Value.ToString();
                            inicio8 = dgvHorario.Rows[3].Cells[5].Value.ToString();
                            grupo4 = dgvHorario.Rows[3].Cells[7].Value.ToString();
                            carrera4 = dgvHorario.Rows[3].Cells[8].Value.ToString();

                            updateMateria(materia1, dia1, inicio1, dia2, inicio2, grupo1, carrera1,
                                            materia2, dia3, inicio3, dia4, inicio4, grupo2, carrera2,
                                            materia3, dia5, inicio5, dia6, inicio6, grupo3, carrera3,
                                            materia4, dia7, inicio7, dia8, inicio8, grupo4, carrera4,
                                            materia5, dia9, inicio9, dia10, inicio10, grupo5, carrera5,
                                            materia6, dia11, inicio11, dia12, inicio12, grupo6, carrera6,
                                            materia7, dia13, inicio13, dia14, inicio14, grupo7, carrera7,
                                            materia8, dia15, inicio15, dia16, inicio16, grupo8, carrera8,
                                            materia9, dia17, inicio17, dia18, inicio18, grupo9, carrera9,
                                            materia10, dia19, inicio19, dia20, inicio20, grupo10, carrera10
                                           );
                            break;


                        case 5:

                            materia1 = dgvHorario.Rows[0].Cells[0].Value.ToString();
                            dia1 = dgvHorario.Rows[0].Cells[1].Value.ToString();
                            inicio1 = dgvHorario.Rows[0].Cells[2].Value.ToString();
                            dia2 = dgvHorario.Rows[0].Cells[4].Value.ToString();
                            inicio2 = dgvHorario.Rows[0].Cells[5].Value.ToString();
                            grupo1 = dgvHorario.Rows[0].Cells[7].Value.ToString();
                            carrera1 = dgvHorario.Rows[0].Cells[8].Value.ToString();

                            materia2 = dgvHorario.Rows[1].Cells[0].Value.ToString();
                            dia3 = dgvHorario.Rows[1].Cells[1].Value.ToString();
                            inicio3 = dgvHorario.Rows[1].Cells[2].Value.ToString();
                            dia4 = dgvHorario.Rows[1].Cells[4].Value.ToString();
                            inicio4 = dgvHorario.Rows[1].Cells[5].Value.ToString();
                            grupo2 = dgvHorario.Rows[1].Cells[7].Value.ToString();
                            carrera2 = dgvHorario.Rows[1].Cells[8].Value.ToString();

                            materia3 = dgvHorario.Rows[2].Cells[0].Value.ToString();
                            dia5 = dgvHorario.Rows[2].Cells[1].Value.ToString();
                            inicio5 = dgvHorario.Rows[2].Cells[2].Value.ToString();
                            dia6 = dgvHorario.Rows[2].Cells[4].Value.ToString();
                            inicio6 = dgvHorario.Rows[2].Cells[5].Value.ToString();
                            grupo3 = dgvHorario.Rows[2].Cells[7].Value.ToString();
                            carrera3 = dgvHorario.Rows[2].Cells[8].Value.ToString();

                            materia4 = dgvHorario.Rows[3].Cells[0].Value.ToString();
                            dia7 = dgvHorario.Rows[3].Cells[1].Value.ToString();
                            inicio7 = dgvHorario.Rows[3].Cells[2].Value.ToString();
                            dia8 = dgvHorario.Rows[3].Cells[4].Value.ToString();
                            inicio8 = dgvHorario.Rows[3].Cells[5].Value.ToString();
                            grupo4 = dgvHorario.Rows[3].Cells[7].Value.ToString();
                            carrera4 = dgvHorario.Rows[3].Cells[8].Value.ToString();

                            materia5 = dgvHorario.Rows[3].Cells[0].Value.ToString();
                            dia9 = dgvHorario.Rows[3].Cells[1].Value.ToString();
                            inicio9 = dgvHorario.Rows[3].Cells[2].Value.ToString();
                            dia10 = dgvHorario.Rows[3].Cells[4].Value.ToString();
                            inicio10 = dgvHorario.Rows[3].Cells[5].Value.ToString();
                            grupo5 = dgvHorario.Rows[3].Cells[7].Value.ToString();
                            carrera5 = dgvHorario.Rows[3].Cells[8].Value.ToString();

                            updateMateria(materia1, dia1, inicio1, dia2, inicio2, grupo1, carrera1,
                                            materia2, dia3, inicio3, dia4, inicio4, grupo2, carrera2,
                                            materia3, dia5, inicio5, dia6, inicio6, grupo3, carrera3,
                                            materia4, dia7, inicio7, dia8, inicio8, grupo4, carrera4,
                                            materia5, dia9, inicio9, dia10, inicio10, grupo5, carrera5,
                                            materia6, dia11, inicio11, dia12, inicio12, grupo6, carrera6,
                                            materia7, dia13, inicio13, dia14, inicio14, grupo7, carrera7,
                                            materia8, dia15, inicio15, dia16, inicio16, grupo8, carrera8,
                                            materia9, dia17, inicio17, dia18, inicio18, grupo9, carrera9,
                                            materia10, dia19, inicio19, dia20, inicio20, grupo10, carrera10
                                           );
                            break;


                        case 6:

                            materia1 = dgvHorario.Rows[0].Cells[0].Value.ToString();
                            dia1 = dgvHorario.Rows[0].Cells[1].Value.ToString();
                            inicio1 = dgvHorario.Rows[0].Cells[2].Value.ToString();
                            dia2 = dgvHorario.Rows[0].Cells[4].Value.ToString();
                            inicio2 = dgvHorario.Rows[0].Cells[5].Value.ToString();
                            grupo1 = dgvHorario.Rows[0].Cells[7].Value.ToString();
                            carrera1 = dgvHorario.Rows[0].Cells[8].Value.ToString();

                            materia2 = dgvHorario.Rows[1].Cells[0].Value.ToString();
                            dia3 = dgvHorario.Rows[1].Cells[1].Value.ToString();
                            inicio3 = dgvHorario.Rows[1].Cells[2].Value.ToString();
                            dia4 = dgvHorario.Rows[1].Cells[4].Value.ToString();
                            inicio4 = dgvHorario.Rows[1].Cells[5].Value.ToString();
                            grupo2 = dgvHorario.Rows[1].Cells[7].Value.ToString();
                            carrera2 = dgvHorario.Rows[1].Cells[8].Value.ToString();

                            materia3 = dgvHorario.Rows[2].Cells[0].Value.ToString();
                            dia5 = dgvHorario.Rows[2].Cells[1].Value.ToString();
                            inicio5 = dgvHorario.Rows[2].Cells[2].Value.ToString();
                            dia6 = dgvHorario.Rows[2].Cells[4].Value.ToString();
                            inicio6 = dgvHorario.Rows[2].Cells[5].Value.ToString();
                            grupo3 = dgvHorario.Rows[2].Cells[7].Value.ToString();
                            carrera3 = dgvHorario.Rows[2].Cells[8].Value.ToString();

                            materia4 = dgvHorario.Rows[3].Cells[0].Value.ToString();
                            dia7 = dgvHorario.Rows[3].Cells[1].Value.ToString();
                            inicio7 = dgvHorario.Rows[3].Cells[2].Value.ToString();
                            dia8 = dgvHorario.Rows[3].Cells[4].Value.ToString();
                            inicio8 = dgvHorario.Rows[3].Cells[5].Value.ToString();
                            grupo4 = dgvHorario.Rows[3].Cells[7].Value.ToString();
                            carrera4 = dgvHorario.Rows[3].Cells[8].Value.ToString();

                            materia5 = dgvHorario.Rows[3].Cells[0].Value.ToString();
                            dia9 = dgvHorario.Rows[3].Cells[1].Value.ToString();
                            inicio9 = dgvHorario.Rows[3].Cells[2].Value.ToString();
                            dia10 = dgvHorario.Rows[3].Cells[4].Value.ToString();
                            inicio10 = dgvHorario.Rows[3].Cells[5].Value.ToString();
                            grupo5 = dgvHorario.Rows[3].Cells[7].Value.ToString();
                            carrera5 = dgvHorario.Rows[3].Cells[8].Value.ToString();

                            materia6 = dgvHorario.Rows[3].Cells[0].Value.ToString();
                            dia11 = dgvHorario.Rows[3].Cells[1].Value.ToString();
                            inicio11 = dgvHorario.Rows[3].Cells[2].Value.ToString();
                            dia12 = dgvHorario.Rows[3].Cells[4].Value.ToString();
                            inicio12 = dgvHorario.Rows[3].Cells[5].Value.ToString();
                            grupo6 = dgvHorario.Rows[3].Cells[7].Value.ToString();
                            carrera6 = dgvHorario.Rows[3].Cells[8].Value.ToString();

                            updateMateria(materia1, dia1, inicio1, dia2, inicio2, grupo1, carrera1,
                                            materia2, dia3, inicio3, dia4, inicio4, grupo2, carrera2,
                                            materia3, dia5, inicio5, dia6, inicio6, grupo3, carrera3,
                                            materia4, dia7, inicio7, dia8, inicio8, grupo4, carrera4,
                                            materia5, dia9, inicio9, dia10, inicio10, grupo5, carrera5,
                                            materia6, dia11, inicio11, dia12, inicio12, grupo6, carrera6,
                                            materia7, dia13, inicio13, dia14, inicio14, grupo7, carrera7,
                                            materia8, dia15, inicio15, dia16, inicio16, grupo8, carrera8,
                                            materia9, dia17, inicio17, dia18, inicio18, grupo9, carrera9,
                                            materia10, dia19, inicio19, dia20, inicio20, grupo10, carrera10
                                           );
                            break;

                        case 7:

                            materia1 = dgvHorario.Rows[0].Cells[0].Value.ToString();
                            dia1 = dgvHorario.Rows[0].Cells[1].Value.ToString();
                            inicio1 = dgvHorario.Rows[0].Cells[2].Value.ToString();
                            dia2 = dgvHorario.Rows[0].Cells[4].Value.ToString();
                            inicio2 = dgvHorario.Rows[0].Cells[5].Value.ToString();
                            grupo1 = dgvHorario.Rows[0].Cells[7].Value.ToString();
                            carrera1 = dgvHorario.Rows[0].Cells[8].Value.ToString();

                            materia2 = dgvHorario.Rows[1].Cells[0].Value.ToString();
                            dia3 = dgvHorario.Rows[1].Cells[1].Value.ToString();
                            inicio3 = dgvHorario.Rows[1].Cells[2].Value.ToString();
                            dia4 = dgvHorario.Rows[1].Cells[4].Value.ToString();
                            inicio4 = dgvHorario.Rows[1].Cells[5].Value.ToString();
                            grupo2 = dgvHorario.Rows[1].Cells[7].Value.ToString();
                            carrera2 = dgvHorario.Rows[1].Cells[8].Value.ToString();

                            materia3 = dgvHorario.Rows[2].Cells[0].Value.ToString();
                            dia5 = dgvHorario.Rows[2].Cells[1].Value.ToString();
                            inicio5 = dgvHorario.Rows[2].Cells[2].Value.ToString();
                            dia6 = dgvHorario.Rows[2].Cells[4].Value.ToString();
                            inicio6 = dgvHorario.Rows[2].Cells[5].Value.ToString();
                            grupo3 = dgvHorario.Rows[2].Cells[7].Value.ToString();
                            carrera3 = dgvHorario.Rows[2].Cells[8].Value.ToString();

                            materia4 = dgvHorario.Rows[3].Cells[0].Value.ToString();
                            dia7 = dgvHorario.Rows[3].Cells[1].Value.ToString();
                            inicio7 = dgvHorario.Rows[3].Cells[2].Value.ToString();
                            dia8 = dgvHorario.Rows[3].Cells[4].Value.ToString();
                            inicio8 = dgvHorario.Rows[3].Cells[5].Value.ToString();
                            grupo4 = dgvHorario.Rows[3].Cells[7].Value.ToString();
                            carrera4 = dgvHorario.Rows[3].Cells[8].Value.ToString();

                            materia5 = dgvHorario.Rows[3].Cells[0].Value.ToString();
                            dia9 = dgvHorario.Rows[3].Cells[1].Value.ToString();
                            inicio9 = dgvHorario.Rows[3].Cells[2].Value.ToString();
                            dia10 = dgvHorario.Rows[3].Cells[4].Value.ToString();
                            inicio10 = dgvHorario.Rows[3].Cells[5].Value.ToString();
                            grupo5 = dgvHorario.Rows[3].Cells[7].Value.ToString();
                            carrera5 = dgvHorario.Rows[3].Cells[8].Value.ToString();

                            materia6 = dgvHorario.Rows[3].Cells[0].Value.ToString();
                            dia11 = dgvHorario.Rows[3].Cells[1].Value.ToString();
                            inicio11 = dgvHorario.Rows[3].Cells[2].Value.ToString();
                            dia12 = dgvHorario.Rows[3].Cells[4].Value.ToString();
                            inicio12 = dgvHorario.Rows[3].Cells[5].Value.ToString();
                            grupo6 = dgvHorario.Rows[3].Cells[7].Value.ToString();
                            carrera6 = dgvHorario.Rows[3].Cells[8].Value.ToString();

                            materia7 = dgvHorario.Rows[3].Cells[0].Value.ToString();
                            dia13 = dgvHorario.Rows[3].Cells[1].Value.ToString();
                            inicio13 = dgvHorario.Rows[3].Cells[2].Value.ToString();
                            dia14 = dgvHorario.Rows[3].Cells[4].Value.ToString();
                            inicio14 = dgvHorario.Rows[3].Cells[5].Value.ToString();
                            grupo7 = dgvHorario.Rows[3].Cells[7].Value.ToString();
                            carrera7 = dgvHorario.Rows[3].Cells[8].Value.ToString();

                            updateMateria(materia1, dia1, inicio1, dia2, inicio2, grupo1, carrera1,
                                            materia2, dia3, inicio3, dia4, inicio4, grupo2, carrera2,
                                            materia3, dia5, inicio5, dia6, inicio6, grupo3, carrera3,
                                            materia4, dia7, inicio7, dia8, inicio8, grupo4, carrera4,
                                            materia5, dia9, inicio9, dia10, inicio10, grupo5, carrera5,
                                            materia6, dia11, inicio11, dia12, inicio12, grupo6, carrera6,
                                            materia7, dia13, inicio13, dia14, inicio14, grupo7, carrera7,
                                            materia8, dia15, inicio15, dia16, inicio16, grupo8, carrera8,
                                            materia9, dia17, inicio17, dia18, inicio18, grupo9, carrera9,
                                            materia10, dia19, inicio19, dia20, inicio20, grupo10, carrera10
                                           );
                            break;


                        case 8:

                            materia1 = dgvHorario.Rows[0].Cells[0].Value.ToString();
                            dia1 = dgvHorario.Rows[0].Cells[1].Value.ToString();
                            inicio1 = dgvHorario.Rows[0].Cells[2].Value.ToString();
                            dia2 = dgvHorario.Rows[0].Cells[4].Value.ToString();
                            inicio2 = dgvHorario.Rows[0].Cells[5].Value.ToString();
                            grupo1 = dgvHorario.Rows[0].Cells[7].Value.ToString();
                            carrera1 = dgvHorario.Rows[0].Cells[8].Value.ToString();

                            materia2 = dgvHorario.Rows[1].Cells[0].Value.ToString();
                            dia3 = dgvHorario.Rows[1].Cells[1].Value.ToString();
                            inicio3 = dgvHorario.Rows[1].Cells[2].Value.ToString();
                            dia4 = dgvHorario.Rows[1].Cells[4].Value.ToString();
                            inicio4 = dgvHorario.Rows[1].Cells[5].Value.ToString();
                            grupo2 = dgvHorario.Rows[1].Cells[7].Value.ToString();
                            carrera2 = dgvHorario.Rows[1].Cells[8].Value.ToString();

                            materia3 = dgvHorario.Rows[2].Cells[0].Value.ToString();
                            dia5 = dgvHorario.Rows[2].Cells[1].Value.ToString();
                            inicio5 = dgvHorario.Rows[2].Cells[2].Value.ToString();
                            dia6 = dgvHorario.Rows[2].Cells[4].Value.ToString();
                            inicio6 = dgvHorario.Rows[2].Cells[5].Value.ToString();
                            grupo3 = dgvHorario.Rows[2].Cells[7].Value.ToString();
                            carrera3 = dgvHorario.Rows[2].Cells[8].Value.ToString();

                            materia4 = dgvHorario.Rows[3].Cells[0].Value.ToString();
                            dia7 = dgvHorario.Rows[3].Cells[1].Value.ToString();
                            inicio7 = dgvHorario.Rows[3].Cells[2].Value.ToString();
                            dia8 = dgvHorario.Rows[3].Cells[4].Value.ToString();
                            inicio8 = dgvHorario.Rows[3].Cells[5].Value.ToString();
                            grupo4 = dgvHorario.Rows[3].Cells[7].Value.ToString();
                            carrera4 = dgvHorario.Rows[3].Cells[8].Value.ToString();

                            materia5 = dgvHorario.Rows[3].Cells[0].Value.ToString();
                            dia9 = dgvHorario.Rows[3].Cells[1].Value.ToString();
                            inicio9 = dgvHorario.Rows[3].Cells[2].Value.ToString();
                            dia10 = dgvHorario.Rows[3].Cells[4].Value.ToString();
                            inicio10 = dgvHorario.Rows[3].Cells[5].Value.ToString();
                            grupo5 = dgvHorario.Rows[3].Cells[7].Value.ToString();
                            carrera5 = dgvHorario.Rows[3].Cells[8].Value.ToString();

                            materia6 = dgvHorario.Rows[3].Cells[0].Value.ToString();
                            dia11 = dgvHorario.Rows[3].Cells[1].Value.ToString();
                            inicio11 = dgvHorario.Rows[3].Cells[2].Value.ToString();
                            dia12 = dgvHorario.Rows[3].Cells[4].Value.ToString();
                            inicio12 = dgvHorario.Rows[3].Cells[5].Value.ToString();
                            grupo6 = dgvHorario.Rows[3].Cells[7].Value.ToString();
                            carrera6 = dgvHorario.Rows[3].Cells[8].Value.ToString();

                            materia7 = dgvHorario.Rows[3].Cells[0].Value.ToString();
                            dia13 = dgvHorario.Rows[3].Cells[1].Value.ToString();
                            inicio13 = dgvHorario.Rows[3].Cells[2].Value.ToString();
                            dia14 = dgvHorario.Rows[3].Cells[4].Value.ToString();
                            inicio14 = dgvHorario.Rows[3].Cells[5].Value.ToString();
                            grupo7 = dgvHorario.Rows[3].Cells[7].Value.ToString();
                            carrera7 = dgvHorario.Rows[3].Cells[8].Value.ToString();


                            materia8 = dgvHorario.Rows[3].Cells[0].Value.ToString();
                            dia15 = dgvHorario.Rows[3].Cells[1].Value.ToString();
                            inicio15 = dgvHorario.Rows[3].Cells[2].Value.ToString();
                            dia16 = dgvHorario.Rows[3].Cells[4].Value.ToString();
                            inicio16 = dgvHorario.Rows[3].Cells[5].Value.ToString();
                            grupo8 = dgvHorario.Rows[3].Cells[7].Value.ToString();
                            carrera8 = dgvHorario.Rows[3].Cells[8].Value.ToString();

                            updateMateria(materia1, dia1, inicio1, dia2, inicio2, grupo1, carrera1,
                                            materia2, dia3, inicio3, dia4, inicio4, grupo2, carrera2,
                                            materia3, dia5, inicio5, dia6, inicio6, grupo3, carrera3,
                                            materia4, dia7, inicio7, dia8, inicio8, grupo4, carrera4,
                                            materia5, dia9, inicio9, dia10, inicio10, grupo5, carrera5,
                                            materia6, dia11, inicio11, dia12, inicio12, grupo6, carrera6,
                                            materia7, dia13, inicio13, dia14, inicio14, grupo7, carrera7,
                                            materia8, dia15, inicio15, dia16, inicio16, grupo8, carrera8,
                                            materia9, dia17, inicio17, dia18, inicio18, grupo9, carrera9,
                                            materia10, dia19, inicio19, dia20, inicio20, grupo10, carrera10
                                           );
                            break;

                        case 9:

                            materia1 = dgvHorario.Rows[0].Cells[0].Value.ToString();
                            dia1 = dgvHorario.Rows[0].Cells[1].Value.ToString();
                            inicio1 = dgvHorario.Rows[0].Cells[2].Value.ToString();
                            dia2 = dgvHorario.Rows[0].Cells[4].Value.ToString();
                            inicio2 = dgvHorario.Rows[0].Cells[5].Value.ToString();
                            grupo1 = dgvHorario.Rows[0].Cells[7].Value.ToString();
                            carrera1 = dgvHorario.Rows[0].Cells[8].Value.ToString();

                            materia2 = dgvHorario.Rows[1].Cells[0].Value.ToString();
                            dia3 = dgvHorario.Rows[1].Cells[1].Value.ToString();
                            inicio3 = dgvHorario.Rows[1].Cells[2].Value.ToString();
                            dia4 = dgvHorario.Rows[1].Cells[4].Value.ToString();
                            inicio4 = dgvHorario.Rows[1].Cells[5].Value.ToString();
                            grupo2 = dgvHorario.Rows[1].Cells[7].Value.ToString();
                            carrera2 = dgvHorario.Rows[1].Cells[8].Value.ToString();

                            materia3 = dgvHorario.Rows[2].Cells[0].Value.ToString();
                            dia5 = dgvHorario.Rows[2].Cells[1].Value.ToString();
                            inicio5 = dgvHorario.Rows[2].Cells[2].Value.ToString();
                            dia6 = dgvHorario.Rows[2].Cells[4].Value.ToString();
                            inicio6 = dgvHorario.Rows[2].Cells[5].Value.ToString();
                            grupo3 = dgvHorario.Rows[2].Cells[7].Value.ToString();
                            carrera3 = dgvHorario.Rows[2].Cells[8].Value.ToString();

                            materia4 = dgvHorario.Rows[3].Cells[0].Value.ToString();
                            dia7 = dgvHorario.Rows[3].Cells[1].Value.ToString();
                            inicio7 = dgvHorario.Rows[3].Cells[2].Value.ToString();
                            dia8 = dgvHorario.Rows[3].Cells[4].Value.ToString();
                            inicio8 = dgvHorario.Rows[3].Cells[5].Value.ToString();
                            grupo4 = dgvHorario.Rows[3].Cells[7].Value.ToString();
                            carrera4 = dgvHorario.Rows[3].Cells[8].Value.ToString();

                            materia5 = dgvHorario.Rows[3].Cells[0].Value.ToString();
                            dia9 = dgvHorario.Rows[3].Cells[1].Value.ToString();
                            inicio9 = dgvHorario.Rows[3].Cells[2].Value.ToString();
                            dia10 = dgvHorario.Rows[3].Cells[4].Value.ToString();
                            inicio10 = dgvHorario.Rows[3].Cells[5].Value.ToString();
                            grupo5 = dgvHorario.Rows[3].Cells[7].Value.ToString();
                            carrera5 = dgvHorario.Rows[3].Cells[8].Value.ToString();

                            materia6 = dgvHorario.Rows[3].Cells[0].Value.ToString();
                            dia11 = dgvHorario.Rows[3].Cells[1].Value.ToString();
                            inicio11 = dgvHorario.Rows[3].Cells[2].Value.ToString();
                            dia12 = dgvHorario.Rows[3].Cells[4].Value.ToString();
                            inicio12 = dgvHorario.Rows[3].Cells[5].Value.ToString();
                            grupo6 = dgvHorario.Rows[3].Cells[7].Value.ToString();
                            carrera6 = dgvHorario.Rows[3].Cells[8].Value.ToString();

                            materia7 = dgvHorario.Rows[3].Cells[0].Value.ToString();
                            dia13 = dgvHorario.Rows[3].Cells[1].Value.ToString();
                            inicio13 = dgvHorario.Rows[3].Cells[2].Value.ToString();
                            dia14 = dgvHorario.Rows[3].Cells[4].Value.ToString();
                            inicio14 = dgvHorario.Rows[3].Cells[5].Value.ToString();
                            grupo7 = dgvHorario.Rows[3].Cells[7].Value.ToString();
                            carrera7 = dgvHorario.Rows[3].Cells[8].Value.ToString();


                            materia8 = dgvHorario.Rows[3].Cells[0].Value.ToString();
                            dia15 = dgvHorario.Rows[3].Cells[1].Value.ToString();
                            inicio15 = dgvHorario.Rows[3].Cells[2].Value.ToString();
                            dia16 = dgvHorario.Rows[3].Cells[4].Value.ToString();
                            inicio16 = dgvHorario.Rows[3].Cells[5].Value.ToString();
                            grupo8 = dgvHorario.Rows[3].Cells[7].Value.ToString();
                            carrera8 = dgvHorario.Rows[3].Cells[8].Value.ToString();


                            materia9 = dgvHorario.Rows[3].Cells[0].Value.ToString();
                            dia17 = dgvHorario.Rows[3].Cells[1].Value.ToString();
                            inicio17 = dgvHorario.Rows[3].Cells[2].Value.ToString();
                            dia18 = dgvHorario.Rows[3].Cells[4].Value.ToString();
                            inicio18 = dgvHorario.Rows[3].Cells[5].Value.ToString();
                            grupo9 = dgvHorario.Rows[3].Cells[7].Value.ToString();
                            carrera9 = dgvHorario.Rows[3].Cells[8].Value.ToString();

                            updateMateria(materia1, dia1, inicio1, dia2, inicio2, grupo1, carrera1,
                                            materia2, dia3, inicio3, dia4, inicio4, grupo2, carrera2,
                                            materia3, dia5, inicio5, dia6, inicio6, grupo3, carrera3,
                                            materia4, dia7, inicio7, dia8, inicio8, grupo4, carrera4,
                                            materia5, dia9, inicio9, dia10, inicio10, grupo5, carrera5,
                                            materia6, dia11, inicio11, dia12, inicio12, grupo6, carrera6,
                                            materia7, dia13, inicio13, dia14, inicio14, grupo7, carrera7,
                                            materia8, dia15, inicio15, dia16, inicio16, grupo8, carrera8,
                                            materia9, dia17, inicio17, dia18, inicio18, grupo9, carrera9,
                                            materia10, dia19, inicio19, dia20, inicio20, grupo10, carrera10
                                           );
                            break;


                        case 10:

                            materia1 = dgvHorario.Rows[0].Cells[0].Value.ToString();
                            dia1 = dgvHorario.Rows[0].Cells[1].Value.ToString();
                            inicio1 = dgvHorario.Rows[0].Cells[2].Value.ToString();
                            dia2 = dgvHorario.Rows[0].Cells[4].Value.ToString();
                            inicio2 = dgvHorario.Rows[0].Cells[5].Value.ToString();
                            grupo1 = dgvHorario.Rows[0].Cells[7].Value.ToString();
                            carrera1 = dgvHorario.Rows[0].Cells[8].Value.ToString();

                            materia2 = dgvHorario.Rows[1].Cells[0].Value.ToString();
                            dia3 = dgvHorario.Rows[1].Cells[1].Value.ToString();
                            inicio3 = dgvHorario.Rows[1].Cells[2].Value.ToString();
                            dia4 = dgvHorario.Rows[1].Cells[4].Value.ToString();
                            inicio4 = dgvHorario.Rows[1].Cells[5].Value.ToString();
                            grupo2 = dgvHorario.Rows[1].Cells[7].Value.ToString();
                            carrera2 = dgvHorario.Rows[1].Cells[8].Value.ToString();

                            materia3 = dgvHorario.Rows[2].Cells[0].Value.ToString();
                            dia5 = dgvHorario.Rows[2].Cells[1].Value.ToString();
                            inicio5 = dgvHorario.Rows[2].Cells[2].Value.ToString();
                            dia6 = dgvHorario.Rows[2].Cells[4].Value.ToString();
                            inicio6 = dgvHorario.Rows[2].Cells[5].Value.ToString();
                            grupo3 = dgvHorario.Rows[2].Cells[7].Value.ToString();
                            carrera3 = dgvHorario.Rows[2].Cells[8].Value.ToString();

                            materia4 = dgvHorario.Rows[3].Cells[0].Value.ToString();
                            dia7 = dgvHorario.Rows[3].Cells[1].Value.ToString();
                            inicio7 = dgvHorario.Rows[3].Cells[2].Value.ToString();
                            dia8 = dgvHorario.Rows[3].Cells[4].Value.ToString();
                            inicio8 = dgvHorario.Rows[3].Cells[5].Value.ToString();
                            grupo4 = dgvHorario.Rows[3].Cells[7].Value.ToString();
                            carrera4 = dgvHorario.Rows[3].Cells[8].Value.ToString();

                            materia5 = dgvHorario.Rows[3].Cells[0].Value.ToString();
                            dia9 = dgvHorario.Rows[3].Cells[1].Value.ToString();
                            inicio9 = dgvHorario.Rows[3].Cells[2].Value.ToString();
                            dia10 = dgvHorario.Rows[3].Cells[4].Value.ToString();
                            inicio10 = dgvHorario.Rows[3].Cells[5].Value.ToString();
                            grupo5 = dgvHorario.Rows[3].Cells[7].Value.ToString();
                            carrera5 = dgvHorario.Rows[3].Cells[8].Value.ToString();

                            materia6 = dgvHorario.Rows[3].Cells[0].Value.ToString();
                            dia11 = dgvHorario.Rows[3].Cells[1].Value.ToString();
                            inicio11 = dgvHorario.Rows[3].Cells[2].Value.ToString();
                            dia12 = dgvHorario.Rows[3].Cells[4].Value.ToString();
                            inicio12 = dgvHorario.Rows[3].Cells[5].Value.ToString();
                            grupo6 = dgvHorario.Rows[3].Cells[7].Value.ToString();
                            carrera6 = dgvHorario.Rows[3].Cells[8].Value.ToString();

                            materia7 = dgvHorario.Rows[3].Cells[0].Value.ToString();
                            dia13 = dgvHorario.Rows[3].Cells[1].Value.ToString();
                            inicio13 = dgvHorario.Rows[3].Cells[2].Value.ToString();
                            dia14 = dgvHorario.Rows[3].Cells[4].Value.ToString();
                            inicio14 = dgvHorario.Rows[3].Cells[5].Value.ToString();
                            grupo7 = dgvHorario.Rows[3].Cells[7].Value.ToString();
                            carrera7 = dgvHorario.Rows[3].Cells[8].Value.ToString();


                            materia8 = dgvHorario.Rows[3].Cells[0].Value.ToString();
                            dia15 = dgvHorario.Rows[3].Cells[1].Value.ToString();
                            inicio15 = dgvHorario.Rows[3].Cells[2].Value.ToString();
                            dia16 = dgvHorario.Rows[3].Cells[4].Value.ToString();
                            inicio16 = dgvHorario.Rows[3].Cells[5].Value.ToString();
                            grupo8 = dgvHorario.Rows[3].Cells[7].Value.ToString();
                            carrera8 = dgvHorario.Rows[3].Cells[8].Value.ToString();


                            materia9 = dgvHorario.Rows[3].Cells[0].Value.ToString();
                            dia17 = dgvHorario.Rows[3].Cells[1].Value.ToString();
                            inicio17 = dgvHorario.Rows[3].Cells[2].Value.ToString();
                            dia18 = dgvHorario.Rows[3].Cells[4].Value.ToString();
                            inicio18 = dgvHorario.Rows[3].Cells[5].Value.ToString();
                            grupo9 = dgvHorario.Rows[3].Cells[7].Value.ToString();
                            carrera9 = dgvHorario.Rows[3].Cells[8].Value.ToString();

                            materia10 = dgvHorario.Rows[3].Cells[0].Value.ToString();
                            dia19 = dgvHorario.Rows[3].Cells[1].Value.ToString();
                            inicio19 = dgvHorario.Rows[3].Cells[2].Value.ToString();
                            dia20 = dgvHorario.Rows[3].Cells[4].Value.ToString();
                            inicio20 = dgvHorario.Rows[3].Cells[5].Value.ToString();
                            grupo10 = dgvHorario.Rows[3].Cells[7].Value.ToString();
                            carrera10 = dgvHorario.Rows[3].Cells[8].Value.ToString();

                            updateMateria(materia1, dia1, inicio1, dia2, inicio2, grupo1, carrera1,
                                            materia2, dia3, inicio3, dia4, inicio4, grupo2, carrera2,
                                            materia3, dia5, inicio5, dia6, inicio6, grupo3, carrera3,
                                            materia4, dia7, inicio7, dia8, inicio8, grupo4, carrera4,
                                            materia5, dia9, inicio9, dia10, inicio10, grupo5, carrera5,
                                            materia6, dia11, inicio11, dia12, inicio12, grupo6, carrera6,
                                            materia7, dia13, inicio13, dia14, inicio14, grupo7, carrera7,
                                            materia8, dia15, inicio15, dia16, inicio16, grupo8, carrera8,
                                            materia9, dia17, inicio17, dia18, inicio18, grupo9, carrera9,
                                            materia10, dia19, inicio19, dia20, inicio20, grupo10, carrera10
                                           );
                            break;

                            #endregion
                    }
                }
                else
                {
                    dgvHorario.DataSource = dt;
                    dt.Rows.Clear();
                    MessageBox.Show("No existen MATERIAS asignadas", "Aviso", MessageBoxButtons.OK);
                }

            }

        }

        #endregion

        #region Function for ADD Button

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

            crearColumnas();
            //Copy data from Materias to Horario
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

            //Clear DataGridView
            DataTable dt2 = bl.SPdgvMaterias("", "");
            dgvMaterias.DataSource = dt2;
            dt2.Rows.Clear();

            MessageBox.Show("Seleccion GUARDAR y CONSULTA nuevamente", "Aviso!", MessageBoxButtons.OK);

        }
        #endregion


        #region crearColumnas para dgvHorario
        public void crearColumnas()
        {
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
            dgvHorario.AllowUserToAddRows = false;
        }
        #endregion


        #region Function updating dgvMaterias with ALL classes not assigned to teachers based on ALREADY ASSIGNED CLASSES

        public void updateMateria(
        #region Parameters for this Function

               string materia1, string dia1, string inicio1, string dia2, string inicio2, string grupo1, string carrera1,
               string materia2, string dia3, string inicio3, string dia4, string inicio4, string grupo2, string carrera2,
               string materia3, string dia5, string inicio5, string dia6, string inicio6, string grupo3, string carrera3,
               string materia4, string dia7, string inicio7, string dia8, string inicio8, string grupo4, string carrera4,
               string materia5, string dia9, string inicio9, string dia10, string inicio10, string grupo5, string carrera5,
               string materia6, string dia11, string inicio11, string dia12, string inicio12, string grupo6, string carrera6,
               string materia7, string dia13, string inicio13, string dia14, string inicio14, string grupo7, string carrera7,
               string materia8, string dia15, string inicio15, string dia16, string inicio16, string grupo8, string carrera8,
               string materia9, string dia17, string inicio17, string dia18, string inicio18, string grupo9, string carrera9,
               string materia10, string dia19, string inicio19, string dia20, string inicio20, string grupo10, string carrera10
        #endregion
            )
        {
            List<string> parametros = new List<string>();
            string campus = this.cbCampus.GetItemText(this.cbCampus.SelectedItem);

            #region Add Parameters to LIST

            parametros.Add(campus);

            parametros.Add(materia1);
            parametros.Add(dia1);
            parametros.Add(inicio1);
            parametros.Add(dia2);
            parametros.Add(inicio2);
            parametros.Add(grupo1);
            parametros.Add(carrera1);

            parametros.Add(materia2);
            parametros.Add(dia3);
            parametros.Add(inicio3);
            parametros.Add(dia4);
            parametros.Add(inicio4);
            parametros.Add(grupo2);
            parametros.Add(carrera2);

            parametros.Add(materia3);
            parametros.Add(dia5);
            parametros.Add(inicio5);
            parametros.Add(dia6);
            parametros.Add(inicio6);
            parametros.Add(grupo3);
            parametros.Add(carrera3);

            parametros.Add(materia4);
            parametros.Add(dia7);
            parametros.Add(inicio7);
            parametros.Add(dia8);
            parametros.Add(inicio8);
            parametros.Add(grupo4);
            parametros.Add(carrera4);

            parametros.Add(materia5);
            parametros.Add(dia9);
            parametros.Add(inicio9);
            parametros.Add(dia10);
            parametros.Add(inicio10);
            parametros.Add(grupo5);
            parametros.Add(carrera5);

            parametros.Add(materia6);
            parametros.Add(dia11);
            parametros.Add(inicio11);
            parametros.Add(dia12);
            parametros.Add(inicio12);
            parametros.Add(grupo6);
            parametros.Add(carrera6);

            parametros.Add(materia7);
            parametros.Add(dia13);
            parametros.Add(inicio13);
            parametros.Add(dia14);
            parametros.Add(inicio14);
            parametros.Add(grupo7);
            parametros.Add(carrera7);

            parametros.Add(materia8);
            parametros.Add(dia15);
            parametros.Add(inicio15);
            parametros.Add(dia16);
            parametros.Add(inicio16);
            parametros.Add(grupo8);
            parametros.Add(carrera8);

            parametros.Add(materia9);
            parametros.Add(dia17);
            parametros.Add(inicio17);
            parametros.Add(dia18);
            parametros.Add(inicio18);
            parametros.Add(grupo9);
            parametros.Add(carrera9);

            parametros.Add(materia10);
            parametros.Add(dia19);
            parametros.Add(inicio19);
            parametros.Add(dia20);
            parametros.Add(inicio20);
            parametros.Add(grupo10);
            parametros.Add(carrera10);

            #endregion

            DataTable dt = db.ExecSP("SPUpdateMaterias", parametros);

            if (dt.Rows.Count > 0)
            {
                dgvMaterias.DataSource = dt;
                dgvMaterias.AllowUserToAddRows = false;
            }
            else
            {
                dgvMaterias.DataSource = dt;
                dt.Rows.Clear();
                MessageBox.Show("No hay materias sin maestro disponibles", "Aviso", MessageBoxButtons.OK);
            }
        }

        #endregion


        #region Activate Maestro when Campus changes

        private void cbCampus_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBoxCampusMaestro();
        }
        #endregion

        #region Eliminar Evento
        private void btnEliminar_Click(object sender, EventArgs e)
        {

            int vacio = dgvHorario.Rows.Count;

            if(vacio == 0)
            {
                MessageBox.Show("La tabla se encuentra vacia", "Advertencia",MessageBoxButtons.OK);
            }
            else
            {
                string materia1 = String.Empty, dia1 = String.Empty, inicio1 = String.Empty, final1 = String.Empty,
                dia2 = String.Empty, inicio2 = String.Empty, final2 = String.Empty, grupo1 = String.Empty, carrera1 = String.Empty, periodo = String.Empty;

                for (int i = 0; i < dgvHorario.SelectedRows.Count; i++)
                {
                    materia1 = dgvHorario.SelectedRows[i].Cells[0].Value.ToString();
                    dia1 = dgvHorario.SelectedRows[i].Cells[1].Value.ToString();
                    inicio1 = dgvHorario.SelectedRows[i].Cells[2].Value.ToString();
                    final1 = dgvHorario.SelectedRows[i].Cells[3].Value.ToString();
                    dia2 = dgvHorario.SelectedRows[i].Cells[4].Value.ToString();
                    inicio2 = dgvHorario.SelectedRows[i].Cells[5].Value.ToString();
                    final2 = dgvHorario.SelectedRows[i].Cells[6].Value.ToString();
                    grupo1 = dgvHorario.SelectedRows[i].Cells[7].Value.ToString();
                    carrera1 = dgvHorario.SelectedRows[i].Cells[8].Value.ToString();
                    periodo = dgvHorario.SelectedRows[i].Cells[9].Value.ToString();

                    dgvHorario.Rows.RemoveAt(dgvHorario.SelectedRows[i].Index);

                    borrarMateriaMaestro(materia1, dia1, inicio1, final1, dia2, inicio2, final2, grupo1, carrera1, periodo);
                }
                btnLimpiar_Click(sender, e);
            }   
        }
        #endregion

        #region LIMPIAR

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            cbCampus.SelectedIndex = -1;
            cbMaestro.SelectedIndex = -1;
            DataTable dt2 = bl.SPdgvMaterias("", "");

            dgvMaterias.DataSource = dt2;
            dt2.Rows.Clear();

            DataTable dt = bl.SPdgvHorarios("", "");

            dgvHorario.DataSource = dt;
            dt2.Rows.Clear();

        }

        #endregion

        #region borrarMateriaMaestro function
        public void borrarMateriaMaestro( string materia1, string dia1, string inicio1, string final1, string dia2, string inicio2, string final2,
            string grupo1, string carrera1, string periodo)
        {

            List<string> parametros = new List<string>();
            parametros.Add(materia1);
            parametros.Add(grupo1);
            parametros.Add(carrera1);
            parametros.Add(periodo);
            parametros.Add(dia1);
            parametros.Add(inicio1);
            parametros.Add(dia2);
            parametros.Add(inicio2);

            DataTable dt = db.ExecSP("SPBajaMateriaMaestro", parametros);

            
        }
        #endregion


        #region Guardar Evento
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            int vacio = dgvHorario.SelectedRows.Count;

            if (vacio == 0)
            {
                MessageBox.Show("Seleccione la Materia", "Advertencia", MessageBoxButtons.OK);
            }
            else
            {
                string materia1 = String.Empty, dia1 = String.Empty, inicio1 = String.Empty, final1 = String.Empty,
                dia2 = String.Empty, inicio2 = String.Empty, final2 = String.Empty, grupo1 = String.Empty, carrera1 = String.Empty, periodo = String.Empty;

                for (int i = 0; i < dgvHorario.SelectedRows.Count; i++)
                {
                    materia1 = dgvHorario.SelectedRows[i].Cells[0].Value.ToString();
                    dia1 = dgvHorario.SelectedRows[i].Cells[1].Value.ToString();
                    inicio1 = dgvHorario.SelectedRows[i].Cells[2].Value.ToString();
                    final1 = dgvHorario.SelectedRows[i].Cells[3].Value.ToString();
                    dia2 = dgvHorario.SelectedRows[i].Cells[4].Value.ToString();
                    inicio2 = dgvHorario.SelectedRows[i].Cells[5].Value.ToString();
                    final2 = dgvHorario.SelectedRows[i].Cells[6].Value.ToString();
                    grupo1 = dgvHorario.SelectedRows[i].Cells[7].Value.ToString();
                    carrera1 = dgvHorario.SelectedRows[i].Cells[8].Value.ToString();
                    periodo = dgvHorario.SelectedRows[i].Cells[9].Value.ToString();

                    dgvHorario.Rows.RemoveAt(dgvHorario.SelectedRows[i].Index);

                    guardarMateriaMaestro(materia1, dia1, inicio1, final1, dia2, inicio2, final2, grupo1, carrera1, periodo);
                }
                btnLimpiar_Click(sender, e);
            }
        }
        #endregion


        #region GuardarMateriaMaestro function

        public void guardarMateriaMaestro(string materia1, string dia1, string inicio1, string final1, string dia2, string inicio2, string final2,
            string grupo1, string carrera1, string periodo)
        {
            string maestro = this.cbMaestro.GetItemText(this.cbMaestro.SelectedItem);

            List<string> parametros = new List<string>();
            parametros.Add(materia1);
            parametros.Add(grupo1);
            parametros.Add(carrera1);
            parametros.Add(periodo);
            parametros.Add(dia1);
            parametros.Add(inicio1);
            parametros.Add(dia2);
            parametros.Add(inicio2);
            parametros.Add(maestro);

            DataTable dt = db.ExecSP("SPAltaMateriaMaestro", parametros);

        }

        #endregion
    }
}
