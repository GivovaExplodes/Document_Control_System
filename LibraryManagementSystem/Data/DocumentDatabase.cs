
//TODO: make singleton & remove magic data
public class DocumentDatabase {
    const string BOOK_PATH = "../../data.csv";
    const char DELIMITER = ',';
    LibraryModel library;

    public DocumentDatabase()
    {
        //Fills library with book data
        library = new();
        StreamReader sr = new(BOOK_PATH);
        while (!sr.EndOfStream)
        {
            BookModel book = ConvertDataToBookModel(sr.ReadLine().Split(DELIMITER));
            library.AddBook(book);
        }
    }

    //Calls UpdateBook() in the LibraryModel and WriteBook().
    public void UpdateBook(BookModel book) {
        library.UpdateBook(book);
        WriteBook(book);
    }

    //Calls GetBookByID() in LibraryModel
    public BookModel? GetBook(int id) {
        return library.GetBookById(id);
    }

    //converts CSV data to a BookModel object
    BookModel ConvertDataToBookModel(string[] data) {
        if (data.Length != 6 )
        {
            Console.WriteLine("WARN: Bad Read on Book: " + data);
        }
        BookModel book = new()
        {
            Id = int.Parse(data[0]),
            Title = data[1],
            Author = data[2],
            ISBN = data[3],
            Quantity = int.Parse(data[4]),
            Status = (BookModel.BookStatus)int.Parse(data[5]),
        };

        return book;
    }    

    //Writes a single BookModel to file.
    void WriteBook(BookModel book) {
        string bookString = book.Stringify(DELIMITER);
        string[] bookData = File.ReadAllLines(BOOK_PATH);
        int index = Array.FindIndex(bookData, b => b.Split(DELIMITER)[0].Equals(book.Id));
        if (index < 0)
        {
            Array.Resize(ref bookData, bookData.Length + 1);
            bookData[^1] = bookString;
        }
        else 
        {
            bookData[index] = bookString;
        }
        File.WriteAllLines(BOOK_PATH, bookData);
    }
}