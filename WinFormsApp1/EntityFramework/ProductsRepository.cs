using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.EntityFramework;

public class ProductsRepository
{
    private readonly InventoryDbContext _dbContext;

    public ProductsRepository()
    {
        _dbContext = new InventoryDbContext();
    }
    
    public async Task Add(Products product)
    {
        await _dbContext.Products.AddAsync(product);
        _dbContext.SaveChanges();
    }

    public void Edit(Products product)
    { 
        _dbContext.Products.Update(product);
        _dbContext.SaveChanges();
    }

    public void Remove(Guid bookId)
    {
        var product = _dbContext.Products.FirstOrDefault(_ => _.Id == bookId);
        _dbContext.Products.Remove(product);
        _dbContext.SaveChanges();
    }

    public async Task<IEnumerable<Products>> GetAll()
    {
        return await _dbContext.Products.ToListAsync();
    }
}     