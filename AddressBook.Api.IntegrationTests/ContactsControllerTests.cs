using AddressBook.Common.Entities;
using AddressBook.Common.Models.Contact;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Net.Http.Json;

namespace AddressBook.Api.IntegrationTests;
public class ContactsControllerTests : IClassFixture<WebApplicationFactory<Program>>
{
    readonly HttpClient _client;
    public ContactsControllerTests(WebApplicationFactory<Program> app)
    {
        _client = app.CreateClient();
    }

    [Fact]
    public async Task GET_returnsOkWithLastAddedContact()
    {
        var response = await _client.GetAsync("/api/contacts");
        Assert.True(response.StatusCode.Equals(HttpStatusCode.OK));
    }

    [Fact]
    public async Task GET_givenExistingContactId_returnsOkWithContactWithGivenId()
    {
        int id = 0;
        var response = await _client.GetAsync($"/api/contacts/{id}");
        Assert.True(response.StatusCode.Equals(HttpStatusCode.OK));
        
        var contact = await response.Content.ReadFromJsonAsync<Contact?>();
        Assert.True(Equals(contact?.Id, id));
    }


    [Fact]
    public async Task GET_givenNonExistingContactId_returnsNotFound()
    {
        int id = -1;
        var response = await _client.GetAsync($"/api/contacts/{id}");
        Assert.True(response.StatusCode.Equals(HttpStatusCode.NotFound));
    }

    [Fact]
    public async Task POST_givenContactWithExistingPhone_returnsConflict()
    {
        var contact = new ContactRequestModel { Name = "Jan Kowalski", Address = "ul. Widok 13", City = "Rudzica", Country = "Poland", Zip = "43-394", PhoneNumber = "797566900" };
        var response = await _client.PostAsJsonAsync("/api/contacts", contact);
        Assert.True(response.StatusCode.Equals(HttpStatusCode.Conflict));
    }
}
