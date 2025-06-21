using CustomerFlow.Core.Application.Features.Customers.Commands.VerifyEmail;

namespace CustomerFlow.Presentation.API.Endpoints.VerifyEmail;

public record VerifyEmailRequest(int CustomerId, string Code);

public static class VerifyEmailEndpoint
{
    public static void MapEndpoint(this WebApplication app)
    {
        app.MapPost("/api/v1/verifyemail", CreateCustomer);
    }

    public static async Task<Results<Ok, ProblemHttpResult>> CreateCustomer(
        VerifyEmailRequest request,
        ISender sender)
    {
        var command = new VerifyEmailCommand(request.CustomerId, request.Code);

        await sender.Send(command);

        return TypedResults.Ok();
    }
}
