using MvcPrinciples.Infrastucture.Contexts;
using MvcPrinciples.Infrastucture.Interfaces;
using MvcPrinciples.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcPrinciples.Infrastucture.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext applicationDbContext;

        public CategoryRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public IQueryable<Category> SelectAllCategories()
        {
            return this.applicationDbContext.Categories;
        }

        public async ValueTask<Category> SelectCategoryByIdAsync(int categoryId)
        {
            return await this.applicationDbContext.Categories.FindAsync(categoryId);
        }

        public ValueTask<Category> InsertCategoryAsync(Category category)
        {
            throw new NotImplementedException();
        }        

        public ValueTask<Category> UpdateCategoryAsync(Category category)
        {
            throw new NotImplementedException();
        }

        public ValueTask<Category> DeleteCategoryAsync(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
