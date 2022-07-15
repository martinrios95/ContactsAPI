using System.ComponentModel.DataAnnotations;

namespace ContactsAPI.DTOs
{
    public class UserDTO
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
