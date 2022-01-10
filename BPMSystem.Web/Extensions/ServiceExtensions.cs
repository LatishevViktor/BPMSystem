using BPMSystem.BLL.Interfaces;
using BPMSystem.BLL.Services;
using BPMSystem.DAL.Interfaces;
using BPMSystem.DAL.Repositories;
using Identity.Common;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Services.BPMSystemBLL.Services;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BPMSystem.Web.Extensions_services
{
    public static class ServiceExtensions
    {
        private static readonly Dictionary<string, string> _schemes = new()
        {
            { "JWT", "Bearer" }
        };
        public static IServiceCollection AddCustomServices(this IServiceCollection services)
        {
            var policy = new AuthorizationPolicyBuilder()
                .AddAuthenticationSchemes(
                    _schemes.Values
                    .Select(x => x.ToString())
                    .ToArray()
                 ).RequireAuthenticatedUser()
                    .Build();

            services.AddMvc(options =>
            {
                options.Filters.Add(new AuthorizeFilter(policy));
            });

            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<IDepartmentService, DepartmentService>();

            services.AddScoped<IPositionRepository, PositionRepository>();
            services.AddScoped<IPositionService, PositionService>();

            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IEmployeeService, EmployeeService>();

            services.AddControllersWithViews()
                        .AddNewtonsoftJson(options =>
                        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                    );

            return services;
        }

        public static IApplicationBuilder UseCustomSwagger(this IApplicationBuilder app)
        {
            app.UseDeveloperExceptionPage();
            string swaggerBasePath = "system";
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger(c =>
            {

                c.RouteTemplate = swaggerBasePath + "/swagger/{documentName}/swagger.json";
                c.PreSerializeFilters.Add((swagger, httpReq) =>
                {
                    swagger.Servers = new List<OpenApiServer> { new OpenApiServer { Url = $"{httpReq.Scheme}://{httpReq.Host.Value}/{httpReq.Headers["X-Forwarded-Prefix"]}" } };
                });
            });

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint($"/{swaggerBasePath}/swagger/v1/swagger.json", $"ReaderService API");
                c.RoutePrefix = $"{swaggerBasePath}/swagger";
            });

            return app;
        }

        /// <summary>
        /// Настройка аутентификации web-платформы.
        /// </summary>
        public static IServiceCollection AddPortalAuth(this IServiceCollection services, AuthOptions options)
        {
            services.AddCors();
            var auth = services.AddAuthentication(options => {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            });
            AddJWT(options, auth);
            return services;
        }

        private static void AddJWT(AuthOptions options, AuthenticationBuilder auth)
        {
            auth.Services.AddAuthorization();
            auth.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
            {
                opt.TokenValidationParameters = new()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = options.Issuer,
                    ValidAudience = options.Audience,
                    ValidAudiences = options.AllowAudiences.ToArray(),
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(options.Secret))
                };
            });
        }
    }
}
