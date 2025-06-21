namespace CustomerFlow.Core.Application.Features.Customers.Commands.VerifyEmail;

public record VerifyEmailCommand(
    int CustomerId,
    string Code
) : ICommand;

public class VerifyEmailQueryValidator : AbstractValidator<VerifyEmailCommand>
{
    public VerifyEmailQueryValidator()
    {
        RuleFor(x => x.CustomerId)
            .GreaterThan(0).WithMessage("Customer ID must be greater than 0.");

        RuleFor(x => x.Code)
            .NotNull().NotEmpty().WithMessage("Verification code is required.");
    }
}
