public class ReservationModel
{
    public required int ReservationId { get; set; }
    public required int UserId { get; set; }
    public required int BookId { get; set; }
    public required DateTime ReservationDate { get; set; }
    //TODO - Change this as necessary to implement charge logic based on other factors - Matt
    public required decimal Surcharge { get; set; }

    // Additional properties and methods as needed
}
