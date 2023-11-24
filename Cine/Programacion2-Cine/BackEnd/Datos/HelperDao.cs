using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BackEnd.Datos
{
    public class HelperDao
    {
        private static HelperDao Instancia;
        private SqlConnection Conexion;
        private string CadenaConexion = @"Data Source=.;Initial Catalog=db_cine;Integrated Security=True";


        public HelperDao()
        {
            Conexion = new SqlConnection(CadenaConexion);
        }

        public static HelperDao ObtenerInstancia()
        {
            if (Instancia == null)
            {
                Instancia = new HelperDao();
            }
            return Instancia;
        }
        public DataTable Consultar(string nombreTabla)
        {
            {
                using (SqlConnection conexion = new SqlConnection(CadenaConexion))
                {
                    try
                    {
                        SqlCommand comando = new SqlCommand();
                        comando.Connection = conexion;

                        if (comando.Connection.State == ConnectionState.Open)
                        {
                            comando.Connection.Close();
                        }

                        conexion.Open();
                        comando.CommandType = CommandType.Text;
                        comando.CommandText = "select * from " + nombreTabla;
                        DataTable tabla = new DataTable();
                        tabla.Load(comando.ExecuteReader());
                        return tabla;
                    }
                    catch (Exception ex)
                    {

                        throw ex;
                    }
                    finally
                    {
                        if (conexion.State == ConnectionState.Open)
                        {
                            conexion.Close();
                        }
                    }
                }
            }
        }

        public DataTable ConsultarProcedureFiltro(string consultaSql, List<Parametro> lst)
        {
            Conexion.Open();
            SqlCommand comando = new SqlCommand();
            comando.Connection = Conexion;
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = consultaSql;

            foreach (Parametro parametro in lst)
            {
                comando.Parameters.AddWithValue(parametro.Nombre, parametro.Valor);
            }

            DataTable tabla = new DataTable();
            tabla.Load(comando.ExecuteReader());
            Conexion.Close();
            return tabla;
        }

        public DataTable ConsultarProcedure(string consultaSql)
        {
            Conexion.Open();
            SqlCommand comando = new SqlCommand();
            comando.Connection = Conexion;
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = consultaSql;
            DataTable tabla = new DataTable();
            tabla.Load(comando.ExecuteReader());
            Conexion.Close();
            return tabla;
        }

        public DataTable Sql(string consultaSql)
        {
            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            {
                try
                {
                    SqlCommand comando = new SqlCommand();
                    comando.Connection = conexion;

                    if (comando.Connection.State == ConnectionState.Open)
                    {
                        comando.Connection.Close();
                    }

                    conexion.Open();
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = consultaSql;
                    DataTable tabla = new DataTable();
                    tabla.Load(comando.ExecuteReader());
                    return tabla;
                }
                catch (Exception ex)
                {
                    
                    throw ex;
                }
                finally
                {
                    if (conexion.State == ConnectionState.Open)
                    {
                        conexion.Close();
                    }
                }
            }
        }

        public SqlConnection ObtenerConexion()
        {
            return Conexion;
        }

    }
}
