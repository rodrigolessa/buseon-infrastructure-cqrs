using System.Linq.Expressions;
using System.Reflection;

namespace Buseon.Infrastructure.Mediator;

public static class MyHandlerCompiler
{
    public static MyRequestHandlerDelegate Compile(
        object handler,
        MethodInfo method,
        Type requestType)
    {
        var requestParam = Expression.Parameter(typeof(object), "request");
        var ctParam = Expression.Parameter(typeof(CancellationToken), "ct");

        var handlerConst = Expression.Constant(handler);

        var castRequest = Expression.Convert(requestParam, requestType);

        var call = Expression.Call(
            handlerConst,
            method,
            castRequest,
            ctParam);

        var castResult = Expression.Convert(call, typeof(Task<object>));

        var lambda = Expression.Lambda<MyRequestHandlerDelegate>(
            castResult,
            requestParam,
            ctParam);

        return lambda.Compile();
    }
}