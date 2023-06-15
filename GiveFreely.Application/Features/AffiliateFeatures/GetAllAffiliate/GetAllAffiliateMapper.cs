using AutoMapper;
using GiveFreely.Domain.Entities;

namespace GiveFreely.Application.Features.AffiliateFeatures.GetAllAffiliate;

public sealed class GetAllAffiliateMapper: Profile
{
    public GetAllAffiliateMapper()
    {
        CreateMap<Affiliate, GetAllAffiliateResponse>();
    }
}