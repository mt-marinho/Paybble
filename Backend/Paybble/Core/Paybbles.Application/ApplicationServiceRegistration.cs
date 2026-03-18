using Microsoft.Extensions.DependencyInjection;
using Paybble.Application.Features.Expenses.Commands.CreateExpense;

namespace Paybble.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateExpenseCommand).Assembly));

            return services;
        }
    }
}
