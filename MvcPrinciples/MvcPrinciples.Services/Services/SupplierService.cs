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
    public class SupplierService : ISupplierService
    {
        private readonly ISupplierRepository supplierRepository;
        
        public SupplierService(ISupplierRepository supplierRepository)
        {
            this.supplierRepository = supplierRepository;
        }

        public IQueryable<Supplier> RetrieveAllSuppliers()
        {
            return this.supplierRepository.SelectAllSuppliers();
        }

        public async ValueTask<Supplier> RetrieveSupplierByIdAsync(int supplierId)
        {
            return await this.supplierRepository.SelectSupplierByIdAsync(supplierId);
        }
    }
}
