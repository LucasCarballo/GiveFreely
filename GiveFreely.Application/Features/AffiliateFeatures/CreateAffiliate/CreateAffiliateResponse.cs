namespace GiveFreely.Application.Features.AffiliateFeatures.CreateAffiliate;

public sealed record CreateAffiliateResponse
{
    public Guid Id {get;set;}
    public string? Name {get;set;}
}