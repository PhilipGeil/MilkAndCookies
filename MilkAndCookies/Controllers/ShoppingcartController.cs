using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MilkAndCookies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingcartController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Product> Get(string name, double price)
        {
            // Convert parameters into Product object
            Product p = new Product(name, price);
            // Create a list of products 
            List<Product> products;
            // Check if the cart is empty
            if (HttpContext.Session.GetString("cart") == null)
            {
                // return an empty list if the cart is empty
                return new List<Product>();
            }
            else
            {
                // Deserialize products from the cart
                products = HttpContext.Session.GetObjectFromJson<List<Product>>("cart");
            }
            // Add the new product to the list
            products.Add(p);
            // Overwrite the session, so the new object is included.
            HttpContext.Session.SetObjectAsJson("cart", products);
            return products;
        }
    }
}
