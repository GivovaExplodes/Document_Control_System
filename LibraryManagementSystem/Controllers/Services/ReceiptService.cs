
public static class ReceiptService {
    
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
        return "Reservation " + reservationModel.ReservationId;
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
    decimal dailyCost;
    public WithOverdue(decimal overdue, decimal costPerDay, Receipt r) : base(r)
    {
        daysOverdue = overdue;
        dailyCost = costPerDay;
    }

    public override string GetReceipt()
    {
        return receipt.GetReceipt() + "\nOverdue Cost: " + daysOverdue + " * " + dailyCost + " = " + daysOverdue * dailyCost;
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