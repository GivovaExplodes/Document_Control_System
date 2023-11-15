using System.Linq;
using Microsoft.AspNetCore.Mvc;

public class LibraryController : Controller
{
    private readonly LibraryModel _library;

    public LibraryController()
    {
        // Initialize your LibraryModel instance
        _library = new LibraryModel();
    }

    // Action method for displaying all books
    [HttpPost]
    public IActionResult Index()
    {
        var allBooks = _library.GetAllBooks();
        return View(allBooks);
    }

    // Action method for checking out a book
    [HttpPost]
    public IActionResult CheckOutBook(int bookId)
    {
        _library.CheckOutBook(bookId);
        // Implement the logic for checking out a book
        // For simplicity, let's just remove the book for now
        
        // Redirect back to the Index action
        return RedirectToAction("Index");
    }

    // Action method for showing checked-out books
    public IActionResult CheckedOutBooks()
    {
        // Implement the logic for showing checked-out books
        // For simplicity, let's just return a view with all books
        var checkedOutBooks = _library.GetAllBooks();
        return View(checkedOutBooks);
    }
}
