using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
namespace BakeryProj.Models
{
    public class Customer
    {
        [Key]
        public int ID_Cs {get; set; }
        public string Name_Cs {get; set; }

        [Required(ErrorMessage="Email is required"),]
        [EmailAddress]
        public string Email {get; set;}

        [Required(ErrorMessage="Password is required")]
        public string Password{get; set;}
        
    }
}