using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCWebProjectBLL.DTO
{
    public class PersonDTO
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string Title { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public string Comments { get; set; }
    }
}
