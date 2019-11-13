using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Kardex;
using Kardex.Layers;
using UX1.Layers;

namespace UX1
{
    public partial class Plantilla : Form
    {
        int pm = 0;
        private bool isCollapsed;
        public Plantilla()
        {
            InitializeComponent();
            expandirCarrera.Start();
            pm = Permisos.permiso;
            EstablecerPermisos(pm);
        }

        private int tolerance = 15;
        private const int WM_NCHITTEST = 132;
        private const int HTBOTTOMRIGHT = 17;
        private Rectangle sizeGripRectangle;

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_NCHITTEST:
                    base.WndProc(ref m);
                    var hitPoint = this.PointToClient(new Point(m.LParam.ToInt32() & 0xffff, m.LParam.ToInt32() >> 16));
                    if (sizeGripRectangle.Contains(hitPoint))
                        m.Result = new IntPtr(HTBOTTOMRIGHT);
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            var region = new Region(new Rectangle(0, 0, this.ClientRectangle.Width, this.ClientRectangle.Height));

            sizeGripRectangle = new Rectangle(this.ClientRectangle.Width - tolerance, this.ClientRectangle.Height - tolerance, tolerance, tolerance);

            region.Exclude(sizeGripRectangle);
            this.PanelContenedor.Region = region;
            this.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {

            SolidBrush blueBrush = new SolidBrush(Color.FromArgb(55, 61, 69));
            e.Graphics.FillRectangle(blueBrush, sizeGripRectangle);

            base.OnPaint(e);
            ControlPaint.DrawSizeGrip(e.Graphics, Color.Transparent, sizeGripRectangle);
        }

        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
        private void Iconcerrar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro de salir?", "Alerta", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //Codigo mas limpio
                try
                {
                    Environment.Exit(0);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    this.Close();
                }
                
            }
        }
        int LX, LY;
        private void Iconmaximizar_Click(object sender, EventArgs e)
        {
            LX = this.Location.X;
            LY = this.Location.Y;
            //this.WindowState = FormWindowState.Maximized;
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;
            iconmaximizar.Visible = false;
            iconrestaurar.Visible = true;
        }

        private void Iconminimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;


        }

        private void Iconrestaurar_Click(object sender, EventArgs e)
        {
            //this.WindowState = FormWindowState.Normal;
            this.Size = new Size(1300, 650);
            this.Location = new  Point(LX,LY);
            iconmaximizar.Visible = true;
            iconrestaurar.Visible = false;
        }

        private void Btnslide_Click(object sender, EventArgs e)
        {

            if (MenuVertical.Width == 230)
            {
                this.tmContraerMenu.Start();
            }
            else if (MenuVertical.Width == 55)
            {
                this.tmExpandirMenu.Start();
            }
        }

        private void BarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);

        }

        

        private void Button5_Click(object sender, EventArgs e)
        {
            expandirPeriodo.Start();
        }

        private void MenuVertical_Paint(object sender, PaintEventArgs e)
        {

        }
        private void AbrirFormInPanel(object Formhijo)
        {
            if (this.PanelContenedor.Controls.Count > 0)
                this.PanelContenedor.Controls.RemoveAt(0);
            Form fh = Formhijo as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.PanelContenedor.Controls.Add(fh);

            this.PanelContenedor.Tag = fh;
            fh.Show();
        }
        private void BtnCarrera_Click(object sender, EventArgs e)
        {
            expandirCarrera.Start();
        }

        private void BtnMateria_Click(object sender, EventArgs e)
        {
            expandirMateria.Start();
        }

        private void BtnAlumno_Click(object sender, EventArgs e)
        {
            expandirAlumno.Start();
        }

        private void BtnMaestro_Click(object sender, EventArgs e)
        {
            expandirMaestro.Start();
        }

        private void BtnCalificacion_Click(object sender, EventArgs e)
        {
            expandirCalificacion.Start();
        }

        private void BtnCarreraMateria_Click(object sender, EventArgs e)
        {
            expandirCarreraMateria.Start();
        }

        private void TmExpandirMenu_Tick(object sender, EventArgs e)
        {
            if (MenuVertical.Width >= 230)
                this.tmExpandirMenu.Stop();
            else
                MenuVertical.Width = MenuVertical.Width + 5;
        }

        private void TmContraerMenu_Tick(object sender, EventArgs e)
        {
            if (MenuVertical.Width <= 55)
                this.tmContraerMenu.Stop();
            else
                MenuVertical.Width = MenuVertical.Width - 5;
        }

        private void PanelContenedor_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Expandir_Tick(object sender, EventArgs e)
        {
            if (isCollapsed)
            {
                btnCarrera.Image = UX1.Properties.Resources.Collapse_Arrow_20px;
                panelCarrera.Height += 500;
                if (panelCarrera.Size == panelCarrera.MaximumSize)
                {
                    expandirCarrera.Stop();
                    isCollapsed = false;
                }
            }
            else
            {
                btnCarrera.Image = UX1.Properties.Resources.Expand_Arrow_20px;
                panelCarrera.Height -= 500;
                if (panelCarrera.Size == panelCarrera.MinimumSize)
                {
                    expandirCarrera.Stop();
                    isCollapsed = true;
                }
            }
        }

        private void expandirMateria_Tick(object sender, EventArgs e)
        {
            if (isCollapsed)
            {
                btnMateria.Image = UX1.Properties.Resources.Collapse_Arrow_20px;
                panelMateria.Height += 500;
                if (panelMateria.Size == panelMateria.MaximumSize)
                {
                    expandirMateria.Stop();
                    isCollapsed = false;
                }
            }
            else
            {
                btnMateria.Image = UX1.Properties.Resources.Expand_Arrow_20px;
                panelMateria.Height -= 500;
                if (panelMateria.Size == panelMateria.MinimumSize)
                {
                    expandirMateria.Stop();
                    isCollapsed = true;
                }
            }
        }

        private void expandirAlumno_Tick(object sender, EventArgs e)
        {
            if (isCollapsed)
            {
                btnAlumno.Image = UX1.Properties.Resources.Collapse_Arrow_20px;
                panelAlumno.Height += 500;
                if (panelAlumno.Size == panelAlumno.MaximumSize)
                {
                    expandirAlumno.Stop();
                    isCollapsed = false;
                }
            }
            else
            {
                btnAlumno.Image = UX1.Properties.Resources.Expand_Arrow_20px;
                panelAlumno.Height -= 500;
                if (panelAlumno.Size == panelAlumno.MinimumSize)
                {
                    expandirAlumno.Stop();
                    isCollapsed = true;
                }
            }
        }

        private void expandirMaestro_Tick(object sender, EventArgs e)
        {
            if (isCollapsed)
            {
                btnMaestro.Image = UX1.Properties.Resources.Collapse_Arrow_20px;
                panelMaestro.Height += 500;
                if (panelMaestro.Size == panelMaestro.MaximumSize)
                {
                    expandirMaestro.Stop();
                    isCollapsed = false;
                }
            }
            else
            {
                btnMaestro.Image = UX1.Properties.Resources.Expand_Arrow_20px;
                panelMaestro.Height -= 500;
                if (panelMaestro.Size == panelMaestro.MinimumSize)
                {
                    expandirMaestro.Stop();
                    isCollapsed = true;
                }
            }
        }

        private void expandirPeriodo_Tick(object sender, EventArgs e)
        {
            if (isCollapsed)
            {
                btnPeriodo.Image = UX1.Properties.Resources.Collapse_Arrow_20px;
                panelPeriodo.Height += 500;
                if (panelPeriodo.Size == panelPeriodo.MaximumSize)
                {
                    expandirPeriodo.Stop();
                    isCollapsed = false;
                }
            }
            else
            {
                btnPeriodo.Image = UX1.Properties.Resources.Expand_Arrow_20px;
                panelPeriodo.Height -= 500;
                if (panelPeriodo.Size == panelPeriodo.MinimumSize)
                {
                    expandirPeriodo.Stop();
                    isCollapsed = true;
                }
            }
        }

        private void expandirCalificacion_Tick(object sender, EventArgs e)
        {
            if (isCollapsed)
            {
                btnCalificacion.Image = UX1.Properties.Resources.Collapse_Arrow_20px;
                panelCalificacion.Height += 500;
                if (panelCalificacion.Size == panelCalificacion.MaximumSize)
                {
                    expandirCalificacion.Stop();
                    isCollapsed = false;
                }
            }
            else
            {
                btnCalificacion.Image = UX1.Properties.Resources.Expand_Arrow_20px;
                panelCalificacion.Height -= 500;
                if (panelCalificacion.Size == panelCalificacion.MinimumSize)
                {
                    expandirCalificacion.Stop();
                    isCollapsed = true;
                }
            }
        }

        

        

        private void BtnAltaCarrera_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new frmAltaCarrera());
        }

        private void BtnAltaMateria_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new frmAltaMateria());
        }

        private void BtnAltaAlumno_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new frmAltaAlumno());
        }

        private void BtnBajaAlumno_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new frmBajaAlumno());
        }

        private void BtnBajaCarrera_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new frmBajaCarrera());
        }

        private void BtnBajaMateria_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new frmBajaMateria());
        }

        private void BtnConsultaAlumno_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new frmConsultaAlumno());
        }

        private void BtnConsultaMateria_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new frmConsultaMateria());
        }

        private void BtnConsultaCarrera_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new frmConsultaCarrera());
        }

        private void BtnModificacionAlumno_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new frmModificaAlumno());
        }

        public void BtnModificacionCarrera_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new frmModificaCarrera());
        }

        private void BtnModificacionMateria_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new frmModificaMateria());
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            expandirMateriaAlumnoMaestro.Start();
        }

        private void BtnAltaMaestro_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new frmAltaMaestro());
        }

        private void BtnBajaMaestro_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new frmBajaMaestro());
        }

        private void BtnConsultaMaestro_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new frmConsultaMaestro());
        }

        private void btnModificacionMaestro_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new frmModificaMaestro());
        }

        private void EstablecerPermisos(int pm)
        {
            switch (pm)
            {
                case 1:
                    {
                      //ALUMNO
                        lbUsuario.Text = "Alumno";
                        btnAlumno.Enabled = false;

                        //Modulo Carrera
                        btnCarrera.Enabled = false;

                        //Modulo Materia
                        btnMateria.Enabled = false;
                        break;
                    }
                case 2:
                    {
                      //MAESTRO
                        lbUsuario.Text = "Maestro";
                        //Modulo Alumno
                        btnAltaAlumno.Enabled = false;
                        btnBajaAlumno.Enabled = false;
                        btnModificacionAlumno.Enabled = false;
                        btnConsultaAlumno.Enabled = true;

                        //Modulo Carrera
                        btnAltaCarrera.Enabled = false;
                        btnBajaCarrera.Enabled = false;
                        btnModificacionCarrera.Enabled = false;
                        btnConsultaCarrera.Enabled = true;

                        //Modulo Materia
                        btnAltaMateria.Enabled = false;
                        btnBajaMateria.Enabled = false;
                        btnModificacionMateria.Enabled = false;
                        btnConsultaMateria.Enabled = true;
                        break;
                    }
                case 3:
                    {
                      //SECRETARIA
                        lbUsuario.Text = "Secretaria";
                        //Modulo Alumno
                        btnAltaAlumno.Enabled = true;
                        btnBajaAlumno.Enabled = false;
                        btnModificacionAlumno.Enabled = true;
                        btnConsultaAlumno.Enabled = true;

                        //Modulo Carrera
                        btnAltaCarrera.Enabled = true;
                        btnBajaCarrera.Enabled = false;
                        btnModificacionCarrera.Enabled = false;
                        btnConsultaCarrera.Enabled = true;

                        //Modulo Materia
                        btnAltaMateria.Enabled = true;
                        btnBajaMateria.Enabled = false;
                        btnModificacionMateria.Enabled = false;
                        btnConsultaMateria.Enabled = true;
                        break;
                    }
                case 4:
                    {
                      //COORDINADOR
                        lbUsuario.Text = "Coordinador";
                        //Modulo Alumno
                        btnAltaAlumno.Enabled = true;
                        btnBajaAlumno.Enabled = true;
                        btnModificacionAlumno.Enabled = true;
                        btnConsultaAlumno.Enabled = true;

                        //Modulo Carrera
                        btnAltaCarrera.Enabled = true;
                        btnBajaCarrera.Enabled = true;
                        btnModificacionCarrera.Enabled = true;
                        btnConsultaCarrera.Enabled = true;

                        //Modulo Materia
                        btnAltaMateria.Enabled = true;
                        btnBajaMateria.Enabled = true;
                        btnModificacionMateria.Enabled = true;
                        btnConsultaMateria.Enabled = true;
                        break;
                    }
                case 5:
                    {
                      //DIRECTOR
                        lbUsuario.Text = "Director";
                        //Modulo Alumno
                        btnAltaAlumno.Enabled = true;
                        btnBajaAlumno.Enabled = false;
                        btnModificacionAlumno.Enabled = true;
                        btnConsultaAlumno.Enabled = true;

                        //Modulo Carrera
                        btnAltaCarrera.Enabled = true;
                        btnBajaCarrera.Enabled = true;
                        btnModificacionCarrera.Enabled = true;
                        btnConsultaCarrera.Enabled = true;

                        //Modulo Materia
                        btnAltaMateria.Enabled = true;
                        btnBajaMateria.Enabled = true;
                        btnModificacionMateria.Enabled = true;
                        btnConsultaMateria.Enabled = true;
                        break;
                    }
                case 6:
                    {
                      //ROOT
                        
                        lbUsuario.Text = "God Mode";
                        //Modulo Alumno
                        btnAltaAlumno.Enabled = true;
                        btnBajaAlumno.Enabled = true;
                        btnModificacionAlumno.Enabled = true;
                        btnConsultaAlumno.Enabled = true;

                        //Modulo Carrera
                        btnAltaCarrera.Enabled = true;
                        btnBajaCarrera.Enabled = true;
                        btnModificacionCarrera.Enabled = true;
                        btnConsultaCarrera.Enabled = true;

                        //Modulo Materia
                        btnAltaMateria.Enabled = true;
                        btnBajaMateria.Enabled = true;
                        btnModificacionMateria.Enabled = true;
                        btnConsultaMateria.Enabled = true;
                        break;
                    }

                default:
                    {
                        //Validacion para evitar que traspasen LOGIN

                        MessageBox.Show("Privilegios no reconocidos. cerrando programa por seguridad.");
                        //this.Close();
                        break;
                    }
            }
        }

        


    }
}