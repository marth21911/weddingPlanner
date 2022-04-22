using Microsoft.EntityFrameworkCore;
namespace weddingPlanner.Models
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options) : base(options) {} 
        public DbSet<User> Users {get;set;}
        public DbSet<Wedding> Weddings {get;set;}
        public DbSet<Event> SharedEvent {get;set;}
    }

}