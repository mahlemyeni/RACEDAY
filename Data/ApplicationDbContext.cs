using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace RaceDay.Data
{
   public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            //Optional: store as a string
            builder.Entity<ApplicationUser>()
                    .Property(u => u.Gender)
                    .HasConversion<string>()
                    .HasMaxLength(20);
        }
   }
}
