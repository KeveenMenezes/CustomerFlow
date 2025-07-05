using CustomerFlow.Core.Application.Features.Customers.Queries.GetCustomers;

namespace CustomerFlow.Presentation.API.Endpoints.Customers;

public record GetCustomersResponse(
    IEnumerable<GetCustomerResponse> Customers
);

public record GetCustomerResponse(
    int Id,
    string FirstName,
    string LastName,
    string Email,
    string PhoneNumber,
    string Address,
    string City,
    string State,
    string ZipCode,
    string Country
);

public class GetCustomersEndpoint : IEndpoint
{
    public static void MapEndpoint(WebApplication app)
    {
        app.MapGet("/customer", CreateCustomer)
            .WithName("GetAllCustomer")
            .WithTags("Customer")
            .Produces(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Get all customers with their basic personal information, address, and contact.")
            .WithDescription("This endpoint retrieves all customers by returning their personal, address, and contact information.");
    }

    public static async Task<Results<Ok<GetCustomersResponse>, ProblemHttpResult>> CreateCustomer(
        IMediator mediator,
        CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetCustomersQuery(), cancellationToken);

        var response = result.Adapt<GetCustomersResponse>();

        return TypedResults.Ok(response);
    }
}
