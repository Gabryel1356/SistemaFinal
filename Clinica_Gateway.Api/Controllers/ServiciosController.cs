using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using static Clinica_Gateway.Api.Routes.Class;
using Servicios = Clinica_Gateway.Aplicacion.ServiciosClient;
using Clinica_Gateway.Aplicacion.Pacientes.Request;
using Clinica_Gateway.Aplicacion.ServiciosClient;

namespace Clinica_Gateway.Api.Controllers
{


    [ApiController]
    public class ServiciosController : ControllerBase
    {
        private readonly Servicios.Client _ServiciosClient;

        public ServiciosController(Client serviciosClient)
        {
            _ServiciosClient = serviciosClient;
        }

        [HttpGet(RouteServicios.GetAll)]
        public ICollection<Servicios.Servicios> ListarListarServicios()
        {
            var ListarServicios = _ServiciosClient.ApiV1ServiciosAllAsync().Result;
            return ListarServicios;
        }




        //[HttpPost(RouteServicios.RegistrarServicio)]
        //public async void RegistrarServicios(RegistrarPacienteRequest request)
        //{


        //    var Servicios = await _ServiciosClient.ApiV1ServiciosAsync(request.i);


        //    var consulta = _ServiciosClient.ApiV1ServiciosUpdateAsync(Servicios);

        //}


    }
}
