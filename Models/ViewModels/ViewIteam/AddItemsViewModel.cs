using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace TestWeb.Models.ViewModels.ViewIteam
{
    public class AddItemsViewModel
    {
        public AddItemsViewModel()
        {
            CreateDate = DateTime.Now;
        }
       
        [Required]
        [Remote("IsItemNameExists", "Items", HttpMethod = "Post", ErrorMessage = "The Name Is Already Exists")]
        public string Name { get; set; }

        [Required]
        [DisplayName("Price")]
        [Range(10, 1000, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public decimal Price { get; set; }

        public DateTime CreateDate { get; set; }

        [Required]
        [DisplayName("Category")]
        public int CategoryId { get; set; }
    }
}
