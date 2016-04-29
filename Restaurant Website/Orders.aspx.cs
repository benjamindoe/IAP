using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

public partial class Orders : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["isLoggedIn"] == null || !(bool)Session["isLoggedIn"])
        {
            var returnUrl = Server.UrlEncode(Request.Url.PathAndQuery);
            Response.Redirect("/login.aspx?returnURL=" + returnUrl);
        }
        string username = (string)Session["username"];
        string connectStr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        using (SqlConnection con = new SqlConnection(connectStr))
        {
            con.Open();
            string Query = @"SELECT DISTINCT [Orders].[ID], [Orders].[SubTotal], [Orders].[isProcessed], [Menu].[Title], [OrderItem].[quantity] 
                                FROM Orders 
                                INNER JOIN [OrderItem] 
                                    ON [OrderItem].[orderID] = [Orders].[ID] 
                                INNER JOIN [Menu] 
                                    ON [Menu].[ID] = [OrderItem].[menuID]
                                WHERE [Orders].[username] = @username";
            using (SqlCommand cmd = new SqlCommand(Query, con))
            {
                cmd.Parameters.AddWithValue("@username", username);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int id = (int)reader["Id"];
                        string idAttrVal = "OrderNo" + id;
                        HtmlGenericControl order;
                        HtmlGenericControl ul;
                        if (OrderHistory.FindControl(idAttrVal) == null)
                        {
                            order = new HtmlGenericControl("li");
                            order.Attributes.Add("class", "order-history__order");
                            order.ID = idAttrVal;
                            ul = new HtmlGenericControl("ul");
                            ul.ID = idAttrVal + "Lst";
                            HtmlGenericControl priceSpan = new HtmlGenericControl("span");
                            priceSpan.Attributes.Add("class", "order-history__order-subtotal");
                            decimal price = (decimal)reader["SubTotal"];
                            priceSpan.InnerHtml = "Total Price: " + price.ToString("c");
                            HtmlGenericControl orderIdSpan = new HtmlGenericControl("span");
                            orderIdSpan.InnerHtml = "Order Ref Number #" + id;
                            string pendingClass = (bool)reader["isProcessed"] ? "fa fa-check" : "fa fa-spinner fa-pulse";
                            string pendingText = (bool)reader["isProcessed"] ? "Processed!" : "Pending";
                            HtmlGenericControl pending = new HtmlGenericControl("div");
                            pending.Attributes.Add("class", "pending-wrapper");
                            pending.InnerHtml = "<i class=\""+ pendingClass +" fa-2x fa-fw margin-bottom\"></i> <span>"+pendingText+"</span>";
                            order.Controls.Add(pending);
                            order.Controls.Add(orderIdSpan);
                            order.Controls.Add(ul);
                            order.Controls.Add(priceSpan);

                        } else
                        {
                            order = (HtmlGenericControl)OrderHistory.FindControl(idAttrVal);
                            ul = (HtmlGenericControl)order.FindControl(idAttrVal + "Lst");
                        }
                        HtmlGenericControl itemLi = new HtmlGenericControl("li");
                        HtmlGenericControl titleSpan = new HtmlGenericControl("span");
                        titleSpan.Attributes.Add("class", "order-history__order-title");
                        titleSpan.InnerText = reader["Title"].ToString();
                        HtmlGenericControl quantitySpan = new HtmlGenericControl("span");
                        quantitySpan.Attributes.Add("class", "order-history__order-quantity");
                        quantitySpan.InnerText = "Quantity: " + reader["Quantity"];

                        itemLi.Controls.Add(titleSpan);
                        itemLi.Controls.Add(quantitySpan);
                        ul.Controls.Add(itemLi);

                        OrderHistory.Controls.Add(order);
                    }
                }
            }
        }
    }
}