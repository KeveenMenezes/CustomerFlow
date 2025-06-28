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

public class CreateCustomerEndpoint : IEndpoint
{
    public static void MapEndpoint(WebApplication app)
    {
        app.MapPost("/customer", CreateCustomer)
            .WithName("CreateCustomer")
            .WithTags("Customer")
            .Produces(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Creates a new customer with basic personal information, address, and contact.")
            .WithDescription("This endpoint creates a new customer by accepting personal, address, and contact information.");
    }

    public static async Task<Results<Ok<CreateCustomerResponse>, ProblemHttpResult>> CreateCustomer(
        CreateCustomerRequest request,
        IMediator mediator,
        CancellationToken cancellationToken)
    {
        var command = request.Adapt<CreateCustomerCommand>();

        var result = await mediator.Send(command, cancellationToken);

        var response = new CreateCustomerResponse(result.CustomerId.Value);

        return TypedResults.Ok(response);
    }
}
