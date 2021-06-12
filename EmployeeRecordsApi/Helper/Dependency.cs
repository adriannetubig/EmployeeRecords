using EmployeeRecordsRepository;
using EmployeeRecordsRepository.Interfaces;
using EmployeeRecordsRepository.Repositories;
using EmployeeRecordsService.Interfaces;
using EmployeeRecordsService.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeRecordsApi.Helper
{
    public static class Dependencies
    {
        public static void Register(IServiceCollection services, IConfiguration Configuration)
        {
            var connectionString = Configuration.GetConnectionString("DefaultConnection");

            services.AddScoped(a => new EmployeeRecordsContext(connectionString));

            services.AddScoped<IEmployeeRepository, EmployeeRepository>();

            services.AddScoped<IEmployeeService, EmployeeService>();

        }
    }
}
