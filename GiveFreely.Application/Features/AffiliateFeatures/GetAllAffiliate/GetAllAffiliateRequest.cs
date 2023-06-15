using MediatR;

namespace GiveFreely.Application.Features.AffiliateFeatures.GetAllAffiliate;

public sealed record GetAllAffiliateRequest: IRequest<List<GetAllAffiliateResponse>>;