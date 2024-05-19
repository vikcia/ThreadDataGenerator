namespace ThreadDataGenerator.Interfaces;

public interface IDispatcherWrapper
{
    Task InvokeAsync(Action callback);
}