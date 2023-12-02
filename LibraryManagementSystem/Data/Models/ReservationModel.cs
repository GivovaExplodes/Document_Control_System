public class ReservationModel
{
    public required int ReservationId { get; set; }
    public required int UserId { get; set; }
    public required int BookId { get; set; }
    public required DateTime ReservationDate { get; set; }
    public required decimal Surcharge { get; set; }
}
