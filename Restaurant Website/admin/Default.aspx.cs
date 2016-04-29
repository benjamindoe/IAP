using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class admin_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string conStr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        using (SqlConnection con = new SqlConnection(conStr))
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand("SELECT COUNT(username) FROM Users", con))
            {
                int count = (int)cmd.ExecuteScalar();
                userNumber.InnerText = count.ToString() + " Registered Users";
            }
            using (SqlCommand cmd = new SqlCommand("SELECT COUNT(Id) FROM Menu", con))
            {
                int count = (int)cmd.ExecuteScalar();
                menuItemNumber.InnerText = count.ToString() + " Items in the Menu";
            }
            con.Close();
        }
    }
}