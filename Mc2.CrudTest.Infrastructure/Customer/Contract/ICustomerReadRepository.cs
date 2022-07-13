using Mc2.CrudTest.Application;
using Mc2.CrudTest.Application.Queries.GetAllCustomers;
using Mc2.CrudTest.Infrastructure.Queries.GetAllCustomers;

namespace Mc2.CrudTest.Infrastructure.Customer.Contract;

public interface ICustomerReadRepository
{
    Task<QueryListResult<CustomerQueryResponse>> GetAllCustomer(CustomerQuery customerQuery,
        CancellationToken cancellationToken);
    
    bool FindByNameFamilyBirthday(string firstname, string lastname, DateTime birthday);
    bool FindByEmail(string email);
}