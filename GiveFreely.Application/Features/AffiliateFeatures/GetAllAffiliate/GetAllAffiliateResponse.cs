namespace GiveFreely.Application.Features.AffiliateFeatures.GetAllAffiliate;

public sealed record GetAllAffiliateResponse
{
    public Guid Id {get;set;}
    public string? Name {get;set;}
}