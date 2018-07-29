using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class DbAccess
    {
        #region Variables Declaration
        private Boolean bIsDisposed = false;
        SqlConnection oConn;
        SqlCommand oCommand;
        SqlDataAdapter oDataAdapter;
        String strConString = string.Empty;
        SqlTransaction oTransaction;
        Boolean _isInTransaction;
        System.IO.StreamWriter sw;

        CommandBehavior _ReaderCommandBehavior = CommandBehavior.CloseConnection;
        String mstrError = "";
        Boolean StartLog;
        Boolean IsTrace;
        String strTraceFile;
        #endregion

        #region Properties Declaration
        /// <summary>
        /// Property used to get and set the connection string
        /// </summary>
        public string ConnString { get { return strConString; } set { strConString = value; } }

        public CommandBehavior ReaderCommandBehavior { get { return _ReaderCommandBehavior; } set { _ReaderCommandBehavior = value; } }
        public ConnectionState ConnState { get { if (oConn != null) { return oConn.State; } else { return ConnectionState.Closed; } } }
        public Boolean isInTransaction { get { return _isInTransaction; } }
        #endregion

        /// <summary>
        /// To override the functionality of the finalize method of the garbage collector.
        /// </summary>
        protected void Finalize()
        {
            Dispose();
        }

        /// <summary>
        /// An isolation level is provided to each transaction to execuote it independent of the other transactions
        /// </summary>
        /// <param name="transisolationLevel">Transisolation Level IsolationLevel</param>
        public void BeginTrans(IsolationLevel transisolationLevel)
        {
            oTransaction = oConn.BeginTransaction(transisolationLevel);
            _isInTransaction = true;
        }

        /// <summary>
        /// To commit the transaction.
        /// </summary>
        public void CommitTrans()
        {
            oTransaction.Commit();
            oTransaction = null;
            _isInTransaction = false;
        }

        /// <summary>
        /// To undo(rollback) the set of instructions before commit.
        /// </summary>
        public void AbortTrans()
        {
            if (_isInTransaction)
            {
                oTransaction.Rollback();
                oTransaction = null;
                _isInTransaction = false;
            }
        }

        /// <summary>
        /// The procedure aims at establishing a database connection.
        /// If the first connection (primary connection) fails to connect after 50 trials, second connection(secondary connection) is used to connect to the database.
        /// </summary>
        public void OpenDbConn()
        {
            try
            {
                if (oConn == null)
                    oConn = new SqlConnection();
                if (ConnState == ConnectionState.Closed)
                {
                    oConn.ConnectionString = ConnString;
                    oConn.Open();
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        /// <summary>
        /// For closing the database connection.
        /// </summary>
        public void CloseDbConn()
        {
            if (oConn != null)
                if (oConn.State != ConnectionState.Closed)
                {
                    oConn.Close();
                    oConn.Dispose();
                    oConn = null;
                }
        }

        /// <summary>
        /// For returning the dataset according to the query and commandtype being passed.
        /// </summary>
        /// <param name="strQuery">Query</param>
        /// <param name="oCmdType">Command Type</param>
        /// <returns></returns>
        public DataSet ExecDataSet(String strQuery, CommandType oCmdType)
        {
            oConn = new SqlConnection();
            oConn.ConnectionString = ConnString;
            DataSet objDs = new DataSet();

            try
            {
                oDataAdapter = new SqlDataAdapter(strQuery, oConn);
                oDataAdapter.Fill(objDs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                oDataAdapter.Dispose();
                oDataAdapter = null;
            }
            return objDs;
        }

        /// <summary>
        /// For returning the datareader according to the query and commandtype being passed.
        /// </summary>
        /// <param name="strQuery">Query</param>
        /// <param name="oCmdType">Command Type</param>
        /// <returns>IDataReader</returns>
        public IDataReader ExecDataReader(String strQuery, CommandType oCmdType)
        {
            IDataReader objReader;
            try
            {
                oCommand = new SqlCommand();
                oCommand.Connection = oConn;
                oCommand.CommandType = oCmdType;
                oCommand.CommandText = strQuery;
                objReader = oCommand.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                oCommand.Dispose();
                oCommand = null;
            }
            return objReader;
        }

        /// <summary>
        /// For returning the first column of the first row of the dataset as a result.... according to the query and commandtype being passed.
        /// </summary>
        /// <param name="strSQL">Query</param>
        /// <param name="cmdtype">Command Type</param>
        /// <returns>Object</returns>
        public Object ExecScalar(String strSQL, CommandType cmdtype)
        {
            Object oRetValue;
            try
            {
                oCommand = new SqlCommand();
                oCommand.Connection = oConn;
                oCommand.CommandType = cmdtype;
                oCommand.CommandText = strSQL;
                if (isInTransaction)
                {
                    oCommand.Transaction = oTransaction;
                }
                oRetValue = oCommand.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                oCommand.Dispose();
                oCommand = null;
            }
            return oRetValue;
        }

        /// <summary>
        /// For returning the dataset according to the query and commandtype being passed.
        /// </summary>
        /// <param name="strSQL">Query</param>
        /// <param name="cmdType">Command Type</param>
        /// <returns>Int</returns>
        public Int32 ExecNonQuery(String strSQL, CommandType cmdType)
        {
            Int32 iRetValue;

            try
            {
                oCommand = new SqlCommand();
                oCommand.Connection = oConn;
                oCommand.CommandType = cmdType;
                oCommand.CommandText = strSQL;
                if (isInTransaction)
                    oCommand.Transaction = oTransaction;
                iRetValue = oCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                oCommand.Dispose();
                oCommand = null;
            }
            return iRetValue;
        }

        public Int32 ExecNonQuery(CommandType commandType, string commandText, SqlParameter[] commandParameters)
        {
            Int32 iRetValue;
            SqlCommand cmd = new SqlCommand();

            PrepareCommand(cmd, oConn, commandType, commandText, commandParameters);

            try
            {
                iRetValue = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return iRetValue;
        }

        /// <summary>
        /// This function implements the Dispose method of the Disposable Interface for disposing the connection,command object,data adapter or transaction...if  the memory obtained by any of these is left unreleased. 
        /// </summary>
        public void Dispose()
        {
            if (!bIsDisposed)
                if (oConn != null)
                {
                    if (oConn.State == ConnectionState.Open)
                    {
                        try
                        {
                            oConn.Close();
                        }
                        catch
                        {
                        }
                    }
                    oConn.Dispose();
                    oConn = null;
                }
            //'sw = Nothing

            if (oCommand != null)
            {
                oCommand.Dispose();
                oCommand = null;
            }

            if (oDataAdapter != null)
            {
                oDataAdapter.Dispose();
                oDataAdapter = null;
            }

            if (oTransaction != null)
                oTransaction = null;
        }

        /// <summary>
        /// defualt method of the class.
        /// </summary>
        public DbAccess()
        {
            strConString = System.Configuration.ConfigurationSettings.AppSettings["MahaCoachTestDBConnectionString"].ToString();
        }

        public object ExecuteSP(CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            OpenDbConn();

            if ((oConn == null))
                throw new ArgumentNullException("connection");

            try
            {
                return ReturnExecuteScalar(commandType, commandText, commandParameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IDataReader ExecuteSP_GetDR(CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();
            IDataReader DR;
            SqlDataAdapter dataAdatpter = null;
            bool mustCloseConnection = false;

            PrepareCommand(cmd, oConn, commandType, commandText, commandParameters);

            try
            {
                DR = cmd.ExecuteReader();
                cmd.Parameters.Clear();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return DR;
        }

        public DataSet ExecuteSP_GetDS(CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            if (oConn == null)
            {
                oConn = new SqlConnection();
                oConn.ConnectionString = ConnString;
            }

            SqlCommand cmd = new SqlCommand();
            DataSet objds = new DataSet();
            SqlDataAdapter dataAdatpter = null;
            bool mustCloseConnection = false;

            PrepareCommand(cmd, oConn, commandType, commandText, commandParameters);

            try
            {
                dataAdatpter = new SqlDataAdapter(cmd);
                dataAdatpter.Fill(objds);
                cmd.Parameters.Clear();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

                if (((dataAdatpter != null)))
                    dataAdatpter.Dispose();
            }

            return objds;
        }

        public object ReturnExecuteScalar(CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            if ((oConn == null))
                throw new ArgumentNullException("connection");

            SqlCommand cmd = new SqlCommand();
            object retval;

            PrepareCommand(cmd, oConn, commandType, commandText, commandParameters);
            OpenDbConn();
            retval = cmd.ExecuteScalar();
            cmd.Parameters.Clear();
            CloseDbConn();
            return retval;
        }

        private static void PrepareCommand(SqlCommand command, SqlConnection connection, CommandType commandType, string commandText, SqlParameter[] commandParameters)
        {
            if (command == null)
                throw new ArgumentNullException("command");

            if (commandText == null || commandText.Length == 0)
                throw new ArgumentNullException("commandText");

            command.Connection = connection;
            command.CommandText = commandText;
            command.CommandType = commandType;

            if (commandParameters != null)
                AttachParameters(command, commandParameters);

            return;
        }

        /// <summary>
        /// Prepare Command
        /// </summary>
        /// <param name="command">SqlCommand</param>
        /// <param name="commandParameters">Command Parameters</param>
        private static void AttachParameters(SqlCommand command, SqlParameter[] commandParameters)
        {
            if (command == null)
                throw new ArgumentNullException("command");

            if (commandParameters != null)
            {
                foreach (SqlParameter p in commandParameters)
                {
                    if (p != null)
                    {
                        if ((p.Direction == ParameterDirection.InputOutput || p.Direction == ParameterDirection.Input) && p.Value == null)
                            p.Value = DBNull.Value;
                        command.Parameters.Add(p);
                    }
                }
            }
        }
    }
}
