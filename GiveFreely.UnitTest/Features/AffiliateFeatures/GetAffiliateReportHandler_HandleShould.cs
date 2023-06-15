

using AutoMapper;
using GiveFreely.Application.Features.AffiliateFeatures.CreateAffiliate;
using GiveFreely.Application.Features.AffiliateFeatures.GetAffiliateReport;
using GiveFreely.Application.Repositories;
using GiveFreely.Domain.Entities;
using Moq;

namespace GiveFreely.UnitTest.Features.AffiliateFeatures;

public class GetAffiliateReportHandler_HandleShould
{
    [Fact]
    public async Task Handle_InputValid_ReturnsAffiliate()
    {
        var affiliateId = Guid.NewGuid();
        var customerList = new List<Customer> {new Customer {
            Id = Guid.NewGuid(),
            Name = "Customer One",
            DateCreated = new DateTimeOffset(DateTime.UtcNow.AddDays(-1)),
            AffiliateId = affiliateId
        },
        new Customer {
            Id = Guid.NewGuid(),
            Name = "Customer Two",
            DateCreated = new DateTimeOffset(DateTime.UtcNow.AddDays(-1)),
            AffiliateId = affiliateId
        }};
        var customerListCount = customerList.Count;

        var mockCustomerRepository = new Mock<ICustomerRepository>();
        mockCustomerRepository.Setup(x => x.CountByAffiliateId(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(customerListCount);

        var handler = new GetAffiliateReportHandler(mockCustomerRepository.Object);
        var result = await handler.Handle(new GetAffiliateReportRequest(affiliateId), new CancellationToken());

        mockCustomerRepository.Verify(x => x.CountByAffiliateId(It.Is<Guid>(x => x == affiliateId), It.IsAny<CancellationToken>()), Times.Once);

        Assert.Equivalent(new GetAffiliateReportResponse(customerListCount), result);
    }
}