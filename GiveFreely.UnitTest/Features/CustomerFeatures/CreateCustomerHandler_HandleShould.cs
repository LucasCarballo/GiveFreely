

using AutoMapper;
using GiveFreely.Application.Common.Exceptions;
using GiveFreely.Application.Features.CustomerFeatures.CreateCustomer;
using GiveFreely.Application.Repositories;
using GiveFreely.Domain.Entities;
using Moq;

namespace GiveFreely.UnitTest.Features.CustomerFeatures;

public class CreateCustomerHandler_HandleShould
{
    [Fact]
    public async Task Handle_InputValid_ReturnsCustomer()
    {
        var customerName = "Jhon Doe";
        var affiliateId = new Guid();
        var customer = new Customer {
            Id = new Guid(),
            Name = customerName,
            DateCreated = new DateTimeOffset(DateTime.UtcNow.AddDays(-1)),
            AffiliateId = affiliateId
        };
        var customerResponse = new CreateCustomerResponse {
            Id = customer.Id,
            Name = customer.Name,
            AffiliateId = customer.AffiliateId
        };

        var mockUnitOfWork = new Mock<IUnitOfWork>();
        mockUnitOfWork.Setup(x => x.Save(It.IsAny<CancellationToken>()));

        var mockCustomerRepository = new Mock<ICustomerRepository>();
        mockCustomerRepository.Setup(x => x.Create(It.IsAny<Customer>()));

        var mockAffiliateRepository = new Mock<IAffiliateRepository>();
        mockAffiliateRepository.Setup(x => x.Get(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new Affiliate {
                Id = affiliateId
            });

        var mockMapper = new Mock<IMapper>();
        mockMapper.Setup(x => x.Map<Customer>(It.IsAny<CreateCustomerRequest>()))
            .Returns(customer);
        mockMapper.Setup(x => x.Map<CreateCustomerResponse>(It.IsAny<Customer>()))
            .Returns(customerResponse);

        var handler = new CreateCustomerHandler(
            mockUnitOfWork.Object, mockCustomerRepository.Object, mockAffiliateRepository.Object, mockMapper.Object);
        var result = await handler.Handle(new CreateCustomerRequest(customerName, affiliateId), new CancellationToken());

        mockAffiliateRepository.Verify(x => x.Get(It.Is<Guid>(x => x == affiliateId), It.IsAny<CancellationToken>()), Times.Once);
        mockCustomerRepository.Verify(x => x.Create(It.Is<Customer>(x => x == customer)), Times.Once);
        mockUnitOfWork.Verify(x => x.Save(It.IsAny<CancellationToken>()), Times.Once);

        Assert.Same(customerResponse, result);
    }

    [Fact]
    public async Task Handle_InexistentAffiliateId_ThrowsBadRequestException()
    {
        var customerName = "Jhon Doe";
        var affiliateId = new Guid();
        var customer = new Customer {
            Id = new Guid(),
            Name = customerName,
            DateCreated = new DateTimeOffset(DateTime.UtcNow.AddDays(-1)),
            AffiliateId = affiliateId
        };
        var customerResponse = new CreateCustomerResponse {
            Id = customer.Id,
            Name = customer.Name,
            AffiliateId = customer.AffiliateId
        };

        var mockUnitOfWork = new Mock<IUnitOfWork>();
        mockUnitOfWork.Setup(x => x.Save(It.IsAny<CancellationToken>()));

        var mockCustomerRepository = new Mock<ICustomerRepository>();
        mockCustomerRepository.Setup(x => x.Create(It.IsAny<Customer>()));

        var mockAffiliateRepository = new Mock<IAffiliateRepository>();
        mockAffiliateRepository.Setup(x => x.Get(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(value: null);

        var mockMapper = new Mock<IMapper>();
        mockMapper.Setup(x => x.Map<Customer>(It.IsAny<CreateCustomerRequest>()))
            .Returns(customer);
        mockMapper.Setup(x => x.Map<CreateCustomerResponse>(It.IsAny<Customer>()))
            .Returns(customerResponse);

        var handler = new CreateCustomerHandler(
            mockUnitOfWork.Object, mockCustomerRepository.Object, mockAffiliateRepository.Object, mockMapper.Object);
        var ex = await Assert.ThrowsAsync<BadRequestException>(async () => await handler.Handle(new CreateCustomerRequest(customerName, affiliateId), new CancellationToken()));

        Assert.Equal("Affiliate Id doest not exist.", ex.Message);
    }    
}