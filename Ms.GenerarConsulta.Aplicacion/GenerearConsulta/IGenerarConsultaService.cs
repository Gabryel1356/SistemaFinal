using dominio = Ms.GenerarConsulta.Dominio.Entidades;

namespace Ms.GenerarConsulta.Aplicacion.GenerarConsulta
{
    public interface IGenerarConsultaService
    {
        List<dominio.GenerarConsulta> ListarConsultas();
        dominio.GenerarConsulta BuscarPorId(int IdConsulta);
        bool Registrar(dominio.GenerarConsulta Consultas);
        bool Modificar(dominio.GenerarConsulta Consultas);

        void Eliminar(int IdConsulta);
       

    }
}
