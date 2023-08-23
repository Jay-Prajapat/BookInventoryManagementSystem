using BookDataAccessLayer.Models;
using BookDataAccessLayer.Repository;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Permissions;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace BookInventorySystemWeb.Controllers
{
    [Authorize]
    public class BookController : Controller
    {
        private readonly IBookInventoryRepository _bookInventoryRepository;
        public BookController()
        {
            _bookInventoryRepository = new BookInventoryRepository();
        }
        public BookController(IBookInventoryRepository bookInventoryRepository)
        {
            _bookInventoryRepository = bookInventoryRepository;
        }
        // GET: Book
        public async Task<ActionResult> Index(int? page)
        {
            var books = await _bookInventoryRepository.GetAllBooks();
            return View(books.ToList().ToPagedList(page ?? 1,5));
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Create(Book book)
        {

            var fileName = Path.GetFileNameWithoutExtension(book.ImageFile.FileName);
            var extension = Path.GetExtension(book.ImageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssffff") + extension;
            book.CoverImage = "~/Images/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/Images/"), fileName);
            book.ImageFile.SaveAs(fileName);
            if (ModelState.IsValid)
            {

                await _bookInventoryRepository.AddBookDetails(book);
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Model state is not valild");
            return View(book);
        }

        public async Task<ActionResult> Details(int id)
        {
            var book = await _bookInventoryRepository.GetBookById(id);
            return View(book);
        }
        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            var book = await _bookInventoryRepository.GetBookById(id);
            return View(book);
        }

        [HttpPost]
        public async Task<ActionResult> Delete(Book book)
        {
            await _bookInventoryRepository.DeleteBook(book.Id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            var book = await _bookInventoryRepository.GetBookById(id);
            return View(book);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(Book book)
        {
            if(book.ImageFile != null)
            {
                var fileName = Path.GetFileNameWithoutExtension(book.ImageFile.FileName);
                var extension = Path.GetExtension(book.ImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssffff") + extension;
                book.CoverImage = "~/Images/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Images/"), fileName);
                book.ImageFile.SaveAs(fileName);
            }
            else
            {
                Book oldBookObject = await _bookInventoryRepository.GetBookById(book.Id);
                book.CoverImage = oldBookObject.CoverImage;
            }
            if (ModelState.IsValid)
            {
                await _bookInventoryRepository.UpdateBookDetails(book);
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Model state is not valid.");
            return View(book);
        }

        public ActionResult GetBooksBySearchValue(string searchValue,int? page)
        {
            var result = _bookInventoryRepository.GetBooksDetailsBySearchValue(searchValue).ToPagedList(page ?? 1,5);
            return PartialView("_GetBookData",result);
        }
        
    }
}