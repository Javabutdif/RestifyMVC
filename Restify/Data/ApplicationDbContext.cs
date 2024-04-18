using Microsoft.EntityFrameworkCore;
using Restify.Models;


namespace Restify.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
       public DbSet<Landlord> landlords { get; set; }
    }
}
