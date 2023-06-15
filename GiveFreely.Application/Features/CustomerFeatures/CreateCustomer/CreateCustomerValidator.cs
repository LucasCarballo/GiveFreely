using FluentValidation;

namespace GiveFreely.Application.Features.CustomerFeatures.CreateCustomer;

public sealed class CreateCustomerValidator: AbstractValidator<CreateCustomerRequest>
{
    public CreateCustomerValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MinimumLength(3).MaximumLength(100);
        RuleFor(x => x.AffiliateId).NotEmpty();
    }
}