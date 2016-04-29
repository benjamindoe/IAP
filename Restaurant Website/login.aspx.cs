using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Data.SqlClient;

public partial class login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Master.BodyTag.Attributes.Add("class", "login");
        if (Session["isLoggedIn"] != null && (bool)Session["isLoggedIn"])
            returnRedirect();
    }

    /*
     * root username: root
     *      password: pass
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
                        Session["isLoggedIn"] = true;
                        Session["username"] = username;
                        Session["isAdmin"] = reader["isAdmin"] as bool? ?? false; // reader["isAdmin"] as bool != null ? reader["isAdmin"] as bool : false;
                        con.Close();
                        returnRedirect();
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
    private void returnRedirect()
    {
        string returnUrl = Request.QueryString["returnURL"] != null ? Request.QueryString["returnURL"] : "/";
        Response.Redirect(returnUrl);
    }
}