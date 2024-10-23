using AddressBookAPI.Models;

namespace AddressBookAPI.Services
{
    public interface IPeopleService
    {
        Task<IEnumerable<Person>> GetPeopleAsync();
        Task<Person?> GetPersonByIdAsync(int id);
    }
}
