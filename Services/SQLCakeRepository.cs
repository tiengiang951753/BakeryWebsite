using BakeryProj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BakeryProj.Data;
using BakeryProj.Repository;
namespace BakeryProj.Services
{
    public class SQLCakeRepository : ICakeRepository
    {
        private readonly BakeryContext _db;

        public SQLCakeRepository(BakeryContext db)
        {
            _db = db;
        }
        public string SearchString { get; set; }
        public Product Add(Product newCake)
        {
            _db.Products.Add(newCake);
            _db.SaveChanges();
            return newCake;
        }

        public Product Delete(int id)
        {
            Product product = _db.Products.Find(id);
            if(product != null)
            {
                _db.Products.Remove(product);
                _db.SaveChanges();
            }
            return product;
        }

        public IEnumerable<Product> GetAllCakes()
        {
                return _db.Products;  
        }
        public Product GetCake(int id)
        {
            return _db.Products.Find(id);
        }
        public IEnumerable<Product> GetCakes(int id)
        {
            return _db.Products.Where(d => d.Id == id);
        }
        public IEnumerable<Product> Search(string SearchString)
        {
            if(string.IsNullOrEmpty(SearchString))
            {
                return _db.Products.ToList();
            }
            return _db.Products.Where(d => d.Name.Contains(SearchString));
        }

        public Product Update(Product updatedCake)
        {
            var product = _db.Products.Attach(updatedCake);
            product.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _db.SaveChanges();
            return updatedCake;
        }
    }
}