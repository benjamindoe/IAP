using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
public partial class Basket : System.Web.UI.Page
{
    private CartItemList cart;
    protected void Page_Load(object sender, EventArgs e)
    {
        cart = CartItemList.GetCart();
        if (!IsPostBack)
        {
            this.DisplayCart();
        }
    }
    private void DisplayCart()
    {
        lstCart.Items.Clear();
        for (int i = 0; i < cart.Count; i++)
        {
            lstCart.Items.Add(this.cart[i].Display());
        }
    }
    protected void btnRemove_Click(object sender, EventArgs e)
    {
        if (cart.Count > 0)
        {
            if (lstCart.SelectedIndex > -1)
            {
                cart.RemoveAt(lstCart.SelectedIndex);
                this.DisplayCart();
            }
            else
            {
                lblMessage.Text = "Please select an item to remove.";
            }
        }
    }
    protected void btnEmpty_Click(object sender, EventArgs e)
    {
        if (cart.Count > 0)
        {
            cart.Clear();
            lstCart.Items.Clear();
        }
    }
    protected void btnCheckOut_Click(object sender, EventArgs e)
    {
        var returnUrl = Server.UrlEncode(Request.Url.PathAndQuery);
        string redirectUrl = "/login.aspx?returnURL=" + returnUrl;
        if (Session["isLoggedIn"] as bool? ?? false)
        {
            string username = (string)Session["username"];
            int? newID = null;
            string conStr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(conStr))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("INSERT INTO [Orders]([username],[SubTotal]) OUTPUT INSERTED.ID VALUES (@username, @subtotal)", con))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@subtotal", cart.SubTotal);
                    try
                    {
                        newID = (int?)cmd.ExecuteScalar();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                for (int i = 0; newID != null && i < cart.Count; i++)
                {
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO OrderItem ([orderID],[menuID],[quantity]) VALUES (@OrderID, @MenuID, @quantity)", con))
                    {
                        cmd.Parameters.AddWithValue("@OrderID", newID);
                        cmd.Parameters.AddWithValue("@MenuID", cart[i].Product.ID);
                        cmd.Parameters.AddWithValue("@quantity", cart[i].Quantity);
                        cmd.ExecuteScalar();
                    }
                }
                con.Close();
                if (cart.Count > 0)
                {
                    cart.Clear();
                    lstCart.Items.Clear();
                }
                redirectUrl = "/Orders.aspx";
            }

        }
        Response.Redirect(redirectUrl);
    }
}