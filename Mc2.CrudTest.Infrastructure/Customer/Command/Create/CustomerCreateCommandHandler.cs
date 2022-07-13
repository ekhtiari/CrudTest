using Mc2.CrudTest.Application;
using Mc2.CrudTest.Infrastructure.Customer.Contract;
using MediatR;

namespace Mc2.CrudTest.Infrastructure.Customer.Command.Create;

public class CustomerCreateCommandHandler:RequestHandler<CustomCreateCommand,CreateCommandResponse>
{
    private readonly ICustomerWriteRepository _writeRepository;
    private readonly ICustomerReadRepository _readRepository;

    public CustomerCreateCommandHandler(ICustomerWriteRepository writeRepository , ICustomerReadRepository readRepository )
    {
        _writeRepository = writeRepository;
        _readRepository = readRepository;
    }
    protected override CreateCommandResponse Handle(CustomCreateCommand request)
    {

        var findDuplicateUser =  
            _readRepository.FindByNameFamilyBirthday(request.firstName, request.lastName, request.dateOfBirth);

        if (findDuplicateUser)
        {
             
             return new CreateCommandResponse()
             {
                 
                 Error = new ResponseError()
                 {
                     Code = 403,
                     Message = "Customer already exists"
                 }
             };

        }

        var findDuplicateEmail = _readRepository.FindByEmail(request.email);
        if (findDuplicateEmail)
        {
            
            return new CreateCommandResponse()
            {
                 
                Error = new ResponseError()
                {
                    Code = 403,
                    Message = "Email already exists"
                }
            };
        }
        
        CrudTest.Domain.Entities.Customer newCustomer = new()
        {
            Email = request.email,
            FirstName = request.firstName,
            LastName = request.lastName,
            PhoneNumber = request.phoneNumber,
            BankAccountNumber = request.bankAccountNumber,
            DateOfBirth = request.dateOfBirth
        };
        
          _writeRepository.Add(newCustomer);

        return new CreateCommandResponse()
        {
            Id = newCustomer.Id
        };
        
    }
}