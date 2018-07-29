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
    public class clsGangdhariAdmin
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

        public DataTable PageForGNG_GetForSelectedDate(string FromDate, string ToDate)
        {
            DataTable dt = new DataTable();
            dt = DB.ExecScalerSP_DataSet(CommandType.StoredProcedure, "USP_PageForGNG_GetForSelectedDate"
                , new SqlParameter("@FromDate", Convert.ToDateTime(FromDate))
                , new SqlParameter("@ToDate", Convert.ToDateTime(ToDate))).Tables[0];
            CloseAll();
            return dt;
        }

        public int InsertScreen(string ScreenName, string ScreenURL, string ParentScreen, string Created_By, DateTime Created_Date)
        {
            int status = DB.ExecuteNonQuery(CommandType.StoredProcedure, "USP_SCREENS_Insert"
                , new SqlParameter("@SCREEN_NAME", ScreenName)
                , new SqlParameter("@SCREEN_URL", ScreenURL)
                , new SqlParameter("@PRT_SCREEN_CD", ParentScreen)
                , new SqlParameter("@CREATED_BY", Created_By)
                , new SqlParameter("@CREATED_DT", Created_Date));
            CloseAll();
            return status;
        }

        public DataTable GetParentScreens()
        {
            DataTable dt = new DataTable();
            dt = DB.ExecScalerSP_DataSet(CommandType.StoredProcedure, "USP_MST_SCREENS_GetParentList").Tables[0];
            CloseAll();
            return dt;
        }

        public DataTable GetAllScreens()
        {
            DataTable dt = new DataTable();
            dt = DB.ExecScalerSP_DataSet(CommandType.StoredProcedure, "USP_MST_SCREENS_SelectAll").Tables[0];
            CloseAll();
            return dt;
        }
    }
}
