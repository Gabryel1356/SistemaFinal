using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using MongoDB.Driver;
using Release.MongoDB.Repository;
using Ms.Medico.Aplicacion.Servicios;
using Ms.Medico.Infraestructura;
using dominio = Ms.Medico.Dominio.Entidades;

namespace Ms.Medico.Aplicacion
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAplicacion(this IServiceCollection services, IConfiguration configuration)
        {


            string cs = configuration.GetSection("DBSettings:ConnectionString").Value;
            var dbUrl = new MongoUrl(cs);

            services.AddScoped<IDbContext>(x => new DbContext(dbUrl));


            services.TryAddScoped<ICollectionContext<dominio.Medico>>(x => new CollectionContext<dominio.Medico>(x.GetService<IDbContext>()));



            services.TryAddScoped<IBaseRepository<dominio.Medico>>(x => new BaseRepository<dominio.Medico>(x.GetService<IDbContext>()));


            services.AddScoped<IMedicoService, MedicoService>();

            return services;
        }
    }
}
