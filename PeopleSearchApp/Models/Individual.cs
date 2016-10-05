using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PeopleSearchApp.Models
{
    public class Individual
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public string Interests { get; set; }
        public string Picture { get; set; }
    }
}