using dominio = Ms.Paciente.Dominio.Entidades;

namespace Ms.Paciente.Aplicacion.Paciente
{
  
        public interface IPacienteService
        {
            List<dominio.Paciente> ListarPaciente();
            dominio.Paciente BuscarPorId(int idPac);
            bool Registrar(dominio.Paciente Paciente);
            bool Modificar( dominio.Paciente paciente);

            bool Eliminar(int idPac);


        }
    
}
