
public static class ReceiptService {
    public static Receipt NewReservationReceipt(ReservationModel reservation)
    {
        return new WithTotal(PaymentService.CalculateFee(reservation), new WithSurcharge(reservation.Surcharge, new WithOverdue((DateTime.Now - reservation.ReservationDate).Days, new ReservationReceipt(reservation))));
    }
}


public abstract class Receipt {
    public abstract string GetReceipt();
}

public class ReservationReceipt : Receipt {
    ReservationModel reservationModel;
    public ReservationReceipt(ReservationModel r)
    {
        reservationModel = r;
    }

    public override string GetReceipt()
    {
        return "Reservation ID: " + reservationModel.ReservationId;
    }
}

public class WithSurcharge : ReceiptDecorator {
    decimal surcharge;
    public WithSurcharge(decimal value, Receipt r) : base(r)
    {
        surcharge = value;
    }

    public override string GetReceipt()
    {
        return receipt.GetReceipt() + "\nSurcharge: " + surcharge;
    }
}

public class WithOverdue : ReceiptDecorator {
    decimal daysOverdue;
    public WithOverdue(decimal overdue, Receipt r) : base(r)
    {
        daysOverdue = overdue;
    }

    public override string GetReceipt()
    {
        return receipt.GetReceipt() + "\nOverdue Cost: " + daysOverdue + " * " + Constants.costPerDayOverdue + " = " + daysOverdue * Constants.costPerDayOverdue;
    }
}

public class WithTotal : ReceiptDecorator {
    decimal total;
    public WithTotal(decimal value, Receipt r) : base(r)
    {
        total = value;
    }

    public override string GetReceipt()
    {
        return receipt.GetReceipt() + "\nTotal: " + total;
    }
}

public class ReceiptDecorator : Receipt {
    public Receipt receipt;

    public ReceiptDecorator(Receipt r)
    {
        receipt = r;
    }

    public override string GetReceipt()
    {
        return "";
    }
}