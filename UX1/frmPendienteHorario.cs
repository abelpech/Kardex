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
    public partial class frmPendienteHorario : Form
    {
        KeyPressValidation kpv = new KeyPressValidation();
        BL bl = new BL();
        Plantilla pl = new Plantilla();

        string data = string.Empty;

        public frmPendienteHorario()
        {
            
            InitializeComponent();
        }

        private void BtnConsulta_Click(object sender, EventArgs e)
        {
            string carrera = txtCarrera.Text.Trim();

            if (carrera != "")
            {
                DataTable dt = bl.HorariosAsignar(carrera);
                if (dt.Rows.Count > 0)
                {
                    dgvMaterias.DataSource = dt;
                    dgvMaterias.AllowUserToAddRows = false;
                }
                else
                {
                    MessageBox.Show("No hay materias con horarios pendientes por asignar", "Aviso", MessageBoxButtons.OK);
                }
            }
            else
            {
                DataTable dt = bl.HorariosAsignar("");
                if (dt.Rows.Count > 0)
                {
                    dgvMaterias.DataSource = dt;
                    dgvMaterias.AllowUserToAddRows = false;
                }
                else
                {
                    MessageBox.Show("No hay materias con horarios pendientes por asignar", "Aviso", MessageBoxButtons.OK);
                }
            }
            
        }

        private void FrmConsultaCarrera_Load(object sender, EventArgs e)
        {
            AutoCompleteStringCollection mycollection = new AutoCompleteStringCollection();
            mycollection = bl.AutoCarrera();
            txtCarrera.AutoCompleteCustomSource = mycollection;
        } 

        private void button1_Click(object sender, EventArgs e)
        {
            txtCarrera.Text = "";
            DataTable dt = bl.HorariosAsignar("");

            if (dt.Rows.Count > 0)
            {
                dgvMaterias.DataSource = dt;
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

        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (dgvMaterias.Rows.Count == 0)
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
                worksheet.Name = "MateriasPendientesdeHorario";
                for (int i = 1; i < dgvMaterias.Columns.Count + 1; i++)
                {
                    worksheet.Cells[1, i] = dgvMaterias.Columns[i - 1].HeaderText;

                }
                for (int i = 0; i < dgvMaterias.Rows.Count; i++)
                {
                    for (int j = 0; j < dgvMaterias.Columns.Count; j++)
                    {
                        worksheet.Cells[i + 2, j + 1] = dgvMaterias.Rows[i].Cells[j].Value.ToString();
                    }
                }
                workbook.SaveAs("C:\\Users\\AbelFH\\Desktop\\MateriasPendientesdeHorario.xlsx", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                app.Quit();
                MessageBox.Show("EXCEL generado exitosamente", "Aviso", MessageBoxButtons.OK);
            }
        }
        private void btnExportarPDF_Click(object sender, EventArgs e)
        {
            if (dgvMaterias.Rows.Count == 0)
            {
                MessageBox.Show("Sin datos por EXPORTAR", "Aviso", MessageBoxButtons.OK);
            }
            else
            {
                PdfDocument pdf = new PdfDocument();
                PdfPageBase page = pdf.Pages.Add();
                PdfTable table = new PdfTable();

                table.DataSource = dgvMaterias.DataSource;

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
                table.BeginRowLayout += new BeginRowLayoutEventHandler(table_BeginRowLayout);

                table.Draw(page, new RectangleF(10, 50, 450, 400), tableLayout);

                pdf.SaveToFile("C:\\Users\\AbelFH\\Desktop\\MateriasPendientesdeHorario.pdf");
                MessageBox.Show("PDF generado exitosamente", "Aviso", MessageBoxButtons.OK);
            }
        }
    
        private static void table_BeginRowLayout(object sender, BeginRowLayoutEventArgs args)
        {
            PdfCellStyle cellstyle = new PdfCellStyle();
            cellstyle.StringFormat = new PdfStringFormat(PdfTextAlignment.Center);
            cellstyle.Font = new PdfTrueTypeFont(new Font("Arial", 8f), true);
            args.CellStyle = cellstyle;
        }
    }
}
