using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using ComitLibrary;
using ComitLibrary.Models;
using ComitLibrary.Storage;

namespace ComitLibraryWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        // Private data member 
        private LibrarySystem _library;

        public BookController(LibrarySystem library)
        {
            _library = library;
        }

        // Return all books at the library
        [HttpGet]
        public List<Book> GetAllBooks()
        {
            List<Book> results = _library.GetAllBooks();
            return results;
        }

        [HttpPost]
        public string CreateBook(Book newBook) 
        {
            _library.AddNewBook(newBook);
            return "Book added";
        }

    }
}
