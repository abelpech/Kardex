using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Net;


namespace Kardex.Layers
{
    class dbConn
    {
        SqlConnection conn;
        public static List<string> lista = new List<string>();
        public dbConn()
        {

            //Obtiene el hostname de la computadora que utiliza el programa para adecuar la instancia
            //a la correcta de cada quien
            string host = Dns.GetHostName();
            
            //Se le asigna al objeto de SqlConnection la direccion de la instancia de la BD
            conn = new SqlConnection("server =  "+host+"; database=kardex ; integrated security = true");

        }

        public DataTable ExcQryDt(string query)
        {
            //Creamos objeto DataTable y SqlCommand
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand();

            //Le agregamos a la instncia cmd su query, tiempo de ejecucion y donde se va a ejecutar
            cmd.CommandText = query;
            cmd.CommandTimeout = 0;
            cmd.Connection = conn;

            //Abrimos la coneccion, cargamos iformacion al DataTable y cerramos coneccion.
            conn.Open();
            dt.Load(cmd.ExecuteReader());
            conn.Close();
            return dt;

        }

        public void ExcQry(string query)
        {
            
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = query;
            cmd.CommandTimeout = 0;
            cmd.Connection = conn;
            //MessageBox.Show(query);
            conn.Open();
            cmd.ExecuteNonQuery();
            
            conn.Close();


        }

        public int ExcQryInt(string query, string username, string password)
        {
            /*
            //int variableretornada = 0;

            using (SqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = query;
                cmd.CommandType = CommandType.Text;
                //cmd.CommandTimeout = 0;
                //cmd.Connection = conn;

                var returnParameter = cmd.Parameters.Add("@ReturnVal", SqlDbType.Int);
                returnParameter.Direction = ParameterDirection.ReturnValue;
                MessageBox.Show(query);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                int result = (int)returnParameter.Value;
                MessageBox.Show(result.ToString());
                return (result);
            }
            */
            
            using (SqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = query;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre", username);
                cmd.Parameters.AddWithValue("@Password", password);

                var returnParameter = cmd.Parameters.Add("@ReturnVal", SqlDbType.Int);
                returnParameter.Direction = ParameterDirection.ReturnValue;


                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                int result = (int)returnParameter.Value;
                return result;
            }
            
        }

        public int ExcQryLG(string query, string username)
        {

            using (SqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = query;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre", username);

                var returnParameter = cmd.Parameters.Add("@ReturnVal", SqlDbType.Int);
                returnParameter.Direction = ParameterDirection.ReturnValue;


                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                int result = (int)returnParameter.Value;
                return result;
            }

        }

        public AutoCompleteStringCollection ExcQryAuto(string query)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = query;
            cmd.CommandTimeout = 0;
            cmd.Connection = conn;
            conn.Open();
            SqlDataReader registros = cmd.ExecuteReader();
            
            AutoCompleteStringCollection mycollection = new AutoCompleteStringCollection();

            while (registros.Read())
            {
                mycollection.Add(registros.GetString(0));
                //MessageBox.Show(registros["carrera"].ToString());
            }
            conn.Close();
            return mycollection;

        }

        public int ExcQryUpdate(string query, string username)
        {

            using (SqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = query;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre", username);

                var returnParameter = cmd.Parameters.Add("@ReturnVal", SqlDbType.Int);
                returnParameter.Direction = ParameterDirection.ReturnValue;


                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                int result = (int)returnParameter.Value;
                return result;
            }

        }

        public void ExcQryReturn(string query)
        {
            
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = query;
            cmd.CommandTimeout = 0;
            cmd.Connection = conn;
            //cmd.CommandType = CommandType.StoredProcedure;

            conn.Open();


            int retVal = (Int32)cmd.ExecuteScalar();

            //MessageBox.Show(retVal.ToString());
            conn.Close();
            // El 0 sera para EXITOSO
            // EL 1 es para ERROR
            // Los mensajes los cambie a mas generales para que puedan aplicar en todos nuestros modulos
            if (retVal == 0)
            {
                MessageBox.Show("Solicitud Procesada Exitosamente", "Aviso", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Ya existe un registro con esos datos", "Aviso", MessageBoxButtons.OK);
            }
           
            
        }

        //Creacion de Nuevo Metodo para confirmar si la contrasena fue actualizada

        public void ExcQryReturn2(string query)
        {

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = query;
            cmd.CommandTimeout = 0;
            cmd.Connection = conn;
            //cmd.CommandType = CommandType.StoredProcedure;

            conn.Open();


            int retVal = (Int32)cmd.ExecuteScalar();

            //MessageBox.Show(retVal.ToString());
            conn.Close();
            // El 0 sera para EXITOSO
            // EL 1 es para ERROR
            // Los mensajes los cambie a mas generales para que puedan aplicar en todos nuestros modulos
            if (retVal == 0)
            {
                MessageBox.Show("Contraseña fue Actualizada Correctamente", "Aviso", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("No pudimos actualizar informacion - Favor de contactar Coordinacion", "Aviso", MessageBoxButtons.OK);
            }


        }
        public void ExcQryBaja(string query)
        {

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = query;
            cmd.CommandTimeout = 0;
            cmd.Connection = conn;
            //cmd.CommandType = CommandType.StoredProcedure;

            conn.Open();


            int retVal = (Int32)cmd.ExecuteScalar();

            //MessageBox.Show(retVal.ToString());
            if (retVal == 0)
            {
                MessageBox.Show("No existe un registro para dar de baja", "Aviso", MessageBoxButtons.OK);
            }
            else if(retVal > 0)
            {
                MessageBox.Show("Baja del registro exitosa", "Aviso", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("La carrera no puede darse de baja porque tiene Alumnos asignados", "Aviso", MessageBoxButtons.OK);
            }
            conn.Close();

        }

        public DataTable getInfo(string query)
        {
            int opcion = 0;
            SqlCommand cmd = new SqlCommand(("Select * from " + query), conn);
            

            //Valores de parametros para distintas listas:
            //alumno - Lista de todos los alumnos
            //materia - Lista de todas las materias
            //carrera - Lista de todas las carreras
            //maestro - Lista de todos los maestros
            //periodo - Lista de todos los periodos
            


            //Set up the parameters
            //cmd.Parameters.Add("@Result", SqlDbType.Int);
            //cmd.Parameters["@Result"].Direction = ParameterDirection.Output;

            conn.Open();

            DataTable reader2 = new DataTable();
            reader2.Load(cmd.ExecuteReader());
            SqlDataReader reader = cmd.ExecuteReader();

            
            while (reader.Read())
            {
                lista.Clear();
                switch (query)
                {
                    case "alumno":
                        lista.Add(reader["nombre"].ToString());
                        break;
                    case "materia":
                        lista.Add(reader["materia"].ToString());
                        break;
                    case "carrera":
                        lista.Add(reader["carrera"].ToString());
                        break;
                    case "maestro":
                        lista.Add(reader["nombre"].ToString());
                        break;
                    case "periodo":
                        lista.Add(reader["periodo"].ToString());
                        break;
                    default:
                        MessageBox.Show("Parametro incorrecto.");
                        break;

                }
                

            }
            conn.Close();
            return reader2;
            //TableName.Rows[0]["ColumnName"].ToString(); 
        }

        
      
    }




}

