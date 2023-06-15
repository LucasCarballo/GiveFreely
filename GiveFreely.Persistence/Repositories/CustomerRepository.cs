using GiveFreely.Application.Repositories;
using GiveFreely.Domain.Entities;
using GiveFreely.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace GiveFreely.Persistence.Repositories;

public class CustomerRepository: BaseRepository<Customer>, ICustomerRepository
{
    public CustomerRepository(DataContext context): base(context)
    {
    }

    public Task<List<Customer>> GetAllByAffiliateId(Guid affiliateId, CancellationToken cancellationToken)
    {
        return Context.Customers.Where(x => x.AffiliateId == affiliateId).ToListAsync();
    }

    public Task<int> CountByAffiliateId(Guid affiliateId, CancellationToken cancellationToken)
    {
        return Context.Customers.CountAsync(x => x.AffiliateId == affiliateId, cancellationToken);
    }    
}