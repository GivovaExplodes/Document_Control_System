// Abstract factory interface
public interface IAccountFactory
{
    UserModel CreateUserAccount(string username, string email, string password, string role);
}
