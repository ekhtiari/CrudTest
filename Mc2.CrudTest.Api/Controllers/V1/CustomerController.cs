using Mc2.CrudTest.Application;
using Mc2.CrudTest.Application.Queries.GetAllCustomers;
using Mc2.CrudTest.Infrastructure.Customer.Command.Create;
using Mc2.CrudTest.Infrastructure.Queries.GetAllCustomers;
using Microsoft.AspNetCore.Mvc;
namespace Mc2.CrudTest.Api.Controllers.V1;

[ApiVersion("1")]
[Route("[controller]")]
public class CustomerController:ApiControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(QueryListResult<CustomerQueryResponse>),200)]
    public async Task<QueryListResult<CustomerQueryResponse>> GetAllCustomer([FromQuery] CustomerQuery query)
    {
        return await SendRequest(query);
    }

    [HttpPost]
    [ProducesResponseType(typeof(CreateCommandResponse),200)]
    public async Task<CreateCommandResponse> Create([FromBody]CustomCreateCommand command)
    {
        
        return await SendRequest(command);
    }
}