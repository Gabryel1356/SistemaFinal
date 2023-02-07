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
        public IEnumerable<dominio.Medico> ListarServicios()
        {

            var listaServicios = _service.ListarMedico();
            return listaServicios;
        }



        [HttpGet(RouteMedico.GetById)]
        public dominio.Medico BuscarCliente(int id)
        {
            var objCliente = _service.BuscarPorId(id);

            return objCliente;
        }
        [HttpPost(RouteMedico.Create)]
        public ActionResult<dominio.Medico> CrearMedico([FromBody] dominio.Medico Servicios)
        {
            _service.Registrar(Servicios);

            return Ok();
        }


        [HttpPut(RouteMedico.Update)]
        public ActionResult<dominio.Medico> ModificarMedico([FromBody] dominio.Medico servicios)
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

           
        




    [HttpDelete(RouteMedico.Delete)]
        public ActionResult<dominio.Medico> EliminarCliente(int id)
        {
            _service.Eliminar(id);

            return Ok(id);
        }

    }
}
