namespace AddressBook.Common.Models;
public class PaginationParameters
{
    const int _maxPageSize = 100;
    public int PageNumber { get; set; } = 1;
    private int _pageSize = 10;
    public int PageSize
    {
        get
        {
            return _pageSize;
        }
        set
        {
            _pageSize = (value > _maxPageSize) ? _maxPageSize : value;
        }
    }
}
