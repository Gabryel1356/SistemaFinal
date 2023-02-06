using dominio = Ms.Servicios.Dominio.Entidades;

namespace Ms.Servicios.Aplicacion.Servicios
{
    public interface IServiciosService
    {
        List<dominio.Servicios> ListarServicios();
        dominio.Servicios BuscarPorId(int idServicios);
        bool Registrar(dominio.Servicios servicios);
        bool Modificar(dominio.Servicios servicios);

        void Eliminar(int idServicios);
       

    }
}
