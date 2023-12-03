// LibraryManagementSystem/Controllers/Services/DocumentSearchService.cs


public class BookSearchService
{    
    private readonly IEnumerable<BookModel> _books; // Collection of all books

    // Constructor to initialize the service with a collection of books
    public BookSearchService(IEnumerable<BookModel> books)
    {
        _books = books;
    }

    // Search for books by title
    public IEnumerable<BookModel> SearchByTitle(string title)
    {
        // Returns books whose titles contain the search string, case-insensitive
        return _books.Where(book => book.Title.Contains(title, StringComparison.OrdinalIgnoreCase));
    }

    // Search for books by author
    public IEnumerable<BookModel> SearchByAuthor(string author)
    {
        // Returns books whose authors' names contain the search string, case-insensitive
        return _books.Where(book => book.Author.Contains(author, StringComparison.OrdinalIgnoreCase));
    }

    // Search for a book by its ISBN
    public IEnumerable<BookModel> SearchByISBN(string isbn)
    {
        // Returns the first book (or null) that matches the given ISBN
        return _books.Where(book => book.ISBN.Contains(isbn, StringComparison.OrdinalIgnoreCase));
    }
}
