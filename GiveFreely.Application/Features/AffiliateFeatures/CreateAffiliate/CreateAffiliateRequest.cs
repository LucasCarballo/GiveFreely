using MediatR;

namespace GiveFreely.Application.Features.AffiliateFeatures.CreateAffiliate;

public sealed record CreateAffiliateRequest(string Name): IRequest<CreateAffiliateResponse>;