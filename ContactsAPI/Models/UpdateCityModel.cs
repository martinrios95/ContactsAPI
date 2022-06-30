namespace ContactsAPI.Models
{
    public class UpdateCityModel
    {
        public string CityName { get; set; }

        public int StateID { get; set; }

        public State CityState { get; set; }
    }
}
