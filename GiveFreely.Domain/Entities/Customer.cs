using GiveFreely.Domain.Common;

namespace GiveFreely.Domain.Entities;

public sealed class Customer : BaseEntity
{
    public string? Name {get;set;}

    public Guid AffiliateId {get;set;}
}
