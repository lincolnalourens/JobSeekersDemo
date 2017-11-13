using System.Collections.Generic;

namespace JobSeekers.Data.Models
{
    public class Profile
    {
        public Profile()
        {
            WorkHistory = new List<Position>();
        }

        public long Id { get; set; }

        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }

        public string Skills { get; set; }

        public ICollection<Position> WorkHistory { get; set; }

    }
}
