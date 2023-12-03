public class BookModel
{
    public int BookId { get; set; }
    public required string Title { get; set; }
    public required string Author { get; set; }
    public required string ISBN { get; set; }
    public int Quantity { get; set; }
    public bool IsAvailable { get; internal set; }

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
