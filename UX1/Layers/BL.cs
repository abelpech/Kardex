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
        public DataTable ConsultaCarrera(string carrera, int estado)
        {
            
            if (carrera != "")
            {
                
                return dal.ConsultaCarrera(carrera, estado);
            }
            else if(carrera == "" && estado !=-1)
            {
                //MessageBox.Show("Es necesario especificar el valor para la carrera.", "Alerta", MessageBoxButtons.OK);
                //return null;
                return dal.ConsultaCarrera(carrera, estado);
            }
            else
            {
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
                //MessageBox.Show("La carrera se modifico exitosamente", "Aviso", MessageBoxButtons.OK);

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

        public DataTable ConsultaMateria(string materia, int estado)
        {

            if (materia != "")
            {

                return dal.ConsultaMateria(materia, estado);
            }
            else if(materia == "" && estado != -1)
            {
                return dal.ConsultaMateria(materia, estado);
            }
                else
                {
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
                //MessageBox.Show("La materia se modifico exitosamente", "Aviso", MessageBoxButtons.OK);
               
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

        public DataTable ConsultaAlumno(int matricula, string alumno, string carrera, int estado)
        {

            //if (carrera != "")
            //{

                return dal.ConsultaAlumno(matricula, alumno, carrera, estado);
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

//MAESTRO
        public void AltaMaestro(string maestro, string direccion, string telefono)
        {
            if (maestro == "")
            {

                MessageBox.Show("Es necesario especificar la informacion completa", "Alerta", MessageBoxButtons.OK);

            }
            else
            {

                dal.AltaMaestro(maestro, direccion, telefono);
                //MessageBox.Show("El Maestro se dio de alta correctamente", "Aviso", MessageBoxButtons.OK);

            }
        }

        public void BajaMaestro(int matricula, string maestro)
        {
            if (matricula == 0)
            {

                MessageBox.Show("Es necesario especificar una matricula", "Alerta", MessageBoxButtons.OK);

            }
            else
            {

                dal.BajaMaestro(matricula, maestro);
                //MessageBox.Show("El Maestro se dio de baja correctamente", "Aviso", MessageBoxButtons.OK);

            }
        }

        public DataTable ConsultaMaestro(int matricula, string maestro, bool estatus)
        {

            //if (carrera != "")
            //{

            return dal.ConsultaMaestro(matricula, maestro, estatus);
            //}
            /*else
            {
                MessageBox.Show("Es necesario especificar el valor para la carrera.", "Alerta", MessageBoxButtons.OK);
                return null;
            }*/


        }

        public void ModificaMaestro(int matricula, string maestro, string direccion, string telefono, bool estatus)
        {


            dal.ModificaMaestro(matricula, maestro, direccion, telefono, estatus);
            //MessageBox.Show("El Maestro se modifico exitosamente", "Aviso", MessageBoxButtons.OK);


        }



//PERIODO

        public DataTable ConsultaPeriodo(string periodo, int estado)
        {

            if (periodo != "")
            {

                return dal.ConsultaPeriodo(periodo, estado);
            }
            else if (periodo == "" && estado != -1)
            {
                return dal.ConsultaPeriodo(periodo, estado);
            }
            else
            {
                return null;
            }

        }

        public void AltaPeriodo(string periodo, bool estatus)
        {
            dal.AltaPeriodo(periodo, estatus);
        }

        public void BajaPeriodo(string periodo)
        {
            if (periodo == "")
            {
                MessageBox.Show("Es necesario especificar el nombre del periodo", "Alerta", MessageBoxButtons.OK);

            }
            else
            {
                dal.BajaPeriodo(periodo);

            }
        }

        public void ModificaPeriodo(string periodobaja, string periodo, bool estatus)
        {
            if (periodo == "")
            {
                MessageBox.Show("Favor de especificar el periodo a modificar", "Alerta", MessageBoxButtons.OK);

            }
            else
            {

                dal.ModificaPeriodo(periodobaja, periodo, estatus);
                //MessageBox.Show("La carrera se modifico exitosamente", "Aviso", MessageBoxButtons.OK);

            }
        }
 //CALIFICACION

        public DataTable ConsultaCalificacion(int matricula, string alumno, string periodo, int estado)
        {
      
            return dal.ConsultaCalificacion(matricula, alumno, periodo, estado);
        
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

        public AutoCompleteStringCollection AutoPeriodo()
        {
            AutoCompleteStringCollection mycollection = new AutoCompleteStringCollection();
            mycollection = dal.AutoPeriodo();

            return mycollection;
        }

    }
}
