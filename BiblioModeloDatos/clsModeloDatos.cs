using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;

namespace BiblioModeloDatos
{

    /// <summary>
    /// Clase de acceso a datos
    /// </summary>

    public class clsModeloDatos
    {
        private SqlConnectionStringBuilder builder;
        private SqlConnection conn;

        public clsModeloDatos()
        {
            builder = clsSqlParameters.SqlConectionString();
            conn = new SqlConnection(builder.ConnectionString);
        }

        /// <summary>
        /// Método conectar
        /// </summary>

        private void Conectar()
        {
            if (conn.State != ConnectionState.Open) conn.Open();
        }

        /// <summary>
        /// Método desconectar
        /// </summary>

        private void Desconectar()
        {
            if (conn.State == ConnectionState.Open) conn.Close();
        }

        /// <summary>
        /// Método para obetener un tabla mediante el nombre de la tabla
        /// </summary>
        /// <param name="taula"></param>
        /// <returns>Devuelve un DataSet con el contenido</returns>
        public DataSet PortarTaula(string taula)
        {
            DataSet ds = new DataSet();

            Conectar();

            bool existeixTaula = ExisteixTaula(taula);

            if (existeixTaula)
            {
                SqlDataAdapter da = new SqlDataAdapter($"select * from {taula}", conn);
                da.Fill(ds);
                da.Dispose();
            }

            Desconectar();

            return ds;
        }

        /// <summary>
        /// Método privado que devuelve un bool indicando si la tabla existe o no en la BBDD
        /// </summary>
        /// <param name="taula"></param>
        /// <returns>Devuelve un bool</returns>
        private bool ExisteixTaula(string taula)
        {
            Conectar();

            string strsql = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME=@tabla AND TABLE_SCHEMA = 'dbo' and TABLE_CATALOG='SecureCoreG1'";
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(strsql, conn);
            da.SelectCommand.Parameters.AddWithValue("@taula", taula);
            da.Fill(ds);

            Desconectar();

            return ds.Tables[0].Rows.Count > 0;
        }

        /// <summary>
        /// Método que nos devuelve un DataSet con el contenido de la consulta que le pasamos como parámetro
        /// </summary>
        /// <param name="consulta"></param>
        /// <returns>Devuelve un DataSet</returns>
        public DataSet PortarPerConsulta (string consulta)
        {
            Conectar();

            string strsql = consulta;
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(strsql, conn);
            da.Fill(ds);

            Desconectar();

            return ds;
        }

        /// <summary>
        /// Método que nos devuelve un DataSet con el contenido de la consulta que le pasamos como parámetro. También le pasamos el nombre de la DataTable como parametro
        /// </summary>
        /// <param name="consulta"></param>
        /// <param name="nomDataTable"></param>
        /// <returns>Devuelve un DataSet</returns>
        public DataSet PortarPerConsulta(string consulta, string nomDataTable)
        {
            Conectar();

            string strsql = consulta;
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(strsql, conn);
            da.Fill(ds, nomDataTable);

            Desconectar();

            return ds;
        }

        /// <summary>
        /// Método que le pasamos como parámetros una consulta y una lista de parámetros SQL para la consulta
        /// </summary>
        /// <param name="consulta"></param>
        /// <param name="parametres"></param>
        /// <returns>Devuelve un DataSet</returns>
        public DataSet PortarPerConsulta(string consulta, List<SqlParameter> parametres = null)
        {
            Conectar();

            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(consulta, conn);
            if (parametres != null)
            {
                foreach (var parametro in parametres)
                {
                    da.SelectCommand.Parameters.Add(parametro);
                }
            }
            da.Fill(ds);

            Desconectar();

            return ds;
        }

        /// <summary>
        /// Método privado para detectar si al hacer el update del DataSet, da un error
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="Exception"></exception>
        private void OnRowUpdated(object sender, SqlRowUpdatedEventArgs e)
        {
            if (e.Status == UpdateStatus.ErrorsOccurred)
            {
                throw new Exception("Error: " + e.Errors.Message);
            }
        }

        /// <summary>
        /// Método que mediante el DataSet modificado y la consulta original, actualiza la BBDD
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="consultaOriginal"></param>
        /// <returns>Devuelve el nº de registros afectados</returns>
        /// <exception cref="Exception"></exception>
        public int Actualitzar(DataSet ds, string consultaOriginal)
        {
            Conectar();

            int result = -1;

            SqlTransaction sqlTrans = null;

            try
            {
                sqlTrans = conn.BeginTransaction();
                SqlDataAdapter da2 = new SqlDataAdapter(consultaOriginal, conn);

                //da2.RowUpdated += new SqlRowUpdatedEventHandler(OnRowUpdated);
                da2.RowUpdated += OnRowUpdated;
                da2.SelectCommand.Transaction = sqlTrans;

                SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(da2);

                if (ds.HasChanges())
                {
                    result = da2.Update(ds.Tables[0]);
                    sqlTrans.Commit();
                }
                else
                {
                    sqlTrans.Rollback();
                }

                sqlTrans.Dispose();
                da2.Dispose();
            }
            catch (Exception) 
            {
                if (sqlTrans != null && sqlTrans.Connection != null)
                {
                    try
                    {
                        sqlTrans.Rollback();
                    }
                    catch (Exception)
                    {
                    }
                }

                throw new Exception("Error en la transacción");
            }
            finally
            {
                Desconectar();
            }

            return result;
        }

        /// <summary>
        /// Método para ejecutar una consulta Update, Delete o Insert, pero el Insert sin Scope
        /// </summary>
        /// <param name="consulta"></param>
        /// <returns>Devuelve el nº de registros afectados</returns>
        public int Executa(string consulta)
        {
            Conectar();

            SqlCommand cmd = new SqlCommand(consulta, conn);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();

            int numRegistres = cmd.ExecuteNonQuery();

            Desconectar();

            return numRegistres;
        }

        /// <summary>
        /// Método para ejecutar una consulta Update, Delete o Insert, pero el Insert sin Scope, con parámetros
        /// </summary>
        /// <param name="consulta"></param>
        /// <param name="parametros"></param>
        /// <returns>Devuelve el nº de registros afectados</returns>
        public int ExecutaConParametros(string consulta, Dictionary<string, object> parametros)
        {
            Conectar();

            SqlCommand cmd = new SqlCommand(consulta, conn);
            cmd.CommandType = CommandType.Text;

            foreach (var param in parametros)
            {
                cmd.Parameters.AddWithValue(param.Key, param.Value);
            }

            int registrosAfectados = cmd.ExecuteNonQuery();

            Desconectar();

            return registrosAfectados;
        }

        /// <summary>
        /// Método para ejecutar una consulta Insert con Scope
        /// </summary>
        /// <param name="consulta"></param>
        /// <returns>Devuelve el id del registro añadido (Scope)</returns>
        public int ExecutaScope(string consulta)
        {
            Conectar();

            SqlCommand cmd = new SqlCommand(consulta, conn);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();

            int scopeIdentity = Convert.ToInt32(cmd.ExecuteScalar());

            Desconectar();

            return scopeIdentity;
        }

        /// <summary>
        /// Método para ejecutar una consulta Insert con Scope, con parámetros
        /// </summary>
        /// <param name="consulta"></param>
        /// <param name="parametres"></param>
        /// <returns>Devuelve el id del registro añadido (Scope)</returns>
        public DataSet GeneraConsultaCerca(string consulta, Dictionary<string, object> parametres)
        {
            Conectar();

            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(consulta, conn);
            foreach (KeyValuePair<string, object> parametre in parametres)
            {
                da.SelectCommand.Parameters.AddWithValue(parametre.Key, parametre.Value);
            }
            da.Fill(ds);

            Desconectar();

            return ds;
        }

        /// <summary>
        /// Método para ejectura un StoreProcedure almacenado en la BBDD, con parámetros
        /// </summary>
        /// <param name="procedure"></param>
        /// <param name="parametres"></param>
        /// <returns>Devuelve un DataSet</returns>
        public DataSet StoreProcedure(string procedure, Dictionary<string, object> parametres)
        {
            Conectar();

            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(procedure, conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            foreach (KeyValuePair<string, object> parametre in parametres)
            {
                da.SelectCommand.Parameters.AddWithValue(parametre.Key, parametre.Value);
            }
            da.Fill(ds);

            Desconectar();

            return ds;
        }
    }
}
