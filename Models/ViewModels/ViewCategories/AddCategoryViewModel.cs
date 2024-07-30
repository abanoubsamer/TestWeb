using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
namespace TestWeb.Models.ViewModels.ViewCategories
{
    public class AddCategoryViewModel
    {      
        [Remote("CategoryExist", "Categories", HttpMethod = "Post", ErrorMessage = "This Name Already Exists")]
        [Required]
        public string Name { get; set; }

    }
}
