using AutoMapper;
using GiveFreely.Domain.Entities;

namespace GiveFreely.Application.Features.CustomerFeatures.GetAllCustomerByAffiliate;

public sealed class GetAllCustomerByAffiliateMapper: Profile
{
    public GetAllCustomerByAffiliateMapper()
    {
        CreateMap<Customer, GetAllCustomerByAffiliateResponse>();
    }
}