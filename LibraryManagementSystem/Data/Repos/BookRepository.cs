using System.Globalization;

public class BookRepository : IBookRepository
{
    private const string FilePath = "Books.csv";

    public BookModel GetBookById(int bookId)
    {
        var books = ReadFromCsv();
        return books.FirstOrDefault(b => b.BookId == bookId);
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
        books.Remove(book);
        WriteToCsv(books);
    }

    public IEnumerable<BookModel> GetAll()
    {
        return ReadFromCsv();
    }

    private List<BookModel> ReadFromCsv()
    {
        using (var reader = new StreamReader(FilePath))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            return csv.GetRecords<BookModel>().ToList();
        }
    }

    private void WriteToCsv(IEnumerable<Book> books)
    {
        using (var writer = new StreamWriter(FilePath))
        using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
        {
            csv.WriteRecords(books);
        }
    }
}
