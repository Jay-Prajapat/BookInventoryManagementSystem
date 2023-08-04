using ClassLibrary1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Repository
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
