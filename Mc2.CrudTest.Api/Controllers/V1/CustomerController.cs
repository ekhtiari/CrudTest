using Mc2.CrudTest.Application;
using Mc2.CrudTest.Infrastructure.Customer.Command.Create;
using Mc2.CrudTest.Infrastructure.Customer.Queries.GetAllCustomers;
using Mc2.CrudTest.Infrastructure.Queries.GetAllCustomers;
using Microsoft.AspNetCore.Mvc;
namespace Mc2.CrudTest.Api.Controllers.V1;

/// <summary>
/// 
/// </summary>
[ApiVersion("1")]
[Route("[controller]")]
public class CustomerController:ApiControllerBase
{
    /// <summary>
    /// get all data 
    /// </summary>
    /// <param name="query"></param>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType(typeof(QueryListResult<CustomerQueryResponse>),200)]
    public async Task<QueryListResult<CustomerQueryResponse>> GetAllCustomer([FromQuery] CustomerQuery query)
    {
        return await SendRequest(query);
    }

    /// <summary>
    /// create new item
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(typeof(CreateCommandResponse),200)]
    public async Task<CreateCommandResponse> Create([FromBody]CustomCreateCommand command)
    {
        
        return await SendRequest(command);
    }
}