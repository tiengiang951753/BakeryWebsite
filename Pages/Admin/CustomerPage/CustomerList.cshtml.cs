using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BakeryProj.Models;
using BakeryProj.Data;
using Microsoft.AspNetCore.Identity;
using BakeryProj.Repository;

namespace BakeryProj.Pages.Admin.CustomerPage
{
    public class CustomerListModel : PageModel
    {   
        private readonly ICustomerRepository customerRepository;
        public CustomerListModel(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }
        public IEnumerable<IdentityUser> customers{get; set;}

        [BindProperty(SupportsGet = true)]
        public string SearchString{get; set;}
        public void OnGet()
        {
            if(SearchString != null)
            {
                customers = customerRepository.Search(SearchString);
            }
            else
            {
                customers = customerRepository.GetAllCustomer();
            }
        }
        public IActionResult OnPostDelete(string id)
        {
            customerRepository.Delete(id);
            return RedirectToPage("/Admin/CustomerPage/CustomerList");
        }
    }
}
