using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace Kardex.Layers
{
    class dbConn
    {
        SqlConnection conn;
        public dbConn()
        {
            //Se le asigna al objeto de SqlConnection la direccion de la instancia de la BD
            conn = new SqlConnection("server = PECH\\SQLEXPRESS; database=kardex ; integrated security = true");

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
            if (retVal == 0)
            {
                MessageBox.Show("Alta Exitosa", "Aviso", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Ya existe un registro con esos datos", "Aviso", MessageBoxButtons.OK);
            }
            conn.Close();
            
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
            else
            {
                MessageBox.Show("Baja del registro exitosa", "Aviso", MessageBoxButtons.OK);
            }
            conn.Close();

        }

        /*
        
         public void ExcQryBaja(string query)
        {

            Estoy cambiando esto
        */
    }




}

