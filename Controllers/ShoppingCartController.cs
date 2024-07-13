using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using project01.Data;
using project01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace project01.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly ApplicationDbContext db;

        public ShoppingCartController(ApplicationDbContext db)
        {
            this.db = db;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddToCart(int productId)
        {
            try
            {
                var product = db.Products.Find(productId);

                if (product == null)
                {
                    return RedirectToAction("Index");
                }
                product.Quantity--;
                db.SaveChanges();
                if (HttpContext.Session.GetString("cart") == null)
                {
                    List<Item> cart = new List<Item>();
                    cart.Add(new Item() { Product = db.Products.Find(productId), Quantity = 1 });
                    HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(cart));
                }
                else
                {
                    string cartJson = HttpContext.Session.GetString("cart");
                    List<Item> cart;

                    if (string.IsNullOrEmpty(cartJson))
                    {
                        cart = new List<Item>();
                    }
                    else
                    {
                        cart = JsonConvert.DeserializeObject<List<Item>>(cartJson);
                    }

                    int index = IsInCart(productId);

                    if (index != -1)
                    {
                        cart[index].Quantity++;
                    }
                    else
                    {
                        cart.Add(new Item() { Product = db.Products.Find(productId), Quantity = 1 });
                    }

                    HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(cart));
                }

                return Json(new { success = true });
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", "An error occurred while adding the product to the cart");
                return Json(new { success = false, error = "An error occurred while adding the product to the cart" });
            }
        }


        public ActionResult RemoveFromCart(int id)
        {
            string cartJson = HttpContext.Session.GetString("cart");
            List<Item> cart;
            var product = db.Products.Find(id);
            if (string.IsNullOrEmpty(cartJson))
            {
                cart = new List<Item>();
            }
            else
            {
                cart = JsonConvert.DeserializeObject<List<Item>>(cartJson);
            }

            int index = IsInCart(id);

            if (index != -1)
            {
                cart.RemoveAt(index);
                HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(cart));
                ++product.Quantity;
                db.SaveChanges();
            }
            
            return RedirectToAction("Index");
        }
        public int IsInCart(int id)
        {
            List<Item> cart;
            string cartJson = HttpContext.Session.GetString("cart");

            if (string.IsNullOrEmpty(cartJson))
            {
                cart = new List<Item>();
            }
            else
            {
                cart = JsonConvert.DeserializeObject<List<Item>>(cartJson);
            }
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].Product.Id == id)
                {
                    return i;
                }
            }
            return -1;
        }

    }
}
