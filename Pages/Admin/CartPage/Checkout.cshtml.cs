using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BakeryProj.Models;
using BakeryProj.Helpers;
using BakeryProj.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace BakeryProj.Pages.Admin.CartPage
{
    public class CheckoutModel : PageModel
    {
        private readonly BakeryContext _db;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        public CheckoutModel(BakeryContext db,SignInManager<IdentityUser> signInManager,UserManager<IdentityUser> userManager)
        {
            _db = db;
            _signInManager = signInManager;
            _userManager = userManager;
        }
        public List<Item> cart { get; set; } = new List<Item>();
        
        [BindProperty]
        public Order Orderr { get; set; } 
        [BindProperty]
        public OrderDetails OrderDetails {get; set;}
        private readonly Random _random = new Random();
        public async Task OnGet()
        {           
            Orderr = new Order();
            OrderDetails = new OrderDetails();
            String user = HttpContext.Session.GetString("username");
            Check2();
            if(user != null)
            {       
                    var data = await _userManager.FindByEmailAsync(user);
                    Orderr.Name_Cs  =  data.Email;
                    Orderr.ID_Cs = data.Id;
                    Orderr.ID_Od = _random.Next(1000000,9999999);
                    Orderr.PhoneNumber = data.PhoneNumber;
                    Orderr.Total_Price = cart.Sum(i => i.Product.Price*i.TotalQuantity); 
                    Orderr.Total_Quantity = cart.Sum(i => i.TotalQuantity);
                    Orderr.Date = DateTime.Now; 
            } 
            else
            {       
                     Orderr.ID_Od =  _random.Next(1000000,9999999);
                     Orderr.Total_Price = cart.Sum(i => i.Product.Price*i.TotalQuantity); 
                     Orderr.Total_Quantity = cart.Sum(i => i.TotalQuantity);
                     Orderr.Date = DateTime.Now;
            }  
        }
        public async Task<IActionResult> OnPost()
        {   
            String user = HttpContext.Session.GetString("username");
            Check2();
            foreach(var item in cart)
                    {
                            OrderDetails.ID_Od = Orderr.ID_Od;
                            OrderDetails.Id = item.Product.Id;
                            OrderDetails.Quantity_Order = item.TotalQuantity;
                            await _db.OrderDetails.AddAsync(OrderDetails);
                            await _db.SaveChangesAsync();
                    }       
            if(ModelState.IsValid)
            {                 
                await _db.Order.AddAsync(Orderr);
                await _db.SaveChangesAsync();
                if(user != null)
                {
                    HttpContext.Session.Remove(user);
                }
                else
                {
                    HttpContext.Session.Remove("cart");
                }
                return RedirectToPage("/Admin/CartPage/OrderSuccess");
            }
            else
            {
                return Page(); 
            }   
        }
        public List<Item> Check2()
        {   
            String user = HttpContext.Session.GetString("username");
            if(user != null)
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
