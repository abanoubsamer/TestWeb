using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using TestWeb.Data;
using System.Linq.Expressions;
using TestWeb.Repostory.Base;

namespace TestWeb.SharedRepositories.Implementation
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly AppDbContext _db;
        private readonly DbSet<T> _dbset;

        public GenericRepository(AppDbContext context)
        {
            _db = context;
            _dbset = _db.Set<T>();
        }

        public async Task AddItemAsync(T item)
        {
            await _dbset.AddAsync(item);
            await _db.SaveChangesAsync();
        }

        public async Task AddItemsRangeAsync(List<T> items)
        {
            await _dbset.AddRangeAsync(items);
            await _db.SaveChangesAsync(); // Save changes after adding the range
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return await _db.Database.BeginTransactionAsync();
        }

        public async Task DeleteItemAsync(T item)
        {
            _dbset.Remove(item);
            await _db.SaveChangesAsync();
        }
        public async Task DeleteItemsRangeAsync(List<T> items)
        {
            _dbset.RemoveRange(items);
            await _db.SaveChangesAsync();
        }
        public IQueryable<T> GetItemsAsQueryable()
        {
            return _dbset.AsQueryable();
        }
        public async Task<List<T>> GetItemsAsync()
        {
            return await _dbset.ToListAsync();
        }
        public async Task<bool> AnyAsync(Expression<Func<T, bool>> match)
        {
            return await _dbset.AnyAsync(match);
        }
        public async Task UpdateItemAsync(T item)
        {
            _dbset.Update(item);
            await _db.SaveChangesAsync();
        }
        public async Task UpdateItemsRangeAsync(List<T> items)
        {
            _dbset.UpdateRange(items);
            await _db.SaveChangesAsync();
        }
        public async Task<T> SelectOneAsync(Expression<Func<T, bool>> match)
        {
            return await _dbset.SingleOrDefaultAsync(match);
        }
        public async Task<List<T>> SelectMoreOneAsync(Expression<Func<T, bool>> match)
        {
            return await _dbset.Where(match).ToListAsync();
        }

    }
}
