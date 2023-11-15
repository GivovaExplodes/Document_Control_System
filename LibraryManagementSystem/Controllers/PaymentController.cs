using Microsoft.AspNetCore.Mvc;

public class PaymentController : Controller
{
    const int allowedWithdrawTimeInDays = 14;
    private readonly ReservationRepository _reservations;
    private TimeSpan allowedWithdrawTime;

    public PaymentController()
    {
        _reservations = new ReservationRepository();
        allowedWithdrawTime = new TimeSpan(allowedWithdrawTimeInDays, 0, 0, 0);
    }

    //Action method for displaying overdue reservations
    public IActionResult LateFees(int userId)
    {
        List<ReservationModel> reservations = _reservations.GetReservationsByUserId(userId);
        for (int i = 0; i < reservations.Count; i++)
        {
            if (reservations[i].ReservationDate + allowedWithdrawTime <= DateTime.Now)
            {
                reservations.RemoveAt(i);
                i--;
            }
        }
        return View(reservations);
    }

    //Action method for paying a given fee. Redirects to LateFees() when paid.
    public IActionResult PayFee(ReservationModel reservation)
    {
        if (PaymentService.PayLateFee(reservation))
        {
            _reservations.RemoveReservation(reservation);
        }
        return RedirectToAction("LateFees");
    }

}
