using MediatR;

namespace GiveFreely.Application.Features.CustomerFeatures.CreateCustomer;

public sealed record CreateCustomerRequest(string Name, Guid AffiliateId): IRequest<CreateCustomerResponse>;