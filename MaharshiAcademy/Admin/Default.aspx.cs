using Classes.Admin;
using Classes.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;

public partial class Admin_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        { }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            clsUserLoginManage objUserLogin = new clsUserLoginManage();
            dtoUser objUser = new dtoUser();
            string UserName = EncDec.Encrypt(txtuserid.Text, DbConnect.AdminKey);
            string Password = EncDec.Encrypt(txtpassword.Text, DbConnect.AdminKey);

            DataTable dt = objUserLogin.GetLogin(UserName, Password);

            if (dt.Rows.Count > 0)
            {
                objUser.AUTO_ID = dt.Rows[0]["AUTO_ID"].ToString();
                objUser.USER_ID = EncDec.Decrypt(dt.Rows[0]["USER_ID"].ToString(), DbConnect.AdminKey);
                objUser.USER_TYPE = Convert.ToInt32(dt.Rows[0]["USER_TYPE"].ToString());
                Session["AdminUser"] = objUser;

                if (Session["AdminUser"] != null)
                    Response.Redirect("Home.aspx");
            }
            else
            {
                Session["AdminUser"] = null;
            }
        }
        catch (Exception ex)
        {
            Page.RegisterStartupScript("aa", "<script>alert('" + ex.Message + "');</script>");
        }
    }
}