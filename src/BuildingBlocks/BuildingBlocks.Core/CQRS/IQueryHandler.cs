namespace BuildingBlocks.Core.CQRS;

public interface IQueryHandler<in TQuery, TResponse>
    : IConsumer<TQuery>
    where TQuery : class, IQuery<TResponse>
    where TResponse : class
{
}
