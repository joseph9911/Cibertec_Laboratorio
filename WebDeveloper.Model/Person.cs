using System.ComponentModel.DataAnnotations;

namespace WebDeveloper.Model
{
    public class Person
    {
        public int PersonId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
    }
}
