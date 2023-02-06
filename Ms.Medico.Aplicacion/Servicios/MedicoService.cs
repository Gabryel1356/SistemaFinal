using MongoDB.Driver;
using Release.MongoDB.Repository;
using System.Linq.Expressions;
using dominio = Ms.Medico.Dominio.Entidades;


namespace Ms.Medico.Aplicacion.Servicios
{
    public class MedicoService : IMedicoService
    {
        private readonly ICollectionContext<dominio.Medico> _servicios;
        private readonly IBaseRepository<dominio.Medico> _serviciosT;

        public MedicoService(ICollectionContext<dominio.Medico> servicio, IBaseRepository<dominio.Medico> serviciosT)
        {
            _servicios = servicio;
            _serviciosT = serviciosT;
        }
        public List<dominio.Medico> ListarServicios()
        {
            Expression<Func<dominio.Medico, bool>> filter = b => b.esEliminado == false;
            var items = _servicios.Context().FindAsync(filter, null).Result.ToList();
            return items;
        }


        public dominio.Medico BuscarPorId(int id_medico)
        {
            Expression<Func<dominio.Medico, bool>> filter = b => b.esEliminado == false && b.id_medico == id_medico;
            var items = _servicios.Context().FindAsync(filter, null).Result.FirstOrDefault();
            return items;

        }

        public bool Registrar(dominio.Medico servicios)
        {
            servicios.esEliminado = false;

            servicios.fechaCreacion = DateTime.Now;
            servicios.esActivo = true;
            var R = _serviciosT.InsertOne(servicios);

            return true;
        }


        public bool Modificar(dominio.Medico servicios)
        {
            throw new NotImplementedException();
        }

        public void Eliminar(int id_medico)
        {
            Expression<Func<dominio.Medico, bool>> filter = b => b.esEliminado == false && b.id_medico == id_medico;
            var items = _servicios.Context().FindOneAndDeleteAsync(filter, null);

        }

        public List<dominio.Medico> ListarMedico()
        {
            throw new NotImplementedException();
        }
    }
}
