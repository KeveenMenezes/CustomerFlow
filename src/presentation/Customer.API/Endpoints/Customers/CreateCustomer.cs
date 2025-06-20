namespace CustomerFlow.Presentation.API.Endpoints.Customers;

public record CreateCustomerRequest(
    string Email,
    string Password,
    string State,
    int PartnerId,
    bool UsePartner,
    string UtmSource,
    string? CustomerToken,
    string? ReferralCode,
    string? BrowserFingerprint
);

public record CreateCustomerResponse(
    int CustomerId
);

public static class CreateCustomerEndpoint
{
    public static void MapEndpoint(this WebApplication app)
    {
        app.MapPost("/api/v1/customer", CreateCustomer);
    }

    public static async Task<Results<Ok<CreateCustomerResponse>, ProblemHttpResult>> CreateCustomer(
        CreateCustomerRequest request,
        IMediator mediator)
    {
        var command = request.Adapt<CreateCustomerCommand>();

        var result = await mediator.SendRequest(command);

        var response = result.Adapt<CreateCustomerResponse>();

        return TypedResults.Ok(response);
    }
}
