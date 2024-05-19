using System.Windows.Threading;
using ThreadDataGenerator.Interfaces;

namespace ThreadDataGenerator;

public class DispatcherWrapper : IDispatcherWrapper
{
    private Dispatcher _dispatcher;

    public DispatcherWrapper(Dispatcher dispatcher)
    {
        if (dispatcher == null)
        {
            throw new ArgumentNullException(nameof(dispatcher));
        }
        _dispatcher = dispatcher;
    }
    public Task InvokeAsync(Action callback)
    {
        return _dispatcher.InvokeAsync(callback).Task;
    }
}
