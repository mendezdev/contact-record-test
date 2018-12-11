using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ContactRecordTest.Domain;
using ContactRecordTest.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContactRecordTest.Controllers
{
    [Produces("application/json")]
    [Route("api/Contacts")]
    public class ContactsController : Controller
    {
        private readonly IContactDomain contactDomain;

        public ContactsController(IContactDomain contactDomain)
        {
            this.contactDomain = contactDomain;
        }

        // GET: api/Contacts
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await contactDomain.GetAllContacts());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetContactById(string id)
        {
            return Ok(await contactDomain.GetContactById(id));
        }
        
        // POST: api/Contacts
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Contact contact)
        {
            await contactDomain.Create(contact);
            return StatusCode((int)HttpStatusCode.Created, contact);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody]Contact contact)
        {
            var result = await contactDomain.Update(id, contact);

            return Ok();
        }
    }
}
