using MongoDB.Driver;
using Release.MongoDB.Repository;
using System.Linq.Expressions;
using dominio = Ms.GenerarConsulta.Dominio.Entidades;

namespace Ms.GenerarConsulta.Aplicacion.GenerarConsulta
{
  public class GenerarConsultaService : IGenerarConsultaService
    {
        private readonly ICollectionContext<dominio.GenerarConsulta> _servicios;
        private readonly IBaseRepository<dominio.GenerarConsulta> _serviciosT;

        public GenerarConsultaService(ICollectionContext<dominio.GenerarConsulta> servicio,IBaseRepository<dominio.GenerarConsulta> serviciosT)
        {
            _servicios = servicio;
            _serviciosT = serviciosT;
        }
        public List<dominio.GenerarConsulta> ListarConsultas()
        {
            Expression<Func<dominio.GenerarConsulta, bool>> filter = b => b.esEliminado == false;
            var items = (_servicios.Context().FindAsync(filter, null).Result).ToList();
            return items;
        }


        public dominio.GenerarConsulta BuscarPorId(int IdConsulta)
        {
            Expression<Func<dominio.GenerarConsulta, bool>> filter = b => b.esEliminado == false && b.IdConsulta == IdConsulta;
            var items = (_servicios.Context().FindAsync(filter, null).Result).FirstOrDefault();
            return items;

        }
       
        public bool Registrar(dominio.GenerarConsulta consulta)
        {
            consulta.esEliminado = false;

            consulta.fechaCreacion = DateTime.Now;
            consulta.esActivo = true;
            var R = _serviciosT.InsertOne(consulta);

            return true;
        }


        public bool Modificar(dominio.GenerarConsulta consulta)
        {

            consulta.esEliminado = false;
            consulta.fechaModificacion = DateTime.Now;
            consulta.esActivo = true;

            var filter = Builders<dominio.GenerarConsulta>.Filter.Eq(c => c.IdConsulta, consulta.IdConsulta);

            var update = Builders<dominio.GenerarConsulta>.Update

                .Set(c => c.IdConsulta, consulta.IdConsulta)
                .Set(c => c.NroConsulta, consulta.NroConsulta)
                .Set(c => c.PacienteDiagnostico, consulta.PacienteDiagnostico)
                .Set(c => c.MeidicoAtencion, consulta.MeidicoAtencion)
                 .Set(c => c.idPaciente, consulta.idPaciente);
                

            var result = _serviciosT.UpdateOneAsync(filter, update);



            return true;
        }




        public void Eliminar(int idServicios)
        {
            Expression<Func<dominio.GenerarConsulta, bool>> filter = b => b.esEliminado == false && b.IdConsulta == idServicios;
            var items = (_servicios.Context().FindOneAndDeleteAsync(filter,null));
            
        }





    }
}
