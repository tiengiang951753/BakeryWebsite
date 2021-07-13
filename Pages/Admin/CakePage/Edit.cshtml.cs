using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BakeryProj.Data;
using BakeryProj.Models;
using Microsoft.EntityFrameworkCore;
using BakeryProj.Repository;
namespace BakeryProj.Pages.Admin.CakePage
{
    public class EditModel : PageModel
    {
        private readonly ICakeRepository cakeRepository;
        public EditModel(ICakeRepository cakeRepository)
        {
            this.cakeRepository = cakeRepository;
        }
        [BindProperty]
        public Product Product {get; set;}

        public void OnGet(int id)
        {
            Product = cakeRepository.GetCake(id);
        }
        public IActionResult OnPost()
        {
            if(ModelState.IsValid)
            {
                var CakeFromDb = cakeRepository.GetCake(Product.Id);
                CakeFromDb.Name = Product.Name;
                CakeFromDb.Description = Product.Description;
                CakeFromDb.Price = Product.Price;
                CakeFromDb.ImageName = Product.ImageName;
                CakeFromDb.Quantity = Product.Quantity;
                CakeFromDb.Category = Product.Category;
                cakeRepository.Update(CakeFromDb);
                return RedirectToPage("/Admin/CakePage/CakeList");
            }
            return RedirectToPage();
        }
    }
}
