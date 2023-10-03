using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Repository
{
    public static class RepositoryDependency
    {
        public static void AddRepoId(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddDbContext<DemoOADbContext>(
                o => o.UseSqlServer(configuration.GetConnectionString("DemoOAConnectionString")
                , s => s.MigrationsAssembly(typeof(DemoOADbContext).Assembly.FullName))
                );
            //Dang ky DI cho respository
            service.AddScoped<IAccountRepository, AccountRespository>();
        }
    }
}
