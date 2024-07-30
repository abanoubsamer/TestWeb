using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc; 


namespace TestWeb.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
      
      
        public string Name { get; set; }

        public ICollection<TestItemcs>? Items { get; set; }
    }
}
