using System;
using System.Data;
using System.Data.SqlClient;
using DAL;

namespace BLL
{
    public class BLLQuery : IDisposable
    {
        //string connectDbString = System.Configuration.ConfigurationSettings.AppSettings["ConnectionString"];
        DbAccess _DataAccess;
        protected bool isDisposed;
        //private IntPtr handle;

        public BLLQuery()
        {
            _DataAccess = new DbAccess();
        }
        // Use interop to call the method necessary
        // to clean up the unmanaged resource.
        //[System.Runtime.InteropServices.DllImport("Kernel32")]
        //private extern static Boolean CloseHandle(IntPtr handle);

        private void ConnectToDatabase()
        {
            try
            {
                _DataAccess.OpenDbConn();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        //close connection
        public void CloseConnection()
        {
            _DataAccess.CloseDbConn();
        }

        // Open Connection
        public void OpenConnection()
        {
            _DataAccess.OpenDbConn();
        }
        public void Dispose()
        {
            if (!(isDisposed))
            {
                if (_DataAccess.ConnState == ConnectionState.Open)
                {
                    //if (_DataAccess.isInTransaction)
                    //{
                    //    _DataAccess.AbortTrans();
                    //}
                    _DataAccess.CloseDbConn();
                    _DataAccess.Dispose();
                    _DataAccess = null;
                    //GC.Collect();
                }
                //CloseHandle(handle);
                //handle = IntPtr.Zero;

                Finalize();
                //GC.SuppressFinalize(this);
                isDisposed = true;
            }
        }
        protected void Finalize()
        {
            //Dispose();
            //base.Finalize();
        }
        //Get Datatset
        public DataSet GetDS(string strQ)
        {
            DataSet objDs = new DataSet();
            objDs = _DataAccess.ExecDataSet(strQ, CommandType.Text);
            return objDs;
        }

        //Returns First column of the First Row, if only a Querystring will be passed by the codebehind calling then this function will be called
        public object GetScaler(string strQuery)
        {
            object retValue;
            ConnectToDatabase();
            retValue = _DataAccess.ExecScalar(strQuery, CommandType.Text);
            return retValue;
        }

        //Returns First column of the First Row, if only strQury and closeconnection will be passed by the codebehind calling then this function will be called
        public object GetScaler(string strQuery, bool CloseConnection)
        {
            object retValue;
            ConnectToDatabase();
            retValue = _DataAccess.ExecScalar(strQuery, CommandType.Text);
            if (CloseConnection)
            {
                _DataAccess.CloseDbConn();
            }
            return retValue;
        }

        //Gets the Data Readers for the perticulare query being passed
        public IDataReader GetReader(string strQuery)
        {
            IDataReader objR;
            objR = _DataAccess.ExecDataReader(strQuery, CommandType.Text);
            return objR;
        }

        //Overloading of GetReader
        //Gets the Data Readers for the perticulare query being passed
        public IDataReader GetReader(string strQuery, bool CloseConnection)
        {
            IDataReader objR;
            //ConnectToDatabase();
            objR = _DataAccess.ExecDataReader(strQuery, CommandType.Text);
            if (CloseConnection)
            {
                _DataAccess.CloseDbConn();
            }
            return objR;
        }

        //To Execute a Query
        public int ExecuteNonQuery(string strQuery)
        {
            int iret;
            ConnectToDatabase();
            iret = _DataAccess.ExecNonQuery(strQuery, CommandType.Text);
            CloseConnection();
            return iret;
        }

        //Overloading of ExecuteNonQuery
        public int ExecuteNonQuery(CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            int iret;
            ConnectToDatabase();
            iret = _DataAccess.ExecNonQuery(commandType, commandText, commandParameters);
            _DataAccess.CloseDbConn();
            return iret;
        }

        //Overloading of ExecuteNonQuery StoredProcedure
        public int ExecuteNonQuery(string strQuery, bool CloseConnection)
        {
            int iret;
            ConnectToDatabase();
            iret = _DataAccess.ExecNonQuery(strQuery, CommandType.Text);
            _DataAccess.CloseDbConn();
            return iret;
        }

        //To begin a TRANSACTION
        public void BeginTrans()
        {
            _DataAccess.BeginTrans(IsolationLevel.ReadUncommitted);
        }
        //To Undo the commands
        public void AbortTrans()
        {
            _DataAccess.AbortTrans();
        }
        //To commit the set of instructions
        public void CommitTrans()
        {
            _DataAccess.CommitTrans();
        }
        //connect to database

        public IDataReader ExecScalerSP_Reader(CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            IDataReader DR;
            //ConnectToDatabase();
            DR = _DataAccess.ExecuteSP_GetDR(commandType, commandText, commandParameters);
            return DR;
        }
        public DataSet ExecScalerSP_DataSet(CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            DataSet DS;
            DS = _DataAccess.ExecuteSP_GetDS(commandType, commandText, commandParameters);
            CloseConnection();
            return DS;
        }
        public object ExecScalerSP_Object(CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            object obj = new object();
            obj = _DataAccess.ExecuteSP(commandType, commandText, commandParameters);
            return obj;
        }

    }
}
