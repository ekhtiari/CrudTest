using System;
using BlazorApp.Model;
using Xunit;

namespace TestProject_front;

public class UnitTest
{
    [Fact]
    public void Model_Validation_Email_Phone_Test()
    {
         
        NewCustomer newCustomer = new()
        {
            FirstName = "test",
            LastName = "test",
            PhoneNumber = "+989100000000",
            Email = "test@test.com",
            BankAccountNumber = "test",
            DateOfBirth = DateTime.Now
        };


        var result = TestModelHelper.Validate(newCustomer);
        
        Assert.Equal(0,result.Count);

    }


    [Fact]
    public void Model_Validation_firstName_isEmpty()
    {
        NewCustomer newCustomer = new()
        {
            
            LastName = "test",
            PhoneNumber = "+989100000000",
            Email = "test@test.com",
            BankAccountNumber = "test",
            DateOfBirth = DateTime.Now
        };


        var result = TestModelHelper.Validate(newCustomer);
        
        
        Assert.NotEqual(0,result.Count);
        
    }
    
    [Fact]
    public void Model_Validation_email_format_check()
    {
        NewCustomer newCustomer = new()
        {
            FirstName = "test",
            LastName = "test",
            PhoneNumber = "+989100000000",
            Email = "test",
            BankAccountNumber = "test",
            DateOfBirth = DateTime.Now
        };


        var result = TestModelHelper.Validate(newCustomer);
        
        
        Assert.NotEqual(0,result.Count);
        
    }
    
    
    
    
   
}

