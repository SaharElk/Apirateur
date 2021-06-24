using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Data
{
    public class Contact
    {
        
        public int Id { get; private set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public int CategoryId { get; set; }
        public int UserId { get; private set; }

        // Constructeur pour application web
        public Contact(string lastName, string firstName, string email, int categoryId)
        {
            LastName = lastName;
            FirstName = firstName;
            Email = email;
            CategoryId = categoryId;
        }

        // Constructeur pour le mappers
        internal Contact(int id, string lastName, string firstName, string email, int categoryId, int userId) : this(lastName, firstName, email, categoryId)
        {
            Id = id;
            UserId = userId;
        }

        //internal Contact(int id, string lastName, string firstName, string email, int categoryId, int userId)
        //{
        //    Id = id;
        //    LastName = lastName;
        //    FirstName = firstName;
        //    Email = email;
        //    CategoryId = categoryId;
        //    UserId = userId;
        //}
    }
}
