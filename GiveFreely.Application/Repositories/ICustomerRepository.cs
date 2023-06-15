using GiveFreely.Domain.Entities;

namespace GiveFreely.Application.Repositories;

public interface ICustomerRepository : IBaseRepository<Customer>
{
    Task<List<Customer>> GetAllByAffiliateId(Guid affiliateId, CancellationToken cancellationToken);

    Task<int> CountByAffiliateId(Guid affiliateId, CancellationToken cancellationToken);
}