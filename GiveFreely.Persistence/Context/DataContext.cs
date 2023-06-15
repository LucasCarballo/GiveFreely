using GiveFreely.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GiveFreely.Persistence.Context;

public class DataContext: DbContext
{
    public DataContext(DbContextOptions<DataContext> options): base(options)
    {
    }

    public DbSet<Affiliate> Affiliates {get;set;}

    public DbSet<Customer> Customers {get;set;}
}