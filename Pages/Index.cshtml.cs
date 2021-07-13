using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BakeryProj.Data;
using Microsoft.AspNetCore.Http;
using BakeryProj.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BakeryProj.Helpers;
namespace BakeryProj.Pages.User
{
    public class IndexModel : PageModel
    {
        private readonly BakeryContext db;  
        public IndexModel(BakeryContext db) => this.db = db;
        public List<Product> Products { get; set; } = new List<Product>(); 
        public List<Item> cart { get; set; } = new List<Item>();
        public Product FeaturedProduct { get; set; }  
        [BindProperty]
        public List<Product> products {get; set; } = new List<Product>();
        [BindProperty]
        public string SearchString { get; set; }
        public async Task OnGetAsync()
        {   
            cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            Products = await db.Products.ToListAsync();
            FeaturedProduct = Products.ElementAt(new Random().Next(Products.Count));
        }
        public async Task<IActionResult> OnPost()
        {   
            if(SearchString == null)
            {
                return RedirectToPage("/User/Index");
            }
            else
            {
                products = await db.Products.Where(d => d.Name.Contains(SearchString)).ToListAsync();
                if(products == null)
                {
                    return RedirectToPage("/User/Index");
                }    
                return RedirectToPage("/Admin/CakePage/Search");
            }
        }
    }
}