using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SubMaster : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var returnUrl = Server.UrlEncode(Request.Url.PathAndQuery);
        if (Session["isLoggedIn"] != null && (bool)Session["isLoggedIn"])
        {
            user.Text = "Welcome " + (string)Session["username"];
            loginControl.HRef = "/logout.aspx";
            loginControl.InnerText = "Logout";
        }
        loginControl.HRef += "?returnURL=" + returnUrl;
    }
}
