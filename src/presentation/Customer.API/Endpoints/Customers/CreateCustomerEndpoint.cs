using Microsoft.AspNetCore.Http.HttpResults;

namespace Customer.API.Endpoints.Customers;

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
        CreateCustomerRequest request)
    {
        var customerId = 1;
        await Task.Delay(100); // Simulate async operation
        return TypedResults.Ok(new CreateCustomerResponse(customerId));
    }
}
