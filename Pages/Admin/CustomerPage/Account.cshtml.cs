using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BakeryProj.Data;
using BakeryProj.Models;
using BCrypt.Net;
using BakeryProj.Repository;
namespace BakeryProj.Pages.Admin.CustomerPage
{
    public class AccountModel : PageModel
    {   
        private readonly IAccountRepository accountRepository;
        public AccountModel(IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }
        public IEnumerable<Account> accounts {get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchString{get; set;}
        public void OnGet()
        {   
            if(SearchString != null)
            {
                accounts = accountRepository.Search(SearchString);
            }
            else
            {
                accounts = accountRepository.GetAllAccount();
            }
        }
        public IActionResult OnPostDelete(string id)
        {
            accountRepository.Delete(id);
            return RedirectToPage("/Admin/CustomerPage/Account");
        }

        public void OnGetAccounts(string id)
        {
            accounts = accountRepository.GetAccounts(id);
        }

    }
}
