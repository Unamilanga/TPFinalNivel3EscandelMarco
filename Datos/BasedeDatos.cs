using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Collections;
using System.Configuration;
using System.Data;

namespace Datos
{
    public class ConexionDB
    {
        private SqlConnection Connection;

        private SqlCommand Command;

        private SqlDataReader Reader;



        public ConexionDB()
        {
            Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConexionDB"].ConnectionString);

            Command = new SqlCommand();
        }

        public void SqlQuery(string query)
        {
            try
            {
                Command.CommandType = System.Data.CommandType.Text;
                Command.CommandText = query;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al ejecutar la consulta: " + ex.Message);
            }

        }
        public void SqlProcedimiento(string sp)
        {

            try
            {
                Command.CommandType = System.Data.CommandType.StoredProcedure;
                Command.CommandText = sp;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al ejecutar la consulta: " + ex.Message);
            }

        }
        public SqlDataReader EjecutarLectura()
        {
            Command.Connection = Connection;
            try
            {
                Connection.Open();
                Reader = Command.ExecuteReader();
                return Reader;

            }
            catch (Exception ex)
            {
                throw new Exception("Error al ejecutar la lectura: " + ex.Message);
            }
            finally
            {

            }

        }
        public void EjecutarComando()
        {
            Command.Connection = Connection;
            try
            {
                Connection.Open();
                Command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al ejecutar el comando: " + ex.Message);
            }
            finally
            {
                Connection.Close();
            }
        }
        public void CerrarConexion()
        {
            if (Reader != null)
            {
                Reader.Close();
            }

            if (Connection.State == System.Data.ConnectionState.Open)
            {
                Connection.Close();
            }

        }

        public void AgregarParametro(string nombre, object valor)
        {
            Command.Parameters.AddWithValue(nombre, valor);
        }

        public object EjecutarEscalar()
        {
            Command.Connection = Connection;
            try
            {
                Connection.Open();
                return Command.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al ejecutar el escalar: " + ex.Message);
            }
            finally
            {
                Connection.Close();
            }
        }

        public SqlParameter AgregarParametroReturn()
        {
            SqlParameter param = new SqlParameter("@ReturnVal", SqlDbType.Int);
            param.Direction = ParameterDirection.ReturnValue;
            Command.Parameters.Add(param);
            return param;
        }


    }
}

