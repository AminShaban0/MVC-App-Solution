using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using MVC_BLL;
using MVC_BLL.InterfaceRepository;
using MVC_BLL.Repositories;
using MVC_DAL.Data;
using MVC_DAL.Data.Migrations;

namespace MVC_BL.Extentions
{
    public static class ApplicationServicesCollection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            //    services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            //    services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IUnit_Of_Work, UnitOfWork>();
			

			return services;
        }
    }
}
