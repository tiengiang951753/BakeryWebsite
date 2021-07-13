using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
namespace BakeryProj.Models
{
    public class Item
    {
        public Product Product {get; set;}
        public int TotalQuantity {get; set; }
    }
}