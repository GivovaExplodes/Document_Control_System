using Microsoft.AspNetCore.Mvc;

public class PaymentController : Controller
{
    private readonly LibraryModel _library;
    private readonly ReservationRepository _reservations;
    private TimeSpan allowedWithdrawTime;

    public PaymentController()
    {
        _reservations = new ReservationRepository();
        _library = new LibraryModel();
        allowedWithdrawTime = new TimeSpan(Constants.daysAllowedBeforeLate, 0, 0, 0);
    }

    //redirects to LateFees()
    [HttpPost]
    public IActionResult Index(int userId)
    {
        List<ReservationModel> reservations = _reservations.GetReservationsByUserId(userId);
        for (int i = 0; i < reservations.Count; i++)
        {
            if (reservations[i].ReservationDate + allowedWithdrawTime >= DateTime.Now)
            {
                reservations.Remove(reservations[i]);
            }
        }
        TempData.Put("ReservationData", reservations);
        TempData["userId"] = userId;
        return RedirectToAction("LateFees");
    }

    //Action method for displaying overdue reservations
    public IActionResult LateFees()
    {
        return View();
    }

    //Action method for paying a given fee. Redirects to LateFees() when paid.
    public IActionResult PayFee(int reservationId)
    {
        ReservationModel reservation = _reservations.GetReservationById(reservationId);
        Receipt? receipt = PaymentService.PayLateFee(reservation);
        if (receipt != null)
        {
            _reservations.RemoveReservation(reservation);
            _library.ReturnBook(reservation.BookId);
        }
        TempData["reservationId"] = reservationId;
        TempData["receipt"] = receipt.GetReceipt();
        return View();
    }

}
