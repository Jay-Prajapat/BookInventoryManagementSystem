using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookInventoryDataAccessLayer.Repository;

namespace Book_Inventory_Management_System.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        private readonly IBookInventoryRepository _bookRepository;
        public BookController(IBookInventoryRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public ActionResult Index()
        {
            return View();
        }
    }
}