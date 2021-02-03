using Crud.Domain.Interfaces.Services;
using Crud.Services.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Crud.Infra.CrossCutting.IOC
{
    public static class ServiceDependency
    {
        public static void AddServiceDependency(this IServiceCollection service)
        {
            service.AddScoped<IServiceCategorias, ServiceCategorias>();
            service.AddScoped<IServiceLivro, ServiceLivro>();
        }
    }
}
