using BakeryProj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace BakeryProj.Repository
{
    public interface ICakeRepository
    {
         IEnumerable<Product> GetAllCakes();
         IEnumerable<Product> GetCakes(int id);
         Product GetCake(int id);
         Product Add(Product newCake);
         Product Update(Product updatedCake);
         Product Delete(int id);
         IEnumerable<Product> Search(string SearchString);
    }
}