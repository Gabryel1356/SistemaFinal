using MongoDB.Driver;
using Release.MongoDB.Repository;
using System.Linq.Expressions;
using dominio = Ms.Paciente.Dominio.Entidades;


namespace Ms.Paciente.Aplicacion.Paciente
{
    public class PacienteService : IPacienteService
    {

        private readonly ICollectionContext<dominio.Paciente> _Paciente;
        private readonly IBaseRepository<dominio.Paciente> _PacienteR;

        public PacienteService(ICollectionContext<dominio.Paciente> paciente, IBaseRepository<dominio.Paciente> pacienteT)
        {
            _Paciente = paciente;
            _PacienteR = pacienteT;
        }
        public List<dominio.Paciente> ListarPaciente()
        {
            Expression<Func<dominio.Paciente, bool>> filter = b => b.esEliminado == false;
            var items = (_Paciente.Context().FindAsync(filter, null).Result).ToList();
            return items;
        }


        public dominio.Paciente BuscarPorId(int idPac)
        {
            Expression<Func<dominio.Paciente, bool>> filter = b => b.esEliminado == false && b.idPac == idPac;
            var items = (_Paciente.Context().FindAsync(filter, null).Result).FirstOrDefault();
            return items;

        }

        public bool Registrar(dominio.Paciente paciente)
        {
            paciente.esEliminado = false;

            paciente.fechaCreacion = DateTime.Now;
            paciente.esActivo = true;
            var R = _PacienteR.InsertOne(paciente);

            return true;
        }


        public bool Modificar(dominio.Paciente paciente)
        {
            throw new NotImplementedException();
        }

        public void Eliminar(int idPac)
        {
            Expression<Func<dominio.Paciente, bool>> filter = b => b.esEliminado == false && b.idPac == idPac;
            var items = (_Paciente.Context().FindOneAndDeleteAsync(filter, null));

        }


    }
}
