using System;
using GR = Global.Repositories;
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
        private readonly GR.IContactRepository _contactRepository;

        public ContactService(GR.IContactRepository contactService)
        {
            _contactRepository = contactService;
        }

        public IEnumerable<Contact> Get()
        {
            return _contactRepository.Get().Select(contact => contact.ToClient());
        }

        public IEnumerable<Contact> GetByCategory(int id)
        {
            return _contactRepository.GetByCategory(id).Select(contact => contact.ToClient());
        }

        public IEnumerable<Contact> GetByUser(int id)
        {
            return _contactRepository.GetByUser(id).Select(contact => contact.ToClient());
        }

        public Contact Get(int id)
        {
            return _contactRepository.Get(id)?.ToClient();
        }

        public bool Insert(Contact contact)
        {
            return _contactRepository.Insert(contact.ToGlobal());
        }

        public bool Update(int id, Contact contact)
        {
            return _contactRepository.Update(id, contact.ToGlobal());
        }

        public bool Delete(int id)
        {
            return _contactRepository.Delete(id);
        }
    }
}
