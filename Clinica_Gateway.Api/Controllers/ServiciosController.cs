using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using static Clinica_Gateway.Api.Routes.ApiRoutes;
using Servicio = Clinica_Gateway.Aplicacion.ServiciosClient;
using Clinica_Gateway.Aplicacion.Pacientes.Request;


namespace Clinica_Gateway.Api.Controllers
{
    [ApiController]

    public class ServiciosController : ControllerBase
    {
        private readonly Servicio.Client _ServiciosClient;

        public ServiciosController(Servicio.Client serviciosClient)
        {
            _ServiciosClient = serviciosClient;
        }

        //[HttpGet(RouteServicios.GetAl)]
        //public ICollection<Servicio.Servicios> ListarServicios()
        //{
        //    var ListarServicios = _ServiciosClient.ApiV1ServiciosAllAsync().Result;

        //    return ListarServicios;
        //}




        [HttpPost(RouteServicios.RegistrarServicio)]
        public async void RegistrarServicios(RegistrarPacienteRequest request)
        {


            var Servicios = await _ServiciosClient.ApiV1ServiciosAsync(request.idServicios);


            var consulta = _ServiciosClient.ApiV1ServiciosUpdateAsync(Servicios);

        }


    }
}
