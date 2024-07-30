using Microsoft.EntityFrameworkCore.Storage;
using System.Linq.Expressions;

namespace TestWeb.Repostory.Base
{
    public interface IGenericRepository<T> where T :class 
    {
        public Task<bool> AnyAsync(Expression<Func<T, bool>> match);
        public Task<T> SelectOneAsync(Expression<Func<T, bool>> match);
        public Task<List<T>> SelectMoreOneAsync(Expression<Func<T, bool>> match);
        public Task AddItemAsync(T item);
        public Task AddItemsRangeAsync(List<T> items);
        public Task UpdateItemAsync(T item);
        public Task UpdateItemsRangeAsync(List<T> items);
        public Task DeleteItemAsync(T item);
        public Task DeleteItemsRangeAsync(List<T> items);
        public Task<List<T>> GetItemsAsync();
       
        public IQueryable<T> GetItemsAsQueryable();
      

        public Task<IDbContextTransaction> BeginTransactionAsync();

    }
}
