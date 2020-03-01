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
        public frmAltaHorarioAlumno()
        {
            InitializeComponent();
            ObtenerMateriasDisponibles();
            per.setUsuario("Marc Albrand");
            lbUser.Text = Permisos.usuario;
            
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
            DataTable workTable = dgvHorario.DataSource as DataTable;

            foreach (DataGridViewRow row in dgvMaterias.SelectedRows)
            {
                try
                {
                    var datarow = ((DataRowView)row.DataBoundItem).Row;
                    workTable.Rows.Add(datarow.ItemArray);
                    dgvMaterias.Rows.RemoveAt(row.Index);
                    dgvMaterias.ClearSelection();
                }
                catch (Exception)
                {
                    throw;
                }
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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DataTable workTable = dgvMaterias.DataSource as DataTable;

            foreach (DataGridViewRow row in dgvHorario.SelectedRows)
            {
                try
                {
                    var datarow = ((DataRowView)row.DataBoundItem).Row;
                    workTable.Rows.Add(datarow.ItemArray);
                    dgvHorario.Rows.RemoveAt(row.Index);
                    dgvHorario.ClearSelection();
                }
                catch (Exception)
                {
                    throw;
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
