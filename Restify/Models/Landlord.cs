using System.ComponentModel.DataAnnotations;

namespace Restify.Models
{
    public class Landlord
    {
        [Key]
        public int landlord_id { get; set; }
        [Required]
        public string? landlord_first_name { get; set; }
        public string? landlord_last_name { get; set; }
        public string? landlord_email { get; set; }
        public string? landlord_contact { get; set; }
        public string? landlord_password { get; set; }
    }
}
