public class UserModel
{
    public int Id { get; set; }
    public required string Username { get; set; }
    public required string Name { get; set; }
    public int LoyaltyPts {get; set;}
    public UserRole Role { get; set; } // Enum for user status

    public enum UserRole 
    {
        admin,
        librarian,
        patron
    }
}
