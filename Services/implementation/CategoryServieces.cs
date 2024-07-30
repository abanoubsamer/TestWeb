using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using TestWeb.Models;
using TestWeb.Repository.Interface;
using TestWeb.Services.Interface;
using TestWeb.SharedRepositories.Implementation;
using TestWeb.UnitOfWork;

namespace TestWeb.Services.implementation
{
    public class CategoryServieces : ICategoryServieces
    {

        private IUnitOfWork _MyUnit;

        public CategoryServieces(IUnitOfWork MyUnit)
        {
            _MyUnit = MyUnit;
        }

        public async Task<bool> AddCategoryAsync(Category item)
        {
            if (item == null) return false;

            try
            {
                await _MyUnit.Categories.AddItemAsync(item);
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
           
        }

        public async Task<bool> AddCategorysRangeAsync(List<Category> items)
        {
            if (items == null) return false;

            try
            {
                await _MyUnit.Categories.AddItemsRangeAsync(items);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<bool> DeleteCategoryAsync(int? id)
        {
            if (id == null) return false;
            var Category = await GetCategorysByIdAsync(id);
            try
            {
              if(Category == null) return false;
              await _MyUnit.Categories.DeleteItemAsync(Category);
                return true;
            }catch(Exception e)
            {
                return false;
            }

        }

        public async Task<bool> DeleteCategorysRangeAsync(List<int>? ids)
        {
            if (ids == null) return false;
            var Category = await _MyUnit.Categories.SelectMoreOneAsync(C=>ids.Contains(C.Id));
            try
            {
                if (Category == null) return false;
                await _MyUnit.Categories.DeleteItemsRangeAsync(Category);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<List<Category>> GetCategorysAsync()
        {
          return await _MyUnit.Categories.GetItemsAsync();
        }

        public async Task<Category> GetCategorysByIdAsync(int? id)
        {
            return await _MyUnit.Categories.SelectOneAsync(C => C.Id == id);
        }

        public IQueryable<Category> GetTestCategorysIQueryable()
        {
            return _MyUnit.Categories.GetItemsAsQueryable();
        }

        public async Task<bool> IsCategoryExitsExcludeItSelfAsync(string Name, int Id)
        {
            return await _MyUnit.Categories.GetItemsAsQueryable().AnyAsync(c => c.Name == Name && c.Id != Id);
        }

        public async Task<bool> IsCategoryNameExitsAsync(string Name)
        {
            return await _MyUnit.Categories.GetItemsAsQueryable().AnyAsync(c => c.Name == Name);
        }

        public async Task<bool> UpdateCategoryAsync(Category item)
        {
            if (item == null) return false;

            try
            {
                await _MyUnit.Categories.UpdateItemAsync(item);
                return true;
            }catch(Exception e)
            {
                return false;
            }
        }
        
        public async Task<List<Category>> GetCategorysDetailsByIdAsync(int? id)
        {
            return await _MyUnit.Categories.GetItemsAsQueryable().Where(C=>C.Id==id).Include(I=>I.Items).ToListAsync();
        }
        public async Task<bool> UpdateCategorysAsync(List<Category> items)
        {
            if (items == null) return false;

            try
            {
                await _MyUnit.Categories.UpdateItemsRangeAsync(items);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
