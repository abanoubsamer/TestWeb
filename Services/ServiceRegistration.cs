using Microsoft.AspNetCore.Identity;
using TestWeb.Repository.implementation;
using TestWeb.Repository.Interface;
using TestWeb.Repostory.Base;
using TestWeb.Services.Email;
using TestWeb.Services.implementation;
using TestWeb.Services.Interface;
using TestWeb.Services.Email;
using TestWeb.UnitOfWork;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace TestWeb.Services
{
    public static class ServiceRegistration
    {
        public static void AddServices(this IServiceCollection services)
        {
            // Register Services
            services.AddTransient<ICategoryServieces, CategoryServieces>();
            services.AddTransient<IItemServices, ItemServices>();

            services.AddTransient<IEmailSender, EmailConfirm>();

            //unit of work
            services.AddTransient<IUnitOfWork,UnitOfWork.UnitOfWork>();
        }
    }
}
