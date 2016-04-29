using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
public partial class Admin_Menu : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Insert" && Page.IsValid)
        {
            TextBox NewTitle = (TextBox)GridView1.FooterRow.FindControl("NewTitle");
            TextBox NewDesc = (TextBox)GridView1.FooterRow.FindControl("NewDescription");
            CheckBox newVeg = (CheckBox)GridView1.FooterRow.FindControl("NewVeg");
            RadioButtonList newHeat = (RadioButtonList)GridView1.FooterRow.FindControl("NewHeatLvl");
            MenuData.InsertParameters["Title"].DefaultValue = NewTitle.Text;
            MenuData.InsertParameters["Description"].DefaultValue = NewDesc.Text;
            MenuData.InsertParameters["isVeg"].DefaultValue = newVeg.Checked.ToString();
            MenuData.InsertParameters["heatLvl"].DefaultValue = newHeat.SelectedValue;
            MenuData.Insert();
        }
    }
}