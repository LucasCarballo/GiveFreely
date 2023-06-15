

using AutoMapper;
using GiveFreely.Application.Features.AffiliateFeatures.CreateAffiliate;
using GiveFreely.Application.Repositories;
using GiveFreely.Domain.Entities;
using Moq;

namespace GiveFreely.UnitTest.Features.AffiliateFeatures;

public class CreateAffiliateHandler_HandleShould
{
    [Fact]
    public async Task Handle_InputValid_ReturnsAffiliate()
    {
        var affiliateName = "Jhon Doe";
        var affiliate = new Affiliate {
            Id = Guid.NewGuid(),
            Name = affiliateName,
            DateCreated = new DateTimeOffset(DateTime.UtcNow.AddDays(-1))
        };
        var affiliateResponse = new CreateAffiliateResponse {
            Id = affiliate.Id,
            Name = affiliate.Name
        };

        var mockUnitOfWork = new Mock<IUnitOfWork>();
        mockUnitOfWork.Setup(x => x.Save(It.IsAny<CancellationToken>()));

        var mockAffiliateRepository = new Mock<IAffiliateRepository>();
        mockAffiliateRepository.Setup(x => x.Create(It.IsAny<Affiliate>()));

        var mockMapper = new Mock<IMapper>();
        mockMapper.Setup(x => x.Map<Affiliate>(It.IsAny<CreateAffiliateRequest>()))
            .Returns(affiliate);
        mockMapper.Setup(x => x.Map<CreateAffiliateResponse>(It.IsAny<Affiliate>()))
            .Returns(affiliateResponse);

        var handler = new CreateAffiliateHandler(mockUnitOfWork.Object, mockAffiliateRepository.Object, mockMapper.Object);
        var result = await handler.Handle(new CreateAffiliateRequest(affiliateName), new CancellationToken());

        mockAffiliateRepository.Verify(x => x.Create(It.Is<Affiliate>(x => x == affiliate)), Times.Once);
        mockUnitOfWork.Verify(x => x.Save(It.IsAny<CancellationToken>()), Times.Once);

        Assert.Same(affiliateResponse, result);
    }
}