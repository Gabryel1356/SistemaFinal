using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using MongoDB.Driver;
using Release.MongoDB.Repository;
using Ms.Servicios.Aplicacion.Servicios;
using Ms.Servicios.Infraestructura;
using dominio = Ms.Servicios.Dominio.Entidades;

namespace Ms.Servicios.Aplicacion
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAplicacion(this IServiceCollection services, IConfiguration configuration)
        {


            string cs = configuration.GetSection("DBSettings:ConnectionString").Value;
            var dbUrl = new MongoUrl(cs);

            services.AddScoped<IDbContext>(x => new DbContext(dbUrl));


            services.TryAddScoped<ICollectionContext<dominio.Servicios>>(x => new CollectionContext<dominio.Servicios>(x.GetService<IDbContext>()));



            services.TryAddScoped<IBaseRepository<dominio.Servicios>>(x => new BaseRepository<dominio.Servicios>(x.GetService<IDbContext>()));



            services.AddScoped<IServiciosService, ServiciosService>();




            return services;
        }
    }
}
