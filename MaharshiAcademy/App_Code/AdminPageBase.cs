using System;
using Classes.BusinessEntities;

public class AdminPageBase : System.Web.UI.Page
{
    public AdminPageBase()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    protected override void OnInit(System.EventArgs e)
    {
        if (Session["AdminUser"] == null || Session["AdminUser"].ToString() == "")
            System.Web.HttpContext.Current.Response.Redirect("Default.aspx", true);
        else
        {
            dtoUser obj_user = new dtoUser();
            obj_user = (dtoUser)Session["AdminUser"];

            if (string.IsNullOrEmpty(obj_user.USER_ID))
                System.Web.HttpContext.Current.Response.Redirect("Home.aspx", true);
        }
    }
}