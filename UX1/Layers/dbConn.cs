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
            
            conn = new SqlConnection("server =  "+host+ "; database=kardex ; integrated security = true");
            //conn = new SqlConnection("server =  " + host + "\\SQLEXPRESS; database=kardex ; integrated security = true");

        }

        public DataTable ExcQryDt(string query)
        {
            //Creamos objeto DataTable y SqlCommand
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand();
            conn.Close();

            try
            {
                
                //Le agregamos a la instncia cmd su query, tiempo de ejecucion y donde se va a ejecutar
                cmd.CommandText = query;
                cmd.CommandTimeout = 0;
                cmd.Connection = conn;
                //Abrimos la coneccion, cargamos iformacion al DataTable y cerramos coneccion.
                conn.Open();
                dt.Load(cmd.ExecuteReader());
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }
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

            lista.Clear();
            /*while (reader.Read())
            {
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
            }*/
            conn.Close();
            return reader2;
            //TableName.Rows[0]["ColumnName"].ToString(); 
        }

        public DataTable SCAN(string query, int distinct)
        {
            string dist = "";
            if (distinct == 1)
            {
                dist = ("Select distinct * from " + query);
            }
            else
            {
                dist = ("Select * from " + query);
            }
            SqlCommand cmd = new SqlCommand((dist), conn);


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

            lista.Clear();
           
            conn.Close();
            return reader2;
        }


        public void ExcQryCalificacion(string query)
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
                MessageBox.Show("Alta de Unidad/Calificacion Exitosamente", "Aviso", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Registro de Unidad/Calificacion Existente", "Aviso", MessageBoxButtons.OK);
            }


        }

        public void ExcQryCalificacionModifica(string query)
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
                MessageBox.Show("Modificacion de Calificacion Exitosamente", "Aviso", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("No fue posible procesar Modificacion", "Aviso", MessageBoxButtons.OK);
            }


        }


        //Obtiene todos los parametros del SP automaticamente y devuelve un DataTable
        public DataTable ExecSP(string querySP, List<string> parametros)
        {
            System.Diagnostics.Debug.WriteLine("\n----- Intentado ejecutar SP: " + querySP + " -----");
            DataTable dt = new DataTable();
            // SPResult es la variable que se encarga de guardar el mensaje resultante de un SP (StoredProcedure).
            string SPResult = "";
            bool SPResultDetected = false;
            bool intDetected = false;
            // i es la variable cuyo unico objetivo es ser un contador para la lista parametros que recibimos.
            int i = 0;
            int a = 0;
            // Esta lista contiene los nombres de los parametros de cualquier SP que mandemos llamar.
            List<string> NombreParametros = new List<string>();

            // Iniciamos la variable cmd indicandole que sera un SP con el nombre de la variable "querySP"
            // y utilizara la conexion de la variable "conexion".
            SqlCommand cmd = new SqlCommand(querySP, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            // Se abre la conexion y se recopilan todos los parametros que se piden en el SP de la
            // variable "cmd". (ojo: este metodo te llena el espacio de los parametros de cmd.Parameters).
            conn.Open();
            SqlCommandBuilder.DeriveParameters(cmd);

            // El siguiente ciclo guarda los parametros recopilados en una variable tipo lista<string>
            // para posteriormente poder tener acceso al nombre de todos los parametros utilizados
            // en el SP que mandamos llamar.
            foreach (SqlParameter p in cmd.Parameters)
            {
                // Nos saltamos el primer parametro con la condicion "i != 0" ya que el primer parametro
                // es el resultado obligatorio de cada query que se ejecuta, y ese no debemos sobreescribirlo
                // ni nos interesa guardarlo.
                if (i != 0)
                {
                    System.Diagnostics.Debug.WriteLine("Leyendo parametro: " + p.ParameterName);
                    NombreParametros.Add(p.ParameterName.ToString());
                }
                i++;
            }
            i = 0;

            // Limpiamos los parametros obtenidos en nuestro primer metodo para tener el espacio libre.
            cmd.Parameters.Clear();

            // Recorremos cada uno de los parametros que agregamos anteriormente para agregar los que
            // realmente necesitamos a cmd.Parameters.
            foreach (string p in NombreParametros)
            {

                // Para los parametros OUTPUT en los SP, se maneja un estandar. Todos los parametros OUTPUT
                // se llamaran @mensaje en los SP y contendran un mensaje de tipo varchar(150).
                // Asi esta condicion detecta si el parametro leido es de tipo OUTPUT y ejecuta un codigo
                // especial para el.
                if (p == "@mensaje")
                {
                    cmd.Parameters.Add(p, SqlDbType.VarChar, 150);
                    cmd.Parameters[p].Direction = ParameterDirection.Output;
                    SPResultDetected = true;
                    System.Diagnostics.Debug.WriteLine("Se agrega: " + p + ", " + "' '");
                }
                else
                {

                    // Detecta si el parametro que optuvimos puede ser considerado como int o una string.
                    intDetected = int.TryParse(parametros[i], out a);
                    if (intDetected)
                    {
                        cmd.Parameters.AddWithValue(p.ToString(), a);
                        System.Diagnostics.Debug.WriteLine("Se agrega INT: " + p + ", " + parametros[i]);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue(p.ToString(), parametros[i]);
                        System.Diagnostics.Debug.WriteLine("Se agrega: " + p + ", " + parametros[i]);
                    }
                }

                i++;
            }

            // Ejecutamos el SP y cerramos la conexion.
            dt.Load(cmd.ExecuteReader());
            conn.Close();

            // Cualquier mensaje establecido en el parametro @mensaje de tipo OUTPUT se guardara en la variable
            // SPResult y se desplegara por default en la consola.
            if (SPResultDetected)
            {
                SPResult = cmd.Parameters["@mensaje"].Value.ToString();
                System.Diagnostics.Debug.WriteLine("BD respondio: " + SPResult);
            }


            // Se limpian variables para uso posterior de la funcion.
            NombreParametros.Clear();
            i = 0;
            System.Diagnostics.Debug.WriteLine("----- SP: " + querySP + ", ¡Ejecutado con exito! -----");
            return dt;
        }

        //Obtiene todos los parametros del SP automaticamente y devuelve un INT
        public int ExecSPReturnInt(string querySP, List<string> parametros)
        {
            System.Diagnostics.Debug.WriteLine("\n----- Intentado ejecutar SP: " + querySP + " -----");
            string SPResult = "";
            bool SPResultDetected = false;
            bool intDetected = false;

            int i = 0;
            int a = 0;
            int ResultFromSP = 0;
            // Esta lista contiene los nombres de los parametros de cualquier SP que mandemos llamar.
            List<string> NombreParametros = new List<string>();

            SqlCommand cmd = new SqlCommand(querySP, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            conn.Open();
            // Obtiene los parametros del SP y llena la lista de cmd
            SqlCommandBuilder.DeriveParameters(cmd);

            foreach (SqlParameter p in cmd.Parameters)
            {
                // Nos saltamos el primer parametro por defecto
                if (i != 0)
                {
                    System.Diagnostics.Debug.WriteLine("Leyendo parametro: " + p.ParameterName);
                    NombreParametros.Add(p.ParameterName.ToString());
                }
                i++;
            }
            i = 0;
            cmd.Parameters.Clear();

            // Recorremos cada uno de los parametros que agregamos anteriormente para agregar los que
            // realmente necesitamos a cmd.Parameters.
            foreach (string p in NombreParametros)
            {
                if (p == "@mensaje")
                {
                    cmd.Parameters.Add(p, SqlDbType.VarChar, 150);
                    cmd.Parameters[p].Direction = ParameterDirection.Output;
                    SPResultDetected = true;
                    System.Diagnostics.Debug.WriteLine("Se agrega: " + p + ", " + "' '");
                }
                else
                {
                    // Detecta si el parametro que optuvimos puede ser considerado como int o string.
                    intDetected = int.TryParse(parametros[i], out a);
                    if (intDetected)
                    {
                        cmd.Parameters.AddWithValue(p.ToString(), a);
                        System.Diagnostics.Debug.WriteLine("Se agrega INT: " + p + ", " + parametros[i]);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue(p.ToString(), parametros[i]);
                        System.Diagnostics.Debug.WriteLine("Se agrega: " + p + ", " + parametros[i]);
                    }
                }

                i++;
            }

            // Agregamos un parametro OUTPUT para devolver un entero de SP's especiales.
            // Ojo: Necesitas tener un return(@ParameterReturnINT) en tu sp con un valor INT valido.
            var ParameterReturnINT = cmd.Parameters.Add("@ParameterReturnINT", SqlDbType.Int);
            ParameterReturnINT.Direction = ParameterDirection.ReturnValue;

            cmd.ExecuteReader();
            conn.Close();

            // Guardamos el dato de los SP en una variable int.
            ResultFromSP = (int)ParameterReturnINT.Value;

            // Si detecta un mensaje lo guarda y lo despliega en consola.
            if (SPResultDetected)
            {
                SPResult = cmd.Parameters["@mensaje"].Value.ToString();
                System.Diagnostics.Debug.WriteLine("BD respondio: " + SPResult);
                MessageBox.Show(SPResult);
            }


            // Se limpian variables para uso posterior de la funcion.
            NombreParametros.Clear();
            i = 0;
            System.Diagnostics.Debug.WriteLine("----- SP: " + querySP + ", ¡Ejecutado con exito! -----");
            return ResultFromSP;
        }

    }




}

