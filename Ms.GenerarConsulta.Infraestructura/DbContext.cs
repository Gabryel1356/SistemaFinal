
using MongoDB.Driver;
using Release.MongoDB.Repository;

namespace Ms.GenerarConsulta.Infraestructura
{
    public class DbContext : DataContext, IDbContext
    {
        public DbContext(MongoUrl mongoUrl) : base(mongoUrl)
        {
        }
    }
}
