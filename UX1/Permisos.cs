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
        
        

        public void setPermiso(int dt)
        {
            permiso = dt;
            
        }

        public void setUsuario(string Usuario)
        {
            usuario = Usuario;

        }

    }
}
