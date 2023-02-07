using MongoDB.Driver;
using Release.MongoDB.Repository;
using System.Linq.Expressions;
using dominio = Ms.Medico.Dominio.Entidades;


namespace Ms.Medico.Aplicacion.Servicios
{
    public class MedicoService : IMedicoService
    {
        private readonly ICollectionContext<dominio.Medico> _Medico;
        private readonly IBaseRepository<dominio.Medico> _MedicoR;

        public MedicoService(ICollectionContext<dominio.Medico> medico, IBaseRepository<dominio.Medico> medicoT)
        {
            _Medico = medico;
            _MedicoR = medicoT;
        }
        public List<dominio.Medico> ListarMedico()
        {
            Expression<Func<dominio.Medico, bool>> filter = b => b.esEliminado == false;
            var items = (_Medico.Context().FindAsync(filter, null).Result).ToList();
            return items;
        }


        public dominio.Medico BuscarPorId(int idmedico)
        {
            Expression<Func<dominio.Medico, bool>> filter = b => b.esEliminado == false && b.idmedico == idmedico;
            var items = (_Medico.Context().FindAsync(filter, null).Result).FirstOrDefault();
            return items;

        }

        public bool Registrar(dominio.Medico medico)
        {
            medico.esEliminado = false;

            medico.fechaCreacion = DateTime.Now;
            medico.esActivo = true;
            var R = _MedicoR.InsertOne(medico);

            return true;
        }


        public bool Modificar(dominio.Medico medico)
        {
            throw new NotImplementedException();
        }

        public void Eliminar(int idmedico)
        {
            Expression<Func<dominio.Medico, bool>> filter = b => b.esEliminado == false && b.idmedico == idmedico;
            var items = (_Medico.Context().FindOneAndDeleteAsync(filter, null));

        }


    }
}
