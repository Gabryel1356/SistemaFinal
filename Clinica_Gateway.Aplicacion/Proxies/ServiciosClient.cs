
namespace Clinica_Gateway.Aplicacion.ServiciosClient
{
    public partial class Client
    {
        public Client(System.Net.Http.IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("Ms_Servicios");
            _settings = new System.Lazy<Newtonsoft.Json.JsonSerializerSettings>(CreateSerializerSettings);
        }

    }
}


