namespace CustomerFlow.BuildingBlocks.Core.CQRS;

public interface ICommand
    : ICommand<Unit>
{
}

public interface ICommand<out TResult>
    : Request<TResult>
    where TResult : class
{
}
