using System.ComponentModel.DataAnnotations;
using System.Collections.Generic; // Add if your using Relationships
using System;

namespace tenthMVP.Models
{
    public class Dish
    {   
        [Key]
        public int DishId { get; set; }   
        
        [Required(ErrorMessage="Name is required")]     
        public string Name {get;set;}

        [Required(ErrorMessage="Dish name is required")]
        public string DishName {get;set;}

        [Required(ErrorMessage="Calories is required")]
        [Range(0, Int32.MaxValue, ErrorMessage = "No such thing as negative calories silly")]
        public string Calories {get;set;}

        [Required(ErrorMessage="Taste is required")]
        
        public int Taste {get;set;}

        [Required(ErrorMessage="Description is required")]
        public string Description {get;set;}
        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;
        
    }
}