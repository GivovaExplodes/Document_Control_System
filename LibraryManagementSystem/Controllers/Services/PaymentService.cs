

public static class PaymentService
{
    const decimal costPerDayOverdue = 0.2M;

    //Calculates fee from a reservation based on surcharge and days overdue. Being underdue returns a fee of 0.
    public static decimal CalculateFee(ReservationModel reservation)
    {
        int daysOverdue = (DateTime.Now - reservation.ReservationDate).Days;
        return (daysOverdue > 1) ? reservation.Surcharge + costPerDayOverdue * daysOverdue : 0;
    }

    public static bool PayLateFee(ReservationModel reservation)
    {
        decimal value = CalculateFee(reservation);
        return Pay(value);
    }

    private static bool Pay(decimal value)
    {
        //1) Open popup with payment provider
        //2) Charge users money
        //Because this isn't a real business, Pay() always returns true to indicate a successful transaction.
        return true;
    }

}