namespace BookingWeb.Server.ViewModels;

public class PagedList<T>
{
    public List<T> Items { get; set; } = new List<T>();
    public int CurrentPage { get; set; } 
    public int TotalPages { get; set; }
    
    public PagedList(){}
    
    public PagedList(List<T> items, int currentPage, int totalPages)
    {
        Items = items;
        CurrentPage = currentPage;
        TotalPages = totalPages;
    }
}

