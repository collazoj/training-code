using System.ComponentModel.DataAnnotations;

namespace RestApi.Data.Models
{
    public class Pokemon
    {
      public int Id {get; set;} //by calling this Id, EF recognizes it as Id
      [Required]
      public string Name { get; set; }
    }
}