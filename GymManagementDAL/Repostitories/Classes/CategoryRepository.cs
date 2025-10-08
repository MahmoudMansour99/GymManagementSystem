using GymManagementDAL.Data.DbContexts;
using GymManagementDAL.Entities;
using GymManagementDAL.Repostitories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementDAL.Repostitories.Classes
{
    internal class CategoryRepository : ICategoryRepository
    {
        private readonly GymDbContext _dbContext;
        public CategoryRepository(GymDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void AdCategory(Category category)
        {
            _dbContext.Categories.Add(category);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            _dbContext.Categories.Remove(_dbContext.Categories.Find(id));
            _dbContext.SaveChanges();
        }

        public IEnumerable<Category> GetAll() => _dbContext.Categories.ToList();

        public Category GetById(int id) => _dbContext.Categories.Find(id);

        public void Update(Category category)
        {
            _dbContext.Categories.Update(category);
            _dbContext.SaveChanges();
        }
    }
}
