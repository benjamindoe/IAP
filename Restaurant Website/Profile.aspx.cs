using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
public partial class ProfilePage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["isLoggedIn"] == null || Session["username"] == null || !(bool)Session["isLoggedIn"])
        {
            var returnUrl = Server.UrlEncode(Request.Url.PathAndQuery);
            Response.Redirect("/login.aspx?returnURL=" + returnUrl);
        }
        if(!Page.IsPostBack)
        {
            string conStr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(conStr))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT TOP 1 * FROM Users WHERE Username = @username ", con))
                {
                    cmd.Parameters.AddWithValue("@username", (string)Session["username"]);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        FullName.Text = reader["name"].ToString();
                        AddressLine1.Text = reader["AddressLine1"].ToString();
                        AddressLine2.Text = reader["AddressLine2"].ToString();
                        City.Text = reader["City"].ToString();
                        Postcode.Text = reader["Postcode"].ToString();
                        PhoneNumber.Text = reader["PhoneNumber"].ToString();
                    }
                }
                con.Close();
            }
        }
    }

    protected void Submit_Click(object sender, EventArgs e)
    {
        string conStr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        using (SqlConnection con = new SqlConnection(conStr))
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand("UPDATE [Users] SET [Name]=@name, [AddressLine1]=@add1, [AddressLine2]=@add2, [City]=@city, [Postcode]=@post, [PhoneNumber]=@phone WHERE username = @username", con))
            {
                cmd.Parameters.AddWithValue("@username", (string)Session["username"]);
                cmd.Parameters.AddWithValue("@name", FullName.Text);
                cmd.Parameters.AddWithValue("@add1", AddressLine1.Text);
                cmd.Parameters.AddWithValue("@add2", AddressLine2.Text);
                cmd.Parameters.AddWithValue("@city", City.Text);
                cmd.Parameters.AddWithValue("@post", Postcode.Text);
                cmd.Parameters.AddWithValue("@phone", PhoneNumber.Text);
                if(cmd.ExecuteNonQuery() > 0)
                {
                    Message.Text = "Account updated!";
                    Message.Style.Add("color", "green");
                } else
                {
                    Message.Text = "Something went wrong! Resubmit your form and try again.";
                    Message.Style.Add("color", "red");
                }
            }
            con.Close();
        }
    }

    protected void DeleteBtn_Click(object sender, EventArgs e)
    {
        string conStr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        using (SqlConnection con = new SqlConnection(conStr))
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand("DELETE FROM Users WHERE username = @username", con))
            {
                cmd.Parameters.AddWithValue("@username", (string)Session["username"]);
                cmd.ExecuteNonQuery();
            }
            con.Close();
        }
        Response.Redirect("/logout.aspx");
    }
}