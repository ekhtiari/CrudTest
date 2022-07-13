using System.ComponentModel.DataAnnotations;
using BlazorApp.Functions;


namespace BlazorApp.Model;

public class NewCustomer
{
    [Required(ErrorMessage = "First Name must be enter")]
    public string firstName { get; set; }
    [Required(ErrorMessage = "Last Name must be enter")]
    public string lastName { get; set; }
    [Required(ErrorMessage = "Birthday must be enter")]
    public DateTime dateOfBirth { get; set; }
    [Required(ErrorMessage = "Phone number must be enter")]
    [ValidationPhoneNumber]
    public string phoneNumber { get; set; }
    [Required(ErrorMessage = "Email must be enter")]
    [EmailAddress(ErrorMessage = "Enter valid email Address")]
    public string email { get; set; }
    [Required(ErrorMessage = "Bank Account Number must be enter")]
    public string bankAccountNumber { get; set; }
}


