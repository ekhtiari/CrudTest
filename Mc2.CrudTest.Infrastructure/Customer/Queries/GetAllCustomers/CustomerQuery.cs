using Mc2.CrudTest.Infrastructure.Queries.GetAllCustomers;
using MediatR;

namespace Mc2.CrudTest.Application.Queries.GetAllCustomers;

public class CustomerQuery:BaseListQuery,IRequest<QueryListResult<CustomerQueryResponse>>
{
    public string Search { get; set; }
}