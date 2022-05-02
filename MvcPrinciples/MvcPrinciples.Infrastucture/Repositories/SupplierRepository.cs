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
    public class SupplierRepository : ISupplierRepository
    {
        private readonly ApplicationDbContext applicationDbContext;

        public SupplierRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public IQueryable<Supplier> SelectAllSuppliers()
        {
            return this.applicationDbContext.Suppliers;
        }

        public async ValueTask<Supplier> SelectSupplierByIdAsync(int supplierId)
        {
            return await this.applicationDbContext.Suppliers.FindAsync(supplierId);
        }
        public ValueTask<Supplier> InsertSupplierAsync(Supplier supplier)
        {
            throw new NotImplementedException();
        }

        public ValueTask<Supplier> UpdateSupplierAsync(Supplier supplier)
        {
            throw new NotImplementedException();
        }
        public ValueTask<Supplier> DeleteSupplierAsync(Supplier supplier)
        {
            throw new NotImplementedException();
        }
    }
}
