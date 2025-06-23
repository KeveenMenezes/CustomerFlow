using CustomerFlow.Core.Application.Features.Customers.Commands.VerifyEmail;

namespace CustomerFlow.Presentation.API.Endpoints.VerifyEmail;

public record VerifyEmailRequest(int CustomerId, string Code);

public static class VerifyEmailEndpoint
{
    public static void MapVerifyEmailEndpoint(this WebApplication app)
    {
        app.MapPost("/api/v1/verifyemail", VerifyEmail)
            .WithName("VerifyEmail")
            .WithTags("Customer")
            .Produces(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Verifies the email for a given customer using the provided code.")
            .WithDescription("This endpoint allows a customer to verify their email address by providing the customer ID and the verification code sent to them.");
    }

    public static async Task<Results<Ok, ProblemHttpResult>> VerifyEmail(
        VerifyEmailRequest request,
        ISender sender)
    {
        var command = new VerifyEmailCommand(request.CustomerId, request.Code);
        await sender.Send(command);

        return TypedResults.Ok();
    }
}
