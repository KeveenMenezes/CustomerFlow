namespace BuildingBlocks.Core.CQRS;

public interface IQuery<out TResponse>
    : Request<TResponse>
    where TResponse : class
{
}
