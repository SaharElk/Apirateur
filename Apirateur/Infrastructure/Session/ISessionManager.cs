namespace Apirateur.Infrastructure.Session
{
    public interface ISessionManager
    {
        UserSession User { get; set; }

        void Clear();
    }
}