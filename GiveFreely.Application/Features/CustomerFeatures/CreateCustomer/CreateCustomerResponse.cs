namespace GiveFreely.Application.Features.CustomerFeatures.CreateCustomer;

public sealed record CreateCustomerResponse
{
    public Guid Id {get;set;}
    public string? Name {get;set;}
    public Guid AffiliateId{get;set;}
}