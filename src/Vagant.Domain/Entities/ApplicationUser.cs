using Microsoft.AspNet.Identity.EntityFramework;

namespace Vagant.Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public virtual ImageFile Avatar { get; set; }

        public virtual UserContactInfo ContactInfo { get; set; }
    }
}
