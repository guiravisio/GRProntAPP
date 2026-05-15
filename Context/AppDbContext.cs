using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using GRProntAPP.Models;

namespace GRProntAPP.Context
{
    public class AppDbContext : IdentityDbContext<UserProfile>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Patient> Patients { get; set; }
    }
}
