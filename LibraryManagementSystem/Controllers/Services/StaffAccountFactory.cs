
public class StaffAccountFactory : IAccountFactory
{
    public UserModel CreateUserAccount(string username, string email, string password, string role)
    {
        return new UserModel
        {
            UserId = GenerateUserId(),
            Username = username,
            Name = email, // For simplicity, using email as the name
            LoyaltyPoints = 0,
            Role = ParseUserRole(role)
        };
    }

    private int GenerateUserId()
    {
        Random rnd = new Random();
        int StaffId = rnd.Next();
        return StaffId;
    }

    private UserModel.UserRole ParseUserRole(string role)
    {
        // Implement logic to parse the role string to the UserRole enum
        if (Enum.TryParse<UserModel.UserRole>(role, ignoreCase: true, out var parsedRole))
        {
            return parsedRole;
        }
        else
        {
            throw new ArgumentException("Invalid role");
        }
    }
}