public class LibraryModel
{
    private List<BookModel> books;
    private List<UserModel> users;

    public LibraryModel()
    {
        // Initialize your books and users collections or load data from the database.
        books = new List<BookModel>();
        users = new List<UserModel>();
    }

    // Book-related methods
    public List<BookModel> GetAllBooks()
    {
        return books;
    }

        public List<BookModel> GetCheckedOutBooks()
    {
        List<BookModel> allBooks = GetAllBooks();
        List<BookModel> checkedOutBooks = allBooks.Where(book => book.Status == BookModel.BookStatus.CheckedOut).ToList();

        return checkedOutBooks;
    }

    public BookModel? GetBookById(int bookId)
    {
        return books.FirstOrDefault(b => b.BookId == bookId);
    }

    public void AddBook(BookModel book)
    {
        books.Add(book);
    }

    public void UpdateBook(BookModel book)
    {
        var existingBook = books.FirstOrDefault(b => b.BookId == book.BookId);
        if (existingBook != null)
        {
            existingBook.Title = book.Title;
            existingBook.Author = book.Author;
            existingBook.ISBN = book.ISBN;
            existingBook.Quantity = book.Quantity;
            existingBook.Status = book.Status;
        }
    }

    public void CheckOutBook(int bookid)
    {
        var existingBook = books.FirstOrDefault(b => b.BookId == bookid);
        if (existingBook != null)
        {
            existingBook.Status = BookModel.BookStatus.CheckedOut;
        }
    }

    public void RemoveBook(int bookId)
    {
        var bookToRemove = books.FirstOrDefault(b => b.BookId == bookId);
        if (bookToRemove != null)
        {
            books.Remove(bookToRemove);
        }
    }

    // User-related methods
    public List<UserModel> GetAllUsers()
    {
        return users;
    }

    public UserModel? GetUserById(int userId)
    {
        return users.FirstOrDefault(u => u.UserId == userId);
    }

    public void AddUser(UserModel user)
    {
        users.Add(user);
    }

    public void UpdateUser(UserModel user)
    {
        var existingUser = users.FirstOrDefault(u => u.UserId == user.UserId);
        if (existingUser != null)
        {
            existingUser.Username = user.Username;
            existingUser.Name = user.Name;
            existingUser.Role = user.Role;
        }
    }

    public void RemoveUser(int userId)
    {
        var userToRemove = users.FirstOrDefault(u => u.UserId == userId);
        if (userToRemove != null)
        {
            users.Remove(userToRemove);
        }
    }

    // Additional methods for managing transactions, searching books, etc.
}
