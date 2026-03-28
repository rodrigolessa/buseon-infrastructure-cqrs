using Buseon.Infrastructure.Abstractions;

namespace Buseon.Infrastructure.CQRS.Queries;

public interface IMyQueryBus
{
    Task<TResponse> Send<TQuery, TResponse>(
        TQuery query,
        CancellationToken cancellationToken = default)
        where TQuery : IMyQuery<TResponse>;

    Task<PagedResult<TResponse>> SendPagedQuery<TQuery, TResponse>(
        TQuery query,
        CancellationToken cancellationToken = default)
        where TQuery : PagedQuery<TResponse> where TResponse : class;

    Task<PagedResult<TResponse>> SendOrderedPagedQuery<TQuery, TResponse>(
        TQuery query,
        CancellationToken cancellationToken = default)
        where TQuery : OrderedPagedQuery<TResponse> where TResponse : class;   
}