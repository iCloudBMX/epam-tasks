using MvcPrinciples.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcPrinciples.Infrastucture.Interfaces
{
    public interface ICategoryRepository
    {
        IQueryable<Category> SelectAllCategories();
        ValueTask<Category> SelectCategoryByIdAsync(int categoryId);
        ValueTask<Category> InsertCategoryAsync(Category category);
        ValueTask<Category> UpdateCategoryAsync(Category category);
        ValueTask<Category> DeleteCategoryAsync(Category category);
    }
}
