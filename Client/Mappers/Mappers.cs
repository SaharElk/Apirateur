using Client.Data;
using G = Global.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Mappers
{
    internal static class Mappers
    {
        internal static Category ToClient(this G.Category category)
        {
            return new Category(category.Id, category.Name);
        }

        internal static G.Category ToGlobal(this Category category)
        {
            return new G.Category()
            {
                Id = category.Id,
                Name = category.Name
            };
        }

        internal static Contact ToClient(this G.Contact contact)
        {
            return new Contact(contact.Id, contact.LastName, contact.FirstName, contact.Email, contact.CategoryId, contact.UserId);
        }

        internal static G.Contact ToGlobal(this Contact contact)
        {
            return new G.Contact
            {
                Id = contact.Id,
                LastName = contact.LastName,
                FirstName = contact.FirstName,
                Email = contact.Email,
                CategoryId = contact.CategoryId,
                UserId = contact.UserId
            };
        }

        internal static User ToClient(this G.User user)
        {
            // Remarque : on ne récupère jamais le mot de passe de la BD => mot de passe doit être à null quand on le récupère de la DB
            // Ce sont les utilisateurs du projet Client que nous allons utiliser dans notre application
            // Remarque : le mot de passe est déjà à null dans Global !
            return new User(user.Id, user.LastName, user.FirstName, user.Email, user.IsAdmin);
        }

        internal static G.User ToGlobal(this User user)
        {
            return new G.User() {
                Id = user.Id,
                LastName = user.LastName,
                FirstName = user.FirstName,
                Email = user.Email,
                Password = user.Password,
                IsAdmin = user.IsAdmin
            };
        }
    }
}
