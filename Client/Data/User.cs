using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Data
{
    public class User
    {
        public int Id { get; private set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string Password { get; private set; }
        public bool IsAdmin { get; private set; }

        // Constructeur pour application
        // De l'application, on reçoit les valeurs pour lastname, firstName, email et password de notre formulaire Register
        // Donc, on a besoin d'un constructeur avec ses 4 paramètres pour pouvoir créer notre utilisateur dans notre BD.
        // Rappel :
        // Id, on n'a pas besoin de le préciser parce qu'il était auto-incrémenté
        // IsAdmin, on n'a pas besoin d ele préciser parce que par défaut, il est à zéro (false) sauf pour le premier utilisateur
        public User(string lastName, string firstName, string email, string password)
        {
            LastName = lastName;
            FirstName = firstName;
            Email = email;
            Password = password;
        }

        // Constructeur pour Mappers
        internal User(int id, string lastName, string firstName, string email, bool isAdmin) : this(lastName, firstName, email, null)
        {
            Id = id;
            IsAdmin = isAdmin;
        }

        //internal User(int id, string lastName, string firstName, string email, bool isAdmin)
        //{
        //    Id = id;
        //    LastName = lastName;
        //    FirstName = firstName;
        //    Email = email;
        //    IsAdmin = isAdmin;
        //}
    }
}
