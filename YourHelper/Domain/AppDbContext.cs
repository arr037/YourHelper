using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using YourHelper.Models;

namespace YourHelper.Domain
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<PersonalAccount> PersonalAccounts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<PersonalAccount>()
                .HasOne<AppUser>(a => a.AppUser)
                .WithMany(d => d.PersonalAccounts)
                .HasForeignKey(d => d.AppUserId);

           
          


            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "FC4B237A-E1F0-4EE0-9A71-667FD15D3370",
                Name = "Admin",
                NormalizedName = "ADMIN",

            });

            builder.Entity<AppUser>().HasData(new AppUser
            {
                Id = "9FE2BC2C-82E6-4724-9F08-B8B6B279662D",
                UserName = "Ruslan",
                NormalizedUserName = "RUSLAN",
                Email = "arr073099@mail.ru",
                NormalizedEmail = "ARR073099@MAIL.RU",
                EmailConfirmed = true,
                PasswordHash = new PasswordHasher<AppUser>().HashPassword(null, "123456"),
                SecurityStamp = string.Empty
            });

            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                UserId = "9FE2BC2C-82E6-4724-9F08-B8B6B279662D",
                RoleId = "FC4B237A-E1F0-4EE0-9A71-667FD15D3370"
            });
        }
    }
}
