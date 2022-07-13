using System.ComponentModel.DataAnnotations;
using PhoneNumbers;

namespace BlazorApp.Functions;



public class ValidationPhoneNumber : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        string? phoneString = value?.ToString();

        PhoneNumberUtil? phoneNumberUtil = PhoneNumberUtil.GetInstance();

        PhoneNumber? phoneNumber = phoneNumberUtil.Parse(phoneString, null);
        bool result = phoneNumberUtil.IsValidNumber(phoneNumber);


        return result ? ValidationResult.Success : new ValidationResult("Phone number format is not valid", new[] {validationContext.MemberName}!);
    }
}