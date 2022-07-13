using Mc2.CrudTest.Domain.BaseEntities;

namespace Mc2.CrudTest.Domain.Entities;

public class Customer:BaseEntity<Guid>
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string BankAccountNumber { get; set; }
}