using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PizzaBox.Client.Validations;

namespace PizzaBox.Client.Models
{
    public class Pizza //this is the pizza object that the user will be presented. Differs from PizzaModel, PizzaTable. 
    {
        [Required]
        public string Crust {get;set;}

        [Required]
        public string Size {get;set;}

        [Range(1,10)]
        public int Quantity { get; set; }
        [NameAttribute(ErrorMessage="the name must be letters only")]
        [StringLength(50)]
        // [DataType(DataType.)]

        public List<string> Crusts {get;set;}
        public List<string> Sizes {get;set;}

        public Pizza()
        {
          Crusts = new List<string>{"thin", "deep dish", "new york"};
          Sizes = new List<string>{"small", "medium", "large"};
        }
        
    }
}