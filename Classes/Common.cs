using System;
using System.Text;
using System.Data;
using BLL;
using System.Web;
using System.IO;
using System.Data.SqlClient;
using System.Net;
using System.Security.Cryptography;

namespace Classes
{
    public class Common
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
            //GC.Collect();
        }


        public static string GetMonthNameFull(int mm)
        {
            string strM = "";
            switch (mm)
            {
                case 1:
                    strM = "January";
                    break;
                case 2:
                    strM = "February";
                    break;
                case 3:
                    strM = "March";
                    break;
                case 4:
                    strM = "April";
                    break;
                case 5:
                    strM = "May";
                    break;
                case 6:
                    strM = "June";
                    break;
                case 7:
                    strM = "July";
                    break;
                case 8:
                    strM = "August";
                    break;
                case 9:
                    strM = "September";
                    break;
                case 10:
                    strM = "October";
                    break;
                case 11:
                    strM = "November";
                    break;
                case 12:
                    strM = "December";
                    break;
                default:
                    break;
            }
            return strM;
        }


        public static string GetHTMLFileData(string FileNameWithPath)
        {
            string strresp = "";
            try
            {
                string URL = FileNameWithPath;
                WebRequest wq = WebRequest.Create(URL);
                WebResponse wresp = wq.GetResponse();
                StreamReader sr = new StreamReader(wresp.GetResponseStream());
                strresp = sr.ReadToEnd();
                sr.Close();
            }
            catch
            {
                //System.Web.HttpContext.Current.Response.Write(FileNameWithPath);
                //System.Web.HttpContext.Current.Response.End();
            }
            return strresp;
        }

        public static string GetFinancialYear
        {
            get { return DateTime.Now.Month >= 4 ? (DateTime.Now.ToString("yyyy") + "-" + (DateTime.Now.AddYears(1)).ToString("yy")) : ((DateTime.Now.AddYears(-1)).ToString("yyyy") + "-" + DateTime.Now.ToString("yy")); }
        }
        public static string GetPhysicalPath
        {
            get
            {
                return System.Web.HttpContext.Current.Request.PhysicalApplicationPath;
            }
        }

        public static string GetBaseURL
        {
            get
            {
                return System.Web.HttpContext.Current.Application["SitePath"].ToString();
            }
        }

        public static string GetBaseURLAdmin
        {
            get
            {
                return System.Web.HttpContext.Current.Application["SitePathAdmin"].ToString();
            }
        }
        public static string GetBaseURL_PDF_Image
        {
            get
            {
                return System.Web.HttpContext.Current.Application["PDF_SitePath"].ToString();
            }
        }
        public static string GetBaseURLClient
        {
            get
            {
                return System.Web.HttpContext.Current.Application["SitePathClient"].ToString();
            }
        }

        public static string CutString(string str, Int32 length)
        {
            string CutStr = string.Empty;
            if (str.Length > length)
            {
                CutStr = str.Substring(0, length) + "..";
            }
            else
            {
                CutStr = str;
            }
            return CutStr;
        }

        //public string GetUniqueFileName(string FileName, string PhysicalPath)
        //{
        //    if (!System.IO.Directory.Exists(PhysicalPath))
        //    {
        //        System.IO.Directory.CreateDirectory(PhysicalPath);
        //    }
        //    string Extension = GetExtension(FileName, PhysicalPath);
        //    FileName = GetFileNameWithoutExtension(FileName, PhysicalPath);
        //    string FName = FileName;
        //    int i = 1;
        //    while (System.IO.File.Exists(PhysicalPath + FileName + Extension))
        //    {
        //        FileName = FName + i.ToString();
        //        i = i + 1;
        //    }
        //    return FileName + Extension;
        //}
        //public string GetExtension(string FileName, string PhysicalPath)
        //{
        //    return System.IO.Path.GetExtension(PhysicalPath + FileName);
        //}
        //public string GetFileNameWithoutExtension(string FileName, string PhysicalPath)
        //{
        //    return System.IO.Path.GetFileNameWithoutExtension(PhysicalPath + FileName);
        //}

        public int GetDays_In_Month(int month, int year)
        {
            if (1 == month || 3 == month || 5 == month || 7 == month || 8 == month ||
                10 == month || 12 == month)
            {
                return 31;
            }
            else if (2 == month)
            {
                // Check for leap year
                if (0 == (year % 4))
                {
                    // If date is divisible by 400, it's a leap year.
                    // Otherwise, if it's divisible by 100 it's not.
                    if (0 == (year % 400))
                    {
                        return 29;
                    }
                    else if (0 == (year % 100))
                    {
                        return 28;
                    }

                    // Divisible by 4 but not by 100 or 400
                    // so it leaps
                    return 29;
                }
                // Not a leap year
                return 28;
            }
            return 30;
        }
        public static string GetDateFormat_Short(DateTime strDate)
        {
            string strReturnDate = "";
            try
            {
                strReturnDate = strDate.ToString("MM/dd/yyyy");
                return strReturnDate;
            }
            catch
            {
                return strDate.ToShortDateString();
            }
        }
        public static string GetDateFormat_Full(DateTime strDate)
        {
            string strReturnDate = "";
            try
            {
                strReturnDate = strDate.ToString("MM/dd/yyyy hh:mm:ss tt");
                return strReturnDate;
            }
            catch
            {
                return strDate.ToString();
            }
        }
        public static string getDateInFormat(string strDate, string strFormat)
        {
            string strReturnDate = "";
            try
            {
                DateTime objDate = Convert.ToDateTime(strDate);
                strReturnDate = objDate.ToString(strFormat);
                return strReturnDate;
            }
            catch
            {
                return strDate;
            }
        }
        public static DataTable GetHours()
        {
            DataTable dt = Hours();
            for (int i = 1; i < 13; i++)
            {
                dt = InsertHours(dt, Convert.ToString(i));
            }
            return dt;
        }
        public static DataTable Hours()
        {
            DataTable dt = new DataTable();
            DataColumn Value = new DataColumn("Value", Type.GetType("System.String"));
            dt.Columns.Add(Value);
            return dt;
        }
        public static DataTable InsertHours(DataTable dt, string value)
        {
            DataTable rt = dt;
            DataRow Newrow;
            Newrow = rt.NewRow();
            Newrow["Value"] = value;
            rt.Rows.Add(Newrow);
            return rt;
        }
        public static DataTable GetMinutes()
        {
            DataTable dt = Minutes();
            for (int i = 0; i < 60; i++)
            {
                if (i.ToString().Length < 2)
                {
                    string add = "0" + i.ToString();
                    dt = InsertMinutes(dt, Convert.ToString(add));
                }
                else
                {
                    dt = InsertMinutes(dt, Convert.ToString(i));
                }
            }
            return dt;
        }
        public static DataTable Minutes()
        {
            DataTable dt = new DataTable();
            DataColumn Value = new DataColumn("Value", Type.GetType("System.String"));
            dt.Columns.Add(Value);
            return dt;
        }
        public static DataTable InsertMinutes(DataTable dt, string value)
        {
            DataTable rt = dt;
            DataRow Newrow;
            Newrow = rt.NewRow();
            Newrow["Value"] = value;
            rt.Rows.Add(Newrow);
            return rt;
        }
        public string DateNote()
        {
            return "";//"NOTE: Date Format is \"mm/dd/yyyy\"";
        }

        public static string GetResumeID()
        {
            string ResumeID = "";
            ResumeID = DateTime.Now.ToShortDateString().ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();
            ResumeID = ResumeID.Replace("/", "");
            ResumeID = ResumeID.Replace("\\", "");
            ResumeID = ResumeID.Replace(":", "");
            ResumeID = ResumeID.Replace(" ", "");
            ResumeID = ResumeID.Replace("PM", "");
            ResumeID = ResumeID.Replace("AM", "");
            return ResumeID;
        }
        public static bool IsUserIDExists(string UserID)
        {
            BLLQuery DB = new BLLQuery();
            SqlParameter[] SqlParam = { new SqlParameter("@UserID", UserID) };
            int Status = 0;
            try
            {
                Status = Convert.ToInt32(DB.ExecScalerSP_Object(CommandType.StoredProcedure, "SP_User_CheckDuplicateUserId", SqlParam));

            }
            catch
            {
                Status = 0;
            }
            if (Status > 0)
                return true;
            return false;
        }

        public static string EncryptString(string oid)
        {
            string password = "3$t0rcr3d1t";
            TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
            des.IV = new byte[8];
            PasswordDeriveBytes pdb = new PasswordDeriveBytes(password, new byte[0]);
            des.Key = pdb.CryptDeriveKey("RC2", "MD5", 128, new byte[8]);
            MemoryStream ms = new MemoryStream(oid.Length * 2);
            CryptoStream encStream = new CryptoStream(ms, des.CreateEncryptor(),
                CryptoStreamMode.Write);
            byte[] plainBytes = Encoding.UTF8.GetBytes(oid);
            encStream.Write(plainBytes, 0, plainBytes.Length);
            encStream.FlushFinalBlock();
            byte[] encryptedBytes = new byte[ms.Length];
            ms.Position = 0;
            ms.Read(encryptedBytes, 0, (int)ms.Length);
            encStream.Close();
            return Convert.ToBase64String(encryptedBytes).Replace("+", "__");
        }

        public static string DecryptString(string encryptedBase64)
        {
            try
            {
                string password = "3$t0rcr3d1t";
                TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
                des.IV = new byte[8];
                PasswordDeriveBytes pdb = new PasswordDeriveBytes(password, new byte[0]);
                des.Key = pdb.CryptDeriveKey("RC2", "MD5", 128, new byte[8]);
                byte[] encryptedBytes = Convert.FromBase64String(encryptedBase64.Replace("__", "+"));
                MemoryStream ms = new MemoryStream(encryptedBase64.Length);
                CryptoStream decStream = new CryptoStream(ms, des.CreateDecryptor(),
                    CryptoStreamMode.Write);
                decStream.Write(encryptedBytes, 0, encryptedBytes.Length);
                decStream.FlushFinalBlock();
                byte[] plainBytes = new byte[ms.Length];
                ms.Position = 0;
                ms.Read(plainBytes, 0, (int)ms.Length);
                decStream.Close();
                return Encoding.UTF8.GetString(plainBytes);
            }
            catch
            {
                return "0";
            }
        }

        private DataSet FillCountryDropDownList()
        {
            DataSet ds = new DataSet();
            SqlParameter[] param = new SqlParameter[0];
            ds = DB.ExecScalerSP_DataSet(CommandType.StoredProcedure, "SP_Get_Country", param);
            CloseAll();
            return ds;
        }
        private DataSet FillStateDropDownList(string countryId)
        {
            DataSet ds = new DataSet();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@countryId", countryId);
            ds = DB.ExecScalerSP_DataSet(CommandType.StoredProcedure, "SP_Get_State", param);
            CloseAll();
            return ds;
        }

        private DataSet FillCreditCardType()
        {
            DataSet ds = new DataSet();
            ds = DB.ExecScalerSP_DataSet(CommandType.StoredProcedure, "SP_CreditCard_GetType", null);
            CloseAll();
            return ds;
        }

        public class DisplayMessage
        {
            public enum Enum_MessageType
            {
                ErrorMessage,
                ConfirmMessage
            }
            public enum Enum_TableStyle
            {
                DisplayNone,
                VisibilityHidden,
                None
            }

            public static string Display(string Message, Enum_MessageType MsgType, int TimeToDisposeinSeconds, Enum_TableStyle TableStyle)
            {
                StringBuilder Html = new StringBuilder();
                string ClassName = "";
                string ImageNameWithPath = "";
                if (MsgType == Enum_MessageType.ErrorMessage)
                {
                    ImageNameWithPath = GetBaseURL + "admin/images/error.gif";
                    ClassName = "DisplayError";
                }
                if (MsgType == Enum_MessageType.ConfirmMessage)
                {
                    ImageNameWithPath = GetBaseURL + "admin/images/success.gif";
                    ClassName = "DisplayMessage";
                }
                string TableID = System.DateTime.Now.ToString("ddMMyyhhmmss");
                int Duration = TimeToDisposeinSeconds * 1000;
                if ((TableStyle == Enum_TableStyle.DisplayNone))
                {
                    Html.AppendLine("<script language=\"javascript\">setTimeout(\"document.getElementById('" + TableID + "').style.display='none';\"," + Duration.ToString() + ")</script>");
                }
                else if ((TableStyle == Enum_TableStyle.VisibilityHidden))
                {
                    Html.AppendLine("<script language=\"javascript\">setTimeout(\"document.getElementById('" + TableID + "').style.visibility='hidden';\"," + Duration.ToString() + ")</script>");
                }
                Html.AppendLine("<table cellpadding=\"0\" id=\"" + TableID + "\" cellspacing=\"0\" border=\"0\" class=\"" + ClassName + "\">");
                Html.AppendLine("<tr>");
                Html.AppendLine("<td valign=\"top\"><img src=\"" + ImageNameWithPath + "\" border=\"0\"></td>");
                Html.AppendLine("<td valign=\"top\" align=\"left\">" + Message + "</td>");
                Html.AppendLine("</tr>");
                Html.AppendLine("</table>");
                return Html.ToString();
            }


        }

        public void delete_file_from_folder(string Physical_Path, string File_Name)
        {
            if (System.IO.File.Exists(Physical_Path + File_Name))
            {
                System.IO.File.Delete(Physical_Path + File_Name);
            }
        }

        public static string VirtualPath_OtherDoc()
        {
            return GetBaseURL + "OtherDoc/";
        }
        public static string GetPhysicalPath_OtherDoc()
        {
            return System.Web.HttpContext.Current.Request.PhysicalApplicationPath + "OtherDoc\\";
        }

        public void Other_Doc_Insert(string FileName, string FileNameUserGiven, string System_Date_String, string Description, string Status, int UserID)
        {
            DB.ExecScalerSP_Object(CommandType.StoredProcedure, "SP_Other_Documents_User_Insert_Update",
                  new SqlParameter("@UserID", UserID),
                  new SqlParameter("@File_Name_By_User", FileNameUserGiven),
                  new SqlParameter("@File_Name_On_Disk", FileName),
                  new SqlParameter("@Upload_Date", System_Date_String),
                  new SqlParameter("@Description", Description),
                  new SqlParameter("@Status", Status));
            CloseAll();
        }

        public void Other_Doc_User_Delete(int UserID)
        {
            DB.ExecScalerSP_Object(CommandType.StoredProcedure, "SP_Other_Documents_User_Delete", new SqlParameter("@UserID", UserID));
            CloseAll();
        }

        public DataSet Other_Doc_User_Select(int UserID)
        {
            DataSet ds = new DataSet();
            ds = DB.ExecScalerSP_DataSet(CommandType.StoredProcedure, "SP_Other_Documents_User_Select",
                 new SqlParameter("@UserID", UserID));
            CloseAll();
            return ds;
        }

        public DataTable Other_Doc_User_Select_All()
        {
            DataSet ds = new DataSet();
            ds = DB.ExecScalerSP_DataSet(CommandType.StoredProcedure, "SP_Other_Documents_User_Select_All");
            CloseAll();
            return ds.Tables[0];
        }

        public void WriteLog(string ClientNumber, string UserID, string TextMessgae)
        {
            StringBuilder s = new StringBuilder(TextMessgae);

            string LogPath = Classes.Common.GetPhysicalPath + "QuatationLog\\";
            if (!System.IO.Directory.Exists(LogPath))
            {
                System.IO.Directory.CreateDirectory(LogPath);
            }

            string FileName = LogPath + ClientNumber + "_" + UserID + "_" + "Quatation.Log";

            if (System.IO.File.Exists(FileName))
            {
                TextWriter tw = new StreamWriter(FileName, true);
                tw.WriteLine(System.DateTime.Now.ToString() + " : " + TextMessgae);
                tw.Close();
            }
            else
            {
                TextWriter tw = new StreamWriter(FileName, true);
                tw.WriteLine("---- Client No.: " + ClientNumber + " -----------------------------");
                tw.WriteLine(System.DateTime.Now.ToString() + " : " + TextMessgae);
                tw.Close();
            }
        }

        public void WriteLogLineEnd(string ClientNumber, string UserID)
        {
            string LogPath = Classes.Common.GetPhysicalPath + "QuatationLog\\";
            if (!System.IO.Directory.Exists(LogPath))
            {
                System.IO.Directory.CreateDirectory(LogPath);
            }

            string FileName = LogPath + ClientNumber + "_" + UserID + "_" + "Quatation.Log";

            if (System.IO.File.Exists(FileName))
            {
                TextWriter tw = new StreamWriter(FileName, true);
                tw.WriteLine("----------------------------------------------- End");
                tw.Close();
            }
        }
        public string GetPhysicalPath_Admin_DocumentWrite()
        {
            return System.Web.HttpContext.Current.Request.PhysicalApplicationPath + "Upload\\Documents\\";
        }

        #region "Get Virtual Path"
        public static string GetVirtualPath
        {
            get
            {
                return GetBaseURL + "Upload/Photo_Gallery/";
            }
        }

        public static string GetBaseURL_News_Image
        {
            get
            {
                return GetBaseURL + "Upload/Photo_Gallery/";
            }
        }
        #endregion

        #region "Get Physical Path Admin LOI"
        public string GetPhysicalPath_Admin_LOI()
        {
            return System.Web.HttpContext.Current.Request.PhysicalApplicationPath + "admin\\LOI\\LOILetter\\";
        }

        public static string GetVirtualPath_LOI
        {
            get
            {
                return GetBaseURL + "admin/LOI/LOILetter/";
            }
        }
        #endregion
    }

    /// <summary>
    /// Drop Down List Selection Type -
    /// , All = 1
    /// , Active = 2
    /// , Inactive = 3
    /// </summary>
    public enum DropDownSelectionType
    {
        All = 1,
        Active = 2,
        Inactive = 3
    }
}
