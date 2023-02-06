using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using MongoDB.Driver;
using Release.MongoDB.Repository;
using Ms.Paciente.Aplicacion.Paciente;
using Ms.Paciente.Infraestructura;
using dominio = Ms.Paciente.Dominio.Entidades;

namespace Ms.Paciente.Aplicacion
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddAplicacion(this IServiceCollection services, IConfiguration configuration)
        {


            string cs = configuration.GetSection("DBSettings:ConnectionString").Value;
            var dbUrl = new MongoUrl(cs);

            services.AddScoped<IDbContext>(x => new DbContext(dbUrl));


            services.TryAddScoped<ICollectionContext<dominio.Paciente>>(x => new CollectionContext<dominio.Paciente>(x.GetService<IDbContext>()));



            services.TryAddScoped<IBaseRepository<dominio.Paciente>>(x => new BaseRepository<dominio.Paciente>(x.GetService<IDbContext>()));


            services.AddScoped<IPacienteService, PacienteService>();

            return services;
        }


    }
}
