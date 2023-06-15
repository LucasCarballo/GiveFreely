

using AutoMapper;
using GiveFreely.Application.Features.CustomerFeatures.GetAllCustomerByAffiliate;
using GiveFreely.Application.Repositories;
using GiveFreely.Domain.Entities;
using Moq;

namespace GiveFreely.UnitTest.Features.CustomerFeatures;

public class GetAllCustomerByAffiliateHandler_HandleShould
{
    [Fact]
    public async Task Handle_InputValid_ReturnsCustomerList()
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
        var customerListResponse = new List<GetAllCustomerByAffiliateResponse> {
            new GetAllCustomerByAffiliateResponse {
                Id = customerList[0].Id,
                Name = customerList[0].Name,
                AffiliateId = customerList[0].AffiliateId
            },
            new GetAllCustomerByAffiliateResponse {
                Id = customerList[1].Id,
                Name = customerList[1].Name,
                AffiliateId = customerList[1].AffiliateId
            }
        };

        var mockCustomerRepository = new Mock<ICustomerRepository>();
        mockCustomerRepository.Setup(x => x.GetAllByAffiliateId(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(customerList);

        var mockMapper = new Mock<IMapper>();
        mockMapper.Setup(x => x.Map<List<GetAllCustomerByAffiliateResponse>>(It.IsAny<List<Customer>>()))
            .Returns(customerListResponse);

        var handler = new GetAllCustomerByAffiliateHandler(mockCustomerRepository.Object, mockMapper.Object);
        var result = await handler.Handle(new GetAllCustomerByAffiliateRequest(affiliateId), new CancellationToken());

        mockCustomerRepository.Verify(x => x.GetAllByAffiliateId(It.Is<Guid>(x => x == affiliateId), It.IsAny<CancellationToken>()), Times.Once);

        Assert.Same(customerListResponse, result);
    }
}