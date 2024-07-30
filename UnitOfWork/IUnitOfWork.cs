using TestWeb.Repository.Interface;

namespace TestWeb.UnitOfWork
{
    public interface IUnitOfWork:IDisposable
    {
        IItemRepository Items { get; }
        ICategoriesRepository Categories { get; }

        int CommitChanges();
    }
}
 