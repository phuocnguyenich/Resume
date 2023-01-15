using System.ComponentModel.DataAnnotations;

namespace ResumeMindX.Domain
{
    public class Resume
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Github { get; set; }
        public string Linkedin { get; set; }
        public string ShortDescription { get; set; }
        public string JobTitle { get; set; }
        public string Company { get; set; }
        public string Period { get; set; }
        public string JobDescription { get; set; }
        public string University { get; set; }
        public string Faculty { get; set; }
        public double GPA { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
