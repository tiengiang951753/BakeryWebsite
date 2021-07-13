using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BakeryProj.Data;
using BakeryProj.Models;
using BakeryProj.Repository;
namespace BakeryProj.Pages.Admin.CustomerPage
{
    public class EditAccountModel : PageModel
    {   
        private readonly IAccountRepository accountRepository;
        public EditAccountModel(IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }
        [BindProperty]
        public Account account {get; set;}

        public void OnGet(string Id)
        {
            account = accountRepository.GetAccount(Id);
        }
        public IActionResult OnPost()
        {   
            if(ModelState.IsValid)
            {
                var AccountFromDb = accountRepository.GetAccount(account.Id);
                AccountFromDb.Permission = account.Permission;
                accountRepository.Update(AccountFromDb);
                return RedirectToPage("/Admin/CustomerPage/Account");
            }
            return RedirectToPage();
        }
    }
}
