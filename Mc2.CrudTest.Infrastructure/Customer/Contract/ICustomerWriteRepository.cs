namespace Mc2.CrudTest.Infrastructure.Customer.Contract;

public interface ICustomerWriteRepository
{
    void Add(CrudTest.Domain.Entities.Customer customer);
    
}