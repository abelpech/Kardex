using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using Kardex.Layers;

namespace Kardex.Layers
{
    class BL //Business Layer
    {
        DAL dal = new DAL();

        //CARRERA
        public DataTable ConsultaCarrera(string carrera)
        {
            
            if (carrera != "")
            {
                
                return dal.ConsultaCarrera(carrera);
            }
            else
            {
                MessageBox.Show("Es necesario especificar el valor para la carrera.", "Alerta", MessageBoxButtons.OK);
                return null;
            }

            
        }

        public void ModificaCarrera(string carrerabaja, string carrera, bool estatus)
        {
            if(carrera == "")
            {
                MessageBox.Show("Favor de especificar la carrera a modificar", "Alerta", MessageBoxButtons.OK);
                
            }
            else
            {

                dal.ModificaCarrera(carrerabaja, carrera, estatus);
                MessageBox.Show("La carrera se modifico exitosamente", "Aviso", MessageBoxButtons.OK);

            }
        }

        public void AltaCarrera (string carrera, bool estatus)
        {
            if(carrera == "")
            {
                MessageBox.Show("Es necesario especificar el nombre de la carrera", "Alerta", MessageBoxButtons.OK);

            }
            else
            {

                dal.AltaCarrera(carrera, estatus);
                //MessageBox.Show("La carrera se dio de alta correctamente", "Aviso", MessageBoxButtons.OK);

            }
        }

        public void BajaCarrera(string carrera)
        {
            if (carrera == "")
            {
                MessageBox.Show("Es necesario especificar el nombre de la carrera", "Alerta", MessageBoxButtons.OK);

            }
            else
            {
                dal.BajaCarrera(carrera);
                //MessageBox.Show("La carrera se dio de baja correctamente", "Aviso", MessageBoxButtons.OK);

            }
        }

        //MATERIA
        public void AltaMateria(string materia)
        {
            if (materia == "")
            {
                MessageBox.Show("Es necesario especificar el nombre de la Materia", "Alerta", MessageBoxButtons.OK);

            }
            else
            {
                /*if (fechaalta > DateTime.Now)
                {
                    MessageBox.Show("La fecha de alta no puede ser mayor al dia de hoy", "Alerta", MessageBoxButtons.OK);

                }
                else
                {*/
                    dal.AltaMateria(materia);
                    //MessageBox.Show("La materia se dio de alta correctamente", "Aviso", MessageBoxButtons.OK);
                //}
            }
        }

        public void BajaMateria(string materia)
        {
            if (materia == "")
            {
                MessageBox.Show("Es necesario especificar el nombre de la Materia", "Alerta", MessageBoxButtons.OK);

            }
            else
            {
                /*if (fechaalta > DateTime.Now)
                {
                    MessageBox.Show("La fecha de alta no puede ser mayor al dia de hoy", "Alerta", MessageBoxButtons.OK);

                }
                else
                {*/
                dal.BajaMateria(materia);
                //MessageBox.Show("La materia se dio de baja correctamente", "Aviso", MessageBoxButtons.OK);
                //}
            }
        }

        public DataTable ConsultaMateria(string materia)
        {

            if (materia != "")
            {

                return dal.ConsultaMateria(materia);
            }
            else
            {
                MessageBox.Show("Es necesario especificar el valor para la materia.", "Alerta", MessageBoxButtons.OK);
                return null;
            }


        }

        public void ModificaMateria(string materiabaja1, string materia, bool estatus)
        {
            if (materia == "")
            {
                MessageBox.Show("Favor de especificar la materia a modificar", "Alerta", MessageBoxButtons.OK);

            }
            else
            {
                
                dal.ModificaMateria(materiabaja1, materia, estatus);
                MessageBox.Show("La materia se modifico exitosamente", "Aviso", MessageBoxButtons.OK);
               
            }
        }

    //ALUMNO
        public void AltaAlumno(string alumno, string direccion, string telefono, DateTime fechaNac, string carrera)
        {
            if (alumno == "" || direccion =="" || telefono =="" || carrera =="")
            {
                
                MessageBox.Show("Es necesario especificar la informacion completa", "Alerta", MessageBoxButtons.OK);

            }
            else
            {
                if (fechaNac > DateTime.Now)
                {
                    MessageBox.Show("La fecha de alta no puede ser mayor al dia de hoy", "Alerta", MessageBoxButtons.OK);

                }
                else
                {
                    dal.AltaAlumno(alumno, direccion, telefono, fechaNac, carrera);
                    MessageBox.Show("El Alumno se dio de alta correctamente", "Aviso", MessageBoxButtons.OK);
                }
            }
        }

        public void BajaAlumno(string alumno, string carrera)
        {
            if (alumno == "" || carrera =="")
            {
                MessageBox.Show("Es necesario especificar la informacion completa", "Alerta", MessageBoxButtons.OK);

            }
            else
            {
                /*if (fechaalta > DateTime.Now)
                {
                    MessageBox.Show("La fecha de alta no puede ser mayor al dia de hoy", "Alerta", MessageBoxButtons.OK);

                }
                else
                {*/
                dal.BajaAlumno(alumno, carrera);
                //MessageBox.Show("El Alumno se dio de baja correctamente", "Aviso", MessageBoxButtons.OK);
                //}
            }
        }

        public DataTable ConsultaAlumno(int matricula, string alumno, string carrera)
        {

            //if (carrera != "")
            //{

                return dal.ConsultaAlumno(matricula, alumno, carrera);
            //}
            /*else
            {
                MessageBox.Show("Es necesario especificar el valor para la carrera.", "Alerta", MessageBoxButtons.OK);
                return null;
            }*/


        }

        public void ModificaAlumno(int matricula, string alumno, string direccion, string telefono, DateTime fechaNac, bool estatus, string carrera)
        {
            /* if (matricula == 0)
             {
                 MessageBox.Show("Favor de especificar la matricula a modificar", "Alerta", MessageBoxButtons.OK);

             }

             else
             {*/
            if (fechaNac > DateTime.Now)
                {
                    MessageBox.Show("La fecha de alta no puede ser mayor al dia de hoy", "Alerta", MessageBoxButtons.OK);
                }
                else
                {
                    /*if (fechabaja > DateTime.Now)
                    {
                        MessageBox.Show("La fecha de baja no puede ser mayor al dia de hoy", "Alerta", MessageBoxButtons.OK);
                    }
                    else
                    { */
                        dal.ModificaAlumno(matricula, alumno, direccion, telefono, fechaNac, estatus, carrera);
                        MessageBox.Show("El Alumno se modifico exitosamente", "Aviso", MessageBoxButtons.OK);
                    //}
                }
            
        }
        public int LoginValidation(string username, string password)
        {
            if(username == "")
            {
                MessageBox.Show("Es necesario especificar un nombre de usuario.", "Alerta", MessageBoxButtons.OK);
                return 0;
            }
            else
            {
                if(password == "")
                {
                    MessageBox.Show("Es necesario especificar una contraseña", "Alerta", MessageBoxButtons.OK);
                    return 0;
                }
                else
                {
                    return dal.LoginValidation(username, password);

                }
            }
            
        }

        //Login Validation for Password Reset

        public int LoginValidationPR(string username)
        {
            if (username == "")
            {
                MessageBox.Show("Es necesario especificar un nombre de usuario.", "Alerta", MessageBoxButtons.OK);
                return 0;
            }
            else
            {
                return dal.LoginValidationPR(username);
            }

        }

        public AutoCompleteStringCollection AutoCarrera()
        {
            AutoCompleteStringCollection mycollection = new AutoCompleteStringCollection();
            mycollection = dal.AutoCarrera();

            return mycollection;
        }

        public AutoCompleteStringCollection AutoMateria()
        {
            AutoCompleteStringCollection mycollection = new AutoCompleteStringCollection();
            mycollection = dal.AutoMateria();

            return mycollection;
        }

        public AutoCompleteStringCollection AutoAlumno()
        {
            AutoCompleteStringCollection mycollection = new AutoCompleteStringCollection();
            mycollection = dal.AutoAlumno();

            return mycollection;
        }


    }
}
