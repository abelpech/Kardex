using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UX1.Layers
{
    class Permisos
    {
        public static int permiso;
        public static string usuario;
        public static string campus;
        public static string periodo;
        public static string carrera;
        public static string grupo;




        public void setPermiso(int dt)
        {
            permiso = dt;
            
        }

        public void setUsuario(string Usuario)
        {
            usuario = Usuario;

        }

        public void setCampus(string Campus)
        {
            campus = Campus;

        }

        public void setCarrera(string Carrera)
        {
            carrera = Carrera;

        }

        public void setPeriodo(string Periodo)
        {
            periodo = Periodo;

        }

        public void setGrupo(string Grupo)
        {
            grupo = Grupo;

        }
    }
}
