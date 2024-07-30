using AutoMapper;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using TestWeb.Models;
using TestWeb.Models.ViewModels.ViewCategories;

namespace TestWeb.Mapping
{
    public class CategoryProfile:Profile
    {
        public CategoryProfile()
        {
           CreateMap<AddCategoryViewModel, Category>();
           CreateMap<EditCategoryViewModel, Category>();
           CreateMap<Category, EditCategoryViewModel>();
            CreateMap<Category, DetialsCategoryViewModel>();
            CreateMap<DetialsCategoryViewModel, Category>();
        }
    }
}
