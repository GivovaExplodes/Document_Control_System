using Microsoft.AspNetCore.Mvc;
using LibraryManagementSystem.Models; 

public class RegisterController : Controller
{
    private readonly IAccountFactory accountFactory;

    [HttpPost]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Register(){

        string username = Request.Form["Username"];
        string email = Request.Form["Email"];
        string password = Request.Form["Password"];
        string role = Request.Form["Role"];
        
        return View();
    }

}