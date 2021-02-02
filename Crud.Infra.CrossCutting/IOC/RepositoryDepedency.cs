using Crud.Domain.Interfaces.Repository;
using Crud.Infra.Data.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Crud.Infra.CrossCutting.IOC
{
    public static class RepositoryDepedency
    {
        public static void AddRepositoryDependency(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryCategorias, RepositoryCategorias>();
        }
    }
}
