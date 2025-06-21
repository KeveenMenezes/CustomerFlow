using CustomerFlow.Core.Application.Features.Customers.Commands.CreateCustomer;

namespace CustomerFlow.Presentation.API.Endpoints.Customers;

public record CreateCustomerRequest(
    string FirstName,
    string LastName,
    string Email,
    string Password,
    string PhoneNumber,
    string Address,
    string City,
    string State,
    string ZipCode,
    string Country
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
        ISender sender)
    {
        var command = request.Adapt<CreateCustomerCommand>();

        var result = await sender.Send(command);

        var response = result.Adapt<CreateCustomerResponse>();

        return TypedResults.Ok(response);
    }
}
