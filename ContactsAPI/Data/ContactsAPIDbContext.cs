using ContactsAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactsAPI.Data
{
    public class ContactsAPIDbContext : DbContext
    {
        public ContactsAPIDbContext(DbContextOptions<ContactsAPIDbContext> options) : base(options)
        {
            // Only on any SQL-based DB --> It's like "CREATE TABLE IF NOT EXISTS"
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            new DbInitializer(builder).Seed();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<State> States { get; set; }
    }
}
