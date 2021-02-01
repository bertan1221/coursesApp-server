using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace API.Config.Swagger
{
    public static class SwaggerConfig
    {
        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Courses API",
                    Version = "v1",
                    Description = "This API reference includes all technical documentation developers need to integrate third-party applications and platforms."
                });

                c.EnableAnnotations();
                c.ExampleFilters();

                var filePath = Path.Combine(AppContext.BaseDirectory, "Swagger.xml");
                c.IncludeXmlComments(filePath);
            });

            services.AddSwaggerExamplesFromAssemblies(Assembly.GetEntryAssembly());
        }

        public static void UseSwaggerReDoc(this IApplicationBuilder app)
        {
            app.UseSwagger(c => c.PreSerializeFilters.Add((swagger, httpRequest) =>
            {
                swagger.Servers.Add(new OpenApiServer
                {
                    Url = $"{httpRequest.Scheme}://{httpRequest.Host}"
                });

                swagger.Tags = new List<OpenApiTag>()
                {
                    new OpenApiTag()
                    {
                        Description = "API endpoints for courses. This category currently includes 3 endpoints:",
                        Name = "Courses"
                    },
                };

                })
            );

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Courses API V1");
            });

            app.UseReDoc(c =>
            {
                c.RoutePrefix = "documentation";
                c.DocumentTitle = "Courses API V1 Documentation";
                c.SpecUrl("/swagger/v1/swagger.json");
                c.HideDownloadButton();
                c.RequiredPropsFirst();
                c.ExpandResponses(null);
                c.ConfigObject.AdditionalItems = new Dictionary<string, object>()
                {
                    {"menuToggle", true }
                };                
            }
            );
        }
    }
}
