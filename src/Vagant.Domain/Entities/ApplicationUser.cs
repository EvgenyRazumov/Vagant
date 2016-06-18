using Microsoft.AspNet.Identity.EntityFramework;

namespace Vagant.Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public virtual ImageFile Avatar { get; set; }

        public virtual UserContactInfo ContactInfo { get; set; }
    }
}
