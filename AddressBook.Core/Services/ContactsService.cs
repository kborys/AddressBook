using AddressBook.Common.Entities;
using AddressBook.Common.Interfaces;
using AddressBook.Common.Models;
using AddressBook.Common.Models.Contact;
using AddressBook.Common.Models.Exception;
using AutoMapper;

namespace AddressBook.Core.Services;

internal class ContactsService : IContactsService
{
    private readonly IContactsRepository _contactsRepository;
    private readonly IMapper _mapper;

    public ContactsService(IContactsRepository contactsRepository, IMapper mapper)
    {
        _contactsRepository = contactsRepository;
        _mapper = mapper;
    }
    public async Task<ContactResponseModel> Add(ContactRequestModel model)
    {
        var phoneExists = await _contactsRepository.PhoneExists(model.PhoneNumber);
        if (phoneExists)
            throw new AlreadyExistsException("Contact with given phone number already exists");

        var contact = _mapper.Map<Contact>(model);
        contact.Id = await _contactsRepository.Add(contact);
        var responseModel = _mapper.Map<ContactResponseModel>(contact);
        return responseModel;
    }

    public async Task<ContactResponseModel?> GetLast()
    {
        var contact = await _contactsRepository.GetLastAdded();
        if (contact is null)
            return null;

        var responseModel = _mapper.Map<ContactResponseModel>(contact);
        return responseModel;
    }

    public async Task<ContactResponseModel?> GetById(int id)
    {
        var contact = await _contactsRepository.GetById(id);
        if (contact is null)
            return null;

        var responseModel = _mapper.Map<ContactResponseModel>(contact);
        return responseModel;
    }

    public async Task<IEnumerable<ContactResponseModel>> GetPaginatedByCity(PaginationParameters paginationParameters, string city)
    {
        var contacts = await _contactsRepository.GetPaginatedByCity(paginationParameters, city);
        var responseModel = _mapper.Map<IEnumerable<ContactResponseModel>>(contacts);
        return responseModel;
    }


}