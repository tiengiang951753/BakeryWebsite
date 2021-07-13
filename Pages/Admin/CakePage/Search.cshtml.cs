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
    public class SearchModel : PageModel
    {
        private BakeryContext _db;
        public SearchModel(BakeryContext db)
        {
            _db = db;
        }
        [BindProperty]
        public List<Product> products {get; set; } = new List<Product>();
        [BindProperty]
        public string SearchString { get; set; }
        public async Task<IActionResult> OnPost()
        {   
            if(SearchString == null)
            {
                return RedirectToPage("/User/Index");
            }
            else
            {
                products = await _db.Products.Where(d => d.Name.Contains(SearchString)).ToListAsync();
                if(products == null)
                {
                    return RedirectToPage("/User/Index");
                }    
                return Page();
            }
        }
    }
}
