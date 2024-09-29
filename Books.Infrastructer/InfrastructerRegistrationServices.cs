using Books.Application.Presistance;
using Books.Infrastructer.Data;
using Books.Infrastructer.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Infrastructer
{
    public static class InfrastructerRegistrationServices
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbcontext>(option => option.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddTransient<Iuniteofwork, Uniteofwork>();
           return services;

        }
    }
}
