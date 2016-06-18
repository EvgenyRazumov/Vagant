using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using Vagant.Domain.Entities;

namespace Vagant.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        { }

        public DbSet<ImageFile> ImageFiles { get; set; }

        public DbSet<UserContactInfo> UserContactInfos { get; set; }
    }
}
