namespace CustomerFlow.BuildingBlocks.Core.CQRS;

public interface IQueryStream<out TResponse> : IStreamRequest<TResponse>
    where TResponse : notnull
{
}
