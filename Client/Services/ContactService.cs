using System;
using GS = Global.Services;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Data;
using Client.Mappers;
using Client.Repositories;

namespace Client.Services
{
    public class ContactService : IContactRepository
    {
        private readonly GS.ContactService _contactService;

        public ContactService(GS.ContactService contactService)
        {
            _contactService = contactService;
        }

        public IEnumerable<Contact> Get()
        {
            return _contactService.Get().Select(contact => contact.ToClient());
        }

        public IEnumerable<Contact> GetByCategory(int id)
        {
            return _contactService.GetByCategory(id).Select(contact => contact.ToClient());
        }

        public IEnumerable<Contact> GetByUser(int id)
        {
            return _contactService.GetByUser(id).Select(contact => contact.ToClient());
        }

        public Contact Get(int id)
        {
            return _contactService.Get(id)?.ToClient();
        }

        public bool Insert(Contact contact)
        {
            return _contactService.Insert(contact.ToGlobal());
        }

        public bool Update(int id, Contact contact)
        {
            return _contactService.Update(id, contact.ToGlobal());
        }

        public bool Delete(int id)
        {
            return _contactService.Delete(id);
        }
    }
}
