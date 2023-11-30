public class BookModel
{
    public int BookId { get; set; }
    public required string Title { get; set; }
    public required string Author { get; set; }
    public required string ISBN { get; set; }
    public int Quantity { get; set; }

    //updated to state design pattern - MB
    //public BookStatus Status { get; set; } // Enum for available, checked out, etc.

    /*public enum BookStatus
    {
        Available,
        CheckedOut,
        OnHold,
        Lost,
        // Add more statuses as needed - MJ
    }*/

    private IBookState currentState;

    public BookModel()
    {
        currentState = new AvailableState(); // Initial state is available
    }

    public void ChangeState(IBookState newState)
    {
        currentState = newState;
    }

    public void Borrow()
    {
        currentState.BorrowBook(this);
    }

    public void Return()
    {
        currentState.ReturnBook(this);
    }

    public IBookState GetCurrentState()
        {
            return currentState;
        }
}
