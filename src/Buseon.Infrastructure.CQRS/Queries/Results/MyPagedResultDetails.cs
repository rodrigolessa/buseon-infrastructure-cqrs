namespace Buseon.Infrastructure.CQRS.Queries.Results;

public class MyPagedResultDetails
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public int PageCount { get; set; }
    public long TotalRecords { get; set; }

    public MyPagedResultDetails()
    {
    }

    public MyPagedResultDetails(int pageNumber, int pageSize, long totalRecords)
    {
        PageNumber = pageNumber;
        PageSize = pageSize;
        PageCount = (int)Math.Ceiling((double)totalRecords / pageSize);
        TotalRecords = totalRecords;
    }
}