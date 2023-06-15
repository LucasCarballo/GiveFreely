using AutoMapper;
using GiveFreely.Domain.Entities;

namespace GiveFreely.Application.Features.CustomerFeatures.CreateCustomer;

public sealed class CreateCustomerMapper: Profile
{
    public CreateCustomerMapper()
    {
        CreateMap<CreateCustomerRequest, Customer>();
        CreateMap<Customer, CreateCustomerResponse>();
    }
}