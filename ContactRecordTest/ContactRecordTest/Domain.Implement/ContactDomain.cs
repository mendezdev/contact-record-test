using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactRecordTest.Models;
using MongoDB.Driver;

namespace ContactRecordTest.Domain.Implement
{
    public class ContactDomain : IContactDomain
    {
        private readonly IContext context;

        public ContactDomain(IContext context)
        {
            this.context = context;
        }

        public Task Create(Contact contact)
        {
            return context.Contacts.InsertOneAsync(contact);
        }

        public async Task<bool> Delete(string id)
        {
            DeleteResult deleteResult = await context
                .Contacts.DeleteOneAsync(
                    filter: c => c.Id == id
                );
            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }

        public async Task<IEnumerable<Contact>> GetAllContacts()
        {
            return await context.Contacts.Find(_ => true).ToListAsync();
        }

        public Task<Contact> GetContactById(string id)
        {
            FilterDefinition<Contact> filter = Builders<Contact>.Filter.Eq(m => m.Id, id);
            return context.Contacts.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<bool> Update(Contact contact)
        {
            ReplaceOneResult updateResult = await context
                .Contacts.ReplaceOneAsync(
                    filter: c => c.Id == contact.Id,
                    replacement: contact);

            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }
    }
}
