namespace Buseon.Infrastructure.CQRS.Queries.Results;

public interface IPagedResult
{
    IEnumerable GetRecords();
    MyPagedResultDetails GetPagination();
}