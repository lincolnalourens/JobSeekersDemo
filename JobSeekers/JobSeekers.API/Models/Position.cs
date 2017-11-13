namespace JobSeekers.API.Models
{
    public class Position
    {
        public string Title { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string EmployerName { get; set; }
        public string Description { get; set; }
        public Location Location { get; set; }
    }
}
