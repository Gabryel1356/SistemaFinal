namespace Ms.Paciente.Api.Routes
{
    public static class ApiRoutes
    {

        public const string Root = "api";
        public const string Version = "v1";
        public const string Base = Root + "/" + Version;

        public static class RoutePaciente
        {
            public const string GetAll = Base + "/Paciente/all";
            public const string GetById = Base + "/Paciente/{id}";


            public const string Create = Base + "/Paciente/create";
            public const string Update = Base + "/Paciente/update";
            public const string Delete = Base + "/Paciente/delete";

        }


    }
}
