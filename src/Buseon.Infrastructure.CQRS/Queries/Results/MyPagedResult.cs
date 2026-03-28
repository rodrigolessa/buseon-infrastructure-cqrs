namespace Buseon.Infrastructure.CQRS.Queries.Results;

public class MyPagedResult<T> : IMyPagedResult where T : class
{
    private IEnumerable<T> Records { get; set; }
    private MyPagedResultDetails PageDetails { get; set; }
    
    public MyPagedResult(IEnumerable<T> records)
    {
        Records = records;
        PageDetails = new MyPagedResultDetails();
    }

    public IEnumerable GetRecords()
    {
        return Records;
    }

    public MyPagedResultDetails GetPagination()
    {
        return PageDetails;
    }
}