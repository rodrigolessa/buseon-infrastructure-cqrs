using System.Linq.Expressions;
using Buseon.Infrastructure.Abstractions;

namespace Buseon.Infrastructure.CQRS.Queries.Specifications;

public interface IMySpecification<T> : IMyQuery<IEnumerable<T>>, IMyRequest<T> where T : class
{
    Expression<Func<T, bool>> SatisfiedBy();
}

// public interface ISpecification<T> : IQuery<IEnumerable<T>>, MediatR.IRequest where T : class