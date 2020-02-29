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
using System.Data.SqlClient;
using UX1;
using UX1.Validaciones;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using Spire.Pdf;
using Spire.Pdf.Tables;
using Spire.Pdf.Graphics;

namespace UX1
{
    public partial class frmConsultaHorarioAlumno : Form
    {
        KeyPressValidation kpv = new KeyPressValidation();
        BL bl = new BL();
        Plantilla pl = new Plantilla();

        string data = string.Empty;

        public frmConsultaHorarioAlumno()
        {
            InitializeComponent();
        }

        private void BtnConsulta_Click(object sender, EventArgs e)
        {
            string alumno = txtAlumno.Text.Trim();

            DataTable dt = bl.ConsultaHorarioAlumno(alumno);
                if (dt.Rows.Count > 0)
                {
                    dgvHorario.DataSource = dt;
                    dgvHorario.AllowUserToAddRows = false;
                }
                else
                {
                    btnLimpiar_Click(sender, e);
                    MessageBox.Show("No hay horarios disponibles", "Aviso", MessageBoxButtons.OK);
                }
            }

        private void frmConsultaHorario_Load(object sender, EventArgs e)
        {
            AutoCompleteStringCollection mycollection = new AutoCompleteStringCollection();
            mycollection = bl.AutoAlumno();
            txtAlumno.AutoCompleteCustomSource = mycollection;
          
        }

        private void btnExportarPDF_Click(object sender, EventArgs e)
        {
            if(dgvHorario.Rows.Count == 0)
            {
                MessageBox.Show("Sin datos por EXPORTAR", "Aviso", MessageBoxButtons.OK);
            }
            else
            {
                PdfDocument pdf = new PdfDocument();
                PdfPageBase page = pdf.Pages.Add();
                PdfTable table = new PdfTable();
                table.DataSource = dgvHorario.DataSource;
                table.Style.ShowHeader = true;

                PdfImage image = PdfImage.FromFile(Path.Combine(System.IO.Path.GetFullPath(@"..\..\"), "Resources\\reporte.jpeg"));
                float width = image.Width * 0.75f;
                float height = image.Height * 0.75f;
                float x = (page.Canvas.ClientSize.Width - width) / 2;
                page.Canvas.DrawImage(image, x, 60, width, height);

                table.Style.CellPadding = 2;
                PdfTableLayoutFormat tableLayout = new PdfTableLayoutFormat();
                tableLayout.Break = PdfLayoutBreakType.FitElement;
                tableLayout.Layout = PdfLayoutType.Paginate;
                table.BeginRowLayout += new BeginRowLayoutEventHandler(BeginRowLayout);
                table.Draw(page, new RectangleF(10, 30, 500, 700), tableLayout);


                pdf.SaveToFile("C:\\Users\\AbelFH\\Desktop\\Horario-Alumno.pdf");
                MessageBox.Show("PDF generado exitosamente", "Aviso", MessageBoxButtons.OK);
            }
            
        }

        private void BeginRowLayout(object sender, BeginRowLayoutEventArgs args)
        {
            PdfCellStyle cellstyle = new PdfCellStyle();
            cellstyle.StringFormat = new PdfStringFormat(PdfTextAlignment.Center);
            cellstyle.Font = new PdfTrueTypeFont(new Font("Arial", 8f), true);
            args.CellStyle = cellstyle;

            PdfPageSettings ps = new PdfPageSettings();
            ps.Orientation = PdfPageOrientation.Landscape;

        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (dgvHorario.Rows.Count == 0)
            {
                MessageBox.Show("Sin datos por EXPORTAR", "Aviso", MessageBoxButtons.OK);
            }
            else
            {
                Excel._Application app = new Excel.Application();
                Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
                Excel._Worksheet worksheet = null;
                app.Visible = true;
                worksheet = workbook.Sheets[1];
                worksheet = workbook.ActiveSheet;
                worksheet.Name = "Horario-Alumno";
                for (int i = 1; i < dgvHorario.Columns.Count + 1; i++)
                {
                    worksheet.Cells[1, i] = dgvHorario.Columns[i - 1].HeaderText;

                }
                for (int i = 0; i < dgvHorario.Rows.Count; i++)
                {
                    for (int j = 0; j < dgvHorario.Columns.Count; j++)
                    {
                        worksheet.Cells[i + 2, j + 1] = dgvHorario.Rows[i].Cells[j].Value.ToString();
                    }
                }
                workbook.SaveAs("C:\\Users\\AbelFH\\Desktop\\Horario-Alumno.xlsx", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                app.Quit();
                MessageBox.Show("EXCEL generado exitosamente", "Aviso", MessageBoxButtons.OK);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtAlumno.Text = "";

            DataTable dt = bl.ConsultaHorarioAlumno("");

            if (dt.Rows.Count > 0)
            {
                dgvHorario.DataSource = dt;
                dt.Rows.Clear();
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

    }

}
