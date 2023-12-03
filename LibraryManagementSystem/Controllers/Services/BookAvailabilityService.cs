// LibraryManagementSystem/Controllers/Services/BookAvailabilityService.cs


public class BookAvailabilityService
{
    private List<IBookObserver> _observers = new List<IBookObserver>(); // List of observers
    private BookModel _book; // The book being observed

    // Constructor initializing with a book
    public BookAvailabilityService(BookModel book)
    {
        _book = book;
    }

    // Attach an observer to the service
    public void Attach(IBookObserver observer)
    {
        _observers.Add(observer);
    }

    // Detach an observer from the service
    public void Detach(IBookObserver observer)
    {
        _observers.Remove(observer);
    }

    // Notify all observers of a change
    public void Notify()
    {
        _observers.ForEach(observer => observer.Update(_book));
    }

    // Change the availability of the book and notify observers
    public void ChangeAvailability(bool isAvailable)
    {
        _book.IsAvailable = isAvailable;
        Notify();
    }

}
