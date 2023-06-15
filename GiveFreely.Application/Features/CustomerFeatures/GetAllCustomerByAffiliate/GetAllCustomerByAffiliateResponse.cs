namespace GiveFreely.Application.Features.CustomerFeatures.GetAllCustomerByAffiliate;

public sealed record GetAllCustomerByAffiliateResponse
{
    public Guid Id {get;set;}
    public string? Name {get;set;}
    public Guid AffiliateId {get;set;}
}