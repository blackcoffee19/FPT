using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OA.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Service
{
    public static class ServiceDependency
    {
        public static void AddServiceDI(this IServiceCollection service)
        {
            service.AddScoped<IAccountService, AccountService>();
        }
    }
}
