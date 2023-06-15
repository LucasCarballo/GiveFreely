using AutoMapper;
using GiveFreely.Domain.Entities;

namespace GiveFreely.Application.Features.AffiliateFeatures.CreateAffiliate;

public sealed class CreateAffiliateMapper: Profile
{
    public CreateAffiliateMapper()
    {
        CreateMap<CreateAffiliateRequest, Affiliate>();
        CreateMap<Affiliate, CreateAffiliateResponse>();
    }
}