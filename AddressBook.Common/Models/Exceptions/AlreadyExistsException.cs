namespace AddressBook.Common.Models.Exception;
public class AlreadyExistsException : System.Exception
{
    public AlreadyExistsException(string message) : base(message)
    {

    }
}
