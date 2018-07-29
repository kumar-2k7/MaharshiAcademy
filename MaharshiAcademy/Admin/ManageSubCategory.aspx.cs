using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Classes;
using Classes.Admin;
using Classes.Tables;

public partial class Admin_ManageSubCategory : AdminPageBase
{
    clsManageMasterTables obj_MC;
    TBL_SUB_CATEGORY obj;

    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            Bind_ddlMainCourse();
            Bind_grdSubCategory();
        }
    }

    private void Bind_ddlMainCourse()
    {
        try
        {
            obj_MC = new clsManageMasterTables();
            DataTable dt = obj_MC.MainCourseSelectAll(DropDownSelectionType.Active);
            ddlMainCourse.DataSource = dt;
            ddlMainCourse.DataValueField = "MAIN_COURSE_ID";
            ddlMainCourse.DataTextField = "COURSE_NAME";
            ddlMainCourse.DataBind();
            ddlMainCourse.Items.Insert(0, new ListItem("-- Select a Main Course --", "0"));
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }

    protected void btnSaveNewSubCategory_Click(object sender, EventArgs e)
    {
        try
        {
            obj_MC = new clsManageMasterTables();
            obj = new TBL_SUB_CATEGORY();
            obj.SUBCAT_ID = 0;
            obj.MAIN_COURSE_ID = Convert.ToInt32(ddlMainCourse.SelectedValue);
            obj.SUBCAT_NAME = txtSubCategoryName.Text;
            obj.SUBCAT_DESC = txtSubCategoryDesc.Text;
            obj.CREATED_ON = DbConnect.GetCurrentDateTimeIndia();
            obj.CREATED_BY = 1000000001;
            obj.MODIFIED_ON = DbConnect.GetCurrentDateTimeIndia();
            obj.MODIFIED_BY = 1000000001;
            obj.PURGEFLAG = "A";
            obj_MC.SubCategoryInsertUpdate(obj);
            Bind_grdSubCategory();
            txtSubCategoryName.Text = txtSubCategoryDesc.Text = string.Empty;
            ddlMainCourse.SelectedValue = "0";
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }

    private void Bind_grdSubCategory()
    {
        try
        {
            obj_MC = new clsManageMasterTables();
            DataTable dt = obj_MC.SubCategorySelectAll(DropDownSelectionType.All);
            grdSubCategory.DataSource = dt;
            grdSubCategory.DataBind();
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        Response.Redirect("ManageSubCategory.aspx");
    }
}