using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BakeryProj.Data;
using BakeryProj.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BakeryProj.Pages.Admin.CakePage
{    
    public class CreateModel : PageModel
    {
        private readonly BakeryContext _db; 
        public CreateModel(BakeryContext db)
        {
            _db = db;
        }
        [BindProperty]
        public Product Product {get; set; }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost()
        {
            if(ModelState.IsValid)
            {
                await _db.Products.AddAsync(Product);
                await _db.SaveChangesAsync();
                return RedirectToPage("/Admin/CakePage/CakeList");
            }
            else
            {
                return Page();
            }
        }
    }
}
