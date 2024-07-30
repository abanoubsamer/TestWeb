using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
namespace TestWeb.Models.ViewModels.ViewCategories
{
    public class EditCategoryViewModel
    {
        
        public int Id { get; set; }
		[Remote("CategoryExistSelf", "Categories", AdditionalFields ="Id",HttpMethod = "Post", ErrorMessage = "This Name Already Exists")]
        [Required]
        public string Name { get; set; }

     
    }
}
