using AddressBook.Common.Models;
using AddressBook.Common.Models.Contact;

namespace AddressBook.Common.Interfaces;

public interface IContactsService
{
    Task<ContactResponseModel> Add(ContactRequestModel model);
    Task<ContactResponseModel?> GetLast();
    Task<ContactResponseModel?> GetById(int id);
    Task<IEnumerable<ContactResponseModel>> GetPaginatedByCity(PaginationParameters paginationParameters, string city);
}