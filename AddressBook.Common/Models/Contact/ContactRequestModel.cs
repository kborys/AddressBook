using System.ComponentModel.DataAnnotations;

namespace AddressBook.Common.Models.Contact;

public class ContactRequestModel
{
    [Required]
    public string Name { get; set; }
    [Required]
    public string Address { get; set; }
    [Required]
    public string City { get; set; }
    [Required]
    public string Country { get; set; }
    [Required]
    public string Zip { get; set; }
    [Required]
    [Phone]
    public string PhoneNumber { get; set; }
}