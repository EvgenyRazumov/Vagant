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

        public DbSet<Location> Locations { get; set; }

        public DbSet<Event> Events { get; set; }

        public DbSet<EventComment> EventComments { get; set; }

        public DbSet<Message> Messages { get; set; }

        public DbSet<EventImage> EventImages { get; set; }

        public DbSet<Visitor> Visitors { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<EventImage>()
            .HasRequired(c => c.ImageFile)
            .WithMany()
            .WillCascadeOnDelete(false);

            modelBuilder.Entity<EventImage>()
                .HasRequired(s => s.Event)
                .WithMany()
                .WillCascadeOnDelete(false);
        }
    }
}
