using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ResumeMindX.Domain
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public ICollection<Resume> Resumes { get; set; } = new List<Resume>();
    }
}
