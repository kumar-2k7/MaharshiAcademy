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
    public class clsGangdhari
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

        public DataTable GetImagesFromPostOnSocial()
        {
            DataTable dt = new DataTable();
            dt = DB.ExecScalerSP_DataSet(CommandType.StoredProcedure, "USP_GetImagesFromPostOnSocial").Tables[0];
            CloseAll();
            return dt;
        }

        public int InsertScreen(string ScreenName, string ScreenURL, string ParentScreen, string Created_By, DateTime Created_Date)
        {
            int status = DB.ExecuteNonQuery(CommandType.StoredProcedure, "USP_SCREENS_Insert"
                , new SqlParameter("@STATUS_NAME", ScreenName)
                , new SqlParameter("@STATUS_URL", ScreenURL)
                , new SqlParameter("@PRT_SCREEN_CD", ParentScreen)
                , new SqlParameter("@CREATED_BY", Created_By)
                , new SqlParameter("@CREATED_DT", Created_Date));
            CloseAll();
            return status;
        }

        public int InsertVisiterThought(string Name, string EmailId, string Message, DateTime ReceivedDate, int IsDelete)
        {
            int status = DB.ExecuteNonQuery(CommandType.StoredProcedure, "USP_VisiterThoughtInsert"
                , new SqlParameter("@Name", Name)
                , new SqlParameter("@EmailId", EmailId)
                , new SqlParameter("@Message", Message)
                , new SqlParameter("@ReceivedDate", ReceivedDate)
                , new SqlParameter("@IsDelete", IsDelete));
            CloseAll();
            return status;
        }
    }
}
