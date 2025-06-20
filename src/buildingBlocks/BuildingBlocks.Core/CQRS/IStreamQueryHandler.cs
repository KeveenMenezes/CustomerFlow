namespace CustomerFlow.BuildingBlocks.Core.CQRS;

public interface IStreamQueryHandler<in TQueryStream, TResponse>
    : IStreamRequestHandler<TQueryStream, TResponse>
    where TQueryStream : IQueryStream<TResponse>
    where TResponse : notnull
{
}
