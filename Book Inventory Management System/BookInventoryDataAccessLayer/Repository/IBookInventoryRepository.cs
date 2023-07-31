using BookInventoryDataAccessLayer.DAL;
using BookInventoryDataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookInventoryDataAccessLayer.Repository
{
    public interface IBookInventoryRepository
    {
        Task<Book> GetBookById(int id);
        Task<IEnumerable<Book>> GetAllBooks();
        Task DeleteBook(int id);
        Task UpdateBookDetails(Book book);
        Task AddBookDetails(Book book);
    }
}
