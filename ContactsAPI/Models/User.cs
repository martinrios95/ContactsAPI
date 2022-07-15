using System.ComponentModel.DataAnnotations;

namespace ContactsAPI.Models
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
