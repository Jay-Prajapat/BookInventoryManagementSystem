using ClassLibrary1.DAL;
using ClassLibrary1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Repository
{
    public class BookInventoryRepository:IBookInventoryRepository
    {
        private readonly BookInventoryEntity _dbContext;
        public BookInventoryRepository()
        {
            _dbContext = BookDataAccess.GetInstance();
        }
        public async  Task AddBookDetails(Book book)
        {
            _dbContext.Books.Add(book);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteBook(int id)
        {
            var book = await _dbContext.Books.FirstOrDefaultAsync(x => x.Id == id && x.IsDeleted == false);
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

        public IEnumerable<Book> GetBooksDetailsBySearchValue(string searchValue)
        {
            return  _dbContext.Books.Where(b => (b.Title.Contains(searchValue) || b.Author.Contains(searchValue) || b.Genre.Contains(searchValue)) && b.IsDeleted == false).ToList();
        }

        public async Task UpdateBookDetails(Book bookToUpdate)
        {
            if (bookToUpdate != null)
            {
                _dbContext.Books.AddOrUpdate(bookToUpdate);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
