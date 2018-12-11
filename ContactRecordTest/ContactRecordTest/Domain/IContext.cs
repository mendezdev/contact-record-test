﻿using ContactRecordTest.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactRecordTest.Domain
{
    public interface IContext
    {
        IMongoCollection<Contact> Contacts { get; }
    }
}
