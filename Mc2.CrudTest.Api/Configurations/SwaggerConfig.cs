using System.Reflection;
using Microsoft.OpenApi.Models;

namespace Mc2.CrudTest.Api.Configurations;

public static class SwaggerConfig
    {
        public static void AddSwaggerConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "User Information Microservice"
                });

                  s.IncludeXmlComments(XmlCommentsFilePath);
            });
        }

        public static void UseSwaggerSetup(this IApplicationBuilder app)
        {
            if (app == null) throw new ArgumentNullException(nameof(app));

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            });
        }

        private static string XmlCommentsFilePath
        {
            get
            {
                string? basePath = Path.GetDirectoryName(Assembly.GetEntryAssembly()?.Location);
                string fileName = typeof(Program).GetTypeInfo().Assembly.GetName().Name + ".xml";
                return Path.Combine(basePath ?? string.Empty, fileName);
            }
        }
    }