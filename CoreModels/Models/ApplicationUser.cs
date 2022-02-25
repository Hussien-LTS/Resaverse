using Microsoft.AspNetCore.Identity;

namespace CoreModels.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Avatar { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
