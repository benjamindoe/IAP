using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using BCrypt.Net;

public partial class Register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void registerBtn_Click(object sender, EventArgs e)
    {
        string username = txtUsername.Text.Trim();
        string password = txtPassword.Text;

        string salt = BCrypt.Net.BCrypt.GenerateSalt();
        string hash = BCrypt.Net.BCrypt.HashPassword(password);
        // checker
        // matches = BCrypt.Net.BCrypt.CheckPassword(candidate, hash);

        string conStr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(conStr))
        {
            conn.Open();
            bool isTaken = false;
            using(SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM [Users] WHERE [username] = @username", conn))
            {
                cmd.Parameters.AddWithValue("@username", username);
                isTaken = (int)cmd.ExecuteScalar() > 0;
            }

            if (isTaken)
            {
                //string msg.Text("Username already exists.");
                return; 
            }

            using (SqlCommand cmd = new SqlCommand("INSERT INTO [Users]([username], [password]) Values (@username, @pass)", conn))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@username", username.Trim());
                cmd.Parameters.AddWithValue("@pass", hash);
                cmd.ExecuteNonQuery();
            }
            conn.Close();
            Response.Redirect("login.aspx");
        }
    }
}