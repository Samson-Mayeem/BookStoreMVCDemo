using BookStoreMVCDemo.Data;
using BookStoreMVCDemo.Models;
using BookStoreMVCDemo.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookStoreMVCDemo.Controllers
{
    public class BookController : Controller
    {
        private readonly BaseDbContext bookDbContext;

        public BookController(BaseDbContext bookDbContext)
        {
            this.bookDbContext = bookDbContext;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var books = await bookDbContext.BookModel.ToListAsync();
            return View(books);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddBookModel addBookModel)
        {
            var book = new BookModel()
            {
                Name = addBookModel.Name,
                Description = addBookModel.Description,
                Category = addBookModel.Category,
                Price = addBookModel.Price
            };
            await bookDbContext.BookModel.AddAsync(book);
            await bookDbContext.SaveChangesAsync();
            return RedirectToAction("Add");
        }
        [HttpGet]
        public async Task<IActionResult> View(int id)
        {
            var book = await bookDbContext.BookModel.FirstOrDefaultAsync(x => x.Id == id);
            if (book != null)
            {
                var viewModel = new UpdateBookModel()
                {
                    Name = book.Name,
                    Description = book.Description,
                    Category = book.Category,
                    Price = book.Price
                };
                return await Task.Run(() => View("View", viewModel));
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> View(UpdateBookModel updateBookModel)
        {
            var book = await bookDbContext.BookModel.FindAsync(updateBookModel.Id);
            if (book != null)
            {
                book.Name = updateBookModel.Name;
                book.Description = updateBookModel.Description;
                book.Category = updateBookModel.Category;
                book.Price = updateBookModel.Price;
                await bookDbContext.SaveChangesAsync();
                return RedirectToAction("Index");
            };
            return View(book);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(UpdateBookModel updateBook)
        {
            var book = bookDbContext.BookModel.Find(updateBook.Id);
            if (book != null)
            {
                bookDbContext.BookModel.Remove(book);
                await bookDbContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}