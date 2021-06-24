using Global.Data;
using Global.Mappers;
using Global.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools.Connections.Database;

namespace Global.Services
{
    public class AuthService : IAuthRepository
    {
        private readonly Connection _connection;

        public AuthService(Connection connection)
        {
            _connection = connection;
        }

        // Récupère l'utilisateur qui s'est authentifié
        public User Login(string email, string password)
        {
            Command command = new Command("SP_AuthUser", true);
            command.AddParameter("Email", email);
            command.AddParameter("Password", password);
            return _connection.ExecuteReader(command, dr => dr.ToUser()).SingleOrDefault();
        }

        // Insère l'utilisateur qui s'est enregistré sur notre application
        public bool Register(User user)
        {
            Command command = new Command("SP_RegisterUser", true);
            command.AddParameter("LastName", user.LastName);
            command.AddParameter("FirstName", user.FirstName);
            command.AddParameter("Email", user.Email);
            command.AddParameter("Password", user.Password);
            return _connection.ExecuteNonQuery(command) == 1;
        }

        public bool EmailExists(string email)
        {
            Command command = new Command("SELECT COUNT(Email) FROM[User] WHERE Email = @Email", false);
            command.AddParameter("Email", email);
            return _connection.ExecuteNonQuery(command) == 1;
        }
    }
}
