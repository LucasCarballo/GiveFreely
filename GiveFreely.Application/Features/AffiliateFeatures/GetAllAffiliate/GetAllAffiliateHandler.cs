using AutoMapper;
using GiveFreely.Application.Repositories;
using MediatR;

namespace GiveFreely.Application.Features.AffiliateFeatures.GetAllAffiliate;

public sealed class GetAllAffiliateHandler: IRequestHandler<GetAllAffiliateRequest, List<GetAllAffiliateResponse>>
{
    private readonly IAffiliateRepository _affiliateRepository;
    private readonly IMapper _mapper;

    public GetAllAffiliateHandler(IAffiliateRepository affiliateRepository, IMapper mapper)
    {
        _affiliateRepository = affiliateRepository;
        _mapper = mapper;
    }

    public async Task<List<GetAllAffiliateResponse>> Handle(GetAllAffiliateRequest request, CancellationToken cancellationToken)
    {
        var affiliates = await _affiliateRepository.GetAll(cancellationToken);
        return _mapper.Map<List<GetAllAffiliateResponse>>(affiliates);
    }
}