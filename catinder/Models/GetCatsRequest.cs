using System.ComponentModel.DataAnnotations;

namespace catinder.Models
{
    public class GetCatsRequest
    {
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        public int Page { get; set; } = 1;
    }      
}