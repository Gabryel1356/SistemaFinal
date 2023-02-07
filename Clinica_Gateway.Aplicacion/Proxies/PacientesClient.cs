
namespace Clinica_Gateway.Aplicacion.PacienteClient
{
    public partial class Client
    {
        public Client(System.Net.Http.IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("Ms_Paciente");
            _settings = new System.Lazy<Newtonsoft.Json.JsonSerializerSettings>(CreateSerializerSettings);
        }

    }
}
