
public static class PaymentService
{
    const decimal costPerDayOverdue = 0.2M;
    const int daysAllowed = 14;

    //Calculates fee from a reservation based on surcharge and days overdue. Being underdue returns a fee of 0.
    public static decimal CalculateFee(ReservationModel reservation)
    {
        int daysOverdue = (DateTime.Now - reservation.ReservationDate).Days;
        decimal overdueCost = Math.Max(costPerDayOverdue * (daysOverdue - daysAllowed), 0);
        return (daysOverdue > 1) ? reservation.Surcharge + overdueCost : 0;
    }

    public static Receipt? PayLateFee(ReservationModel reservation)
    {
        decimal value = CalculateFee(reservation);
        if (Pay(value))
        {
            return new WithTotal(value, new WithSurcharge(reservation.Surcharge, new WithOverdue((DateTime.Now - reservation.ReservationDate).Days, costPerDayOverdue, new ReservationReceipt(reservation))));
        }
        else return null;
    }

    private static bool Pay(decimal value)
    {
        //1) Open popup with payment provider
        //2) Charge users money
        //Because this isn't a real business, Pay() always returns true to indicate a successful transaction.        
        return true;
    }

}