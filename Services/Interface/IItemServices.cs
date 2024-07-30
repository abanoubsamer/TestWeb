using NuGet.Configuration;
using System.Collections.Generic;
using TestWeb.Models;

namespace TestWeb.Services.Interface
{
    public interface IItemServices 
    {
       
        public Task<List<TestItemcs>> GetItemsRangeByNameAsync(List<string>? Names);
        public Task<TestItemcs> GetItemByNameAsync(string? Name);
        public Task<bool> AddItemAsync(TestItemcs item);
        public Task<bool> AddItemsRangeAsync(List<TestItemcs> items);
        public Task<bool> UpdateItemAsync(TestItemcs item);
        public Task<bool> UpdateItemsAsync(List<TestItemcs> items);
        public Task<bool> DeleteItemsRangeAsync(List<int>? ids);
        public Task<bool> DeleteItemAsync(int? id);
        public Task<List<TestItemcs>> GetItemsAsyncWithCategory();
        public Task<bool> IsItemExitsExcludeItSelfAsync(string Name, int id);
        public Task<bool> IsItemNameExitsAsync(string Name);
        public Task<List<TestItemcs>> GetTestItemcsSearchAsync(string? search);
        public Task<List<TestItemcs>> GetItemsAsync();
        public Task<List<TestItemcs>> GetItemsAsync(params string[] agers);
        public Task<TestItemcs> GetItemByIdAsync(int? id);

    }
}
