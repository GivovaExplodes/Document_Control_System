namespace LibraryManagementSystem.Models
{
    public class LostState : IBookState
    {
        public void BorrowBook(BookModel book)
        {
            // Book is lost, cannot borrow
            Console.WriteLine("Book is lost and cannot be borrowed.");
        }

        public void ReturnBook(BookModel book)
        {
            // Lost book cannot be returned
            Console.WriteLine("Lost book cannot be returned.");
        }

        public void PlaceOnHold(BookModel book)
        {
            // Book is lost, cannot be put on hold
            Console.WriteLine("Lost book cannot be put on hold.");
        }

        public void MarkAsLost(BookModel book)
        {
            // Book is already marked as lost
            Console.WriteLine("Book is already marked as lost.");
        }
    }
}
