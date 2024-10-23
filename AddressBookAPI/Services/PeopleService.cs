using AddressBookAPI.Data;
using AddressBookAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AddressBookAPI.Services
{
    public class PeopleService : IPeopleService
    {
        private readonly AddressBookDbContext _context;

        public PeopleService(AddressBookDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Person>> GetPeopleAsync()
        {
            return await _context.People.ToListAsync();
        }

        public async Task<Person?> GetPersonByIdAsync(int id)
        {
            return await _context.People.FindAsync(id);
        }

    }
}
