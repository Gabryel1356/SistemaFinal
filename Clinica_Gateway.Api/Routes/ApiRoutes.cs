namespace Clinica_Gateway.Api.Routes
{
    public static class ApiRoutes
    {
        public const string Root = "api";
        public const string Version = "v1";
        public const string Base = Root + "/" + Version;

        public static class RoutePaciente
        {
            // Read
            public const string GetAll = Base + "/Paciente/all";
            public const string GetById = Base + "/Paciente/{id}";

            // Write
            public const string Create = Base + "/Paciente/create";
            public const string Update = Base + "/Paciente/update";
            public const string Delete = Base + "/Paciente/delete";

            public const string RegistrarPaciente = Base + "/Consulta/create";

        }



        public static class RouteGenerarConsulta
        {
            // Read


            // Write           
            public const string RegistrarPaciente = Base + "/´Consulta/creates";

        }




        public static class RouteServicios
        {
            public const string GetAll = Base + "/Servicios/all";
            public const string GetById = Base + "/Servicios/{id}";


            public const string Create = Base + "/Servicios/create";
            public const string Update = Base + "/Servicios/update";
            public const string Delete = Base + "/Servicios/delete";


            public const string RegistrarServicio = Base + "/Servicios/create";

        }



    }
}
