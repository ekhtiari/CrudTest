namespace Mc2.CrudTest.Infrastructure.Queries.GetAllCustomers;

public class CustomerQueryResponse
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
   
    public string Email { get; set; }
    
}