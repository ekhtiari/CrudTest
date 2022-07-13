using Mc2.CrudTest.Application;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Mc2.CrudTest.Api.Controllers;

[ApiController]
public class ApiControllerBase: ControllerBase
{
    public IMediator? _mediator;
    public IMediator Mediator => (_mediator ??= HttpContext.RequestServices.GetService<IMediator>())!;

    protected Task<TResponse> SendRequest<TResponse>(IRequest<TResponse> request)
        where TResponse : BaseResponse
    {
       
        return Mediator.Send(request);
    }
}