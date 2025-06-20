namespace CustomerFlow.Core.Application.Features.Customer.Commands.CreateCustomer;

public record CreateCustomerCommand(
    string Email,
    string Password,
    string State,
    int PartnerId,
    bool UsePartner,
    string UtmSource,
    string? CustomerToken,
    string? ReferralCode,
    string? BrowserFingerprint
) : ICommand<CreateCustomerResult>;

public record CreateCustomerResult(
    int CustomerId
);

public class CreateCustomerCommandValidator
    : AbstractValidator<CreateCustomerCommand>
{
    public CreateCustomerCommandValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Invalid email format.");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required.")
            .Matches("[0-9]").WithMessage("Password must contain at least one number.");

        RuleFor(x => x.State)
            .NotEmpty().WithMessage("State is required.")
            .Length(2).WithMessage("State must be exactly 2 characters long.");

        RuleFor(x => x.BrowserFingerprint)
            .NotEmpty().WithMessage("Browser fingerprint is required.");
    }
}
