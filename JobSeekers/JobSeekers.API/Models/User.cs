using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobSeekers.API.Models
{
    public class User
    {
        public long Id { get; set; }
        public string Email { get; set; }
        public Profile Profile { get; set; }
    }
}
