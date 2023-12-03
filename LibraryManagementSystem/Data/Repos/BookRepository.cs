using System.Globalization;
using CsvHelper;

public class BookRepository : IBookRepository
{
    public BookModel GetBookById(int bookId)
    {
        var books = ReadFromCsv();
        return books.FirstOrDefault(b => b.BookId == bookId) ?? throw new KeyNotFoundException($"Book with ID {bookId} not found.");
    }

    public void AddBook(BookModel book)
    {
        var books = ReadFromCsv();
        books.Add(book);
        WriteToCsv(books);
    }

    public void RemoveBook(BookModel book)
    {
        var books = ReadFromCsv();
        var bookToRemove = books.FirstOrDefault(b => b.BookId == book.BookId);
        if (bookToRemove != null)
        {
            books.Remove(bookToRemove);
            WriteToCsv(books);
        }
    }

    public IEnumerable<BookModel> GetAll()
    {
        return ReadFromCsv();
    }

    private List<BookModel> ReadFromCsv()
    {
        using (var reader = new StreamReader(Constants.BookFilePath))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            return csv.GetRecords<BookModel>().ToList();
        }
    }

    private void WriteToCsv(IEnumerable<BookModel> books)
    {
        using (var writer = new StreamWriter(Constants.BookFilePath))
        using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
        {
            csv.WriteRecords(books);
        }
    }
}
