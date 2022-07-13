using System;
using Mc2.CrudTest.Domain.Entities;
using Mc2.CrudTest.Infrastructure;
using Mc2.CrudTest.Infrastructure.Domain.Customer;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace TestProject_Backend;

public class UnitTest
{
  
    [Fact]
    public void Test_FindDuplicateByNameFamilyBirthDay_Return_True()
    {
        var dbName = $"TempData_{DateTime.UtcNow.ToFileTimeUtc()}";
        var dbContextOptions = new DbContextOptionsBuilder<PlatformContext>()
            .UseInMemoryDatabase(dbName)
            .Options;
        
       
        

        using (var context = new PlatformContext(dbContextOptions))
        {
            context.Customers.Add(new Customer()
            {
                Id = Guid.NewGuid(),
                Email = "test@test.com",
                CreateTime = DateTime.Now,
                FirstName = "test",
                LastName = "test",
                IsDeleted = false,
                ModifyTime = DateTime.Now,
                PhoneNumber = "1234567890",
                BankAccountNumber = "1",
                DateOfBirth = DateTime.Parse("4/18/2020")
            });

            context.SaveChanges();
        }

        using (var context = new PlatformContext(dbContextOptions))
        {
            var repo = new CustomerReadRepository(context);
            
            var result = repo.FindByNameFamilyBirthday("test", "test", DateTime.Now);
            
            Assert.False(result);
        }

       
        
       
    }


    [Fact]
    public void Find_Duplicate_Email_return_false()
    {
        var dbName = $"TempData_{DateTime.UtcNow.ToFileTimeUtc()}";
        var dbContextOptions = new DbContextOptionsBuilder<PlatformContext>()
            .UseInMemoryDatabase(dbName)
            .Options;
        
       
        

        using (var context = new PlatformContext(dbContextOptions))
        {
            context.Customers.Add(new Customer()
            {
                Id = Guid.NewGuid(),
                Email = "test@test.com",
                CreateTime = DateTime.Now,
                FirstName = "test",
                LastName = "test",
                IsDeleted = false,
                ModifyTime = DateTime.Now,
                PhoneNumber = "1234567890",
                BankAccountNumber = "1",
                DateOfBirth = DateTime.Parse("4/18/2020")
            });

            context.SaveChanges();
        }

        using (var context = new PlatformContext(dbContextOptions))
        {
            var repo = new CustomerReadRepository(context);
            
            var result = repo.FindByEmail("test@test.com");
            
            Assert.True(result);
        }
    }
}