public class UserModel
{
    public int UserId { get; set; }
    public required string Username { get; set; }
    public required string Name { get; set; }
    public int LoyaltyPoints {get; set;}
    public UserRole Role { get; set; } // Enum for user status

    public enum UserRole 
    {
        admin,
        librarian,
        patron
    }
}
