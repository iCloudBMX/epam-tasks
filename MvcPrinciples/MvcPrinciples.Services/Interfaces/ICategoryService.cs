using MvcPrinciples.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcPrinciples.Services.Interfaces
{
    public interface ICategoryService
    {
        IQueryable<Category> RetrieveAllCategories();
        ValueTask<Category> RetrieveCategoryByIdAsync(int categoryId);
    }
}
