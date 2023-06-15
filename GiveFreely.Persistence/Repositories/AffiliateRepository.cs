using GiveFreely.Application.Repositories;
using GiveFreely.Domain.Entities;
using GiveFreely.Persistence.Context;

namespace GiveFreely.Persistence.Repositories;

public class AffiliateRepository: BaseRepository<Affiliate>, IAffiliateRepository
{
    public AffiliateRepository(DataContext context): base(context)
    {
    }
}