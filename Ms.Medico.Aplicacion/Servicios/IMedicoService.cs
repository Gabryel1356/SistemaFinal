using dominio = Ms.Medico.Dominio.Entidades;

namespace Ms.Medico.Aplicacion.Servicios

{
    public interface IMedicoService
    {
        List<dominio.Medico> ListarMedico();
        dominio.Medico BuscarPorId(int id_medico);
        bool Registrar(dominio.Medico medico);
        bool Modificar(dominio.Medico medico);

        void Eliminar(int id_medico);

    }
}