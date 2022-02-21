using BPMSystem.DAL.EF;
using BPMSystem.Web.Extensions_services;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;

var builder = WebApplication.CreateBuilder(args);

//Регистрируем логгирование
builder.Host.UseSerilog((ctx, lc) => lc
    .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
            .Enrich.FromLogContext()
            .WriteTo.Console());

//Выполняем настройки аунтификации
//builder.Services.AddPortalAuth(authOptions);

//Регистрируем акссессор для работы с контекстом вне контроллеров
//builder.Services.AddHttpContextAccessor();

//Регистрируем наши кастомные сервисы
builder.Services.AddCustomServices();

//Регистрируем базу данных
builder.Services.AddDbContext<DataContext>(options =>
    options
        .UseLazyLoadingProxies()
        .UseSqlServer(builder.Configuration.GetConnectionString("DbConnect")));

builder.Services.AddCors(options =>
{
    options.AddPolicy(
        name: "AllowOrigin",
        builder => {
            builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
        });
});

builder.Services.AddControllers();

//Регистрируем фабрику для HttpClient
builder.Services.AddHttpClient();

//Регистрируем swagger
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseCustomSwagger();
}

app.UseSerilogRequestLogging();
app.UseRouting();

app.UseCors("AllowOrigin");

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();

