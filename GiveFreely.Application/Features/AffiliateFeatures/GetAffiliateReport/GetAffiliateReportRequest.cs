using MediatR;

namespace GiveFreely.Application.Features.AffiliateFeatures.GetAffiliateReport;

public sealed record GetAffiliateReportRequest(Guid AffiliateId): IRequest<GetAffiliateReportResponse>;