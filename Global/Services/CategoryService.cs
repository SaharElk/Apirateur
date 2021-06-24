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
    public class CategoryService : ICategoryRepository
    {
        private readonly Connection _connection;

        public CategoryService(Connection connection)
        {
            _connection = connection;
        }

        public IEnumerable<Category> Get()
        {
            Command command = new Command("SELECT [Id], [Name] FROM [Category];", false);
            return _connection.ExecuteReader(command, dr => dr.ToCategory());
        }

        public Category Get(int id)
        {
            Command command = new Command("SELECT [Id], [Name] FROM [Category] WHERE [Id] = @Id;", false);
            command.AddParameter("Id", id);
            return _connection.ExecuteReader(command, dr => dr.ToCategory()).SingleOrDefault();
        }
    }
}
