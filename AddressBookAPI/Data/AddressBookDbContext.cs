using AddressBookAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AddressBookAPI.Data
{
    public class AddressBookDbContext : DbContext
    {
        public AddressBookDbContext(DbContextOptions<AddressBookDbContext> options) : base(options) { 
        
        }

        public DbSet<Person> People { get; set; }
    }
}
