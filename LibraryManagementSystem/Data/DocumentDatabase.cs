
//TODO: make singleton & remove magic data
public class DocumentDatabase {
    LibraryModel library;

    public DocumentDatabase()
    {
        //Fills library with book data
        library = new();
        StreamReader sr = new("../../data.csv");
        while (!sr.EndOfStream)
        {
            BookModel book = ConvertDataToBookModel(sr.ReadLine().Split(','));
            library.AddBook(book);
        }

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

    void UpdateBook(BookModel book) {
        library.UpdateBook(book);
    }

}