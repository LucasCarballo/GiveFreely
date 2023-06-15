using GiveFreely.Application.Features.CustomerFeatures.CreateCustomer;
using GiveFreely.Application.Features.CustomerFeatures.GetAllCustomerByAffiliate;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GiveFreely.WebAPI.Controllers;

[ApiController]
[Route("customer")]
public class CustomerController : ControllerBase
{
    private readonly IMediator _mediator;

    public CustomerController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet(Name = "GetAllCustomersByAffiliate")]
    public async Task<ActionResult<List<GetAllCustomerByAffiliateResponse>>> GetAll(string affiliateId, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new GetAllCustomerByAffiliateRequest(new Guid(affiliateId)), cancellationToken);
        return Ok(response);
    }

    [HttpPost(Name = "CreateCustomer")]
    public async Task<ActionResult<CreateCustomerResponse>> Create(CreateCustomerRequest request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }
}
