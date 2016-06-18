using Microsoft.AspNet.Identity.EntityFramework;
using Vagant.Domain.Models;

namespace Vagant.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        { }
    }
}
