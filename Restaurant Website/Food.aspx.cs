using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Configuration;
using System.Data.SqlClient;

public partial class Food : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string connectStr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        using (SqlConnection con = new SqlConnection(connectStr))
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM Menu", con))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int id = (int)reader["Id"];
                        string idAttrVal = "MenuItem" + id;
                        HtmlGenericControl li = new HtmlGenericControl("li");
                        li.Attributes.Add("class", "food-menu__item");
                        li.Attributes.Add("id", idAttrVal);

                        HtmlGenericControl titleSpan = new HtmlGenericControl("span");
                        titleSpan.Attributes.Add("class", "menu__item-title");
                        titleSpan.InnerText = reader["Title"].ToString();

                        if ((bool)reader["isVeg"])
                        {
                            HtmlGenericControl vegIcon = new HtmlGenericControl("i");
                            vegIcon.Attributes.Add("class", "icon icon-leaf");
                            titleSpan.Controls.Add(vegIcon);
                        }

                        int heatLvl = int.Parse(reader["HeatLvl"].ToString());
                        HtmlGenericControl heatSpan = new HtmlGenericControl("span");
                        heatSpan.Attributes.Add("class", "heat-level");
                        for (int i = 0; i < heatLvl; i++)
                        {
                            HtmlGenericControl heatIcon = new HtmlGenericControl("i");
                            heatIcon.Attributes.Add("class", "icon icon-fire");
                            heatSpan.Controls.Add(heatIcon);

                        }
                        titleSpan.Controls.Add(heatSpan);

                        HtmlGenericControl descSpan = new HtmlGenericControl("span");
                        descSpan.Attributes.Add("class", "menu__item-description");
                        descSpan.InnerText = reader["Description"].ToString();
                            
                        HtmlGenericControl priceSpan = new HtmlGenericControl("span");
                        priceSpan.Attributes.Add("class", "menu__item-price");
                        decimal price = (decimal)reader["Price"];
                        priceSpan.InnerHtml = price.ToString("c");

                        string itemData = reader["Id"] + "," + reader["Title"] + "," + reader["Description"] + "," + price;
                        LinkButton cartBtn = new LinkButton();
                        cartBtn.Attributes.Add("class", "fa fa-cart-plus btn menu__item-add");
                        cartBtn.Attributes.Add("ItemDetails", itemData);
                        cartBtn.Attributes.Add("aria-hidden", "true");
                        cartBtn.Click += new EventHandler(cartBtn_Click);
                        cartBtn.Text = "<span class=\"sr-only\">Add to Basket</span>";

                        li.Controls.Add(titleSpan);
                        li.Controls.Add(descSpan);
                        li.Controls.Add(priceSpan);
                        li.Controls.Add(cartBtn);

                        FoodMenu.Controls.Add(li);
                    }
                }
            }
        }

    }
    protected void cartBtn_Click(object sender, EventArgs e)
    {
        //string connectStr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        //using (SqlConnection con = new SqlConnection(connectStr))
        //{
        //    con.Open();
        //    using (SqlCommand cmd = new SqlCommand("SELECT TOP 1 * FROM Users WHERE Username = @username ", con))
        //    {
        //    }
        //    con.Close();
        //}

        Product item = new Product();
        CartItemList cart = CartItemList.GetCart();

        LinkButton btn = (LinkButton)sender;
        string[] data = btn.Attributes["ItemDetails"].ToString().Split(',');

        item.ID = int.Parse(data[0]);
        item.Title = data[1];
        item.Description = data[2];
        item.Price = decimal.Parse(data[3]);
        CartItem cartItem = cart[item.ID.ToString()];
        if (cartItem == null)
        {
            cart.AddItem(item, 1);
        }
        else
        {
            cartItem.AddQuantity(1);
        }
    }
}