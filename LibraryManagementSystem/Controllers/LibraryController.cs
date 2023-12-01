using System.Linq;
using Microsoft.AspNetCore.Mvc;

public class LibraryController : Controller
{
    private readonly LibraryModel _library;
    private readonly BookRepository _books;

    public LibraryController()
    {
        _books = new BookRepository();
        _library = new LibraryModel();
    }

    // Action method for displaying all books
    [HttpPost]
    public IActionResult Index()
    {
        var allBooks = _books.GetAll();
        TempData.Put("BookData", allBooks);
        return View();
    }

    // Action method for checking out a book
    [HttpPost]
    public IActionResult CheckOutBook(int bookId)
    {
        _library.CheckOutBook(bookId);

        return RedirectToAction("CheckedOutBooks");
    }

    // Action method for showing checked-out books
    public IActionResult CheckedOutBooks()
    {
        // Implement the logic for showing checked-out books
        // For simplicity, let's just return a view with all books
        return View();
    }
}
