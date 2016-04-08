using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminMaster : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        bool isAdmin = (bool?)Session["isAdmin"] != null ? (bool)Session["isAdmin"] : false;
        if (!isAdmin)
        {
            var returnUrl = Server.UrlEncode(Request.Url.PathAndQuery);
            Response.Redirect("~/login.aspx?ReturnURL=" + returnUrl);
        }
    }
}
