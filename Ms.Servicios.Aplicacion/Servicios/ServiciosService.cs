using MongoDB.Driver;
using Release.MongoDB.Repository;
using System.Linq.Expressions;
using dominio = Ms.Servicios.Dominio.Entidades;

namespace Ms.Servicios.Aplicacion.Servicios
{
  public class ServiciosService : IServiciosService
    {
        private readonly ICollectionContext<dominio.Servicios> _servicios;
        private readonly IBaseRepository<dominio.Servicios> _serviciosT;

        public ServiciosService(ICollectionContext<dominio.Servicios> servicio,IBaseRepository<dominio.Servicios> serviciosT)
        {
            _servicios = servicio;
            _serviciosT = serviciosT;
        }
        public List<dominio.Servicios> ListarServicios()
        {
            Expression<Func<dominio.Servicios, bool>> filter = b => b.esEliminado == false;
            var items = (_servicios.Context().FindAsync(filter, null).Result).ToList();
            return items;
        }


        public dominio.Servicios BuscarPorId(int idServicios)
        {
            Expression<Func<dominio.Servicios, bool>> filter = b => b.esEliminado == false && b.idServicios== idServicios;
            var items = (_servicios.Context().FindAsync(filter, null).Result).FirstOrDefault();
            return items;

        }
       
        public bool Registrar(dominio.Servicios servicios)
        {
            servicios.esEliminado = false;

            servicios.fechaCreacion = DateTime.Now;
            servicios.esActivo = true;
            var R = _serviciosT.InsertOne(servicios);

            return true;
        }


        public bool Modificar(dominio.Servicios servicios)
        {

            servicios.esEliminado = false;
            servicios.fechaModificacion = DateTime.Now;
            servicios.esActivo = true;

            var filter = Builders<dominio.Servicios>.Filter.Eq(c => c.idServicios, servicios.idServicios);

            var update = Builders<dominio.Servicios>.Update

                .Set(c => c.idServicios, servicios.idServicios)
                .Set(c => c.tiposervcio, servicios.tiposervcio);
                

            var result = _serviciosT.UpdateOneAsync(filter, update);



            return true;
        }




        public void Eliminar(int idServicios)
        {
            Expression<Func<dominio.Servicios, bool>> filter = b => b.esEliminado == false && b.idServicios == idServicios;
            var items = (_servicios.Context().FindOneAndDeleteAsync(filter,null));
            
        }





    }
}
