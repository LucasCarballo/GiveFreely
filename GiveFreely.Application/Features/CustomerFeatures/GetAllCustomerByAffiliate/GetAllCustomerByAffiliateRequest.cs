using MediatR;

namespace GiveFreely.Application.Features.CustomerFeatures.GetAllCustomerByAffiliate;

public sealed record GetAllCustomerByAffiliateRequest(Guid AffiliateId): IRequest<List<GetAllCustomerByAffiliateResponse>>;