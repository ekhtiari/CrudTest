using System.Reflection;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using Mc2.CrudTest.Api.Configurations;
using Mc2.CrudTest.Infrastructure;
using Mc2.CrudTest.Infrastructure.Customer.Contract;
using Mc2.CrudTest.Infrastructure.Domain.Customer;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.

ConfigurationManager configuration = builder.Configuration;

builder.Services
    .AddDbContext<PlatformContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))); 
builder.Services.AddApiVersioning(o =>
{
    o.AssumeDefaultVersionWhenUnspecified = true;
    o.ReportApiVersions = true;
    o.DefaultApiVersion = new ApiVersion(1, 0);
})
    .AddSingleton(HtmlEncoder.Create(new []{UnicodeRanges.BasicLatin, UnicodeRanges.Arabic, }))
    .Configure<RouteOptions>(options =>
            {
                options.LowercaseUrls = true;
                options.LowercaseQueryStrings = true;
                options.AppendTrailingSlash = true;
                
            });
builder.Services.AddScoped<ICustomerWriteRepository, CustomerWriteRepository>();
builder.Services.AddScoped<ICustomerReadRepository, CustomerReadRepository>();

builder.Services.AddMediatR(typeof(MediatorRegistration).GetTypeInfo().Assembly);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerConfiguration();

builder.Services.AddCors(o =>
{
    o.AddPolicy("AllowAllOrigins", builder =>
    {
        builder.AllowAnyOrigin();
        builder.AllowAnyMethod();
        builder.AllowAnyHeader();
    });
});

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowAllOrigins");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();