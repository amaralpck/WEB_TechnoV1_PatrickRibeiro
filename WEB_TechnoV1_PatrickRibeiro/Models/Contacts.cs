using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEB_TechnoV1_PatrickRibeiro.Models
{
    public class Contacts
    {
        public int id { get; set; }

        public string fullname { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }

        public string password { get; set; }
        public string adress { get; set; }

        public string email { get; set; }

        public string mobilePhone { get; set; }
    }
}
