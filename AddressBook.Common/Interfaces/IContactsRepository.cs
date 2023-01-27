using AddressBook.Common.Entities;
using AddressBook.Common.Models;

namespace AddressBook.Common.Interfaces;

public interface IContactsRepository
{
    Task<int> Add(Contact contact);
    Task<Contact?> GetLastAdded();
    Task<Contact?> GetById(int id);
    Task<IEnumerable<Contact>> GetPaginatedByCity(PaginationParameters paginationParameters ,string city);
    Task<bool> PhoneExists(string phoneNumber);
}