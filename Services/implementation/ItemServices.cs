using Microsoft.EntityFrameworkCore;
using NuGet.Configuration;
using System.Text.RegularExpressions;
using TestWeb.Models;
using TestWeb.Repository.Interface;
using TestWeb.Services.Interface;
using TestWeb.UnitOfWork;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace TestWeb.Services.implementation
{
    public class ItemServices :IItemServices
    {

        #region Fialds
        //private IItemRepository _repostoryItem;
        private IUnitOfWork _MyUnit;
        #endregion



        #region Constructor
        public ItemServices(IUnitOfWork MyUnit)
        {
            _MyUnit = MyUnit;
        }
        #endregion




        #region Implementation Services
        public async Task<bool> AddItemAsync(TestItemcs item)
        {
            if (item == null) return false;
            try
            {
                await _MyUnit.Items.AddItemAsync(item); // Assuming AddRange is a method in your repository
                return true;
            }
            catch (Exception ex)
            {
                // Handle the exception (e.g., log it)
                return false;
            }
        }

        public async Task<bool> AddItemsRangeAsync(List<TestItemcs> items)
        {
            if (items == null) return false;
            try
            {
                await _MyUnit.Items.AddItemsRangeAsync(items); // Assuming AddRange is a method in your repository
                return true;
            }
            catch (Exception ex)
            {
                // Handle the exception (e.g., log it)
                return false;
            }
        }

        public async Task<bool> DeleteItemAsync(int? id)
        {
            if (id == null) return false;
            var item = await GetItemByIdAsync(id);
            try
            {
                await _MyUnit.Items.DeleteItemAsync(item);
                return true;

            }
            catch (Exception e)
            {
                return false;
            }

        }

        public async Task<bool> DeleteItemsRangeAsync(List<int>? ids)
        {
            if (ids == null) return false;
            var item = await GetItemsRangeByIdAsync(ids);
            try
            {
                await _MyUnit.Items.DeleteItemsRangeAsync(item);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<List<TestItemcs>> GetItemsAsync()
        {
            return await _MyUnit.Items.GetItemsAsync();
        }
        public async Task<List<TestItemcs>> GetItemsAsync(params string[] agers)
        {
            var Quaery = _MyUnit.Items.GetItemsAsQueryable();
            if (agers.Length > 0)
            {
                foreach(var ager  in agers)
                {
                    Quaery = Quaery.Include(ager);
                }
            }

            return await Quaery.ToListAsync();
        }

        public async Task<List<TestItemcs>> GetItemsAsyncWithCategory()
        {
            return await _MyUnit.Items.GetItemsAsQueryable().Include(c => c.Categorys).ToListAsync();
        }

       

        public async Task<bool> IsItemExitsExcludeItSelfAsync(string Name, int Id)
        {
            return await _MyUnit.Items.AnyAsync(t => t.Id != Id && t.Name == Name);
        }

        public async Task<bool> IsItemNameExitsAsync(string name)
        {
            return await _MyUnit.Items.AnyAsync(I => I.Name == name);
        }

        public async Task<bool> UpdateItemAsync(TestItemcs item)
        {
            if (item == null) return false;
            try
            {
                await _MyUnit.Items.UpdateItemAsync(item);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> UpdateItemsAsync(List<TestItemcs> items)
        {
            if (items == null) return false;
            try
            {
                await _MyUnit.Items.UpdateItemsRangeAsync(items);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public async Task<List<TestItemcs>> GetItemsRangeByIdAsync(List<int>? ids)
        {
            if (ids == null || !ids.Any()) return new List<TestItemcs>();
            return await _MyUnit.Items.SelectMoreOneAsync(i => ids.Contains(i.Id));
        }
        public async Task<List<TestItemcs>> GetItemsRangeByNameAsync(List<string>? Names)
        {
            if (Names == null || !Names.Any()) return new List<TestItemcs>();
            return await _MyUnit.Items.SelectMoreOneAsync(i => Names.Contains(i.Name));
        }

        public async Task<TestItemcs> GetItemByIdAsync(int? id)
        {
            if (id == null) return null;
            return await _MyUnit.Items.SelectOneAsync(I=>I.Id==id);
        }
        public async Task<TestItemcs> GetItemByNameAsync(string? Name)
        {
            if (Name == null) return null;
            return await _MyUnit.Items.SelectOneAsync(I => I.Name == Name);
        }
        public async Task<List<TestItemcs>> GetTestItemcsSearchAsync(string? search)
        {
            var Qaery = _MyUnit.Items.GetItemsAsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                Qaery = Qaery.Where(p => p.Name.Contains(search));
            }

            return await Qaery.ToListAsync();

        }

        #endregion







    }
}
