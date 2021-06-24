using Tools.Connections.Database;
using Global.Data;
using Global.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Global.Repositories;

namespace Global.Services
{
    public class ContactService : IContactRepository
    {
        private readonly Connection _connection;

        public ContactService(Connection connection)
        {
            _connection = connection;
        }

        public IEnumerable<Contact> Get()
        {
            Command command = new Command("SELECT [Id], [LastName], [FirstName], [Email], [CategoryId], [UserId] FROM [Contact];", false);
            return _connection.ExecuteReader(command, dr => dr.ToContact());
        }

        public IEnumerable<Contact> GetByCategory(int id)
        {
            Command command = new Command("SELECT [Id], [LastName], [FirstName], [Email], [CategoryId], [UserId] FROM [Contact] WHERE [CategoryId] = @CategoryId;", false);
            command.AddParameter("CategoryId", id);
            return _connection.ExecuteReader(command, dr => dr.ToContact());
        }

        public IEnumerable<Contact> GetByUser(int id)
        {
            Command command = new Command("SELECT [Id], [LastName], [FirstName], [Email], [CategoryId], [UserId] FROM [Contact] WHERE [UserId] = @UserId;", false);
            command.AddParameter("UserId", id);
            return _connection.ExecuteReader(command, dr => dr.ToContact());
        }

        public Contact Get(int id)
        {
            Command command = new Command("SELECT [Id], [LastName], [FirstName], [Email], [CategoryId], [UserId] FROM [Contact] WHERE [Id] = @Id;", false);
            command.AddParameter("Id", id);
            return _connection.ExecuteReader(command, dr => dr.ToContact()).SingleOrDefault();
        }

        public bool Insert(Contact contact)
        {
            Command command = new Command("SP_AddContact", true);
            command.AddParameter("LastName", contact.LastName);
            command.AddParameter("FirstName", contact.FirstName);
            command.AddParameter("Email", contact.Email);
            command.AddParameter("CategoryId", contact.CategoryId);
            command.AddParameter("UserId", contact.UserId);
            return _connection.ExecuteNonQuery(command) == 1;
        }

        public bool Update(int id, Contact contact)
        {
            Command command = new Command("SP_UpdateContact", true);
            command.AddParameter("Id", id);
            command.AddParameter("LastName", contact.LastName);
            command.AddParameter("FirstName", contact.FirstName);
            command.AddParameter("Email", contact.Email);
            command.AddParameter("CategoryId", contact.CategoryId);
            command.AddParameter("UserId", contact.UserId);
            return _connection.ExecuteNonQuery(command) == 1;
        }

        public bool Delete(int id)
        {
            Command command = new Command("SP_DeleteContact", true);
            command.AddParameter("Id", id);
            return _connection.ExecuteNonQuery(command) == 1;
        }
    }
}
