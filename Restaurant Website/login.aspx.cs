using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    /*
     * root username: root
     *      password: tester
     */



    /*
      var returnUrl = Server.UrlEncode(Request.Url.PathAndQuery);
      Response.Redirect("~/login.aspx?ReturnURL=" + returnUrl);
    */

    protected void submit_Click(object sender, EventArgs e)
    {
        string username = txtUsername.Text;
        string password = txtPassword.Text;

        string conStr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        using (SqlConnection con = new SqlConnection(conStr))
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand("SELECT TOP 1 * FROM Users WHERE Username = @username ", con))
            {
                cmd.Parameters.AddWithValue("@username", username);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    string hash = reader["password"].ToString();
                    if (BCrypt.Net.BCrypt.Verify(password, hash))
                    {
                        Session["username"] = username;
                        Session["isAdmin"] = reader["isAdmin"] as bool? ?? false; // reader["isAdmin"] as bool != null ? reader["isAdmin"] as bool : false;
                        string returnUrl = Request.QueryString["returnURL"] != null ? Request.QueryString["returnURL"] : "/";
                        con.Close();
                        Response.Redirect(returnUrl);
                    }
                    else
                    {
                        txtPassword.Style.Add("border", "1px solid red");
                        alert("Invalid password.");
                    }
                }
                else
                {
                    txtUsername.Style.Add("border", "1px solid red");
                    alert("Invalid Username.");
                }
            }
            con.Close();
        }
    }
   
    private void alert(string str)
    {

        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + str + " ')", true);
    }

}