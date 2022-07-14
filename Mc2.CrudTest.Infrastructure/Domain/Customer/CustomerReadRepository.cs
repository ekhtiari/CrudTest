using Mc2.CrudTest.Application;
using Mc2.CrudTest.Infrastructure.Extensions;
using Mc2.CrudTest.Infrastructure.Queries.GetAllCustomers;
using System.Linq;
using Mc2.CrudTest.Infrastructure.Customer.Contract;
using Mc2.CrudTest.Infrastructure.Customer.Queries.GetAllCustomers;
using Microsoft.EntityFrameworkCore;

namespace Mc2.CrudTest.Infrastructure.Domain.Customer;


public class CustomerReadRepository : ICustomerReadRepository
{
    private readonly PlatformContext _platformContext;

    public CustomerReadRepository(PlatformContext platformContext)
    {
        _platformContext = platformContext;
    }

    public async Task<QueryListResult<CustomerQueryResponse>> GetAllCustomer(CustomerQuery customerQuery,
        CancellationToken cancellationToken)
    {
        IQueryable<CrudTest.Domain.Entities.Customer> queryResult =  _platformContext.Customers.Where(x => !x.IsDeleted);
        IQueryable<CustomerQueryResponse> result = queryResult.WhereSpecificIds(customerQuery).Select(x=>new CustomerQueryResponse()
        {
            Id = x.Id,
            Email = x.Email,
            FirstName = x.FirstName,
            LastName = x.LastName,
            
        });

        return await result.ToQueryListResult(customerQuery, cancellationToken);
    }
    public bool FindByNameFamilyBirthday(string firstname, string lastname, DateTime birthday)
    {
        bool findItem =  _platformContext.Customers.Any(
            x => !x.IsDeleted && x.FirstName == firstname && x.LastName == lastname && x.DateOfBirth == birthday);

        return findItem;
    }

    public bool FindByEmail(string email)
    {
        bool findItem =  _platformContext.Customers.Any(x => !x.IsDeleted && x.Email == email);
        return findItem;

    }
}