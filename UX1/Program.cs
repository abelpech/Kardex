using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UX1
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Application.Run(new frmAltaHorario());
            //Application.Run(new frmPendienteHorario());
            //Application.Run(new frmConsultaHorario());
            //Application.Run(new frmConsultaHorarioAlumno());
            //Application.Run(new frmConsultaHorarioMaestro());
            Application.Run(new frmAltaHorarioMaestro());


        }
    }
}
