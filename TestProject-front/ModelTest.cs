using System;
using BlazorApp.Functions;
using BlazorApp.Model;
using Xunit;

namespace TestProject_front;

public class UnitTest1
{
    [Fact]
    public void Model_Validation_Email_Phone_Test()
    {
         
        NewCustomer newCustomer = new()
        {
            firstName = "test",
            lastName = "test",
            phoneNumber = "+989100000000",
            email = "test@test.com",
            bankAccountNumber = "test",
            dateOfBirth = DateTime.Now
        };


        var result = TestModelHelper.Validate(newCustomer);
        
        Assert.Equal(0,result.Count);

    }


    [Fact]
    public void Model_Validation_firstName_isEmpty()
    {
        NewCustomer newCustomer = new()
        {
            
            lastName = "test",
            phoneNumber = "+989100000000",
            email = "test@test.com",
            bankAccountNumber = "test",
            dateOfBirth = DateTime.Now
        };


        var result = TestModelHelper.Validate(newCustomer);
        
        
        Assert.NotEqual(0,result.Count);
        
    }
    
    [Fact]
    public void Model_Validation_email_format_check()
    {
        NewCustomer newCustomer = new()
        {
            firstName = "test",
            lastName = "test",
            phoneNumber = "+989100000000",
            email = "test",
            bankAccountNumber = "test",
            dateOfBirth = DateTime.Now
        };


        var result = TestModelHelper.Validate(newCustomer);
        
        
        Assert.NotEqual(0,result.Count);
        
    }
    
    
    
    
   
}

