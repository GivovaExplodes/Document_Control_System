using NUnit.Framework;

[TestFixture]
public class Test_PaymentService
{
    class Test_ReservationModel
    {
        public ReservationModel reservationModel;
        public object output;

        public Test_ReservationModel(ReservationModel r, object o)
        {
            reservationModel = r;
            output = o;
        }
    }


    [Test]
    public void Test_CalculateFee()
    {
        List<Test_ReservationModel> testReservations = new List<Test_ReservationModel>()
        {
            new(new ReservationModel()
            {
                UserId = 0,
                ReservationId = 0,
                BookId = 0,
                ReservationDate = DateTime.Now,
                Surcharge = 100
            },
            0),
            new(new ReservationModel()
            {
                UserId = 0,
                ReservationId = 0,
                BookId = 0,
                ReservationDate = DateTime.Now.AddDays(-14),
                Surcharge = 0
            },
            0)
            ,
            new(new ReservationModel()
            {
                UserId = 0,
                ReservationId = 0,
                BookId = 0,
                ReservationDate = DateTime.Now.AddDays(-15),
                Surcharge = 100
            },
            100.2)
        };

        for (int i = 0; i < testReservations.Count; i++)
        {
            decimal cost = PaymentService.CalculateFee(testReservations[i].reservationModel);
            Assert.AreEqual(testReservations[i].output, cost);
        }
        
    }

    [Test]
    public void Test_PayLateFee()
    {
        List<Test_ReservationModel> testReservations = new List<Test_ReservationModel>()
        {
            new(new ReservationModel()
            {
                UserId = 0,
                ReservationId = 0,
                BookId = 0,
                ReservationDate = DateTime.Now,
                Surcharge = 100
            },
            "Reservation 0\nOverdue Cost: 0 * 0.2 = 0.0\nSurcharge: 100\nTotal: 0"),
            new(new ReservationModel()
            {
                UserId = 0,
                ReservationId = 100,
                BookId = 0,
                ReservationDate = DateTime.Now.AddDays(-14),
                Surcharge = 100
            },
            "Reservation 100\nOverdue Cost: 14 * 0.2 = 2.8\nSurcharge: 100\nTotal: 100.0")
            ,
            new(new ReservationModel()
            {
                UserId = 0,
                ReservationId = -60,
                BookId = 0,
                ReservationDate = DateTime.Now.AddDays(-15),
                Surcharge = 100
            },
            "Reservation -60\nOverdue Cost: 15 * 0.2 = 3.0\nSurcharge: 100\nTotal: 100.2")
        };

        for (int i = 0; i < testReservations.Count; i++)
        {
            string receipt = PaymentService.PayLateFee(testReservations[i].reservationModel).GetReceipt();
            Assert.AreEqual(testReservations[i].output, receipt);
        }
    }


}
