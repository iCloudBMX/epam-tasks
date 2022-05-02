using MvcPrinciples.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcPrinciples.Infrastucture.Interfaces
{
    public interface ISupplierRepository
    {
        IQueryable<Supplier> SelectAllSuppliers();
        ValueTask<Supplier> SelectSupplierByIdAsync(int supplierId);
        ValueTask<Supplier> InsertSupplierAsync(Supplier supplier);
        ValueTask<Supplier> UpdateSupplierAsync(Supplier supplier);
        ValueTask<Supplier> DeleteSupplierAsync(Supplier supplier);
    }
}
