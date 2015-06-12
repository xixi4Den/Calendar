using System.Data.Entity;
using Calendar.Entities;
using Calendar.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Calendar.DataAccess
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Event> Events { get; set; } 

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}