using Microsoft.Build.Framework;


namespace LexiconUniversity.Web.Models
{
#nullable disable
    public class StudentCreateViewModel
    {
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public string AddressStreet { get; set; }
        public string AddressZipCode { get; set; }
        public string AddressCity { get; set; }
    }
}
