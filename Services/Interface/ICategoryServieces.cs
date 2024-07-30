using TestWeb.Models;
using TestWeb.Repository.Interface;
using TestWeb.Repostory.Base;

namespace TestWeb.Services.Interface
{
    public interface ICategoryServieces
    {
        public Task<bool> AddCategoryAsync(Category item);
        public Task<bool> AddCategorysRangeAsync(List<Category> items);
        public Task<bool> UpdateCategoryAsync(Category item);
        public Task<bool> UpdateCategorysAsync(List<Category> items);
        public Task<bool> DeleteCategorysRangeAsync(List<int>? ids);
        public Task<bool> DeleteCategoryAsync(int? id);
        public IQueryable<Category> GetTestCategorysIQueryable();
        public Task<bool> IsCategoryExitsExcludeItSelfAsync(string Name, int id);
        public Task<bool> IsCategoryNameExitsAsync(string Name);
        public Task<List<Category>> GetCategorysAsync();
        public Task<List<Category>> GetCategorysDetailsByIdAsync(int? id);
        public Task<Category> GetCategorysByIdAsync(int? id);
    }
}
