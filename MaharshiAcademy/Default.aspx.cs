using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            btnClick_Click(null, null);
        }
    }

    protected void btnClick_Click(object sender, EventArgs e)
    {
        Response.Redirect("Admin/Home.aspx");
    }
}