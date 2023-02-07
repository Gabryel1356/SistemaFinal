using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using static Ms.Paciente.Api.Routes.ApiRoutes;
using System.Collections.Generic;
using Ms.Paciente.Aplicacion.Paciente;
using dominio = Ms.Paciente.Dominio.Entidades;

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
            var objCliente = _service.BuscarPorId(id);

            return objCliente;
        }
        [HttpPost(RoutePaciente.Create)]
        public ActionResult<dominio.Paciente> CrearPaciente([FromBody] dominio.Paciente Servicios)
        {
            _service.Registrar(Servicios);

            return Ok();
        }


        [HttpPut(RoutePaciente.Update)]
        public ActionResult<dominio.Paciente> ModificarPaciente([FromBody] dominio.Paciente servicios)
        {


           var obj= _service.Modificar(servicios);



            //if (objServicio != null)
            //{
            //    objServicio. = paciente._id;
            //    objServicio.idPac = paciente.idPac;
            //    objServicio.Nombre = paciente.Nombre;
            //    objServicio.apepa = paciente.apepa;
            //    objServicio.apema = paciente.apema;
            //    objServicio.edad = paciente.edad;
            //    objServicio.seguro = paciente.seguro;
            //    objServicio.Fecha_ingreso = paciente.Fecha_ingreso;

            //    _service.ReplaceOne(x => x.idPac == objServicio.idPac, objServicio);
            //}

            return Ok();
        }

           
        




    [HttpDelete(RoutePaciente.Delete)]
        public ActionResult<dominio.Paciente> EliminarCliente(int id)
        {
            _service.Eliminar(id);

            return Ok(id);
        }

    }
}
