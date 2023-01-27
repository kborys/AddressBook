namespace AddressBook.Common.Entities;

public class Contact
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    public string Zip { get; set; }
    public string PhoneNumber { get; set; }
}