using Mc2.CrudTest.Application;
using Mc2.CrudTest.Application.Queries.GetAllCustomers;
using Mc2.CrudTest.Infrastructure.Customer.Contract;
using Mc2.CrudTest.Infrastructure.Queries.GetAllCustomers;
using MediatR;

namespace Mc2.CrudTest.Infrastructure.Customer.Queries.GetAllCustomers;

public class CustomerQueryHandler:RequestHandler<CustomerQuery,QueryListResult<CustomerQueryResponse>>
{
    private readonly ICustomerReadRepository _readRepository;

    public CustomerQueryHandler(ICustomerReadRepository readRepository)
    {
        _readRepository = readRepository;
    }
    

    protected override QueryListResult<CustomerQueryResponse> Handle(CustomerQuery request)
    {
        Task<QueryListResult<CustomerQueryResponse>> result = _readRepository.GetAllCustomer(request,CancellationToken.None);

        return  result.Result;
    }
}