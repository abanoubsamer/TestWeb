using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;

namespace TestWeb.Models.ViewModels.ViewIteam
{
    public class EditItemsViewModel
    {
        public int Id { get; set; }

        [Required]
        [Remote("IsItemExitsExcludeItSelf", "Items", AdditionalFields = "Id", HttpMethod = "Post", ErrorMessage = "The Name Is Already Exists")]
        public string Name { get; set; }

        [Required]
        [DisplayName("Price")]
        [Range(10, 1000, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public decimal Price { get; set; }

        [Required]
        [DisplayName("Category")]
        public int CategoryId { get; set; }
    }
}
