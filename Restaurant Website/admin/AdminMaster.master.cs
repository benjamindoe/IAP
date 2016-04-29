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
        Master.BodyTag.Attributes.Add("class", "admin");
        bool isAdmin = (bool?)Session["isAdmin"] != null ? (bool)Session["isAdmin"] : false;
        if (!isAdmin)
        {
            string responsePath = "~/";
            if(Session["isLoggedIn"] == null)
            {
                responsePath = "~/login.aspx?ReturnURL=" + Server.UrlEncode(Request.Url.PathAndQuery);
            }
            Response.Redirect(responsePath);
        }
    }
}
