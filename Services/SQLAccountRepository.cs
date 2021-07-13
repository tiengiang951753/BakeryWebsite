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
    public class SQLAccountRepository : IAccountRepository
    {
        private readonly BakeryContext _db;

        public SQLAccountRepository(BakeryContext db)
        {
            _db = db;
        }
        public Account Delete(string id)
        {
            Account account = _db.Accounts.Find(id);
            if(account != null)
            {
                _db.Accounts.Remove(account);
                _db.SaveChanges();
            }
            return account;
        }

        public IEnumerable<Account> GetAllAccount()
        {
            return _db.Accounts;
        }

        public IEnumerable<Account> GetAccounts(string id)
        {
            return _db.Accounts.Where(d => d.Id == id);
        }

         public Account GetAccount(string id)
        {
            return _db.Accounts.Find(id);
        }

        public IEnumerable<Account> Search(string SearchString)
        {
            if(string.IsNullOrEmpty(SearchString))
            {
                return _db.Accounts.ToList();
            }
            return _db.Accounts.Where(d => d.Id.Contains(SearchString));
        }

        public Account Update(Account updatedAccount)
        {
            var account = _db.Accounts.Attach(updatedAccount);
            account.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _db.SaveChanges();
            return updatedAccount; 
        }
    }
}