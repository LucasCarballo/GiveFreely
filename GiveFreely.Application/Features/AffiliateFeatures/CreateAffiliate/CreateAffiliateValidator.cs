using FluentValidation;

namespace GiveFreely.Application.Features.AffiliateFeatures.CreateAffiliate;

public sealed class CreateAffiliateValidator: AbstractValidator<CreateAffiliateRequest>
{
    public CreateAffiliateValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MinimumLength(3).MaximumLength(100);
    }
}