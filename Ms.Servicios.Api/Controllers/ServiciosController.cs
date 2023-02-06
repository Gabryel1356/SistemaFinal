using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Ms.Servicios.Aplicacion.Servicios;
using static Ms.Servicios.Api.Routes.ApiRoutes;
using dominio = Ms.Servicios.Dominio.Entidades;

namespace Ms.Servicios.Api.Controllers
{
    [ApiController]
    public class ServiciosController : ControllerBase
    {


        private readonly IServiciosService _service;


        public ServiciosController(IServiciosService service)
        {
            _service = service;

        }

        [HttpGet(RouteServicios.GetAll)]
        public IEnumerable<dominio.Servicios> ListarServicios()
        {

            var listaServicios = _service.ListarServicios();
            return listaServicios;
        }





    }
}
