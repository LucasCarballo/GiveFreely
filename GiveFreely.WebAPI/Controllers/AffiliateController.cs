using GiveFreely.Application.Features.AffiliateFeatures.GetAllAffiliate;
using Microsoft.AspNetCore.Mvc;
using GiveFreely.Application.Features.AffiliateFeatures.CreateAffiliate;
using MediatR;
using GiveFreely.Application.Features.AffiliateFeatures.GetAffiliateReport;

namespace GiveFreely.WebAPI.Controllers;

[ApiController]
[Route("affiliate")]
public class AffiliateController : ControllerBase
{
    private readonly IMediator _mediator;

    public AffiliateController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet(Name = "GetAllAffiliates")]
    public async Task<ActionResult<List<GetAllAffiliateResponse>>> GetAll(CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new GetAllAffiliateRequest(), cancellationToken);
        return Ok(response);
    }

    [HttpPost(Name = "CreateAffiliate")]
    public async Task<ActionResult<CreateAffiliateResponse>> Create(CreateAffiliateRequest request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpGet("{id}/report")]
    public async Task<ActionResult<GetAffiliateReportResponse>> GetReport(Guid id, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new GetAffiliateReportRequest(id), cancellationToken);
        return Ok(response);
    }
}
