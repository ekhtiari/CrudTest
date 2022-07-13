using Mc2.CrudTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Mc2.CrudTest.Infrastructure;

public class PlatformContext:DbContext
{
    
    public PlatformContext(DbContextOptions<PlatformContext> options) : base(options)  
    {  
  
    }  
    
    protected override void OnModelCreating(ModelBuilder builder)  
    {  
        base.OnModelCreating(builder);  
    }  
    
    public DbSet<CrudTest.Domain.Entities.Customer> Customers { get; set; }
}