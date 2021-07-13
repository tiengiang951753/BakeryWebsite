using BakeryProj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BakeryProj.Data;
using Microsoft.AspNetCore.Identity;
using BakeryProj.Repository;
using Microsoft.AspNetCore.Mvc;
namespace BakeryProj.Services
{
    public class SQLCustomerRepository : ICustomerRepository
    {
        private readonly BakeryContext _db;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        public SQLCustomerRepository(BakeryContext db,UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager)
        {
            _db = db;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task<IActionResult> Delete(String id)
        {   
            var user = await _userManager.FindByIdAsync(id);
            if(user != null)
            {
               await _userManager.DeleteAsync(user);
               return new RedirectToPageResult("/Admin/CustomerPage/CustomerList");
            }
            return new RedirectToPageResult("/Admin/CustomerPage/CustomerList");
        }

        public IEnumerable<IdentityUser> GetAllCustomer()
        {
            return _userManager.Users;
        }

        public Customer GetCustomer(int id)
        {
            return _db.Customers.Find(id);
        }

        public IEnumerable<IdentityUser> Search(string SearchString)
        {
            if(string.IsNullOrEmpty(SearchString))
            {
                return _userManager.Users.ToList();
            }
            return _userManager.Users.Where(d => d.Id.Contains(SearchString));
        }

        public Customer Update(Customer updatedCustomer)
        {
            var customer = _db.Customers.Attach(updatedCustomer);
            customer.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _db.SaveChanges();
            return updatedCustomer; 
        }
    }
}