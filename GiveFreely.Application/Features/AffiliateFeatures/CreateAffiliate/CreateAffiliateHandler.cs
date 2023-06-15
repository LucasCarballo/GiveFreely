using AutoMapper;
using GiveFreely.Application.Repositories;
using GiveFreely.Domain.Entities;
using MediatR;

namespace GiveFreely.Application.Features.AffiliateFeatures.CreateAffiliate;

public sealed class CreateAffiliateHandler: IRequestHandler<CreateAffiliateRequest, CreateAffiliateResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAffiliateRepository _affiliateRepository;
    private readonly IMapper _mapper;

    public CreateAffiliateHandler(IUnitOfWork unitOfWork, IAffiliateRepository affiliateRepository, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _affiliateRepository = affiliateRepository;
        _mapper = mapper;
    }

    public async Task<CreateAffiliateResponse> Handle(CreateAffiliateRequest request, CancellationToken cancellationToken)
    {
        var affiliate = _mapper.Map<Affiliate>(request);
        _affiliateRepository.Create(affiliate);
        await _unitOfWork.Save(cancellationToken);

        return _mapper.Map<CreateAffiliateResponse>(affiliate);
    }
}