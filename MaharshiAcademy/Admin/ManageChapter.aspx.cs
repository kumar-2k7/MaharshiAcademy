using Classes;
using Classes.Admin;
using Classes.Tables;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_ManageChapter : AdminPageBase
{
    clsManageMasterTables obj_MC;
    TBL_SUBJECT obj;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Bind_ddlSubject();
        }
    }

    private void Bind_ddlSubject()
    {
        try
        {
            obj_MC = new clsManageMasterTables();
            DataTable dt = obj_MC.SubejctForList(DropDownSelectionType.Active, DbConnect.CommaSeparatedValues(chklMainCourseSubCategory));
            ddlSubject.DataSource = dt;
            ddlSubject.DataValueField = "CODE";
            ddlSubject.DataTextField = "NAME";
            ddlSubject.DataBind();
            ddlSubject.Items.Insert(0, new ListItem("-- Select a Subject --", "0"));
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }

    private void Bind_chklMainCourseSubCategory()
    {
        try
        {
            obj_MC = new clsManageMasterTables();
            DataTable dt = obj_MC.SubCategoryWithCourseNameForList(DropDownSelectionType.Active);
            chklMainCourseSubCategory.DataSource = dt;
            chklMainCourseSubCategory.DataValueField = "CODE";
            chklMainCourseSubCategory.DataTextField = "NAME";
            chklMainCourseSubCategory.DataBind();
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }

    protected void btnSaveNewChapter_Click(object sender, EventArgs e)
    {

    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
    }

    protected void ddlSubject_SelectedIndexChanged(object sender, EventArgs e)
    {

        try
        {
            obj_MC = new clsManageMasterTables();
            DataTable dt = obj_MC.SubCategoryWithCourseNameForList(ddlSubject.SelectedValue, DropDownSelectionType.Active);
            chklMainCourseSubCategory.DataSource = dt;
            chklMainCourseSubCategory.DataValueField = "CODE";
            chklMainCourseSubCategory.DataTextField = "NAME";
            chklMainCourseSubCategory.DataBind();
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }
}