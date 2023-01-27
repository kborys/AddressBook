using Microsoft.AspNetCore.Mvc;
using AddressBook.Common.Interfaces;
using AddressBook.Common.Models;
using AddressBook.Common.Models.Contact;


namespace AddressBook.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ContactsController : ControllerBase
{
    private readonly IContactsService _contactsService;

    public ContactsController(IContactsService contactsService)
    {
        _contactsService = contactsService;
    }

    [HttpPost]
    public async Task<ActionResult<ContactResponseModel>> Add(ContactRequestModel model)
    {
        var newContact = await _contactsService.Add(model);
        return CreatedAtRoute("GetContactById", new { id = newContact.Id }, newContact);
    }

    [HttpGet]
    public async Task<ActionResult<ContactResponseModel?>> GetLastAdded()
    {
        var contact = await _contactsService.GetLast();
        if (contact is null) return NotFound("No contacts added yet.");

        return Ok(contact);
    }

    [HttpGet("{id:int}", Name= "GetContactById")]
    public async Task<ActionResult<ContactResponseModel>> GetById(int id)
    {
        var contact = await _contactsService.GetById(id);
        if (contact is null) return NotFound("Contact with given id does not exist.");

        return Ok(contact);
    }

    [HttpGet("{city}")]
    public async Task<ActionResult<IEnumerable<ContactResponseModel>>> GetPaginatedByCity(string city, [FromQuery] PaginationParameters paginationParameters)
    {
        var contacts = await _contactsService.GetPaginatedByCity(paginationParameters, city);
        return Ok(contacts);
    }


}