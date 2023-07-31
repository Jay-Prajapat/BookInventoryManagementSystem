using BookInventoryDataAccessLayer.DAL;
using BookInventoryDataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookInventoryDataAccessLayer.Repository
{
    public class BookInventoryRepository : IBookInventoryRepository
    {
        private readonly BookInventoryEntity _dbContext = BookDataAccess.GetInstance();
        public async Task AddBookDetails(Book book)
        {
            await _dbContext.Books.AddAsync(book);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteBook(int id)
        {
            var book = await _dbContext.Books.FirstOrDefaultAsync(x => x.Id == id);
            book.IsDeleted = true;
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            return await _dbContext.Books.Where(b => b.IsDeleted == false).ToListAsync();
        }

        public async Task<Book> GetBookById(int id)
        {
            return await _dbContext.Books.SingleOrDefaultAsync(b => b.Id == id && b.IsDeleted == false);
        }

        public async Task UpdateBookDetails(Book book)
        {
            Book updateBook = await _dbContext.Books.FirstOrDefaultAsync(b => b.Id == book.Id);
            if (updateBook != null)
            {
                _dbContext.Entry(updateBook).State = EntityState.Detached;
            }
            _dbContext.Books.Update(book);
            await _dbContext.SaveChangesAsync();
        }
    }
}
