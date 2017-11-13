namespace JobSeekers.Data.Models
{
    public class Position
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string EmployerName { get; set; }
        public string Description { get; set; }
        public long LocationId { get; set; }
        public Location Location { get; set; }
    }
}
