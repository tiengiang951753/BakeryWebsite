using System.ComponentModel.DataAnnotations;
namespace BakeryProj.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageName { get; set; }
        public string Category {get; set;}
        public int Quantity { get; set; }
    }
}