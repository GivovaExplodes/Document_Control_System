public interface IBookRepository
{
    BookModel GetBookById(int bookId);
    void AddBook(BookModel book);
    void RemoveBook(BookModel book);
    IEnumerable<BookModel> GetAll();
}
