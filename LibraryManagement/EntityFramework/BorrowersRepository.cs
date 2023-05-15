using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.EntityFramework
{
    public class BorrowersRepository
    {
        private readonly LibraryDbContext _dbContext;

        public BorrowersRepository()
        {
            _dbContext = new LibraryDbContext();
        }

        public async Task Add(Borrowers borrower)
        {
           await _dbContext.Borrowers.AddAsync(borrower);
            _dbContext.SaveChanges();
        }

        public void Edit(Borrowers borrower)
        {
            _dbContext.Borrowers.Update(borrower);
            _dbContext.SaveChanges();
        }

        public void Remove(Guid borrowerId)
        {
            var borrower = _dbContext.Borrowers.FirstOrDefault(_ => _.Id == borrowerId);
            _dbContext.Borrowers.Remove(borrower);
            _dbContext.SaveChanges();
        }

        public async Task<IEnumerable<Borrowers>> GetAll()
        {
            return await _dbContext.Borrowers.ToListAsync();
        }
    }
}
