
public static class PaymentService
{
    //Calculates fee from a reservation based on surcharge and days overdue. Being underdue returns a fee of 0.
    public static decimal CalculateFee(ReservationModel reservation)
    {
        int daysOverdue = (DateTime.Now - reservation.ReservationDate).Days;
        decimal overdueCost = Math.Max(Constants.costPerDayOverdue * (daysOverdue - Constants.daysAllowedBeforeLate), 0);
        return (daysOverdue > 1) ? reservation.Surcharge + overdueCost : 0;
    }

    public static Receipt? PayLateFee(ReservationModel reservation)
    {
        if (Pay(CalculateFee(reservation)))
        {
            return ReceiptService.NewReservationReceipt(reservation);
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