namespace Buseon.Infrastructure.Mediator.Registration;

public sealed class MyHandlerRegistry
{
    private readonly Dictionary<Type, MyRequestHandlerDelegate> _handlers = new();

    public void Register(Type requestType, MyRequestHandlerDelegate handler)
    {
        _handlers[requestType] = handler;
    }

    public MyRequestHandlerDelegate Get(Type requestType)
    {
        return _handlers[requestType];
    }
}