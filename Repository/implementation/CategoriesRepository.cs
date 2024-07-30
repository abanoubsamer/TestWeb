using Microsoft.EntityFrameworkCore;
using TestWeb.Data;
using TestWeb.Models;
using TestWeb.Repository.Interface;
using TestWeb.SharedRepositories.Implementation;

namespace TestWeb.Repository.implementation
{
    public class CategoriesRepository: GenericRepository<Category>, ICategoriesRepository
    {

            private readonly DbSet<Category> _Categories;

            public CategoriesRepository(AppDbContext db) : base(db)
            {
            _Categories = db.Set<Category>();
            }



    }
}
