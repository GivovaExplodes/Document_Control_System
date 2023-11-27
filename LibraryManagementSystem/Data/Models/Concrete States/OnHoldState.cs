namespace LibraryManagementSystem.Models
{
    public class OnHoldState : IBookState
    {
        public void BorrowBook(BookModel book)
        {
            // Book is on hold, cannot borrow until released
            Console.WriteLine("Book is on hold and cannot be borrowed at the moment.");
        }

        public void ReturnBook(BookModel book)
        {
            // Update book status to available upon return
            book.ChangeState(new AvailableState());
            Console.WriteLine("Book returned. Status: Available");
        }

        public void PlaceOnHold(BookModel book)
        {
            // Book is already on hold
            Console.WriteLine("Book is already on hold.");
        }

        public void MarkAsLost(BookModel book)
        {
            // Mark book as lost and change state to LostState
            book.ChangeState(new LostState());
            Console.WriteLine("Book marked as lost.");
        }
    }
}
