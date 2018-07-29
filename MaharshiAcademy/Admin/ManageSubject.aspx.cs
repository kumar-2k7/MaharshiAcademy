using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Classes;
using Classes.Admin;
using Classes.Tables;
using System.Data;

public partial class Admin_ManageSubject : AdminPageBase
{
    clsManageMasterTables obj_MC;
    TBL_SUBJECT obj;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Bind_chklMainCourseSubCategory();
            Bind_grdSubject();
        }
    }

    private void Bind_grdSubject()
    {
        try
        {
            obj_MC = new clsManageMasterTables();
            DataTable dt = obj_MC.SubjectSelectAll(DropDownSelectionType.All);
            grdSubject.DataSource = dt;
            grdSubject.DataBind();
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

    protected void btnSaveNewSubCategory_Click(object sender, EventArgs e)
    {
        try
        {
            obj_MC = new clsManageMasterTables();
            obj = new TBL_SUBJECT();
            obj.SUBJECT_ID = 0;
            obj.SUBCAT_ID = string.Join(",", (chklMainCourseSubCategory.Items.Cast<ListItem>().Where(li => li.Selected).ToList()).Select(i => i.Value));
            obj.SUBJECT_NAME = txtSubjectName.Text;
            obj.CREATED_ON = DbConnect.GetCurrentDateTimeIndia();
            obj.CREATED_BY = 1000000001;
            obj.MODIFIED_ON = DbConnect.GetCurrentDateTimeIndia();
            obj.MODIFIED_BY = 1000000001;
            obj.PURGEFLAG = "A";
            obj_MC.SubjectInsertUpdate(obj);
            Bind_grdSubject();
            txtSubjectName.Text =  string.Empty;
            chklMainCourseSubCategory.ClearSelection();
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        Response.Redirect("ManageSubject.aspx");
    }
}