using Global.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Global.Mappers
{
    internal static class DataRecord
    {
        internal static Category ToCategory(this IDataRecord record)
        {
            return new Category()
            {
                Id = (int)record["Id"],
                Name = (string)record["Name"]
            };
        }

        internal static Contact ToContact(this IDataRecord record)
        {
            return new Contact()
            {
                Id = (int)record["Id"],
                LastName = (string)record["LastName"],
                FirstName = (string)record["FirstName"],
                Email = (string)record["Email"],
                CategoryId = (int)record["CategoryId"],
                UserId = (int)record["UserId"]
            };
        }

        internal static User ToUser(this IDataRecord record)
        {
            return new User()
            {
                Id = (int)record["Id"],
                LastName = (string)record["LastName"],
                FirstName = (string)record["FirstName"],
                Email = (string)record["Email"],
                // Le password ne peut jamais être récupéré de la DB
                Password = null, 
                IsAdmin = (bool)record["IsAdmin"]
            };
        }
    }
}
