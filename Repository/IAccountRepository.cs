using BakeryProj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
namespace BakeryProj.Repository
{
    public interface IAccountRepository
    {
         IEnumerable<Account> GetAllAccount();
         IEnumerable<Account> GetAccounts(string id);
         Account GetAccount(string id);
         Account Delete(string id);
         Account Update(Account updatedAccount);
         IEnumerable<Account> Search(string SearchString);
    }
}