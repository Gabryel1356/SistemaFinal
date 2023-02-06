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
            _service.Registrar(Servicios);

            return Ok();
        }


        //[HttpPut(RouteServicios.Update)]
        //public ActionResult<dominio.Servicios> Modificar([FromBody] dominio.Servicios servicios)
        //{


        //    var objServicio = _service.Modificar(servicios);



        //    //if (objServicio != null)
        //    //{
        //    //    objServicio. = paciente._id;
        //    //    objServicio.idPac = paciente.idPac;
        //    //    objServicio.Nombre = paciente.Nombre;
        //    //    objServicio.apepa = paciente.apepa;
        //    //    objServicio.apema = paciente.apema;
        //    //    objServicio.edad = paciente.edad;
        //    //    objServicio.seguro = paciente.seguro;
        //    //    objServicio.Fecha_ingreso = paciente.Fecha_ingreso;

        //    //    _service.ReplaceOne(x => x.idPac == objServicio.idPac, objServicio);
        //    //}
        //}

        //    return objServicio;
        //}




        [HttpDelete(RouteServicios.Delete)]
        public ActionResult<dominio.Servicios > EliminarCliente(int id)
        {
            _service.Eliminar(id);

            return Ok(id);
        }





    }
}
