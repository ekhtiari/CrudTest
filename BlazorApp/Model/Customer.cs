using System.ComponentModel.DataAnnotations;
using BlazorApp.Functions;


namespace BlazorApp.Model;

public class NewCustomer
{
    [Required(ErrorMessage = "First Name must be enter")]
    public string? FirstName { get; set; }
    [Required(ErrorMessage = "Last Name must be enter")]
    public string? LastName { get; set; }
    [Required(ErrorMessage = "Birthday must be enter")]
    public DateTime DateOfBirth { get; set; }
    [Required(ErrorMessage = "Phone number must be enter")]
    [ValidationPhoneNumber]
    public string? PhoneNumber { get; set; }
    [Required(ErrorMessage = "Email must be enter")]
    [EmailAddress(ErrorMessage = "Enter valid email Address")]
    public string? Email { get; set; }
    [Required(ErrorMessage = "Bank Account Number must be enter")]
    public string? BankAccountNumber { get; set; }
}


