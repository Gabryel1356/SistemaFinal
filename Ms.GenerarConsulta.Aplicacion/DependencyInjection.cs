using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using MongoDB.Driver;
using Release.MongoDB.Repository;
using Ms.GenerarConsulta.Aplicacion.GenerarConsulta;
using Ms.GenerarConsulta.Infraestructura;
using dominio = Ms.GenerarConsulta.Dominio.Entidades;
using Ms.GenerarConsulta.Dominio.Entidades;


namespace Ms.GenerarConsulta.Aplicacion
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAplicacion(this IServiceCollection services, IConfiguration configuration)
        {


            string cs = configuration.GetSection("DBSettings:ConnectionString").Value;
            var dbUrl = new MongoUrl(cs);

            services.AddScoped<IDbContext>(x => new DbContext(dbUrl));


            services.TryAddScoped<ICollectionContext<dominio.GenerarConsulta>>(x => new CollectionContext<dominio.GenerarConsulta>(x.GetService<IDbContext>()));



            services.TryAddScoped<IBaseRepository<dominio.GenerarConsulta>>(x => new BaseRepository<dominio.GenerarConsulta>(x.GetService<IDbContext>()));



            services.AddScoped<IGenerarConsultaService, GenerarConsultaService>();




            return services;
        }
    }
}
