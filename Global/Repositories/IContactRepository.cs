using Global.Data;
using System.Collections.Generic;

namespace Global.Repositories
{
    public interface IContactRepository
    {
        bool Delete(int id);
        IEnumerable<Contact> Get();
        Contact Get(int id);
        IEnumerable<Contact> GetByCategory(int id);
        IEnumerable<Contact> GetByUser(int id);
        bool Insert(Contact contact);
        bool Update(int id, Contact contact);
    }
}