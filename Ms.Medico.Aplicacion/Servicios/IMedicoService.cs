using dominio = Ms.Medico.Dominio.Entidades;

namespace Ms.Medico.Aplicacion.Servicios
{
          public interface IMedicoService
        {
            List<dominio.Medico> ListarMedico();
            dominio.Medico BuscarPorId(int idmedico);
            bool Registrar(dominio.Medico Medico);
            bool Modificar(dominio.Medico medico);
            void Eliminar(int idmedico);
        }
    }
