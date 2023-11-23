namespace LibraryManagementSystem.Models
{
    public class CheckedOutState : IBookState
    {
        public void BorrowBook(BookModel book)
        {
            // Book is already checked out, cannot borrow again
            Console.WriteLine("Book is already checked out.");
        }

        public void ReturnBook(BookModel book)
        {
            // Update book status to available upon return
            book.ChangeState(new AvailableState());
            Console.WriteLine("Book returned. Status: Available");
        }

        public void PlaceOnHold(BookModel book)
        {
            // Book is already checked out, cannot be put on hold
            Console.WriteLine("Cannot place a checked out book on hold.");
        }

        public void MarkAsLost(BookModel book)
        {
            // Mark book as lost and change state to LostState
            book.ChangeState(new LostState());
            Console.WriteLine("Book marked as lost.");
        }

    }
}
