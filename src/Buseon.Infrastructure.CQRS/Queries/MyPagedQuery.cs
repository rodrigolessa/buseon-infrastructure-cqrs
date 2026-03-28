namespace Buseon.Infrastructure.CQRS.Queries;

public class MyPagedQuery<T> : IMyPagedQuery<T>, IMyQuery<MyPagedResult<T>> where T : class
{
    public ISpecification<T> Specification { get; set; }
    public int PageSize { get; set; }
    public int PageNumber { get; set; }
}