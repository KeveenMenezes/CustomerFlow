namespace CustomerFlow.Presentation.API.Configuration;

public interface IEndpoint
{
    static abstract void MapEndpoint(WebApplication app);
}
