using ContactRecordTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactRecordTest.Domain
{
    public interface IContactDomain
    {
        Task<IEnumerable<Contact>> GetAllContacts();
        Task<Contact> GetContactById(string id);
        Task Create(Contact contact);
        Task<bool> Update(Contact contact);
        Task<bool> Delete(string id);
    }
}
