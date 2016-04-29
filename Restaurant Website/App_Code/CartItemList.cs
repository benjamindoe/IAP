using System;
using System.Collections.Generic;
using System.Web;

public class CartItemList
{
    private List<CartItem> cartItems;

    public CartItemList()
    {
        cartItems = new List<CartItem>();
    }

    public int Count {
        get { return cartItems.Count; }
    }

    public decimal SubTotal
    {
        get
        {
            decimal subTotal = 0;
            for (int i = 0; i < this.Count; i++)
            {
                subTotal += this[i].Product.Price;
            }
            return subTotal;
        }
    }

    public CartItem this[int index]
    {
        get { return cartItems[index]; }
        set { cartItems[index] = value; }
    }

    public CartItem this[string id]
    {
        get {
            foreach (CartItem c in cartItems)
                if (c.Product.ID == int.Parse(id)) return c;
            return null;
        }
    }

    public static CartItemList GetCart()
    {
        CartItemList cart = (CartItemList) HttpContext.Current.Session["Cart"];
        if (cart == null)
            HttpContext.Current.Session["Cart"] = new CartItemList();
        return (CartItemList) HttpContext.Current.Session["Cart"];
    }

    public void AddItem(Product product, int quantity)
    {
        CartItem c = new CartItem(product, quantity);
        cartItems.Add(c);
    }

    public void RemoveAt(int index)
    {
        cartItems.RemoveAt(index);
    }

    public void Clear()
    {
        cartItems.Clear();
    }
}