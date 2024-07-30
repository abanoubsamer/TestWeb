using Microsoft.EntityFrameworkCore;
using TestWeb.Data;
using TestWeb.Models;
using TestWeb.Repository.Interface;
using TestWeb.Repostory.Base;
using TestWeb.SharedRepositories.Implementation;

namespace TestWeb.Repository.implementation
{
    public class ItemRepository:GenericRepository<TestItemcs>,IItemRepository
    {
        private readonly DbSet<TestItemcs> _item;

        public ItemRepository(AppDbContext db):base(db)
        {
            _item = db.Set<TestItemcs>();
        }



    }
}
