using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using static Clinica_Gateway.Api.Routes.ApiRoutes;
using Pacientes =Clinica_Gateway.Aplicacion.PacienteClient;
using Clinica_Gateway.Aplicacion.Pacientes.Request;


namespace Clinica_Gateway.Api.Controllers
{

    [ApiController]
    public class PacienteController : ControllerBase
    {
        private readonly Pacientes.Client _pacientesClient;

     

        public PacienteController(Pacientes.Client pacientesClient)
        {
            _pacientesClient = pacientesClient;
        }

        [HttpGet(RoutePaciente.GetAll)]
        public ICollection<Pacientes.Paciente> ListarPaciente()
        {
            var ListarPacientes = _pacientesClient.ApiV1PacienteAllAsync().Result;
            return ListarPacientes;
        }


        [HttpPost(RoutePaciente.RegistrarPaciente)]
        public async void RegistrarPaciente(RegistrarPacienteRequest request)
        {

       
            var Pacienete = await _pacientesClient.ApiV1PacienteAsync(request.idPac);


            var consulta = _pacientesClient.ApiV1PacienteUpdateAsync(Pacienete);

        }


    }

}
