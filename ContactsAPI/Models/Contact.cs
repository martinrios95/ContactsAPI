using ContactsAPI.Validations;
using System.ComponentModel.DataAnnotations;

namespace ContactsAPI.Models
{
    public class Contact
    {
        [Key]
        public Guid ContactID { get; set; } = Guid.NewGuid();

        [Required]
        public string ContactName { get; set; }

        public string ContactAddress { get; set; }

        [PhoneValidation]
        public string ContactPhone { get; set; }

        public int CityID { get; set; }
    }
}
