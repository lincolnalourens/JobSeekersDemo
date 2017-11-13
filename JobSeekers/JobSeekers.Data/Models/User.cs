using System;
using System.Collections.Generic;
using System.Text;

namespace JobSeekers.Data.Models
{
    public class User
    {
        public long Id { get; set; }
        public string Email { get; set; }
        public long ProfileId { get; set; }
        public Profile Profile { get; set; }
    }
}
