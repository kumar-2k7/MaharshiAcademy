using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using BLL;
using System.Data.SqlClient;

namespace Classes
{
    public class ClsVisiterThought
    {
        BLLQuery DB = new BLLQuery();
        BLL.BLLQuery objQ = new BLL.BLLQuery();
        string strSql;

        public void OpenConnection()
        {
            DB.OpenConnection();
        }

        public void CloseAll()
        {

            DB.CloseConnection();
            objQ.CloseConnection();
        }

        public DataTable VisiterThought_Select(string FromDate, string ToDate, int IsDelete)
        {
            DataTable dt = new DataTable();
            dt = DB.ExecScalerSP_DataSet(CommandType.StoredProcedure, "USP_VisiterThought_SELECT"
                , new SqlParameter("@FromDate", Convert.ToDateTime(FromDate))
                , new SqlParameter("@ToDate", Convert.ToDateTime(ToDate))
                , new SqlParameter("@IsDelete", IsDelete)).Tables[0];
            CloseAll();
            return dt;
        }
    }
}
