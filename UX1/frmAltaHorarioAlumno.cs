using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Kardex.Layers;
using UX1.Layers;

namespace UX1
{
    public partial class frmAltaHorarioAlumno : Form
    {
        dbConn db = new dbConn();
        Permisos per = new Permisos();
        public DataTable DatosOcultos = new DataTable();
        public DataTable DatosDescubiertos = new DataTable();

        public frmAltaHorarioAlumno()
        {
            InitializeComponent();
            ObtenerMateriasDisponibles();
            per.setUsuario("Marc Albrand");
            lbUser.Text = Permisos.usuario;
            SetColumnsForTables();
            
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void SetColumnsForTables()
        {
            int i = 0;
            foreach (DataGridViewTextBoxColumn colum in dgvMaterias.Columns)
            {
                DatosOcultos.Columns.Add(dgvMaterias.Columns[i].Name.ToString(), typeof(String));
                DatosDescubiertos.Columns.Add(dgvMaterias.Columns[i].Name.ToString(), typeof(String));
                i++;
            }
            foreach(DataColumn column in DatosOcultos.Columns)
            {
                System.Diagnostics.Debug.WriteLine(column.ColumnName.ToString());
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            
        }
        private void dgvMaterias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int index = dgvMaterias.CurrentRow.Index;
                dgvMaterias.Rows[index].Selected = true;
            }
            catch (Exception ex)
            {

            }
        }


        private void ObtenerMateriasDisponibles()
        {
            List<string> parametros = new List<string>();
            DataTable reader = db.ExecSP("SP_AltaHorarioAlumno_MateriasDisponibles", parametros);

            dgvMaterias.DataSource = reader;
            ObtenerHorarioDeAlumno(reader);
            dgvMaterias.ClearSelection();
        }
        private void ObtenerHorarioDeAlumno(DataTable reader)
        {
            int i = 0;
            DataTable workTable = new DataTable("dgvHorario");

            foreach (DataGridViewTextBoxColumn colum in dgvMaterias.Columns)
            {
                workTable.Columns.Add(dgvMaterias.Columns[i].Name.ToString(), typeof(String));
                i++;
            }

            dgvHorario.DataSource = workTable;

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            #region DeclaredVariables
            
            List<int> listaIndex = new List<int>();
            int i = 0;
            DataTable workTable = dgvHorario.DataSource as DataTable;

            //Prepares DataValidation with the aproppiate columns
            DataTable DataValidation = new DataTable();
            foreach (DataGridViewTextBoxColumn colum in dgvMaterias.Columns)
            {
                DataValidation.Columns.Add(dgvMaterias.Columns[i].Name.ToString(), typeof(String));
                i++;
            }
            i = 0;
            DataTable DataValidation2 = new DataTable();
            foreach (DataGridViewTextBoxColumn colum in dgvMaterias.Columns)
            {
                DataValidation2.Columns.Add(dgvMaterias.Columns[i].Name.ToString(), typeof(String));
                i++;
            }
            i = 0;
            #endregion
            foreach (DataGridViewRow row in dgvMaterias.SelectedRows)
            {
                //try
                {
                    var datarow = ((DataRowView)row.DataBoundItem).Row;
                    workTable.Rows.Add(datarow.ItemArray);

                    string[] arrayOfDays = new string[6];
                    arrayOfDays[0] = row.Cells["Dia 1"].Value.ToString();
                    arrayOfDays[1] = row.Cells["Hora 1"].Value.ToString();
                    arrayOfDays[2] = row.Cells["Hora 2"].Value.ToString();
                    arrayOfDays[3] = row.Cells["Dia 2"].Value.ToString();
                    arrayOfDays[4] = row.Cells["Hora 3"].Value.ToString();
                    arrayOfDays[5] = row.Cells["Hora 4"].Value.ToString();

                    dgvMaterias.Rows.RemoveAt(row.Index);
                    
                    foreach (DataGridViewRow r in dgvMaterias.Rows)
                    {

                        if ((r.Cells["Dia 1"].Value.ToString() == arrayOfDays[0] || r.Cells["Dia 1"].Value.ToString() == arrayOfDays[3]) &&
                            (r.Cells["Hora 1"].Value.ToString() == arrayOfDays[1] || r.Cells["Hora 1"].Value.ToString() == arrayOfDays[4]) &&
                            (r.Cells["Hora 2"].Value.ToString() == arrayOfDays[2] || r.Cells["Hora 2"].Value.ToString() == arrayOfDays[5]) &&
                            (r.Cells["Dia 2"].Value.ToString() == arrayOfDays[3] || r.Cells["Dia 2"].Value.ToString() == arrayOfDays[0]) &&
                            (r.Cells["Hora 3"].Value.ToString() == arrayOfDays[4] || r.Cells["Hora 3"].Value.ToString() == arrayOfDays[1]) &&
                            (r.Cells["Hora 4"].Value.ToString() == arrayOfDays[5] || r.Cells["Hora 4"].Value.ToString() == arrayOfDays[2]))
                        {
                            var dr = ((DataRowView)r.DataBoundItem).Row;
                            DataValidation.Rows.Add(dr.ItemArray);
                            listaIndex.Add(r.Index);
                            listaIndex.Reverse();

                            DatosOcultos.Rows.Add();
                            foreach (DataGridViewCell Cell in r.Cells)
                            {
                                DatosOcultos.Rows[DatosOcultos.Rows.Count - 1][Cell.ColumnIndex] = Cell.Value.ToString();
                            }

                            //DatosOcultos = (dataGridView1.DataSource as DataTable).Copy();
                        }
                        else
                        {
                            var dr = ((DataRowView)r.DataBoundItem).Row;
                            DataValidation2.Rows.Add(dr.ItemArray);
                            DatosDescubiertos = DataValidation2;
                        }
                        
                    }
                    dgvMaterias.DataSource = DataValidation2;
                    dgvMaterias.ClearSelection();
                }
                //catch (Exception)
                {
                   //throw;
                }
            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            
            #region DeclaredVariables
            List<int> listaIndex = new List<int>();
            int i = 0;
            DataTable workTable = dgvMaterias.DataSource as DataTable;

            //Prepares DataValidation with the aproppiate columns
            DataTable DataValidation = new DataTable();
            foreach (DataGridViewTextBoxColumn colum in dgvMaterias.Columns)
            {
                DataValidation.Columns.Add(dgvMaterias.Columns[i].Name.ToString(), typeof(String));
                i++;
            }
            i = 0;
            DataTable DataValidation2 = new DataTable();
            foreach (DataGridViewTextBoxColumn colum in dgvMaterias.Columns)
            {
                DataValidation2.Columns.Add(dgvMaterias.Columns[i].Name.ToString(), typeof(String));
                i++;
            }
            i = 0;
            #endregion
            foreach (DataGridViewRow row in dgvHorario.SelectedRows)
            {
                //try
                {
                    var datarow = ((DataRowView)row.DataBoundItem).Row;
                    workTable.Rows.Add(datarow.ItemArray);

                    string[] arrayOfDays = new string[6];
                    arrayOfDays[0] = row.Cells["Dia 1"].Value.ToString();
                    arrayOfDays[1] = row.Cells["Hora 1"].Value.ToString();
                    arrayOfDays[2] = row.Cells["Hora 2"].Value.ToString();
                    arrayOfDays[3] = row.Cells["Dia 2"].Value.ToString();
                    arrayOfDays[4] = row.Cells["Hora 3"].Value.ToString();
                    arrayOfDays[5] = row.Cells["Hora 4"].Value.ToString();

                    dgvHorario.Rows.RemoveAt(row.Index);
                    dgvHorario.ClearSelection();
                    List<DataRow> listaDROcultos = new List<DataRow>();
                    List<DataRow> listaDRDescubiertos = new List<DataRow>();
                    foreach (DataRow r in DatosOcultos.Rows)
                    {
                        //dgvHorario.DataSource = DatosOcultos;
                        
                        if ((r["Dia 1"].ToString() == arrayOfDays[0] || r["Dia 1"].ToString() == arrayOfDays[3]) &&
                            (r["Hora 1"].ToString() == arrayOfDays[1] || r["Hora 1"].ToString() == arrayOfDays[4]) &&
                            (r["Hora 2"].ToString() == arrayOfDays[2] || r["Hora 2"].ToString() == arrayOfDays[5]) &&
                            (r["Dia 2"].ToString() == arrayOfDays[3] || r["Dia 2"].ToString() == arrayOfDays[0]) &&
                            (r["Hora 3"].ToString() == arrayOfDays[4] || r["Hora 3"].ToString() == arrayOfDays[1]) &&
                            (r["Hora 4"].ToString() == arrayOfDays[5] || r["Hora 4"].ToString() == arrayOfDays[2]))
                        {
                            //var dr = ((DataRowView)r.DataBoundItem).Row;
                            workTable.Rows.Add(r.ItemArray);
                            //DataValidation.Rows.Add(r.ItemArray);
                            listaDROcultos.Add(r);
                            //DatosDescubiertos.Rows.Add(DataValidation.Rows);
                        }
                        else
                        {
                            //var dr = ((DataRowView)r.DataBoundItem).Row;
                            //DataValidation2.Rows.Add(r.ItemArray);
                            //DatosOcultos.Rows.Remove(r);
                            //DatosOcultos = DataValidation2;
                        }

                    }
                    //DatosOcultos = DataValidation2;
                    foreach (DataRow dr in listaDROcultos)
                    {
                        DatosOcultos.Rows.Remove(dr);
                    }
                }
                //catch (Exception)
                {
                    //throw;
                }
            }
        }

        private void dgvHorario_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int index = dgvHorario.CurrentRow.Index;
                dgvHorario.Rows[index].Selected = true;
            }
            catch (Exception ex)
            {

            }
        }
    }
}
