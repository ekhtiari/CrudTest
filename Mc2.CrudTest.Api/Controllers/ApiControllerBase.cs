using Mc2.CrudTest.Application;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Mc2.CrudTest.Api.Controllers;

/// <summary>
/// 
/// </summary>
[ApiController]
public class ApiControllerBase: ControllerBase
{
    /// <summary>
    /// 
    /// </summary>
    public IMediator? _mediator;
    /// <summary>
    /// 
    /// </summary>
    public IMediator Mediator => (_mediator ??= HttpContext.RequestServices.GetService<IMediator>())!;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <typeparam name="TResponse"></typeparam>
    /// <returns></returns>
    protected Task<TResponse> SendRequest<TResponse>(IRequest<TResponse> request)
        where TResponse : BaseResponse
    {
       
        return Mediator.Send(request);
    }
}