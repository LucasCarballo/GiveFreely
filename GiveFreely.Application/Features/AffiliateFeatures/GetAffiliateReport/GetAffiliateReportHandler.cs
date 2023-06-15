using GiveFreely.Application.Repositories;
using MediatR;

namespace GiveFreely.Application.Features.AffiliateFeatures.GetAffiliateReport;

public sealed class GetAffiliateReportHandler: IRequestHandler<GetAffiliateReportRequest, GetAffiliateReportResponse>
{
    private readonly ICustomerRepository _customerRepository;    
    
    public GetAffiliateReportHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<GetAffiliateReportResponse> Handle(GetAffiliateReportRequest request, CancellationToken cancellationToken)
    {
        var customersCount = await _customerRepository.CountByAffiliateId(request.AffiliateId, cancellationToken);
        return new GetAffiliateReportResponse(customersCount);
    }
}