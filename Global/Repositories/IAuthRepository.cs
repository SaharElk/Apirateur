using Global.Data;

namespace Global.Repositories
{
    public interface IAuthRepository
    {
        User Login(string email, string password);
        bool Register(User user);
        bool EmailExists(string email);
    }
}