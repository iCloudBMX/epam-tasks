using MvcPrinciples.Infrastucture.Interfaces;
using MvcPrinciples.Model.Models;
using MvcPrinciples.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcPrinciples.Services.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public IQueryable<Category> RetrieveAllCategories()
        {
            return this.categoryRepository.SelectAllCategories();
        }

        public async ValueTask<Category> RetrieveCategoryByIdAsync(int categoryId)
        {
            return await this.categoryRepository.SelectCategoryByIdAsync(categoryId);
        }
    }
}
