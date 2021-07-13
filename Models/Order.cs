using System.ComponentModel.DataAnnotations;
using System;
namespace BakeryProj.Models
{
    public class Order
    {
        [Key]
        public int ID_Od {get; set;}
        public string ID_Cs {get; set;}
        public string Name_Cs {get; set; }
        public string Address {get; set;}
        public string PhoneNumber {get; set;}
        public int Total_Quantity {get; set;}
        public decimal Total_Price {get; set;}
        public DateTime Date { get; set;}
        public string Note{get; set;}
    }
}