using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BakeryProj.Models;
using BakeryProj.Helpers;
using BakeryProj.Data;
using BakeryProj.Pages.Admin.CakePage;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace BakeryProj.Pages.Admin.CartPage
{
    public class CartModel : PageModel
    {
        private readonly BakeryContext _db;
        public CartModel(BakeryContext db)
        {
            _db = db;
        }
        public Product product { get; set; }
        public List<Item> cart { get; set; } = new List<Item>();
        public decimal Total { get; set; } = 0;
        public int Total_Quantity { get; set; } = 0;
        public void OnGet()
        {
            Check2();
            if (cart != null)
            {
                Total = cart.Sum(i => i.Product.Price * i.TotalQuantity);
                Total_Quantity = cart.Sum(i => i.TotalQuantity);
            }
            else
            {
                Total = 0;
            }
        }
        public async Task<IActionResult> OnGetBuyNow(int Id)
        {
            Check2();
            var products = await _db.Products.FindAsync(Id);
            if (cart == null)
            {
                cart = new List<Item>();
                cart.Add(new Item
                {
                    Product = products,
                    TotalQuantity = 1
                });
                Check1();
            }
            else
            {
                int index = Exists(cart, Id);
                if (index == -1)
                {
                    cart.Add(new Item
                    {
                        Product = products,
                        TotalQuantity = 1
                    });
                }
                else
                {
                    cart[index].TotalQuantity++;
                }
                Check1();
            }
            return RedirectToPage("/Admin/CartPage/Cart");
        }
        public IActionResult OnGetDelete(int id)
        {
            Check2();
            int index = Exists(cart, id);
            cart.RemoveAt(index);
            Check1();
            return RedirectToPage("/Admin/CartPage/Cart");
        }
        public IActionResult OnPostUpdate(int[] quantities)
        {
            Check2();
            for (var i = 0; i < cart.Count; i++)
            {
                cart[i].TotalQuantity = quantities[i];
            }
            Check1();
            return RedirectToPage("/Admin/CartPage/Cart");
        }
        private int Exists(List<Item> cart, int id)
        {
            for (var i = 0; i < cart.Count; i++)
            {
                if (cart[i].Product.Id == id)
                {
                    return i;
                }
            }
            return -1;
        }
        public void Check1()
        {
            String user = HttpContext.Session.GetString("username");
            if (user != null)
            {
                SessionHelper.SetObjectAsJson(HttpContext.Session, user, cart);
            }
            else
            {
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
        }
        public List<Item> Check2()
        {
            String user = HttpContext.Session.GetString("username");
            if (user != null)
            {
                cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, user);
            }
            else
            {
                cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            }
            return cart;
        }
    }
}
