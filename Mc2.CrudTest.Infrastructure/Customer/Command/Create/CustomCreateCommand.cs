using Mc2.CrudTest.Application;
using MediatR;

namespace Mc2.CrudTest.Infrastructure.Customer.Command.Create;

public class CustomCreateCommand:IRequest<CreateCommandResponse>
{
    public string firstName { get; set; }
    public string lastName { get; set; }
    public DateTime dateOfBirth { get; set; }
    public string phoneNumber { get; set; }
    public string email { get; set; }
    public string bankAccountNumber { get; set; }
    
    
}