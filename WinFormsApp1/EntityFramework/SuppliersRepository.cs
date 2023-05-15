using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.EntityFramework
{
    public class SuppliersRepository
    {
        private readonly InventoryDbContext _dbContext;

        public SuppliersRepository()
        {
            _dbContext = new InventoryDbContext();
        }

        public async Task Add(Suppliers Suppliers)
        {
           await _dbContext.Suppliers.AddAsync(Suppliers);
            _dbContext.SaveChanges();
        }

        public void Edit(Suppliers supplier)
        {
            _dbContext.Suppliers.Update(supplier);
            _dbContext.SaveChanges();
        }

        public void Remove(Guid supplierId)
        {
            var supplier = _dbContext.Suppliers.FirstOrDefault(_ => _.Id == supplierId);
            _dbContext.Suppliers.Remove(supplier);
            _dbContext.SaveChanges();
        }

        public async Task<IEnumerable<Suppliers>> GetAll()
        {
            return await _dbContext.Suppliers.ToListAsync();
        }
    }
}
