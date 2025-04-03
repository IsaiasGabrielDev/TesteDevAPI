namespace Core.Abstraction;

public interface IFunctionHandler<TDelegate>
    where TDelegate : Delegate
{
    TDelegate HandlerFunction { get; }
}
