using AddressBook.Common.Entities;
using AddressBook.Common.Models.Contact;
using AutoMapper;

namespace AddressBook.Core.Mappers;

public class ContactProfile : Profile
{
    public ContactProfile()
    {
        CreateMap<ContactRequestModel, Contact>();
        CreateMap<Contact, ContactResponseModel>();
    }
}
