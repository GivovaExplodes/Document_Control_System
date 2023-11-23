public interface IBookState
{
    void BorrowBook(BookModel book);
    void ReturnBook(BookModel book);
    void PlaceOnHold(BookModel book);
    void MarkAsLost(BookModel book);
}
