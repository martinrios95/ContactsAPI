using System.ComponentModel.DataAnnotations;

namespace ContactsAPI.Models
{
    public class StateDTO
    {
        [Required]
        public string StateName { get; set; }
    }
}
