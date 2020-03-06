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
            if (//Permisos.permiso 
                1== 1)
            {

                per.setUsuario("Marc Albrand");
                per.setGrupo("08IDVA");
                per.setPeriodo("2020-1");
                per.setCarrera("Ing Desarrollo de Software");
                SetToolTipTexts();
                ObtenerMateriasDisponibles();
                lbUser.Text = Permisos.usuario;
                lbGrupo.Text = Permisos.grupo;
                SetColumnsForTables();
                QuitarMateriasAprobadas();
                EstablecerDisponibilidad_btnGuardar();
            }
            
            
        }
        private void EstablecerDisponibilidad_btnGuardar()
        {
            List<string> parametros = new List<string>();
            parametros.Add(Permisos.usuario);
            parametros.Add(Permisos.periodo);
            int Total = (db.ExecSPReturnInt("SPAltaHorarioAlumno_ContarMateriasPorAlumno", parametros));

            //Si el alumno ya tiene materias asociadas a este periodo deshabilitar el boton de guardar.
            if ((Total >=6 ) || (dgvHorario.Rows.Count == 0))
            {
                btnGuardar.Enabled = false;
                btnGuardar.BackColor = Color.Red;
                lbLimiteMaterias.Text = "Limite de materias en horario alcanzado. Vuelve en el proximo periodo.";
                dgvMaterias.Enabled = false;
                dgvHorario.Enabled = false;
            }
            else
            {
                btnGuardar.Enabled = true;
                btnGuardar.BackColor = Color.Green;
            }
        }

        private void QuitarMateriasAprobadas()
        {
            
            List<string> parametros = new List<string>();
            parametros.Add(Permisos.usuario);

            List<string> parametros2 = new List<string>();
            
            if (//Permisos.permiso 
                1== 1)
            {
                DataTableReader reader = db.ExecSP("SPAltaHorarioAlumno_MateriasCalificadasAlumno", parametros).CreateDataReader();
                DataTable MateriasCalificadasAlumno = new DataTable();
                MateriasCalificadasAlumno = ObtenerColumnasDedgvMaterias(MateriasCalificadasAlumno);
                DataTable DDescubiertos = new DataTable();
                DDescubiertos = ObtenerColumnasDedgvMaterias(DDescubiertos);
                List<DataRow> materia = new List<DataRow>();

                // Recorre las filas y celdas de dgvMaterias para alimentar el DataTable DDescubiertos
                // Con los datos de dgvMaterias
                foreach (DataGridViewRow r in dgvMaterias.Rows)
                {
                    DDescubiertos.Rows.Add();
                    foreach (DataGridViewCell Cell in r.Cells)
                    {
                        DDescubiertos.Rows[DDescubiertos.Rows.Count - 1][Cell.ColumnIndex] = Cell.Value.ToString();
                    }
                }

                // Lee todas las materias ya aprobadas por el alumno y las guarda en
                // el DataTable MateriasCalificadasAlumno
                while (reader.Read())
                {
                    int Total = 0;
                    parametros2.Add(Permisos.usuario);
                    parametros2.Add(reader["Materia"].ToString());
                    Total = db.ExecSPReturnInt("SPAltaHorarioAlumno_MateriasAprobadasAlumno", parametros2);
                    
                    if (Total >= 7)
                    {
                        //Agrega por ciclo la materia aprobada a DataTable MateriasCalificadasAlumno con un Merge
                        MateriasCalificadasAlumno.Merge(db.ExecSP("SPAltaHorarioAlumno_MateriasAprobadasAlumno", parametros2));
                    }
                    parametros2.Clear();
                }
                
                // Compara las materias aprobadas vs el catalogo disponible para crear una 
                // Lista de DataRows tipo DatosDescubiertos para saber que materias eliminar.
                foreach (DataRow row in DDescubiertos.Rows)
                {
                    
                    string[] arrayOfDays = new string[11];
                    arrayOfDays[0] = row["Materia"].ToString();
                    arrayOfDays[1] = row["Carrera"].ToString();
                    arrayOfDays[2] = row["Dia 1"].ToString();
                    arrayOfDays[3] = row["Hora 1"].ToString();
                    arrayOfDays[4] = row["Hora 2"].ToString();
                    arrayOfDays[5] = row["Dia 2"].ToString();
                    arrayOfDays[6] = row["Hora 3"].ToString();
                    arrayOfDays[7] = row["Hora 4"].ToString();
                    arrayOfDays[8] = row["Periodo"].ToString();
                    arrayOfDays[9] = row["Grupo"].ToString();
                    arrayOfDays[10] = row["Campus"].ToString();
                    foreach (DataRow r in MateriasCalificadasAlumno.Rows)
                    {   
                        if (arrayOfDays[0] == r["Materia"].ToString() && arrayOfDays[1] == r["Carrera"].ToString() &&
                            arrayOfDays[2] == r["Dia 1"].ToString() && arrayOfDays[3] == r["Hora 1"].ToString() &&
                            arrayOfDays[4] == r["Hora 2"].ToString() && arrayOfDays[5] == r["Dia 2"].ToString() &&
                            arrayOfDays[6] == r["Hora 3"].ToString() && arrayOfDays[7] == r["Hora 4"].ToString() &&
                            arrayOfDays[8] == r["Periodo"].ToString() && arrayOfDays[9] == r["Grupo"].ToString() &&
                            arrayOfDays[10] == r["Campus"].ToString())
                        {
                            materia.Add(row);
                        }
                    }
                    
                }
                //Elimina las materias aprobadas de la lista de materias disponibles
                //dependiendo que materias encontro el metodo anterior.
                foreach (DataRow r in materia)
                {
                    
                    DDescubiertos.Rows.Remove(r);
                }
                //Establece los datos de la variable global de materias disponibles
                DatosDescubiertos = DDescubiertos;
                //Establece los datos a mostrar en el DataGridView dgvMaterias
                dgvMaterias.DataSource = DatosDescubiertos;

            }
            
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
            List<string> parametros = new List<string>();
            parametros.Add(Permisos.usuario);
            parametros.Add(Permisos.periodo);
            int Total = db.ExecSPReturnInt("SPAltaHorarioAlumno_ContarMateriasPorAlumno", parametros);
            parametros.Clear();
            int contador = 0;
            
            //Si el alumno ya tiene materias asociadas a este periodo deshabilitar el boton de guardar.
            if (Total >= 6)
            {
                btnGuardar.Enabled = false;
            }
            else
            {
                //Cuenta el total de materias que el alumno planea asignarse
                foreach (DataGridViewRow row in dgvHorario.Rows)
                {
                    contador++;
                }
                //Si las materias asignadas mas las materias por asignar superan el limite de materias
                //asignables por periodo, despliega un mensaje.
                if ((contador + Total) > 6)
                {
                    MessageBox.Show("Superaste el limite de materias, solo puedes asignar: " +(6 - Total) +" materias mas.");
                    
                }
                else
                {
                    foreach (DataGridViewRow row in dgvHorario.Rows)
                    {
                        parametros.Add(Permisos.usuario);
                        parametros.Add(row.Cells["Materia"].Value.ToString());
                        parametros.Add(row.Cells["Carrera"].Value.ToString());
                        parametros.Add(row.Cells["Dia 1"].Value.ToString());
                        parametros.Add(row.Cells["Hora 1"].Value.ToString());
                        parametros.Add(row.Cells["Hora 2"].Value.ToString());
                        parametros.Add(row.Cells["Dia 2"].Value.ToString());
                        parametros.Add(row.Cells["Hora 3"].Value.ToString());
                        parametros.Add(row.Cells["Hora 4"].Value.ToString());
                        parametros.Add(row.Cells["Periodo"].Value.ToString());
                        parametros.Add(row.Cells["Grupo"].Value.ToString());
                        parametros.Add(row.Cells["Campus"].Value.ToString());

                        db.ExecSP("SP_AltaHorarioAlumno_AltaHorarioAlumno", parametros);

                        parametros.Clear();
                        MessageBox.Show("Horario asignado");
                    }
                }
                
                EstablecerDisponibilidad_btnGuardar();
            }

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
            parametros.Add(Permisos.usuario);
            parametros.Add(Permisos.periodo);
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
                try
                {
                    if (row.Cells["Carrera"].Value.ToString() == Permisos.carrera)
                    {
                        var datarow = ((DataRowView)row.DataBoundItem).Row;
                        workTable.Rows.Add(datarow.ItemArray);
                    }
                    else
                    {
                        MessageBox.Show("Necesita permiso del administrador para asignar esta materia");
                        break;
                    }

                    string[] arrayOfDays = new string[6];
                    arrayOfDays[0] = row.Cells["Dia 1"].Value.ToString();
                    arrayOfDays[1] = row.Cells["Hora 1"].Value.ToString();
                    arrayOfDays[2] = row.Cells["Hora 2"].Value.ToString();
                    arrayOfDays[3] = row.Cells["Dia 2"].Value.ToString();
                    arrayOfDays[4] = row.Cells["Hora 3"].Value.ToString();
                    arrayOfDays[5] = row.Cells["Hora 4"].Value.ToString();
                    //arrayOfDays[6] = row.Cells["Carrera"].Value.ToString();

                    dgvMaterias.Rows.RemoveAt(row.Index);
                    
                    foreach (DataGridViewRow r in dgvMaterias.Rows)
                    {

                        if ((r.Cells["Dia 1"].Value.ToString() == arrayOfDays[0] && r.Cells["Hora 1"].Value.ToString() == arrayOfDays[1] &&
                            r.Cells["Hora 2"].Value.ToString() == arrayOfDays[2] && r.Cells["Dia 2"].Value.ToString() == arrayOfDays[3] &&
                            r.Cells["Hora 3"].Value.ToString() == arrayOfDays[4] && r.Cells["Hora 4"].Value.ToString() == arrayOfDays[5])
                            ||
                            (r.Cells["Dia 1"].Value.ToString() == arrayOfDays[3] && r.Cells["Hora 1"].Value.ToString() == arrayOfDays[4] &&
                            r.Cells["Hora 2"].Value.ToString() == arrayOfDays[5] && r.Cells["Dia 2"].Value.ToString() == arrayOfDays[0] &&
                            r.Cells["Hora 3"].Value.ToString() == arrayOfDays[1] && r.Cells["Hora 4"].Value.ToString() == arrayOfDays[2]))
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
                catch (Exception)
                {
                   throw;
                }
            }
            EstablecerDisponibilidad_btnGuardar();
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
                try
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
                        
                        if ((r["Dia 1"].ToString() == arrayOfDays[0] && r["Hora 1"].ToString() == arrayOfDays[1] &&
                            r["Hora 2"].ToString() == arrayOfDays[2] && r["Dia 2"].ToString() == arrayOfDays[3] &&
                            r["Hora 3"].ToString() == arrayOfDays[4] && r["Hora 4"].ToString() == arrayOfDays[5])
                            ||
                            (r["Dia 1"].ToString() == arrayOfDays[3] && r["Hora 1"].ToString() == arrayOfDays[4] &&
                            r["Hora 2"].ToString() == arrayOfDays[5] && r["Dia 2"].ToString() == arrayOfDays[0] &&
                            r["Hora 3"].ToString() == arrayOfDays[1] && r["Hora 4"].ToString() == arrayOfDays[2]))
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
                catch (Exception)
                {
                    throw;
                }
            }
            EstablecerDisponibilidad_btnGuardar();
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

        private DataTable ObtenerColumnasDedgvMaterias(DataTable DataValidation)
        {
            int i = 0;
            foreach (DataGridViewTextBoxColumn colum in dgvMaterias.Columns)
            {
                DataValidation.Columns.Add(dgvMaterias.Columns[i].Name.ToString(), typeof(String));
                i++;
            }
            return DataValidation;
        }

        private void pbHorario_Click(object sender, EventArgs e)
        {
            if (dgvHorario.Visible)
            {
                dgvHorario.Hide();
                List<string> parametros = new List<string>();
                parametros.Add(Permisos.usuario);
                parametros.Add(Permisos.periodo);

                dgvHorarioActual.DataSource = db.ExecSP("SP_AltaHorarioAlumno_HorarioAlumno", parametros);
                ttpbHorario.SetToolTip(pbHorario, "Regresar");
            }
            else
            {
                dgvHorario.Show();
            }
            
        }
        private void SetToolTipTexts()
        {
            ttpbHorario.SetToolTip(pbHorario, "Mostrar Horario actual");
            ttpbHorario.SetToolTip(btnAgregar, "Agregar Materia Seleccionada");
            ttpbHorario.SetToolTip(btnEliminar, "Eliminar Materia Seleccionada");
        }
    }
}
