using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JobSeekers.API.Models
{
    public class Profile
    {
        public Profile()
        {
            Skills = new List<string>();
            WorkHistory = new List<Position>();
        }

        [Required]
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        [Required]
        public string LastName { get; set; }

        public List<string> Skills { get; set; }
        
        public ICollection<Position> WorkHistory { get; set; }
    }
}
