//Declares and holds the constants needed by multiple classes
public static class Constants
{
    //Needed for PaymentService, ReceiptService
    public const decimal costPerDayOverdue = 0.2M;
    public const int daysAllowedBeforeLate = 14;

    //Needed for repositories
    public const string BookFilePath = "Databases/Books.csv";
    public const string ReservationFilePath = "Databases/Reservations.csv";
    public const string UserFilePath = "Databases/Users.csv";
}
