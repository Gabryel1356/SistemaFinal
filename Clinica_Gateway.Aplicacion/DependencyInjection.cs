using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Clinica_Gateway.Aplicacion.Common;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Reflection;


namespace Clinica_Gateway.Aplicacion
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddAplicacion(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddClientes(configuration);

            services.AddServicios(configuration);

            return services;
        }
    
        public static IServiceCollection AddClientes(this IServiceCollection services, IConfiguration configuration)
        {

            var msSettings = new ClientSettings();
            configuration.Bind(nameof(ClientSettings), msSettings);

            #region Cliente Ms Paciente

            services.AddHttpClient("Ms_Paciente", client =>
            {
                client.BaseAddress = new Uri(msSettings.PacienteUrl);
            });

            #endregion

            services.AddTransient<PacienteClient.Client>();

            return services;
        }


        public static IServiceCollection AddServicios(this IServiceCollection services, IConfiguration configuration)
        {

            var msSettings = new ClientSettings();
            configuration.Bind(nameof(ClientSettings), msSettings);

            #region Cliente Ms Servicios

            services.AddHttpClient("Ms_Servicios", client =>
            {
                client.BaseAddress = new Uri(msSettings.ServiciosUrl);
            });

            #endregion

            services.AddTransient<ServiciosClient.Client>();

            return services;
        }





    }
}