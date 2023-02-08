using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using static Ms.Medico.Api.Routes.ApiRoutes;
using System.Collections.Generic;
using Ms.Medico.Aplicacion.Servicios;
using dominio = Ms.Medico.Dominio.Entidades;

namespace Ms.Medico.Api.Controllers
{
    [ApiController]
    public class MedicoController : Controller
    {
        private readonly IMedicoService _service;


        public MedicoController(IMedicoService service)
        {
            _service = service;
        }

        [HttpGet(RouteMedico.GetAll)]
        public IEnumerable<dominio.Medico> ListarMedico()
        {

            var ListarMedico = _service.ListarMedico();
            return ListarMedico;
        }


        [HttpGet(RouteMedico.GetById)]
        public dominio.Medico BuscarCliente(int id)
        {

            var objPaciente = _service.BuscarPorId(id);

            return objPaciente;
        }


        [HttpPost(RouteMedico.Create)]
        public ActionResult<dominio.Medico> CrearPaciente([FromBody] dominio.Medico Paciente)
        {
            try
            {


                _service.Registrar(Paciente);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }



        }


        [HttpPut(RouteMedico.Update)]
        public ActionResult<dominio.Medico> Modificar([FromBody] dominio.Medico paciente)
        {
            try
            {

                var result = _service.Modificar(paciente);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }



        [HttpDelete(RouteMedico.Delete)]
        public ActionResult<dominio.Medico> EliminarCliente(int id)
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
