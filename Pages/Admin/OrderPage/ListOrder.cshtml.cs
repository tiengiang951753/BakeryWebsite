using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore; // to use ToListAsync()
using BakeryProj.Models;
using BakeryProj.Data;
using BakeryProj.Helpers;

namespace BakeryProj.Pages.Admin.OrderPage
{
    public class ListOrderModel : PageModel
    {
        private readonly BakeryContext _db;
        public ListOrderModel(BakeryContext db)
        {
            _db = db;
        }
        public IEnumerable<Order> orders {get; set; }
        public decimal Sum;
        public List<Order> ListOrder {get; set;} = new List<Order>();
        
        [BindProperty(SupportsGet = true)]
        public int SearchString { get; set; }
        public async Task OnGet()
        {
            if (SearchString != 0)
            {
                orders = await _db.Order.Where(d => d.ID_Od == SearchString ).ToListAsync();  
            }
            else
            {
                orders = await _db.Order.ToListAsync();
                Sum = orders.Sum(d => d.Total_Price);
            }      
        }
    }
}
