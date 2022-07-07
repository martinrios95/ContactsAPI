using System.ComponentModel.DataAnnotations;

namespace ContactsAPI.DTOs
{
    public class StateDTO
    {
        [Required]
        public string StateName { get; set; }
    }
}
