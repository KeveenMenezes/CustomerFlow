namespace BuildingBlocks.Core.CQRS;

public interface ICommandHandler<in TCommand>
    : ICommandHandler<TCommand, Unit>
    where TCommand : class, ICommand<Unit>
{
}

public interface ICommandHandler<in TCommand, TResponse>
    : IConsumer<TCommand>
    where TCommand : class, ICommand<TResponse>
    where TResponse : class
{
}
