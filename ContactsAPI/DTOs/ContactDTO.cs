using ContactsAPI.Validations;

namespace ContactsAPI.Models
{
    public class ContactDTO
    {
        public string ContactName { get; set; }

        public string ContactAddress { get; set; }

        [PhoneValidation]
        public string ContactPhone { get; set; }

        public int CityID { get; set; }
    }
}
