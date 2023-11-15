using System.Globalization;
using CsvHelper;

public class ReservationRepository : IReservationRepository
{
    private const string FilePath = "Reservations.csv";

    public ReservationModel GetReservationById(int reservationId)
    {
        var reservations = ReadFromCsv();
        return reservations.FirstOrDefault(r => r.ReservationId == reservationId)
               ?? throw new KeyNotFoundException($"Reservation with ID {reservationId} not found.");
    }

    public List<ReservationModel> GetReservationsByUserId(int userID)
    {
        List<ReservationModel> reservations = ReadFromCsv();
        List<ReservationModel> output = new();
        for (int i = 0; i < reservations.Count; i++)
        {
            if (reservations[i].UserId == userID)
            {
                output.Add(reservations[i]);
            }
        }
        return output;
    }

    public void AddReservation(ReservationModel reservation)
    {
        var reservations = ReadFromCsv();
        reservations.Add(reservation);
        WriteToCsv(reservations);
    }

    public void RemoveReservation(ReservationModel reservation)
    {
        var reservations = ReadFromCsv();
        reservations.Remove(reservation);
        WriteToCsv(reservations);
    }

    public IEnumerable<ReservationModel> GetAll()
    {
        return ReadFromCsv();
    }

    private List<ReservationModel> ReadFromCsv()
    {
        using (var reader = new StreamReader(FilePath))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            return csv.GetRecords<ReservationModel>().ToList();
        }
    }

    private void WriteToCsv(IEnumerable<ReservationModel> reservations)
    {
        using (var writer = new StreamWriter(FilePath))
        using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
        {
            csv.WriteRecords(reservations);
        }
    }
}
