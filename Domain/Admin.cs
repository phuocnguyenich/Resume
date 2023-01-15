using System.ComponentModel.DataAnnotations;

namespace ResumeMindX.Domain
{
    public class Admin
    {
        [Key]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
