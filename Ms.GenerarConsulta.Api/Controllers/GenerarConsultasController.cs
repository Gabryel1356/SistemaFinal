using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using static Ms.GenerarConsulta.Api.Routes.ApiRoutes;
using System.Collections.Generic;
using Ms.GenerarConsulta.Aplicacion.GenerarConsulta;
using dominio = Ms.GenerarConsulta.Dominio.Entidades;
using Ms.GenerarConsulta.Dominio.Entidades;

namespace Ms.GenerarConsulta.Api.Controllers
{
    [ApiController]
    public class GenerarConsultasController : Controller
    {
        private readonly IGenerarConsultaService _service;


        public GenerarConsultasController(IGenerarConsultaService service)
        {
            _service = service;
        }


        [HttpGet(RouteGenerarConsulta.GetAll)]
        public IEnumerable<dominio.GenerarConsulta> ListarConsultas()
        {

            var ListarConsultas = _service.ListarConsultas();
            return ListarConsultas;
        }


        [HttpGet(RouteGenerarConsulta.GetById)]
        public dominio.GenerarConsulta BuscarCliente(int id)
        {

            var objPaciente = _service.BuscarPorId(id);

            return objPaciente;
        }


        [HttpPost(RouteGenerarConsulta.Create)]
        public ActionResult<dominio.GenerarConsulta> CrearPaciente([FromBody] dominio.GenerarConsulta Consultas)
        {
            try
            {


                _service.Registrar(Consultas);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }



        }


        [HttpPut(RouteGenerarConsulta.Update)]
        public ActionResult<dominio.GenerarConsulta> Modificar([FromBody] dominio.GenerarConsulta Consultas)
        {
            try
            {

                var result = _service.Modificar(Consultas);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }



        [HttpDelete(RouteGenerarConsulta.Delete)]
        public ActionResult<dominio.GenerarConsulta> EliminarCliente(int id)
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
