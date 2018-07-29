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

public partial class Admin_ManageMainCourse : AdminPageBase
{
    clsManageMasterTables obj_MC;
    TBL_MAIN_COURSE obj;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Bind_grdMainCourse();
        }
    }

    private void Bind_grdMainCourse()
    {
        try
        {
            obj_MC = new clsManageMasterTables();
            DataTable dt = obj_MC.MainCourseSelectAll(DropDownSelectionType.All);
            grdMainCourse.DataSource = dt;
            grdMainCourse.DataBind();
            //div_grdMainCourse.Visible = true;
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }

    protected void btnSaveNewMainCourse_Click(object sender, EventArgs e)
    {
        try
        {
            int resultNo = 0;
            string resultDesc = string.Empty;
            obj_MC = new clsManageMasterTables();
            obj = new TBL_MAIN_COURSE();
            obj.MAIN_COURSE_ID = 0;
            obj.COURSE_NAME = txtMainCourseName.Text;
            obj.COURSE_DESC = txtMainCourseDesc.Text;
            obj.CREATED_ON = DbConnect.GetCurrentDateTimeIndia();
            obj.CREATED_BY = 1000000001;
            obj.MODIFIED_ON = DbConnect.GetCurrentDateTimeIndia();
            obj.MODIFIED_BY = 1000000001;
            obj.PURGEFLAG = "A";
            obj_MC.MainCourseInsertUpdate(obj, out resultNo, out resultDesc);
            Response.Write(resultDesc);
            Bind_grdMainCourse();
            txtMainCourseDesc.Text = txtMainCourseName.Text = string.Empty;
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        Response.Redirect("ManageMainCourse.aspx");
    }

    protected void grdMainCourse_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdMainCourse.EditIndex = -1;
        grdMainCourse.PageIndex = e.NewPageIndex;
        Bind_grdMainCourse();
    }

    protected void grdMainCourse_RowCommand(object sender, GridViewCommandEventArgs e)
    {
    }

    protected void grdMainCourse_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        grdMainCourse.EditIndex = -1;
        Bind_grdMainCourse();
    }

    protected void grdMainCourse_RowEditing(object sender, GridViewEditEventArgs e)
    {
        grdMainCourse.EditIndex = e.NewEditIndex;
        Bind_grdMainCourse();
    }

    protected void grdMainCourse_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        GridViewRow row = grdMainCourse.Rows[e.RowIndex];
        TextBox txtMainCourseNameGRD = (TextBox)row.FindControl("txtMainCourseNameGRD");
        TextBox txtMainCourseDescGRD = (TextBox)row.FindControl("txtMainCourseDescGRD");

        int resultNo = 0;
        string resultDesc = string.Empty;
        obj_MC = new clsManageMasterTables();
        obj = new TBL_MAIN_COURSE();
        obj.MAIN_COURSE_ID = Convert.ToInt32(grdMainCourse.DataKeys[e.RowIndex].Value.ToString());
        obj.COURSE_NAME = txtMainCourseNameGRD.Text;
        obj.COURSE_DESC = txtMainCourseDescGRD.Text;
        obj.CREATED_ON = DbConnect.GetCurrentDateTimeIndia();
        obj.CREATED_BY = 1000000001;
        obj.MODIFIED_ON = DbConnect.GetCurrentDateTimeIndia();
        obj.MODIFIED_BY = 1000000001;
        obj.PURGEFLAG = "A";
        obj_MC.MainCourseInsertUpdate(obj, out resultNo, out resultDesc);
        Response.Write(resultDesc);
        Bind_grdMainCourse();
        txtMainCourseDesc.Text = txtMainCourseName.Text = string.Empty;

        grdMainCourse.EditIndex = -1;
        Bind_grdMainCourse();
    }

    protected void grdMainCourse_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        grdMainCourse.EditIndex = -1;
        Bind_grdMainCourse();
    }

    protected void grdMainCourse_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            CheckBox chkPURGEFLAG = (CheckBox)e.Row.FindControl("chkPURGEFLAG");
            HiddenField hdnfPurgeFlag = (HiddenField)e.Row.FindControl("hdnfPurgeFlag");

            if (hdnfPurgeFlag.Value == "A")
                chkPURGEFLAG.Checked = true;
            else
                chkPURGEFLAG.Checked = false;
        }
    }

    protected void chkPURGEFLAG_OnCheckedChanged(object sender, EventArgs e)
    {
        CheckBox chkPURGEFLAG = (CheckBox)sender;
        GridViewRow row = (GridViewRow)chkPURGEFLAG.NamingContainer;
        HiddenField hdnfPurgeFlag = (HiddenField)row.FindControl("hdnfPurgeFlag");
        int rowindex = row.RowIndex;

        int resultNo = 0;
        string resultDesc = string.Empty;
        obj_MC = new clsManageMasterTables();
        obj = new TBL_MAIN_COURSE();
        obj.MAIN_COURSE_ID = Convert.ToInt32(grdMainCourse.DataKeys[rowindex].Value.ToString());
        obj.CREATED_ON = DbConnect.GetCurrentDateTimeIndia();
        obj.MODIFIED_ON = DbConnect.GetCurrentDateTimeIndia();
        obj.MODIFIED_BY = 1000000001;
        if (chkPURGEFLAG.Checked)
            obj.PURGEFLAG = "A";
        else
            obj.PURGEFLAG = "I";
        obj_MC.MainCourseInsertUpdate(obj, out resultNo, out resultDesc);
        Response.Write(resultDesc);
        Bind_grdMainCourse();
        txtMainCourseDesc.Text = txtMainCourseName.Text = string.Empty;

        grdMainCourse.EditIndex = -1;
        Bind_grdMainCourse();
    }
}