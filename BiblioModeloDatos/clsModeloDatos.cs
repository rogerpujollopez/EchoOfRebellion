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
    public class clsModeloDatos
    {
        private SqlConnectionStringBuilder builder;
        private SqlConnection conn;
        private string querySelect;
        private string queryUpdate;
        private bool soloCombo;

        public clsModeloDatos()
        {
            builder = clsSqlParameters.SqlConectionString();
            conn = new SqlConnection(builder.ConnectionString);
        }

        public void Dispose()
        {
            Desconectar();
            conn.Dispose();
        }

        private void Conectar()
        {
            if (conn.State != ConnectionState.Open) conn.Open();
        }

        private void Desconectar()
        {
            if (conn.State == ConnectionState.Open) conn.Close();
        }

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

        private void OnRowUpdated(object sender, SqlRowUpdatedEventArgs e)
        {
            if (e.Status == UpdateStatus.ErrorsOccurred)
            {
                throw new Exception("Error: " + e.Errors.Message);
            }
        }

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
            catch (Exception ex) 
            {
                if (sqlTrans != null && sqlTrans.Connection != null)
                {
                    try
                    {
                        sqlTrans.Rollback();
                    }
                    catch (Exception rollbackEx)
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


        //

        //public DataSet GetDataSet(string querySelect, bool soloCombo, string queryUpdate = "")
        //{
        //    this.querySelect = querySelect;
        //    this.soloCombo = soloCombo;

        //    if (!soloCombo)
        //    {
        //        this.queryUpdate = queryUpdate;
        //    }

        //    Conectar();
        //    DataSet ds = new DataSet();
        //    SqlDataAdapter da = new SqlDataAdapter($"{querySelect}", conn);
        //    //da.SelectCommand.Parameters.AddWithValue("@ID_Neg", ID_Neg);
        //    da.Fill(ds);

        //    //if (!soloCombo)
        //    //{
        //    //    dsUp = new DataSet();
        //    //    da = new SqlDataAdapter($"{queryUpdate}", conn);
        //    //    //da.SelectCommand.Parameters.AddWithValue("@ID_Neg", ID_Neg);
        //    //    da.Fill(dsUp);
        //    //}

        //    da.Dispose();

        //    Desconectar();
        //    return ds;
        //}

        //public int ActualitzarOld(DataSet ds)
        //{
        //    int result = -1;

        //    Conectar();

        //    SqlTransaction sqlTrans = conn.BeginTransaction();
        //    SqlDataAdapter da2 = new SqlDataAdapter(queryUpdate, conn);

        //    //da2.RowUpdated += new SqlRowUpdatedEventHandler(OnRowUpdated);
        //    da2.RowUpdated += OnRowUpdated;
        //    da2.SelectCommand.Transaction = sqlTrans;

        //    SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(da2);

        //    if (ds.HasChanges())
        //    {
        //        try
        //        {
        //            result = da2.Update(ds.Tables[0]);
        //            sqlTrans.Commit();
        //        }
        //        catch (Exception ex)
        //        {
        //            sqlTrans.Rollback();
        //        }
        //    }
        //    else
        //    {
        //        sqlTrans.Rollback();
        //    }

        //    sqlTrans.Dispose();
        //    da2.Dispose();

        //    Desconectar();

        //    return result;
        //}


    }
}
