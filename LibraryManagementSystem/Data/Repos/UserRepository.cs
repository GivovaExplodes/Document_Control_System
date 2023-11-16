using System.Globalization;
using CsvHelper;
public class UserRepository : IUserRepository
{
    private const string FilePath = "Data/Databases/Users.csv";

    public async Task AddUserAsync(UserModel user)
    {
        var users = ReadFromCsv();
        users.Add(user);
        await WriteToCsvAsync(users);
    }

    public async Task UpdateUserAsync(UserModel user)
    {
        var users = ReadFromCsv();
        var existingUser = users.FirstOrDefault(u => u.UserId == user.UserId);
        if (existingUser != null)
        {
            // Update user properties
            existingUser.Username = user.Username;
            // Update other properties as needed
        }
        await WriteToCsvAsync(users);
    }

    public async Task DeleteUserAsync(int userId)
    {
        var users = ReadFromCsv();
        var userToRemove = users.FirstOrDefault(u => u.UserId == userId);
        if (userToRemove != null)
        {
            users.Remove(userToRemove);
            await WriteToCsvAsync(users);
        }
    }

    public async Task<UserModel> GetUserByIdAsync(int userId)
    {
        var users = await ReadFromCsvAsync();
        return users.FirstOrDefault(u => u.UserId == userId)
               ?? throw new KeyNotFoundException($"User with ID {userId} not found.");
    }

    public async Task<IEnumerable<UserModel>> GetAllUsersAsync()
    {
        return await ReadFromCsvAsync();
    }

    public async Task<IEnumerable<UserModel>> GetUsersByRoleAsync(UserModel.UserRole role)
    {
        return (await ReadFromCsvAsync()).Where(u => u.Role == role);
    }

    public async Task<UserModel> GetUserByUsernameAsync(string username)
    {
        var users = await ReadFromCsvAsync();
        return users.FirstOrDefault(u => u.Username == username)
               ?? throw new KeyNotFoundException($"User with username '{username}' not found.");
    }

    public async Task<IEnumerable<UserModel>> GetUsersByLoyaltyPointsAsync(int points)
    {
        return (await ReadFromCsvAsync()).Where(u => u.LoyaltyPoints == points);
    }

    private List<UserModel> ReadFromCsv()
    {
        using (var reader = new StreamReader(FilePath))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            return csv.GetRecords<UserModel>().ToList();
        }
    }

    private async Task<List<UserModel>> ReadFromCsvAsync()
    {
        using (var reader = new StreamReader(FilePath))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            return await Task.Run(() => csv.GetRecords<UserModel>().ToList());
        }
    }


    private async Task WriteToCsvAsync(IEnumerable<UserModel> users)
    {
        using (var writer = new StreamWriter(FilePath))
        using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
        {
            await csv.WriteRecordsAsync(users);
        }
    }
}

