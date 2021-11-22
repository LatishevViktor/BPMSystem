using IdentityAPI.EF;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using IdentityAPI.Extensions;
using Identity.Common;

namespace IdentityAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Конфигурация класса отвечающего за настройку аутентификации
            var authConfiguration = Configuration.GetSection("Auth");
            services.Configure<AuthOptions>(authConfiguration);

            //Конфигурация подключения к БД
            var connectionString = Configuration.GetConnectionString("DbConnect");
            services.AddDbContext<AuthContext>(options =>
                options.UseSqlServer(connectionString));

            // Делаем кастомную регистрацию нужных сервисов для того, чтобы разгрузить данный класс
            services.AddRegistrationServices();
            services.AddSwaggerCustom();
            services.AddCorsCustom();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "IdentityAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
