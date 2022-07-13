using Mc2.CrudTest.Infrastructure.Customer.Contract;
using Microsoft.EntityFrameworkCore;

namespace Mc2.CrudTest.Infrastructure.Domain.Customer;


public class CustomerWriteRepository : ICustomerWriteRepository
{
    private readonly PlatformContext _platformContext;

    public CustomerWriteRepository(PlatformContext platformContext)
    {
        _platformContext = platformContext;
    }

    public void Add(CrudTest.Domain.Entities.Customer customer)
    {
        
        _platformContext.Add(customer);

        _platformContext.SaveChanges();

    }

   
}