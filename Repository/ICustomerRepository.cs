using BakeryProj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
namespace BakeryProj.Repository
{
    public interface ICustomerRepository
    {
         IEnumerable<IdentityUser> GetAllCustomer();
         Customer GetCustomer(int id);
         Customer Update(Customer updatedCustomer);
         Task<IActionResult> Delete(string id);
         IEnumerable<IdentityUser> Search(string SearchString);
    }
}