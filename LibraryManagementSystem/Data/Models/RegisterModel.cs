using System.ComponentModel.DataAnnotations;

public class RegisterModel
{
    private readonly IAccountFactory accountFactory;

    public RegisterModel(IAccountFactory accountFactory)
    {
        this.accountFactory = accountFactory;
    }

    [Required(ErrorMessage = "Username is required.")]
    [Display(Name = "Username")]
    public string Username { get; set; } = string.Empty;

    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress]
    [Display(Name = "Email")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Password is required.")]
    [DataType(DataType.Password)]
    [Display(Name = "Password")]
    public string Password { get; set; } = string.Empty;

    [Required(ErrorMessage = "Confirm Password is required.")]
    [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
    [DataType(DataType.Password)]
    [Display(Name = "Confirm Password")]
    public string ConfirmPassword { get; set; } = string.Empty;

    [Required(ErrorMessage = "Role is required.")]
    [Display(Name = "Role")]
    public string Role { get; set; } = string.Empty;

    public void CreateAccount()
    {
        UserModel newUser = accountFactory.CreateUserAccount(Username, Email, Password, Role);

        // Further logic to save the user to the repository or perform other actions
        // ...

        Console.WriteLine($"User Account created: UserID: {newUser.UserId}, Username: {newUser.Username}");
    }
}
