using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactRecordTest.Models
{
    public class Contact
    {
        public string Name { get; set; }
        public string CompanyName { get; set; }
        public string ProfileImageUri { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
    }
}
