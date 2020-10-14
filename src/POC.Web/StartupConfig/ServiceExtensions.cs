using POC.BLL.Interfaces;
using POC.BLL.Services;
using POC.DAL.Interfaces;
using POC.DAL.Models;
using POC.DAL.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace WEB.StartupExtensions
{
  public static class ServiceExtensions
  {
    public static void AddDependenciesService(this IServiceCollection services)
    {
      services.AddScoped<IUnitOfWork, UnitOfWork>();
      services.AddScoped<IEmailSenderService, EmailSenderService>();
      services.AddScoped<IAccountService, AccountService>();
      services.AddScoped<IEmailConfirmService, EmailConfirmService>();
      services.AddScoped<IOrderService, OrderService>();
      services.AddScoped<ICanvasService, CanvasService>();
      services.AddScoped<IRolesService, RolesService>();
    }

    public static void IdentityConfiguration(this IServiceCollection services)
    {
      services.Configure<IdentityOptions>(options =>
      {
        options.Password.RequireDigit = true;
        options.Password.RequireLowercase = true;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireUppercase = false;
        options.Password.RequiredLength = 6;
        options.Password.RequiredUniqueChars = 0;
      });
    }

    public static void EmailConfigService(this IServiceCollection services, EmailConfiguration emailConfig)
    {
      services.AddSingleton(emailConfig);
    }

    public static void SwashBuckleConfigService(this IServiceCollection services)
    {
      services.AddSwaggerGen(cfg =>
      {
        cfg.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
      });
    }
  }
}