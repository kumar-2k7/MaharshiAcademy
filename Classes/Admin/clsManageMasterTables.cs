using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classes.Tables;
using BLL;
using System.Data;
using System.Data.SqlClient;

namespace Classes.Admin
{
    public class clsManageMasterTables
    {
        BLLQuery DB = new BLLQuery();
        BLL.BLLQuery objQ = new BLL.BLLQuery();
        string strSql;

        public void MainCourseInsertUpdate(TBL_MAIN_COURSE obj)
        {
            DB.ExecScalerSP_Object(CommandType.StoredProcedure, "USP_TBL_MAIN_COURSE_InsertUpdate",
                new SqlParameter("@MAIN_COURSE_ID", obj.MAIN_COURSE_ID),
                new SqlParameter("@COURSE_NAME", obj.COURSE_NAME),
                new SqlParameter("@COURSE_DESC", obj.COURSE_DESC),
                new SqlParameter("@CREATED_ON", obj.CREATED_ON),
                new SqlParameter("@CREATED_BY", obj.CREATED_BY),
                new SqlParameter("@MODIFIED_ON", obj.MODIFIED_ON),
                new SqlParameter("@MODIFIED_BY", obj.MODIFIED_BY),
                new SqlParameter("@PURGEFLAG", obj.PURGEFLAG));
            CloseAll();
        }

        public void MainCourseInsertUpdate(TBL_MAIN_COURSE obj, out int resultNo, out string resultDesc)
        {
            SqlParameter resultNoSQL = new SqlParameter("@RESULT_NO", SqlDbType.Int, 100);
            resultNoSQL.Direction = ParameterDirection.Output;
            SqlParameter resultDescSQL = new SqlParameter("@RESULT_DESC", SqlDbType.NVarChar, 2000);
            resultDescSQL.Direction = ParameterDirection.Output;

            DB.ExecScalerSP_Object(CommandType.StoredProcedure, "USP_TBL_MAIN_COURSE_InsertUpdate",
                new SqlParameter("@MAIN_COURSE_ID", obj.MAIN_COURSE_ID),
                new SqlParameter("@COURSE_NAME", obj.COURSE_NAME),
                new SqlParameter("@COURSE_DESC", obj.COURSE_DESC),
                new SqlParameter("@CREATED_ON", obj.CREATED_ON),
                new SqlParameter("@CREATED_BY", obj.CREATED_BY),
                new SqlParameter("@MODIFIED_ON", obj.MODIFIED_ON),
                new SqlParameter("@MODIFIED_BY", obj.MODIFIED_BY),
                new SqlParameter("@PURGEFLAG", obj.PURGEFLAG),
                resultNoSQL, resultDescSQL);
            resultNo = Convert.ToInt32(resultNoSQL.Value.ToString());
            resultDesc = resultDescSQL.Value.ToString();
            CloseAll();
        }

        public DataTable MainCourseSelectAll(DropDownSelectionType SelectedType)
        {
            DataTable dt = new DataTable();
            dt = DB.ExecScalerSP_DataSet(CommandType.StoredProcedure, "USP_TBL_MAIN_COURSE_Select"
                , new SqlParameter("@SelectionType", (int)SelectedType)).Tables[0];
            CloseAll();
            return dt;
        }

        public void SubCategoryInsertUpdate(TBL_SUB_CATEGORY obj)
        {
            DB.ExecScalerSP_Object(CommandType.StoredProcedure, "USP_TBL_SUB_CATEGORY_InsertUpdate",
                 new SqlParameter("@SUBCAT_ID", obj.SUBCAT_ID),
                 new SqlParameter("@MAIN_COURSE_ID", obj.MAIN_COURSE_ID),
                 new SqlParameter("@SUBCAT_NAME", obj.SUBCAT_NAME),
                 new SqlParameter("@SUBCAT_DESC", obj.SUBCAT_DESC),
                 new SqlParameter("@CREATED_ON", obj.CREATED_ON),
                 new SqlParameter("@CREATED_BY", obj.CREATED_BY),
                 new SqlParameter("@MODIFIED_ON", obj.MODIFIED_ON),
                 new SqlParameter("@MODIFIED_BY", obj.MODIFIED_BY),
                 new SqlParameter("@PURGEFLAG", obj.PURGEFLAG));
            CloseAll();
        }

        public DataTable SubCategorySelectAll(DropDownSelectionType SelectedType)
        {
            DataTable dt = new DataTable();
            dt = DB.ExecScalerSP_DataSet(CommandType.StoredProcedure, "USP_TBL_SUB_CATEGORY_Select"
                , new SqlParameter("@SelectionType", (int)SelectedType)).Tables[0];
            CloseAll();
            return dt;
        }

        public DataTable SubCategoryWithCourseNameForList(DropDownSelectionType SelectedType)
        {
            DataTable dt = new DataTable();
            dt = DB.ExecScalerSP_DataSet(CommandType.StoredProcedure, "USP_SubCategoryWithMainCourse_Select"
                , new SqlParameter("@SelectionType", (int)SelectedType)).Tables[0];
            CloseAll();
            return dt;
        }

        public DataTable SubCategoryWithCourseNameForList(string SelectedSubject, DropDownSelectionType SelectedType)
        {
            DataTable dt = new DataTable();
            dt = DB.ExecScalerSP_DataSet(CommandType.StoredProcedure, "USP_SubCategoryWithMainCourse_Select"
                , new SqlParameter("@SelectedSubject", (string)SelectedSubject)
                , new SqlParameter("@SelectionType", (int)SelectedType)).Tables[0];
            CloseAll();
            return dt;
        }

        public DataTable SubejctForList(DropDownSelectionType SelectedType, string SubCategoryIDs)
        {
            DataTable dt = new DataTable();
            dt = DB.ExecScalerSP_DataSet(CommandType.StoredProcedure, "USP_SubejctForList_Select"
                , new SqlParameter("@SelectionType", (int)SelectedType)
                , new SqlParameter("@SubCategoryIDs", SubCategoryIDs)).Tables[0];
            CloseAll();
            return dt;
        }

        public DataTable SubjectSelectAll(DropDownSelectionType SelectedType)
        {
            DataTable dt = new DataTable();
            dt = DB.ExecScalerSP_DataSet(CommandType.StoredProcedure, "USP_TBL_SUBJECT_Select"
                , new SqlParameter("@SelectionType", (int)SelectedType)).Tables[0];
            CloseAll();
            return dt;
        }

        public void SubjectInsertUpdate(TBL_SUBJECT obj)
        {
            DB.ExecScalerSP_Object(CommandType.StoredProcedure, "USP_TBL_SUBJECT_InsertUpdate",
                 new SqlParameter("@SUBJECT_ID", obj.SUBJECT_ID),
                 new SqlParameter("@SUBCAT_ID", obj.SUBCAT_ID),
                 new SqlParameter("@SUBJECT_NAME", obj.SUBJECT_NAME),
                 new SqlParameter("@CREATED_ON", obj.CREATED_ON),
                 new SqlParameter("@CREATED_BY", obj.CREATED_BY),
                 new SqlParameter("@MODIFIED_ON", obj.MODIFIED_ON),
                 new SqlParameter("@MODIFIED_BY", obj.MODIFIED_BY),
                 new SqlParameter("@PURGEFLAG", obj.PURGEFLAG));
            CloseAll();
        }

        private void CloseAll()
        {
            DB.CloseConnection();
            objQ.CloseConnection();
        }
    }
}
