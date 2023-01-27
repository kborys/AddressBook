using AddressBook.Common.Entities;
using AddressBook.Common.Interfaces;
using AddressBook.Common.Models;

namespace AddressBook.Infrastructure.Repositories;

internal class ContactsRepository : IContactsRepository
{
    private static int _lastId;
    private readonly List<Contact> _contacts = new()
    {
        new Contact{Id = 0, Name = "Konrad Boryś", Address = "ul. Statki 378", City = "Rudzica", Country = "Poland", Zip = "43-394", PhoneNumber = "797566900"}
    };

    public ContactsRepository()
    {
        _lastId = _contacts.Count > 0 ? _contacts.Max(contact => contact.Id) : -1;
    }

    public Task<int> Add(Contact contact)
    {
        contact.Id = AssignId();
        _contacts.Add(contact);
        return Task.FromResult(contact.Id);
    }

    public Task<Contact?> GetLastAdded()
    {
        var contact = _contacts.LastOrDefault();
        return Task.FromResult(contact);
    }

    public Task<Contact?> GetById(int id)
    {
        var contact = _contacts.FirstOrDefault(contact => contact.Id == id);

        return Task.FromResult(contact);
    }

    public Task<IEnumerable<Contact>> GetPaginatedByCity(PaginationParameters paginationParameters, string city)
    {
        var contacts = _contacts
            .Where(contact => string.Equals(contact.City.ToLower(), city.ToLower()))
            .Skip(paginationParameters.PageSize * (paginationParameters.PageNumber - 1))
            .Take(paginationParameters.PageSize);
        return Task.FromResult(contacts);
    }

    public Task<bool> PhoneExists(string phoneNumber)
    {
        if (_contacts.Count == 0)
            return Task.FromResult(false);

        var exists = _contacts.Exists(c => c.PhoneNumber == phoneNumber);
        return Task.FromResult(exists);
    }
    private static int AssignId()
    {
        return ++_lastId;
    }
}