using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
public partial class admin_Users : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void Check_Clicked(Object sender, EventArgs e)
    {
        CheckBox chk = (CheckBox)sender;
        GridViewRow row = (GridViewRow)chk.NamingContainer;
        string username = GridView1.DataKeys[row.RowIndex]["username"].ToString();

        string sql = "UPDATE dbo.Users SET isAdmin=@checkbox WHERE username=@username";
        string connectStr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        using (var con = new SqlConnection(connectStr))
        using (var updateCommand = new SqlCommand(sql, con))
        {
            updateCommand.Parameters.AddWithValue("@username", username);
            updateCommand.Parameters.AddWithValue("@isAdmin", chk.Checked);
            con.Open();
            int updated = updateCommand.ExecuteNonQuery();
        }
    }
}