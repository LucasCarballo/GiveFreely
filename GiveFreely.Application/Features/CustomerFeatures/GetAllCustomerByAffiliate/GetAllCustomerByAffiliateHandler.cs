using AutoMapper;
using GiveFreely.Application.Repositories;
using MediatR;

namespace GiveFreely.Application.Features.CustomerFeatures.GetAllCustomerByAffiliate;

public sealed class GetAllCustomerByAffiliateHandler: IRequestHandler<GetAllCustomerByAffiliateRequest, List<GetAllCustomerByAffiliateResponse>>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IMapper _mapper;

    public GetAllCustomerByAffiliateHandler(ICustomerRepository customerRepository, IMapper mapper)
    {
        _customerRepository = customerRepository;
        _mapper = mapper;
    }

    public async Task<List<GetAllCustomerByAffiliateResponse>> Handle(GetAllCustomerByAffiliateRequest request, CancellationToken cancellationToken)
    {
        var customers = await _customerRepository.GetAllByAffiliateId(request.AffiliateId, cancellationToken);
        return _mapper.Map<List<GetAllCustomerByAffiliateResponse>>(customers);
    }
}