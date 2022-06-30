namespace ContactsAPI.Models
{
    public class AddContactModel
    {
        public string ContactName { get; set; }

        public string ContactAddress { get; set; }

        public string ContactPhone { get; set; }

        public int CityID { get; set; }
    }
}
