using Microsoft.AspNetCore.Components.Web;

public class BookModel
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public required string Author { get; set; }
    public required string ISBN { get; set; }
    public int Quantity { get; set; }
    public BookStatus Status { get; set; } // Enum for available, checked out, etc.

    public enum BookStatus
    {
        Available,
        CheckedOut,
        OnHold,
        Lost,
        // Add more statuses as needed - MJ
    }
}
