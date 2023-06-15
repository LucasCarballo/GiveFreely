using AutoMapper;
using GiveFreely.Application.Common.Exceptions;
using GiveFreely.Application.Repositories;
using GiveFreely.Domain.Entities;
using MediatR;

namespace GiveFreely.Application.Features.CustomerFeatures.CreateCustomer;

public sealed class CreateCustomerHandler: IRequestHandler<CreateCustomerRequest, CreateCustomerResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICustomerRepository _customerRepository;
    private readonly IAffiliateRepository _affiliateRepository;
    private readonly IMapper _mapper;

    public CreateCustomerHandler(IUnitOfWork unitOfWork, ICustomerRepository customerRepository, IAffiliateRepository affiliateRepository, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _customerRepository = customerRepository;
        _affiliateRepository = affiliateRepository;
        _mapper = mapper;
    }

    public async Task<CreateCustomerResponse> Handle(CreateCustomerRequest request, CancellationToken cancellationToken)
    {
        var customer = _mapper.Map<Customer>(request);
        _ = await _affiliateRepository.Get(customer.AffiliateId, cancellationToken)
            ?? throw new BadRequestException("Affiliate Id doest not exist.");

        _customerRepository.Create(customer);
        await _unitOfWork.Save(cancellationToken);

        return _mapper.Map<CreateCustomerResponse>(customer);
    }
}