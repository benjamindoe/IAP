using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

public partial class SubMaster : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        CartItemList cart = CartItemList.GetCart();
        string titleAttrib = cart.Count + (cart.Count == 1 ? " item " : " items ") + "in your basket";
        BasketLink.Attributes.Add("Title", titleAttrib);
        var returnUrl = Server.UrlEncode(Request.Url.PathAndQuery);
        LoginControl.HRef += "?returnURL=" + returnUrl;
        if (Session["isLoggedIn"] != null && (bool)Session["isLoggedIn"])
        {
            HtmlGenericControl li = new HtmlGenericControl("li");
            HtmlAnchor orderHistory = new HtmlAnchor();
            orderHistory.HRef = "/Orders.aspx";
            orderHistory.InnerHtml = "Orders";
            li.Controls.Add(orderHistory);
            UserNav.Controls.Add(li);

            li = new HtmlGenericControl("li");
            HtmlAnchor logout = new HtmlAnchor();
            logout.HRef = "/Logout.aspx?returnURL=" + returnUrl;
            logout.InnerHtml = "Logout";
            li.Controls.Add(logout);
            UserNav.Controls.Add(li);

            string name = (string)Session["Name"] ?? (string)Session["username"];
            user.Text = "Hello, " + (string)Session["username"];
            LoginControl.HRef = "/Profile.aspx";
            LoginControl.InnerHtml = "Profile";
        } else
        {

        }
    }
    public HtmlGenericControl BodyTag
    {
        get
        {
            return Master.BodyTag;
        }
        set
        {
            Master.BodyTag = value;
        }
    }
}
