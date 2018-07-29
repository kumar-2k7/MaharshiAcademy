using BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes.Admin
{
    public class clsUserLoginManage
    {
        BLLQuery DB = new BLLQuery();
        BLL.BLLQuery objQ = new BLL.BLLQuery();
        string strSql;

        public DataTable GetLogin(string UserID, string UserPassword)
        {
            DataTable dt = new DataTable();
            dt = DB.ExecScalerSP_DataSet(CommandType.StoredProcedure, "USP_TBL_LOGIN_DETAIL_ValidateUser"
                , new SqlParameter("@USER_ID", UserID)
                , new SqlParameter("@USER_PWD", UserPassword)).Tables[0];
            CloseAll();
            return dt;
        }

        private void CloseAll()
        {
            DB.CloseConnection();
            objQ.CloseConnection();
        }
    }
}
