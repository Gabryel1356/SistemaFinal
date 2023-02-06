namespace Ms.GenerarConsulta.Api.Routes
{
    public static class ApiRoutes
    {

        public const string Root = "api";
        public const string Version = "v1";
        public const string Base = Root + "/" + Version;

        public static class RouteGenerarConsulta
        {
            public const string GetAll = Base + "/Generar Consulta/all";
            public const string GetById = Base + "/Generar Consulta/{id}";


            public const string Create = Base + "/Generar Consulta/create";
            public const string Update = Base + "/Generar Consulta/update";
            public const string Delete = Base + "/Generar Consulta/delete";
            public const string UpdateConsultas = Base + "/Generar Consulta/updateConsultas";
        }


    }
}
