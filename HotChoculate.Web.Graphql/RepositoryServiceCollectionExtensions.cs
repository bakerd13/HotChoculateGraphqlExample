using HotChoculate.Infrastructure.Core.Interfaces;
using HotChoculate.Infrastructure.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotChoculate.Web.Graph
{
    public static class RepositoryServiceCollectionExtensions
    {
        public static IServiceCollection AddRepositories(
            this IServiceCollection services)
        {
            return services
                .AddScoped<IEmployeeRepository>(sp =>
                    new EmployeeRepository(sp.GetRequiredService<IMainDataBaseProvider>()));

        }
    }
}
