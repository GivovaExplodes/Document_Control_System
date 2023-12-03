// LibraryManagementSystem/Controllers/Services/UserNotificationService.cs


public class UserNotificationService : IBookObserver
{
    // Method to handle the update notification
    public void Update(BookModel book)
    {
        // Check if the book is available
        if (book.IsAvailable)
        {
            // Notify the user that the book is available
            Console.WriteLine($"Book {book.Title} is now available.");
        }
    }
}
