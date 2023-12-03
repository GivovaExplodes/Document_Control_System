// LibraryManagementSystem/Data/Models/IDocumentSubject.cs
public interface IBookSubject
{
    // Add an observer to the notification list
    void Attach(IBookObserver observer);

    // Remove an observer from the notification list
    void Detach(IBookObserver observer);

    // Notify all observers about a change in a book
    void Notify(BookModel book);
}