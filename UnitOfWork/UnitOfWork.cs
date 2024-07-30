using TestWeb.Data;
using TestWeb.Repository.implementation;
using TestWeb.Repository.Interface;
using TestWeb.Repostory.Base;
using TestWeb.SharedRepositories.Implementation;

namespace TestWeb.UnitOfWork
{
    public class UnitOfWork: IUnitOfWork
    {
        public IItemRepository Items { get; private set; }

        public ICategoriesRepository Categories { get; private set; }

        private readonly AppDbContext _db;

        public UnitOfWork(AppDbContext db)
        {
            _db = db;
            Items = new ItemRepository(db);
            Categories =new CategoriesRepository(db);
        }


        public int CommitChanges()
        {
            return _db.SaveChanges();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
