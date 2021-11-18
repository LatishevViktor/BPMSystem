using BPMSystem.BLL.Interfaces;
using BPMSystem.BLL.Services;
using BPMSystem.DAL.Interfaces;
using BPMSystem.DAL.Repositories;

using Microsoft.Extensions.DependencyInjection;

using Services.BPMSystemBLL.Services;

namespace BPMSystem.Web.Extensions_services
{
    public static class ServiceExtensions
    {
        public static void AddCorsCustom(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("BpmServicePolicy", builder =>
                {
                    builder.WithOrigins("http://localhost:4200")
                           .AllowAnyHeader()
                           .AllowAnyMethod();
                });
            });
        }

        public static void AddRegistrationServices(this IServiceCollection services)
        {
            services.AddTransient<IDepartmentRepository, DepartmentRepository>();
            services.AddTransient<IDepartmentService, DepartmentService>();

            services.AddTransient<IPositionRepository, PositionRepository>();
            services.AddTransient<IPositionService, PositionService>();

            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            services.AddTransient<IEmployeeService, EmployeeService>();
        }
    }
}
