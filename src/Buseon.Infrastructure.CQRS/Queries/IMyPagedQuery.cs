namespace Buseon.Infrastructure.CQRS.Queries;

public interface IMyPagedQuery<T> where T : class
{
    ISpecification<T> Specification { get; set; }
    int PageSize { get; set; }
    int PageNumber { get; set; }
}