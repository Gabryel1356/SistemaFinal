using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using static Clinica_Gateway.Api.Routes.ApiRoutes;
using System.Collections.Generic;

using Pacientes =Clinica_Gateway.Api.PacienteClient;
using Clinica_Gateway.Aplicacion.Pacientes.Request;
using Clinica_Gateway.Api.PacienteClient;

namespace Clinica_Gateway.Api.Controllers
{

    [ApiController]
    public class PacienteController : ControllerBase
    {

        public readonly Pacientes.Client _client;

        public PacienteController(Client client)
        {
            _client = client;
        }

        [HttpGet(RoutePaciente.GetAll)]
        public ICollection<Pacientes.Paciente> ListarPaciente()
        {
            var ListarPacientes = _client.ApiV1PacienteAllAsync().Result;
            return ListarPacientes;
        }


         

    }

}
