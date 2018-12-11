using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactRecordTest.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace ContactRecordTest.Domain.Implement
{
    public class Context : IContext
    {
        private readonly IMongoDatabase db;

        public Context(IOptions<Settings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            db = client.GetDatabase(settings.Value.Database);
        }

        public IMongoCollection<Contact> Contacts => db.GetCollection<Contact>("Contacts");
    }
}
