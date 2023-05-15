using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.EntityFramework;

public class BooksRepository
{
    private readonly LibraryDbContext _dbContext;

    public BooksRepository()
    {
        _dbContext = new LibraryDbContext();
    }
    
    public async Task Add(Books book)
    {
        await _dbContext.Books.AddAsync(book);
        _dbContext.SaveChanges();
    }

    public void Edit(Books book)
    { 
        _dbContext.Books.Update(book);
        _dbContext.SaveChanges();
    }

    public void Remove(Guid bookId)
    {
        var book = _dbContext.Books.FirstOrDefault(_ => _.Id == bookId);
        _dbContext.Books.Remove(book);
        _dbContext.SaveChanges();
    }

    public async Task<IEnumerable<Books>> GetAll()
    {
        return await _dbContext.Books.ToListAsync();
    }
}     