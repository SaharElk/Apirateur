using Client.Data;

namespace Client.Repositories
{
    public interface IAuthRepository
    {
        User Login(string email, string password);
        bool Register(User user);
    }
}