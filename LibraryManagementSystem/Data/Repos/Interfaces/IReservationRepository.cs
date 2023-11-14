public interface IReservationRepository
{
    ReservationModel GetReservationById(int reservationId);
    void AddReservation(ReservationModel reservation);
    void RemoveReservation(ReservationModel reservation);
    IEnumerable<ReservationModel> GetAll();
}
