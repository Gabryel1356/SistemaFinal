using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Ms.Servicios.Aplicacion.Servicios;
using static Ms.Servicios.Api.Routes.ApiRoutes;
using dominio = Ms.Servicios.Dominio.Entidades;
using MongoDB.Driver;

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



        [HttpGet(RouteServicios.GetById)]
        public dominio.Servicios BuscarCliente(int id)
        {
            var objCliente = _service.BuscarPorId(id);

            return objCliente;
        }
        [HttpPost(RouteServicios.Create)]
        public ActionResult<dominio.Servicios> CrearServicio([FromBody] dominio.Servicios Servicios)
        {

            try
            {


                _service.Registrar(Servicios);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }



        }

        [HttpPut(RouteServicios.Update)]
        public ActionResult<dominio.Servicios> Modificar([FromBody] dominio.Servicios Servicios)
        {
            try
            {

                var result = _service.Modificar(Servicios);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }



        [HttpDelete(RouteServicios.Delete)]
        public ActionResult<dominio.Servicios > EliminarCliente(int id)
        {

            try
            {

                _service.Eliminar(id);

                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

           
        }





    }
}
