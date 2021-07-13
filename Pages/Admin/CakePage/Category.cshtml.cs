using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BakeryProj.Models;
using BakeryProj.Data;

namespace BakeryProj.Pages.Admin.CakePage
{
    public class CategoryModel : PageModel
    {
        private BakeryContext _db;
        public CategoryModel(BakeryContext db)
        {
            _db = db;
        }
        [BindProperty]
        public List<Product> products {get; set; } = new List<Product>();
        public IActionResult OnGet(string category)
        {   
                if(category == "null")
                {
                    products = _db.Products.Where(d => d.Name != null).ToList();
                }
                else
                {
                    products = _db.Products.Where(d => d.Category == category).ToList();
                }    
            return Page();
        }
    }
}
