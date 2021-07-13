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
    public class CakeDetailModel : PageModel
    {
        private BakeryContext db;
        public CakeDetailModel(BakeryContext db) => this.db = db;
        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }
        public Product Product {get; set; }
        public async Task OnGetAsync()
        {
            Product = await db.Products.FindAsync(Id);
        }

    }
}
