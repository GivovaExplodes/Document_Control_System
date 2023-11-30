using LibraryManagementSystem.Models;

public class AvailableState : IBookState
{
    public void BorrowBook(BookModel book)
    {
        book.ChangeState(new CheckedOutState());
        Console.WriteLine("Book checked out.");
    }

    public void ReturnBook(BookModel book) 
    { 
        Console.WriteLine("Book is not checked out.");
    }
    public void PlaceOnHold(BookModel book) 
    {
        book.ChangeState(new OnHoldState());
        Console.WriteLine("Book put on hold.");
    }
    public void MarkAsLost(BookModel book) 
    { 
        book.ChangeState(new LostState());
        Console.WriteLine("Book marked as lost");
    }
}
