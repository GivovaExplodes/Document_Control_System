
public interface IUserRepository
{
    Task AddUserAsync(UserModel user);
    Task UpdateUserAsync(UserModel user);
    Task DeleteUserAsync(int userId);
    Task<UserModel> GetUserByIdAsync(int userId);
    Task<IEnumerable<UserModel>> GetAllUsersAsync();
    Task<IEnumerable<UserModel>> GetUsersByRoleAsync(UserModel.UserRole role);
    Task<UserModel> GetUserByUsernameAsync(string username);
    Task<IEnumerable<UserModel>> GetUsersByLoyaltyPointsAsync(int points);
}
