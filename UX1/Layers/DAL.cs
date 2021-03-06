﻿using System;
using System.Data;
using System.Windows.Forms; //Puede tirar mensajitos
using UX1.Layers;

namespace Kardex.Layers
{
    class DAL //DAL - Data Acces Layer
    {
        dbConn conn = new dbConn();
        
        public DataTable ConsultaCarrera(string carrera, int estado)
        {
            string query;
            DataTable dt = new DataTable();
            try
            {
                //Le asignamos a query el valor del SP "nombre" mas el parametro carrera
                //Para ejecutarlo posteriormente.
                query = "ConsultaCarrera '" + carrera + "', '" + estado + "'";
                dt = conn.ExcQryDt(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Surgio un error de sistema - Favor de contactar a ADMINISTRADOR", "Error", MessageBoxButtons.OK);
            }

            return dt;
        }


        public void ModificaCarrera(string carrerabaja, string carrera, bool estatus)
        {
            try
            {
                string query = "ModificaCarrera '" + carrerabaja + "', '" + carrera + "', '" + Convert.ToInt32(estatus) + "', '" + Permisos.usuario + "'";
                conn.ExcQryReturn(query);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK);
               // MessageBox.Show("Surgio un error de sistema - Favor de contactar a ADMINISTRADOR", "Error", MessageBoxButtons.OK);
            }
        }

        public void AltaCarrera(string carrera, bool estatus)
        {
            try
            {
                string query = "AltaCarrera '" + carrera + "', '" + Convert.ToInt32(estatus) + "', '" + Permisos.usuario + "'";
                conn.ExcQryReturn(query);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Surgio un error de sistema - Favor de contactar a ADMINISTRADOR", "Error", MessageBoxButtons.OK);
            }
        }
        public void BajaCarrera(string carrera)
        {
            try
            {
                string query = "BajaCarrera '" + carrera + "', '" + Permisos.usuario + "'";
                conn.ExcQryBaja(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Surgio un error de sistema - Favor de contactar a ADMINISTRADOR", "Error", MessageBoxButtons.OK);
            }
        }

        public int LoginValidation(string username, string password)
        {
            int dt = 0;
            //DataTable dt = new DataTable();
            try
            {
                //string query = "LoginMaestrosAlumnos '" + username + "'," + "'" + password + "'";
                string query = "LoginMaestrosAlumnos";
                //string query2 = "'" + username + "'," + "'" + password + "'";
                dt = conn.ExcQryInt(query, username, password);
                

            }
            catch(Exception ex)
            {
                MessageBox.Show("Surgio un error de sistema - Favor de contactar a ADMINISTRADOR", "Error", MessageBoxButtons.OK);
            }
            return dt;
        }

        //Login Validation for Password Reset

        public int LoginValidationPR(string username)
        {
            int dt = 0;
           
            try
            {
                //string query = "LoginMaestrosAlumnos '" + username + "'";
                string query = "LoginMaestrosAlumnosEmail";
                dt = conn.ExcQryLG(query, username);

            }
            catch (Exception ex)
            {

                MessageBox.Show("Surgio un error de sistema - Favor de contactar a ADMINISTRADOR", "Error", MessageBoxButtons.OK);
            }
            return dt;
        }
        //Actualizacion de contrasena

        public void ModificaContrasena(string username, string contrasena)
        {
            try
            {
                string query = "ModificaContrasena '" + username + "', '" + contrasena + "'";
                conn.ExcQryReturn2(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Surgio un error de sistema - Favor de contactar a ADMINISTRADOR", "Error", MessageBoxButtons.OK);
            }
        }

        //Materia
        public void AltaMateria(string materia)
        {
            try
            {
                string query = "AltaMateria '" + materia + "', '" + Permisos.usuario + "'";
                conn.ExcQryReturn(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Surgio un error de sistema - Favor de contactar a ADMINISTRADOR", "Error", MessageBoxButtons.OK);
            }
        }

        public void BajaMateria(string materia)
        {
            try
            {
                string query = "BajaMateria '" + materia + "', '" + Permisos.usuario + "'";
                conn.ExcQryBaja(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Surgio un error de sistema - Favor de contactar a ADMINISTRADOR", "Error", MessageBoxButtons.OK);
            }
        }

        public DataTable ConsultaMateria(string materia, int estado)
        {
            string query;
            DataTable dt = new DataTable();
            try
            {
              
                query = "ConsultaMateria '" + materia + "', '" + estado + "'";
                dt = conn.ExcQryDt(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Surgio un error de sistema - Favor de contactar a ADMINISTRADOR", "Error", MessageBoxButtons.OK);
            }

            return dt;
        }

        public void ModificaMateria(string materiabaja1, string materia, bool estatus)
        {
            try
            {

                string query = "ModificaMateria '" + materiabaja1 + "', '" + materia + "', '" + Convert.ToInt32(estatus) + "', '" + Permisos.usuario + "'";
                conn.ExcQryReturn(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Surgio un error de sistema - Favor de contactar a ADMINISTRADOR", "Error", MessageBoxButtons.OK);
            }
        }
        //ALUMNO
        public void AltaAlumno(string alumno,string direccion, string telefono, DateTime fechaalta, string carrera)
        {
            try
            {
                string query = "AltaAlumno '" + alumno + "', '" + direccion + "', '" + telefono + "', '" + fechaalta + "', '" + carrera + "', '" + Permisos.usuario + "'";
                conn.ExcQry(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Surgio un error de sistema - Favor de contactar a ADMINISTRADOR", "Error", MessageBoxButtons.OK);
            }
        }

        public void BajaAlumno(string alumno, string carrera)
        {
            try
            {
                string query = "BajaAlumno '" + alumno + "', '" + carrera + "', '" + Permisos.usuario + "'";
                conn.ExcQryBaja(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Surgio un error de sistema - Favor de contactar a ADMINISTRADOR", "Error", MessageBoxButtons.OK);
            }
        }
        public DataTable ConsultaAlumno(int matricula, string alumno, string carrera, int estado)
        {
            string query;
            DataTable dt = new DataTable();
            try
            {
                //Le asignamos a query el valor del SP "nombre" mas el parametro materia
                //Para ejecutarlo posteriormente.
                query = "ConsultaAlumno '" + matricula + "', '" + alumno + "', '" + carrera + "', '" + estado + "'" ;
                dt = conn.ExcQryDt(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Surgio un error de sistema - Favor de contactar a ADMINISTRADOR", "Error", MessageBoxButtons.OK);
            }

            return dt;
        }
        public void ModificaAlumno(int matricula, string alumno, string direccion, string telefono, DateTime fechaNac, bool estatus, string carrera)
        {
            try
            {
                string query = "ActualizaAlumno '" + matricula + "', '" + alumno + "', '" + direccion + "', '" + telefono + "', '" + fechaNac + "', '" + Convert.ToInt32(estatus) + "', '" + carrera + "','" + Permisos.usuario + "'";
                conn.ExcQry(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Surgio un error de sistema - Favor de contactar a ADMINISTRADOR", "Error", MessageBoxButtons.OK);
            }
        }
//MAESTRO
        public void AltaMaestro(string maestro, string direccion, string telefono)
        {
            try
            {
                string query = "AltaMaestro '" + maestro + "', '" + direccion + "', '" + telefono + "', '" + Permisos.usuario + "'";
                conn.ExcQryReturn(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Surgio un error de sistema - Favor de contactar a ADMINISTRADOR", "Error", MessageBoxButtons.OK);
            }
        }

        public void BajaMaestro(int matricula, string maestro)
        {
            try
            {
                string query = "BajaMaestro '" + matricula + "', '" + maestro + "', '" + Permisos.usuario + "'";
                conn.ExcQryBaja(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK);
            }
        }

        public DataTable ConsultaMaestro(int matricula, string maestro, bool estatus)
        {
            string query;
            DataTable dt = new DataTable();
            try
            {
                //Le asignamos a query el valor del SP "nombre" mas el parametro materia
                //Para ejecutarlo posteriormente.
                query = "ConsultaMaestro '" + matricula + "', '" + maestro + "', '" + Convert.ToInt32(estatus) + "'";
                dt = conn.ExcQryDt(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK);
                //MessageBox.Show("Algo Salio Mal", "Error", MessageBoxButtons.OK);
            }

            return dt;
        }


        public void ModificaMaestro(int matricula, string maestro, string direccion, string telefono, bool estatus)
        {
            try
            {
                string query = "ModificaMaestro '" + matricula + "', '" + maestro + "', '" + direccion + "', '" + telefono + "', '" + Convert.ToInt32(estatus) + "', '" + Permisos.usuario + "'";
                //MessageBox.Show(query);
                conn.ExcQryReturn(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Surgio un error de sistema - Favor de contactar a ADMINISTRADOR", "Error", MessageBoxButtons.OK);
            }
        }

//PERIODO

        public DataTable ConsultaPeriodo(string periodo, int estado)
        {
            string query;
            DataTable dt = new DataTable();
            try
            {

                query = "ConsultaPeriodo '" + periodo + "', '" + estado + "'";
                dt = conn.ExcQryDt(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Surgio un error de sistema - Favor de contactar a ADMINISTRADOR", "Error", MessageBoxButtons.OK);
            }

            return dt;
        }

        public void AltaPeriodo(string periodo, bool estatus)
        {
            try
            {
                string query = "AltaPeriodo '" + periodo + "', '" + Convert.ToInt32(estatus) + "', '" + Permisos.usuario + "'";
                conn.ExcQryReturn(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Surgio un error de sistema - Favor de contactar a ADMINISTRADOR", "Error", MessageBoxButtons.OK);
            }
        }

        public void BajaPeriodo(string periodo)
        {
            try
            {
                string query = "BajaPeriodo '" + periodo + "', '" + Permisos.usuario + "'";
                conn.ExcQryBaja(query);
            }

            catch (Exception ex)
            {
                MessageBox.Show("Surgio un error de sistema - Favor de contactar a ADMINISTRADOR", "Error", MessageBoxButtons.OK);
            }
        }

        public void ModificaPeriodo(string periodobaja, string periodo, bool estatus)
        {
            try
            {
                string query = "ModificaPeriodo '" + periodobaja + "', '" + periodo + "', '" + Convert.ToInt32(estatus) + "', '" + Permisos.usuario + "'";
                conn.ExcQryReturn(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK);
                // MessageBox.Show("Surgio un error de sistema - Favor de contactar a ADMINISTRADOR", "Error", MessageBoxButtons.OK);
            }
        }
 //CALIFICACION

        public DataTable ConsultaCalificacion(int matricula, string alumno, string periodo, int estado)
        {
            string query;
            DataTable dt = new DataTable();
            try
            {
                //Le asignamos a query el valor del SP "nombre" mas el parametro materia
                //Para ejecutarlo posteriormente.
                query = "ConsultaCalificacion '" + matricula + "', '" + alumno + "', '" + periodo + "', '" + estado + "'";
                dt = conn.ExcQryDt(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK);

                MessageBox.Show("Surgio un error de sistema - Favor de contactar a ADMINISTRADOR", "Error", MessageBoxButtons.OK);
            }

            return dt;
        }

        public void AltaCalificacion(int calificacion, int unidad, string alumno, string materia, string periodo)
        {
            try
            {
                string query = "AltaCalificacion '" + calificacion + "', '" + unidad + "', '" + alumno + "', '" + materia + "', '" + periodo + "', '" + Permisos.usuario + "'";
                conn.ExcQryCalificacion(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Surgio un error de sistema - Favor de contactar a ADMINISTRADOR", "Error", MessageBoxButtons.OK);
                //MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK);

            }
        }

        public void ModificaCalificacion(int calificacion, int unidad, string alumno, string materia, string periodo)
        {
            try
            {
                string query = "ModificaCalificacion '" + calificacion + "', '" + unidad + "', '" + alumno + "', '" + materia + "', '" + periodo + "', '" + Permisos.usuario + "'";
                conn.ExcQryCalificacionModifica(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Surgio un error de sistema - Favor de contactar a ADMINISTRADOR", "Error", MessageBoxButtons.OK);
                //MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK);

            }
        }

        public void ModificaCalificacion(int calificacion, int unidad, string alumno, string materia, string carrera, string maestro, string periodo)
        {
            try
            {
                string query = "ModificaCalificacion '" + calificacion + "', '" + unidad + "', '" + alumno + "', '" + materia + "', '" + carrera + "', '" + maestro + "', '" + periodo + "', '" + Permisos.usuario + "'";
                conn.ExcQryReturn(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Surgio un error de sistema - Favor de contactar a ADMINISTRADOR", "Error", MessageBoxButtons.OK);
            }
        }

        public AutoCompleteStringCollection AutoCarrera()
        {
            AutoCompleteStringCollection mycollection = new AutoCompleteStringCollection();
            try
            {
                string query = "select [carrera] from [carrera] ";
                mycollection = conn.ExcQryAuto(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Surgio un error de sistema - Favor de contactar a ADMINISTRADOR", "Error", MessageBoxButtons.OK);
            }
            return mycollection;
        }

        public AutoCompleteStringCollection AutoMateria()
        {
            AutoCompleteStringCollection mycollection = new AutoCompleteStringCollection();
            try
            {
                string query = "select [materia] from [materia]";
                mycollection = conn.ExcQryAuto(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Surgio un error de sistema - Favor de contactar a ADMINISTRADOR", "Error", MessageBoxButtons.OK);
            }
            return mycollection;
        }

        public AutoCompleteStringCollection AutoAlumno()
        {
            AutoCompleteStringCollection mycollection = new AutoCompleteStringCollection();
            try
            {
                string query = "select [nombre] from [alumno]";
                mycollection = conn.ExcQryAuto(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Surgio un error de sistema - Favor de contactar a ADMINISTRADOR", "Error", MessageBoxButtons.OK);
            }
            return mycollection;
        }

        public AutoCompleteStringCollection AutoPeriodo()
        {
            AutoCompleteStringCollection mycollection = new AutoCompleteStringCollection();
            try
            {
                string query = "select [periodo] from [periodo] ";
                mycollection = conn.ExcQryAuto(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Surgio un error de sistema - Favor de contactar a ADMINISTRADOR", "Error", MessageBoxButtons.OK);
            }
            return mycollection;
        }

        public AutoCompleteStringCollection AutoMaestro()
        {
            AutoCompleteStringCollection mycollection = new AutoCompleteStringCollection();
            try
            {
                string query = "select [nombre] from [maestro] ";
                mycollection = conn.ExcQryAuto(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Surgio un error de sistema - Favor de contactar a ADMINISTRADOR", "Error", MessageBoxButtons.OK);
            }
            return mycollection;
        }

        public DataTable HorariosAsignar(string carrera)
        {
            string query;
            DataTable dt = new DataTable();
            try
            {
                query = "SPHorariosAsignar '" + carrera + "'";
                dt = conn.ExcQryDt(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Surgio un error de sistema - Favor de contactar a ADMINISTRADOR", "Error", MessageBoxButtons.OK);
            }

            return dt;
        }

        public DataTable HorariosAsignados(string carrera, string materia)
        {
            string query;
            DataTable dt = new DataTable();
            try
            {
                query = "SPHorariosAsignados '" + carrera + "', '" + materia + "'";
                dt = conn.ExcQryDt(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Surgio un error de sistema - Favor de contactar a ADMINISTRADOR", "Error", MessageBoxButtons.OK);
            }
            return dt;
        }

        public DataTable ConsultaHorarioAlumno(string alumno)
        {
            string query;
            DataTable dt = new DataTable();
            try
            {
                query = "SPConsultaHorarioAlumno '" + alumno + "'";
                dt = conn.ExcQryDt(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Surgio un error de sistema - Favor de contactar a ADMINISTRADOR", "Error", MessageBoxButtons.OK);
            }
            return dt;
        }

        public DataTable ConsultaHorarioMaestro(string maestro)
        {
            string query;
            DataTable dt = new DataTable();
            try
            {
                query = "SPConsultaHorarioMaestro '" + maestro + "'";
                dt = conn.ExcQryDt(query);
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Surgio un error de sistema - Favor de contactar a ADMINISTRADOR", "Error", MessageBoxButtons.OK);
                MessageBox.Show(ex.ToString());
            }
            return dt;
        }

        public DataTable SPdgvMaterias(string campus)
        {
            string query;
            DataTable dt = new DataTable();
            try
            {
                query = "SPdgvMaterias '" + campus + "'";
                dt = conn.ExcQryDt(query);
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Surgio un error de sistema - Favor de contactar a ADMINISTRADOR", "Error", MessageBoxButtons.OK);
                MessageBox.Show(ex.ToString());
            }
            return dt;
        }


    }



}
