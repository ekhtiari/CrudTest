using MediatR;

namespace Mc2.CrudTest.Application;

public class RequestData<TContext, TRequest, TResponse> : IRequest<TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : BaseResponse
{
    public RequestData(TRequest request, TContext context)
    {
        Request = request;
        Context = context;
    }

    public TRequest Request { get; private set; }
    public TContext Context { get; private set; }
}