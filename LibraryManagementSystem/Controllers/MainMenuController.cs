using Microsoft.AspNetCore.Mvc;
using LibraryManagementSystem.Models; // Adjust this namespace to match your project structure

public class MainMenuController : Controller
{
    // Action method for displaying the login view
    public IActionResult Login()
    {
        var loginModel = new LoginModel();
        return View(loginModel);
    }

    // Action method for handling the login form submission
    [HttpPost]
    public IActionResult Login(LoginModel loginModel)
    {
        // Validate the loginModel, authenticate the user, and redirect accordingly
        if (ModelState.IsValid)
        {
            
            // For demonstration purposes, redirect to the Index action with a sample user
            var userModel = new UserModel
            {
                UserId = 1,
                Username = "SampleUser",
                Name = "John Doe",
                LoyaltyPoints = 100,
                Role = UserModel.UserRole.patron
            };

            return RedirectToAction("Index", userModel);
        }

        // If the model is not valid, return the login view with validation errors
        return View(loginModel);
    }

    // Action method for displaying the main menu view
    public IActionResult Index(UserModel userModel)
    {
        // Pass the user model to the view
        return View(userModel);
    }

    // You can add more action methods as needed for different functionalities
}
