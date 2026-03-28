using System.Linq.Expressions;

namespace Buseon.Infrastructure.CQRS.Queries;

public class MyOrderedPagedQuery<T> : MyPagedQuery<T> where T : class
{
    public Expression<Func<T, object>> SortingCriteria { get; set; }
}