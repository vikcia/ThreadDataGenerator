using ThreadDataGenerator.Interfaces;

namespace ThreadDataGenerator;

public class FakeDispatcherWrapper : IDispatcherWrapper
{
    public Task InvokeAsync(Action callback)
    {
        callback();
        return Task.Delay(1);
    }
}