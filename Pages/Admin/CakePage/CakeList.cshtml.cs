using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BakeryProj.Models;
using BakeryProj.Data;
using BakeryProj.Repository;
namespace BakeryProj.Pages.Admin.CakePage
{
    public class CakeListModel : PageModel
    {
        private readonly ICakeRepository cakeRepository;
        public IEnumerable<Product> products {get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchString{get; set;}
        public CakeListModel(ICakeRepository cakeRepository)
        {
            this.cakeRepository = cakeRepository;
        }
        public void OnGet()
        {
            if(SearchString == null)
            {
                products = cakeRepository.GetAllCakes();
            }
            else
            {
                products = cakeRepository.Search(SearchString);
            }     
        }

        public IActionResult OnPostDelete(int id)
        {
            cakeRepository.Delete(id);
            return RedirectToPage("/Admin/CakePage/CakeList");
        }
        public void OnGetCake(int id)
        {
            products = cakeRepository.GetCakes(id);
        }
    }
}
