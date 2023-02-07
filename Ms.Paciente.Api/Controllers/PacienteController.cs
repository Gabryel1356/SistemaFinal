using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using static Ms.Paciente.Api.Routes.ApiRoutes;
using System.Collections.Generic;
using Ms.Paciente.Aplicacion.Paciente;
using dominio = Ms.Paciente.Dominio.Entidades;
using Ms.Paciente.Dominio.Entidades;

namespace Ms.Paciente.Api.Controllers
{
    [ApiController]
    public class PacienteController : Controller
    {
        private readonly IPacienteService _service;


        public PacienteController(IPacienteService service)
        {
            _service = service;
        }


        [HttpGet(RoutePaciente.GetAll)]
        public IEnumerable<dominio.Paciente> ListarServicios()
        {

            var listaServicios = _service.ListarPaciente();
            return listaServicios;
        }


        [HttpGet(RoutePaciente.GetById)]
        public dominio.Paciente BuscarCliente(int id)
        {

            var objPaciente = _service.BuscarPorId(id);

            return objPaciente;
        }


        [HttpPost(RoutePaciente.Create)]
        public ActionResult<dominio.Paciente> CrearPaciente([FromBody] dominio.Paciente Paciente)
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


        [HttpPut(RoutePaciente.Update)]
        public  ActionResult<dominio.Paciente> Modificar([FromBody] dominio.Paciente paciente)
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

           
        
    [HttpDelete(RoutePaciente.Delete)]
        public ActionResult<dominio.Paciente> EliminarCliente(int id)
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
