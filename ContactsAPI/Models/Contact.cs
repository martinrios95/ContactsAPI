namespace ContactsAPI.Models
{
    public class Contact
    {
        public Guid ContactID { get; set; }

        public string ContactName { get; set; }

        public string ContactAddress { get; set; }

        public string ContactPhone { get; set; }

        public int CityID { get; set; }
    }
}
