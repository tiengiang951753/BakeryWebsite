using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore; // to use ToListAsync()
using BakeryProj.Models;
using BakeryProj.Data;
using BakeryProj.Helpers;

namespace BakeryProj.Pages.Admin.OrderPage
{
    public class DetailOrderModel : PageModel
    {   
        private readonly BakeryContext _db;
        public DetailOrderModel(BakeryContext db)
        {
            _db = db;
        }
        public OrderDetails ordersDetail {get; set; }
        public IEnumerable<OrderDetails> ordersdetail {get; set; }
        public List<OrderDetails> ListOrder {get; set;} = new List<OrderDetails>();
        public IActionResult OnGet(int ID_Od)
        {          
            ListOrder = _db.OrderDetails.Where(d => d.ID_Od == ID_Od).ToList();
            SessionHelper.SetObjectAsJson(HttpContext.Session, "ListOrder", ListOrder);
            return Page();
        }
    }
}
